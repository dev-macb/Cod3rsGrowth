using Cod3rsGrowth.Domain.Services;
using Cod3rsGrowth.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests
{
    public class ModuloInjetor
    {
        public static void RegistrarServicos(IServiceCollection servicos)
        {
            servicos.AddScoped<IPersonagemServico, PersonagemServico>();
        }
    }
}