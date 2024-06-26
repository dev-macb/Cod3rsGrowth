using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Service;
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

            _serviceProvider = colecaoServicos.BuildServiceProvider();
        }

        public void Dispose()
        {
            _serviceProvider.Dispose();
        }
    }
}