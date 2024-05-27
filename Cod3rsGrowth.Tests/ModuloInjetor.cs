using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Validators;
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
            servicos.AddScoped<IPersonagemServico, PersonagemServico>();
            servicos.AddScoped<IHabilidadeServico, HabilidadeServico>();

            // Repositórios
            servicos.AddSingleton<IPersonagemRepositorio, PersonagemRepositorio>();
            servicos.AddSingleton<IHabilidadeRepositorio, HabilidadeRepositorio>();
        }
    }
}