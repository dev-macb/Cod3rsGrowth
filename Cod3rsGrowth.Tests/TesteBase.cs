using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Service;
using Cod3rsGrowth.Tests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests
{
    public abstract class TesteBase : IDisposable
    {
        protected ServiceProvider _serviceProvider;

        protected TesteBase()
        {
            var colecaoServicos = new ServiceCollection();

            StartupService.Registrar(colecaoServicos);
            StartupInfra.Registrar(colecaoServicos, "Data Source=DESKTOP-JN18SOC\\SQLEXPRESS; Initial Catalog=Cod3rsGrowth; User ID=sa; Password=sap@123; TrustServerCertificate=True; Encrypt=False");
            colecaoServicos.AddScoped<HabilidadeRepositorioMock>();
            colecaoServicos.AddScoped<PersonagemRepositorioMock>();

            _serviceProvider = colecaoServicos.BuildServiceProvider();
        }

        public void Dispose()
        {
            _serviceProvider.Dispose();
        }
    }
}