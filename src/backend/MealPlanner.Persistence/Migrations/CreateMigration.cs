using Dapper;
using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace MealPlanner.Persistence.Migrations
{
    public static class CreateMigration
    {
        public static void EnsureDatabase(string connectionString)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            var nameDatabase = connectionStringBuilder.InitialCatalog;

            connectionStringBuilder.Remove("database");

            var parameters = new DynamicParameters();

            parameters.Add("name", nameDatabase);

            using var connection = new SqlConnection(connectionStringBuilder.ConnectionString);

            var records = connection.Query("SELECT * FROM sys.databases WHERE name = @name",
                 parameters);

            if (!records.Any())
            {
                connection.Execute($"CREATE DATABASE {nameDatabase}");
            }
        }

        public static void UpMigrations(IServiceProvider provider)
        {
            var runner = provider.GetRequiredService<IMigrationRunner>();

            runner.ListMigrations();
            runner.MigrateUp();


        }

    }
}
