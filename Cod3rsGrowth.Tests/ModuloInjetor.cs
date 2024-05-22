using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Service;
using CodersGrowth.Domain.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests
{
    public class ModuloInjetor
    {
        public static void RegistrarServicos(IServiceCollection servicos)
        {
            // Validadores
            servicos.AddScoped<PersonagemValidador>();
            
            // Serviços
            servicos.AddScoped<IPersonagemServico, PersonagemServico>();
            servicos.AddScoped<IHabilidadeServico, HabilidadeServico>();

            // Repositório Mock
            servicos.AddSingleton<IPersonagemRepositorio, PersonagemRepositorio>();
            servicos.AddSingleton<IHabilidadeRepositorio, HabilidadeRepositorio>();
        }
    }
}