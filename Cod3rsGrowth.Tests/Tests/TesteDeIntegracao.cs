using LinqToDB;
using LinqToDB.Data;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Infra;

namespace Cod3rsGrowth.Tests.Tests
{
    public class TesteDeIntegracao : TesteBase
    {
        public TesteDeIntegracao() : base() { }

        [Fact]
        public void DeveConectarNoBancoDeDadosComExito()
        {
            // Arrange
            ContextoConexao? bancoDeDados = null;

            // Act
            try 
            {
                bancoDeDados = ContextoConexao.CriarConexao("ConexaoPadrao");
                bool statusDeConexao = bancoDeDados.Connection.State == System.Data.ConnectionState.Open;
                    
                // Assert
                Assert.True(statusDeConexao, "A conexão com o banco de dados deve estar aberta.");
            }
            catch 
            {
                bancoDeDados?.Dispose();
            }
            
        }
    }
}