using LinqToDB;
using LinqToDB.Data;
using System.Configuration;
using Cod3rsGrowth.Domain.Entities;

namespace Cod3rsGrowth.Infra
{
    public class ContextoConexao : DataConnection
    {
        public ContextoConexao(DataOptions<ContextoConexao> opcao) : base(opcao.Options) { }

        private ContextoConexao(string stringDeConexao) : base(stringDeConexao) { }

        public static ContextoConexao CriarConexao(string contexto)
        {
            string stringDeConexao = ConfigurationManager.ConnectionStrings[contexto].ConnectionString;
            return new ContextoConexao(stringDeConexao);
        }

        public ITable<Personagem>? Personagens = null;
        public ITable<Habilidade>? Habilidades = null;
    } 
}
 