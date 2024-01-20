using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Infrastructure.DataAcess.Migrations; 
public static class Database 
{
    public static void CriarDatabase(string conectionString, string nameDatabase) {
        using var myconecction = new NpgsqlConnection(conectionString);

        var parameters= new DynamicParameters();
        parameters.Add("name", nameDatabase);
        var registros = myconecction.Query("SELECT * FROM pg_database WHERE datname=@name", parameters);

        if (!registros.Any()) {
            myconecction.Execute($"CREATE DATABASE {nameDatabase}");
        }
    }
}
