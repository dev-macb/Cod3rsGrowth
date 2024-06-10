using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Tests;
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
            StartupInfra.Registrar(colecaoServicos);
            StartupForms.Registrar(colecaoServicos);
            StartupService.Registrar(colecaoServicos);
            _serviceProvider = colecaoServicos.BuildServiceProvider();

            StartupForms.ResetarBancoDeDados(_serviceProvider);
            StartupForms.InicializarBancoDeDados(_serviceProvider);
            
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}