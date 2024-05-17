using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests
{
    public abstract class TesteBase : IDisposable
    {
        protected ServiceProvider ServiceProvider { get; }

        protected TesteBase()
        {
            var serviceCollection = new ServiceCollection();
            ModuloInjetor.RegistrarServicos(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public void Dispose()
        {
            ServiceProvider.Dispose();
        }
    }
}