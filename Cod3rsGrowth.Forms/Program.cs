using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Service;
using Cod3rsGrowth.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms
{
    internal static class Program
    {
        private static ServiceProvider? _serviceProvider;

        [STAThread]
        static void Main()
        {
            var colecaoServicos = new ServiceCollection();
            StartupInfra.Registrar(colecaoServicos, false);
            StartupService.Registrar(colecaoServicos);
            _serviceProvider = colecaoServicos.BuildServiceProvider();

            StartupInfra.InicializarBancoDeDados(_serviceProvider);

            ApplicationConfiguration.Initialize();
            Application.Run(new FormularioPrincipal(
                _serviceProvider.GetRequiredService<PersonagemServico>(), 
                _serviceProvider.GetRequiredService<HabilidadeServico>(),
                _serviceProvider.GetRequiredService<PersonagensHabilidadesServico>()
            ));
        }
    }
}