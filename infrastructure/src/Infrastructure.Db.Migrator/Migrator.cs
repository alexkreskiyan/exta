using System;
using System.Reflection;
using DbUp;
using DbUp.Engine;

namespace Infrastructure.Db.Migrator;

public static class Migrator
{
    public static void Execute(Assembly assembly, string connectionString, string schema)
    {
        EnsureDatabase.For.PostgresqlDatabase(connectionString);
        DeployChanges.To
            .PostgresqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(assembly, x => x.Contains(".Scripts.Init."))
            .WithTransactionPerScript()
            .LogToConsole()
            .Build()
            .PerformUpgrade()
            .AssertResult();
        DeployChanges.To
            .PostgresqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(assembly, x => x.Contains(".Scripts.Migrations."))
            .WithTransactionPerScript()
            .JournalToPostgresqlTable(schema, "db_migrations")
            .LogToConsole()
            .Build()
            .PerformUpgrade()
            .AssertResult();
    }

    private static void AssertResult(this DatabaseUpgradeResult result)
    {
        if (!result.Successful)
            throw new ApplicationException($"{result.ErrorScript}: {result.Error}");
    }
}