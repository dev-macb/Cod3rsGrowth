using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Service;
using Cod3rsGrowth.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Cod3rsGrowth.Forms
{
    internal static class Program
    {
        private static ServiceProvider? _serviceProvider;

        [STAThread]
        static void Main()
        {
            string? stringDeConexao = ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ConnectionString;
            if (string.IsNullOrEmpty(stringDeConexao)) throw new Exception("Sem URI do banco");

            var colecaoServicos = new ServiceCollection();
            StartupInfra.Registrar(colecaoServicos, stringDeConexao);
            StartupService.Registrar(colecaoServicos);
            _serviceProvider = colecaoServicos.BuildServiceProvider();

            StartupInfra.InicializarBancoDeDados(_serviceProvider);

            ApplicationConfiguration.Initialize();
            Application.Run(new FormularioPrincipal(
                _serviceProvider.GetRequiredService<PersonagemServico>(),
                _serviceProvider.GetRequiredService<HabilidadeServico>()
            ));
        }
    }
}