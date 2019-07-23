using DbUp;
using System;
using System.Reflection;

namespace Portfolio.Database
{
    public class DbUpgrader
    {
        private string ConnectionString { get; }

        private string AssemblyName { get; } = Assembly.GetExecutingAssembly().GetName().Name;

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
                upgradeBuilder.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), s => s.StartsWith(AssemblyName + ".Scripts"));
            if (withSeeds)
                upgradeBuilder.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), s => s.StartsWith(AssemblyName + ".Seeds"));
            if (withFakes)
                upgradeBuilder.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), s => s.StartsWith(AssemblyName + ".Fakes"));

            var result = upgradeBuilder.Build().PerformUpgrade();

            if (!result.Successful)
                throw result.Error;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Database upgrade success!");
            Console.ResetColor();
        }
    }
}
