using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests
{
    public class ModuloInjetor
    {
        public static void RegistrarServicos(IServiceCollection servicos)
        {
            // Serviços
            servicos.AddScoped<IPersonagemServico, PersonagemServico>();

            // Repositório Mock
            servicos.AddSingleton<IPersonagemRepositorio, PersonagemRepositorio>();
        }
    }
}