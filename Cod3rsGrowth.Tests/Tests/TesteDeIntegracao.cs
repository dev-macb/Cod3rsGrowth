using Cod3rsGrowth.Infra;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteDeIntegracao : TesteBase
    {
        private readonly ContextoConexao _bancoDeDados;

        public TesteDeIntegracao() : base() 
        {
            _bancoDeDados = _serviceProvider.GetRequiredService<ContextoConexao>();
        }

        [Fact]
        public void DeveConectarNoBancoDeDadosComExito()
        {
            // Arrange
            bool statusDaConexao;
            
            // Act
            statusDaConexao = _bancoDeDados.Connection.State == System.Data.ConnectionState.Open;

            // Assert
            Assert.True(statusDaConexao, "A conexão com o banco de dados deve estar aberta.");
        }
    }
}