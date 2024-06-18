using LinqToDB;
using LinqToDB.Data;
using Cod3rsGrowth.Domain.Entities;

namespace Cod3rsGrowth.Infra
{
    public class ContextoConexao : DataConnection
    {
        public ContextoConexao(DataOptions<ContextoConexao> opcoes) : base(opcoes.Options) { }

        public ITable<Personagem> Personagens => this.GetTable<Personagem>();
        public ITable<Habilidade> Habilidades => this.GetTable<Habilidade>();
        public ITable<PersonagemHabilidade> PersonagensHabilidades => this.GetTable<PersonagemHabilidade>();

    }
}