using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Persistence.Migrations
{
    [Migration(1,"Criação da tabela Foods")]
    public class Migration_000001 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create
                .Table("Foods")
                .WithColumn("Id").AsInt32().PrimaryKey()
                .WithColumn("Name").AsAnsiString().NotNullable()
                .WithColumn("CaloriesPerGram").AsDouble().NotNullable()
                .WithColumn("Active").AsBoolean().NotNullable()
                .WithColumn("CreatedAt").AsDateTime().NotNullable();

        }
    }
}
