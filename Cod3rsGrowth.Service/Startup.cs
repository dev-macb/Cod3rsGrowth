using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests
{
    public class StartupService
    {
        public static void Registrar(IServiceCollection servicos)
        {
            // Serviços
            servicos.AddScoped<PersonagemServico>();
            servicos.AddScoped<HabilidadeServico>();

            // Validadores
            servicos.AddScoped<PersonagemValidador>();
            servicos.AddScoped<HabilidadeValidador>();
        }
    }
}