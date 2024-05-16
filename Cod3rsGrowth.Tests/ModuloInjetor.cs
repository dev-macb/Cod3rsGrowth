using Cod3rsGrowth.Domain.Interfaces;
using Cod3rsGrowth.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Domain
{
    public class ModuloInjetor
    {
        public static void RegistrarServicos(IServiceCollection servicos)
        {
            servicos.AddSingleton<IPersonagemRepositorio, PersonagemRepositorio>();
        }
    }
}