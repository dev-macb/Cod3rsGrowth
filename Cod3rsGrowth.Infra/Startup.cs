using LinqToDB;
using LinqToDB.AspNet;
using FluentMigrator.Runner;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Infra.Migrations;
using Cod3rsGrowth.Domain.Interfaces;
using Cod3rsGrowth.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Infra
{
    public class StartupInfra
    {
        public static void Registrar(IServiceCollection servicos)
        {
            string stringDeConexao = CarregarVariavelDeAmbiente("BANCO_DADOS_URI");
            servicos.AddLinqToDBContext<ContextoConexao>((provider, options) => options.UseSqlServer(stringDeConexao));

            servicos.AddScoped<IRepositorio<Personagem>, PersonagemRepositorio>();
            servicos.AddScoped<IRepositorio<Habilidade>, HabilidadeRepositorio>();
            servicos.AddScoped<IPersonagensHabilidadesRepositorio, PersonagensHabilidadesRepositorio>();

            servicos.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb.AddSqlServer().WithGlobalConnectionString(stringDeConexao).ScanIn(typeof(CriarTabelaHabilidades).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());
        }

        public static void InicializarBancoDeDados(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            try
            {
                runner.MigrateUp();
                Console.WriteLine("[*] Migrações aplicadas com sucesso.");
            }
            catch (Exception excecao)
            {
                Console.WriteLine($"[*] Erro ao aplicar migrações:\n{excecao.Message}");
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

        public static string CarregarVariavelDeAmbiente(string chave)
        {
            string? stringDeConexao = Environment.GetEnvironmentVariable(chave);
            if (string.IsNullOrEmpty(stringDeConexao))
            {
                throw new InvalidOperationException("Erro ao carregar string de conexão com o banco de dados.");
            }

            return stringDeConexao;
        }
    }
}