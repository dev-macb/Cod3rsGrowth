using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests
{
    public abstract class TesteBase : IDisposable
    {
        protected ServiceProvider _serviceProvider;

        protected TesteBase()
        {
            _serviceProvider = ModuloInjetor.RegistrarServicos(new ServiceCollection());
        }

        public void Dispose()
        {
            _serviceProvider.Dispose();
        }
    }
}