using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Extension; 
public static class RepositoryExtension 
{
    public static string GetConnection(this IConfiguration configurationManager) {
        var Connection = configurationManager.GetConnectionString("PostgreSQL");

        return Connection;
    }
}
