using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Validators;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Domain.Interfaces;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.Repositories;

namespace Cod3rsGrowth.Tests
{
    public class Startup
    {
        public static ServiceProvider RegistrarServicos(IServiceCollection servicos)
        {
            // Serviços
            servicos.AddScoped<PersonagemServico>();
            servicos.AddScoped<HabilidadeServico>();

            // Validadores
            servicos.AddScoped<PersonagemValidador>();
            servicos.AddScoped<HabilidadeValidador>();

            // Repositórios
            servicos.AddScoped<IRepositorio<Personagem>, PersonagemRepositorio>();
            servicos.AddScoped<IRepositorio<Habilidade>, HabilidadeRepositorio>();

            return servicos.BuildServiceProvider();
        }
    }
}