using DbUp;
using System;
using System.Reflection;

namespace Portfolio.Database.Upgrader
{
    public class DbUpgrader
    {
        private string ConnectionString { get; }

        public DbUpgrader(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Upgrade(bool withScripts = true, bool withSeeds = true, bool withFakes = false)
        {
            EnsureDatabase.For.SqlDatabase(ConnectionString);

            var upgradeBuilder = DeployChanges.To
                .SqlDatabase(ConnectionString)
                .WithTransaction()
                .LogToConsole();

            if (withScripts)
                upgradeBuilder.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), s => s.StartsWith("Scripts"));
            if (withSeeds)
                upgradeBuilder.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), s => s.StartsWith("Seeds"));
            if (withFakes)
                upgradeBuilder.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), s => s.StartsWith("Fakes"));

            var result = upgradeBuilder.Build().PerformUpgrade();

            if (!result.Successful)
                throw result.Error;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Database upgrade success!");
            Console.ResetColor();
        }
    }
}
