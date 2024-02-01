using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notification.Domain.Entities;
using Notification.Domain.Repositories;
using Notification.Infrastructure.DataAcess.Repository;
using Notification.Infrastructure.Services.SendEmail;
using SendGrid.Extensions.DependencyInjection;
using System.Reflection;



namespace Notification.Infrastructure.DataAcess; 
public static class Bootstrapper 
{
    public static void AddRepository(this IServiceCollection services, IConfiguration configurationManager) 
    {
        AddFluentMigrator(services, configurationManager);
        AddRepositories(services);
        AddUnitOfWork(services);
        AddContexto(services, configurationManager);
        AddMailService(services, configurationManager);
    }

    private static void AddRepositories(IServiceCollection services) 
     {
        services.AddScoped<INotificationDeviceRepository, NotificationDeviceRepository>()
                .AddScoped<INotificationTypeRepository, NotificationTypeRepository>()
                .AddScoped<INotificationTemplateRepository, NotificationTemplateRepository>()
                .AddScoped<INotificationSendRepository, NotificationSendRepository>();

    }

    private static void AddUnitOfWork(IServiceCollection services) {
        services.AddScoped<IUnitofWork, UnitofWork>();

    }

    private static void AddContexto(IServiceCollection services, IConfiguration configurationManager) 
    {
       var conectionString = configurationManager.GetSection("ConnectionStrings:PostgreSQL").Value;

        services.AddDbContext<NotificationContext>(dbContextOptions => {
                dbContextOptions.UseNpgsql(conectionString,o=>o.UseNodaTime());
                dbContextOptions.UseLazyLoadingProxies();

        });

    }

    public static void AddMailService(this IServiceCollection services, IConfiguration configuration) {
        var config = new MailConfig();

        configuration.GetSection("Notifications").Bind(config);

        services.AddSingleton<MailConfig>(m => config);

        services.AddSendGrid(sp => sp.ApiKey = config.SendGridApiKey);

        services.AddTransient<ISendEmailService, SendEmailService>();

    }

    private static void AddFluentMigrator(IServiceCollection services, IConfiguration configurationManager) {
        _ = bool.TryParse(configurationManager.GetSection("Configuracoes:BancodeDadosInMemory").Value, out bool bancodeDadosInMemory);

        if (!bancodeDadosInMemory) {
            var ConectionString =
          services.AddFluentMigratorCore().ConfigureRunner(c =>
             c.AddPostgres()
             .WithGlobalConnectionString(configurationManager.GetSection("ConnectionStrings:PostgreSQL").Value).ScanIn(Assembly.Load("Notification.Infrastructure")).For.All());
        }
    }
}
