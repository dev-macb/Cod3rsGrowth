using DotNetEnv;
using FluentMigrator.Runner;
using Cod3rsGrowth.Infra.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms
{
    public class StartupForms
    {
        public static void Registrar(IServiceCollection servicos)
        {
            Env.Load();
            string? stringDeConexao = Environment.GetEnvironmentVariable("BANCO_DADOS_URI");
            if (string.IsNullOrEmpty(stringDeConexao))
            {
                throw new InvalidOperationException("A string de conexão com o banco de dados não foi configurada.");
            }

            servicos
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(stringDeConexao)
                    .ScanIn(typeof(CriarTabelaHabilidades).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());
        }

        public static void InicializarBancoDeDados(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            try
            {
                runner.MigrateUp();
                Console.WriteLine("Migrações aplicadas com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao aplicar migrações: {ex.Message}");
                throw;
            }
        }

        public static void ResetarBancoDeDados(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            
            if (runner.HasMigrationsToApplyUp())
            {
                if (runner.HasMigrationsToApplyDown(003)) runner.MigrateDown(002);
                if (runner.HasMigrationsToApplyDown(002)) runner.MigrateDown(001);
                if (runner.HasMigrationsToApplyDown(001)) runner.MigrateDown(0);
            }
        }
    }
}