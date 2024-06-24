using LinqToDB;
using LinqToDB.AspNet;
using FluentValidation;
using Cod3rsGrowth.Infra;
using FluentMigrator.Runner;
using Cod3rsGrowth.Infra.Migrations;
using Cod3rsGrowth.Infra.Repositories;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;
using Cod3rsGrowth.Service.Services;
using Cod3rsGrowth.Service.Validators;

namespace Cod3rsGrowth.Web
{
    public class StartupWeb
    {
        public static void Registrar(WebApplicationBuilder construtor)
        {
            string? stringDeConexao = construtor.Configuration.GetConnectionString("ConexaoPadrao");
            if (stringDeConexao == null) throw new Exception("String de conexão com o banco não encontrada");

            construtor.Services.AddControllers();
            construtor.Services.AddEndpointsApiExplorer();
            construtor.Services.AddSwaggerGen();
            
            construtor.Services.AddLinqToDBContext<ContextoConexao>((provider, options) => options.UseSqlServer(stringDeConexao));

            construtor.Services.AddScoped<IRepositorio<Personagem>, PersonagemRepositorio>();
            construtor.Services.AddScoped<IRepositorio<Habilidade>, HabilidadeRepositorio>();
            construtor.Services.AddScoped<IPersonagensHabilidadesRepositorio, PersonagensHabilidadesRepositorio>();

            construtor.Services.AddScoped<PersonagemServico>();
            construtor.Services.AddScoped<HabilidadeServico>();
            construtor.Services.AddScoped<PersonagensHabilidadesServico>();

            construtor.Services.AddValidatorsFromAssemblyContaining<PersonagemValidador>();
            construtor.Services.AddValidatorsFromAssemblyContaining<HabilidadeValidador>();

            construtor.Services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb.AddSqlServer()
                    .WithGlobalConnectionString(stringDeConexao)
                    .ScanIn(typeof(HabilidadeMigration).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());
        }

        public static void InicializarBancoDeDados(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
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