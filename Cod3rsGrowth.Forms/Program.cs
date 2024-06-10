using DotNetEnv;
using FluentMigrator.Runner;
using Cod3rsGrowth.Infra.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var serviceProvider = CreateServices())
            using (var scope = serviceProvider.CreateScope())
            {
                InicializarBancoDeDados(scope.ServiceProvider);
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        /// <summary>
        /// Configure the dependency injection services
        /// </summary>
        private static ServiceProvider CreateServices()
        {
            Env.Load();
            string? stringDeConexao = Environment.GetEnvironmentVariable("BANCO_DADOS_URI");

            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(stringDeConexao)
                    .ScanIn(typeof(HabilidadeMigration).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        /// <summary>
        /// Update the database
        /// </summary>
        private static void InicializarBancoDeDados(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}