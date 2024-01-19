using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notification.Domain.Repositories;
using Notification.Infrastructure.DataAcess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Infrastructure.DataAcess; 
public static class Bootstrapper 
{
    public static void AddRepository(this IServiceCollection services, IConfiguration configurationManager) 
    {

        AddRepositories(services);
        AddUnitOfWork(services);
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
}
