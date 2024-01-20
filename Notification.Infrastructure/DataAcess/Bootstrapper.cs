using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notification.Domain.Repositories;
using Notification.Infrastructure.DataAcess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Infrastructure.DataAcess; 
public static class Bootstrapper 
{
    public static void AddRepository(this IServiceCollection services, IConfiguration configurationManager) 
    {
        AddFluentMigrator(services, configurationManager);
        AddRepositories(services);
        AddUnitOfWork(services);
        AddContexto(services, configurationManager);
    }

    private static void AddRepositories(IServiceCollection services) 
     {
        services.AddScoped<INotificationDeviceRepository, NotificationDeviceRepository>()
                .AddScoped<INotificationTypeRepository, NotificationTypeRepository>()
                .AddScoped<INotificationTemplateRepository, NotificationTemplateRepository>()
                .AddScoped<INotificationSentRepository, NotificationSentRepository>();

    }

    private static void AddUnitOfWork(IServiceCollection services) {
        services.AddScoped<IUnitofWork, UnitofWork>();

    }

    private static void AddContexto(IServiceCollection services, IConfiguration configurationManager) 
    {
       var conectionString = configurationManager.GetSection("ConnectionStrings").Value;

      services.AddDbContext<NotificationContext>(dbContextOptions => {
                dbContextOptions.UseNpgsql(conectionString);
                dbContextOptions.UseLazyLoadingProxies();

      });

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
