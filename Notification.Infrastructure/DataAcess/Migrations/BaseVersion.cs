using FluentMigrator.Builders.Create.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Infrastructure.DataAcess.Migrations; 
public static class BaseVersion 
{
    public static ICreateTableColumnOptionOrWithColumnSyntax InsarirColunasPadrao(ICreateTableWithColumnOrSchemaOrDescriptionSyntax tabela) {

        return tabela.WithColumn("Id").AsGuid().PrimaryKey()
                 .WithColumn("DataRegisto").AsDateTime().NotNullable()
                 .WithColumn("LastUpdate").AsDateTime().NotNullable()
                 .WithColumn("Status").AsInt32().NotNullable();
    }
}
