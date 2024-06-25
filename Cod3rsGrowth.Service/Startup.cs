using Cod3rsGrowth.Service.Services;
using Cod3rsGrowth.Service.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Service
{
    public class StartupService
    {
        public static void Registrar(IServiceCollection servicos)
        {
            // Validadores
            servicos.AddScoped<PersonagemValidador>();
            servicos.AddScoped<HabilidadeValidador>();

            // Serviços
            servicos.AddScoped<PersonagemServico>();
            servicos.AddScoped<HabilidadeServico>();
            servicos.AddScoped<PersonagensHabilidadesServico>();
        }
    }
}