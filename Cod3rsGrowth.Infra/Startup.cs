using LinqToDB;
using LinqToDB.AspNet;
using FluentMigrator.Runner;
using LinqToDB.AspNet.Logging;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Infra.Migrations;
using Cod3rsGrowth.Domain.Interfaces;
using Cod3rsGrowth.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Infra
{
    public class StartupInfra
    {
        public static void Registrar(IServiceCollection servicos, string stringDeConexao)
        {
            servicos.AddLinqToDBContext<ContextoConexao>((provider, options) => options
                .UseSqlServer(stringDeConexao)
                .UseDefaultLogging(provider)
            );

            servicos.AddScoped<IRepositorio<Personagem>, PersonagemRepositorio>();
            servicos.AddScoped<IRepositorio<Habilidade>, HabilidadeRepositorio>();
            servicos.AddScoped<IRepositorio<PersonagensHabilidades>, PersonagensHabilidadesRepositorio>();

            servicos.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb.AddSqlServer()
                .WithGlobalConnectionString(stringDeConexao)
                .ScanIn(typeof(CriarTabelaHabilidadesMigration).Assembly, typeof(ResetarBancoDeDados).Assembly)
                .For.Migrations())
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

        public static void ApagarBancoDeDados(IServiceProvider serviceProvider)
        {
            using var escopo = serviceProvider.CreateScope();
            var executor = escopo.ServiceProvider.GetRequiredService<IMigrationRunner>();
            try
            {
                executor.MigrateDown(000);
                Console.WriteLine("[*] Tabelas foram apagadas com sucesso");
            }
            catch (Exception excecao)
            {
                Console.WriteLine($"[*] Erro ao apagar as tabelas:\n{excecao.Message}");
                throw;
            }
        }
    }
}