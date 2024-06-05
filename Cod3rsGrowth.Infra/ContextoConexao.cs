using LinqToDB;
using LinqToDB.Data;
using System.Configuration;

namespace Cod3rsGrowth.Infra
{
    public class ContextoConexao : DataConnection
    {
        public ContextoConexao(string stringDeConexao) : base(stringDeConexao) { }

        public static ContextoConexao CriarConexao(string contexto)
        {
            string stringDeConexao = ConfigurationManager.ConnectionStrings[contexto].ConnectionString;
            return new ContextoConexao(stringDeConexao);
        }
    } 
}
