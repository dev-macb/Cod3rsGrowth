using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Interfaces;
using Cod3rsGrowth.Domain.Validators;
using Cod3rsGrowth.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests
{
    public class ModuloInjetor
    {
        public static void RegistrarServicos(IServiceCollection servicos)
        {
            // Validadores
            servicos.AddScoped<PersonagemValidador>();
            servicos.AddScoped<HabilidadeValidador>();
            
            // Serviços
            servicos.AddScoped<PersonagemServico>();
            servicos.AddScoped<HabilidadeServico>();

            // Repositórios
            servicos.AddSingleton<IPersonagemRepositorio, PersonagemRepositorio>();
            servicos.AddSingleton<IHabilidadeRepositorio, HabilidadeRepositorio>();
        }
    }
}