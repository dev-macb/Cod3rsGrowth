using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Service;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;
using Cod3rsGrowth.Tests.RepositoriesMock;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests
{
    public abstract class TesteBase : IDisposable
    {
        protected ServiceProvider _serviceProvider;

        protected TesteBase()
        {
            var stringDeConexao = "Data Source=DESKTOP-JN18SOC\\SQLEXPRESS; Initial Catalog=Cod3rsGrowth; User ID=sa; Password=sap@123; TrustServerCertificate=True; Encrypt=False";
            var colecaoServicos = new ServiceCollection();

            StartupInfra.Registrar(colecaoServicos, stringDeConexao);
            StartupService.Registrar(colecaoServicos);
            colecaoServicos.AddScoped<IRepositorio<Personagem>, PersonagemRepositorioMock>();            
            colecaoServicos.AddScoped<IRepositorio<Habilidade>, HabilidadeRepositorioMock>();

            _serviceProvider = colecaoServicos.BuildServiceProvider();
        }

        public void Dispose()
        {
            _serviceProvider.Dispose();
        }
    }
}