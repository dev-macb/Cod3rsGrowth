using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Infra;

namespace Cod3rsGrowth.Tests
{
    public abstract class TesteBase : IDisposable
    {
        protected ServiceProvider _serviceProvider;

        protected TesteBase()
        {
            var colecaoServicos = new ServiceCollection();
            
            StartupInfra.Registrar(colecaoServicos);
            StartupService.Registrar(colecaoServicos);

            _serviceProvider = colecaoServicos.BuildServiceProvider();
        }

        public void Dispose()
        {
            _serviceProvider.Dispose();
        }
    }
}