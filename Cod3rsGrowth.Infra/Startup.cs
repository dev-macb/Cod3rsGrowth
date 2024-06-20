using LinqToDB;
using DotNetEnv;
using LinqToDB.AspNet;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;
using Cod3rsGrowth.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Infra
{
    public class StartupInfra
    {
        public static void Registrar(IServiceCollection servicos)
        {
            Env.Load();
            string? stringDeConexao = Environment.GetEnvironmentVariable("BANCO_DADOS_URI");
            if (string.IsNullOrEmpty(stringDeConexao)) throw new Exception("Erro ao carregar string de conexão com o banco de dados.");

            servicos.AddLinqToDBContext<ContextoConexao>((provider, options) => options.UseSqlServer(stringDeConexao));

            // Repositories
            servicos.AddScoped<IRepositorio<Personagem>, PersonagemRepositorio>();
            servicos.AddScoped<IRepositorio<Habilidade>, HabilidadeRepositorio>();
            servicos.AddScoped<IPersonagensHabilidadesRepositorio, PersonagensHabilidadesRepositorio>();
        }
    }
}