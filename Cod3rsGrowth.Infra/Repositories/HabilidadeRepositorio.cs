using LinqToDB;
using LinqToDB.Data;
using System.Configuration;
using Cod3rsGrowth.Domain.Entities;

namespace Cod3rsGrowth.Service.Repositories
{
    public class HabilidadeRepositorio
    {
        private readonly DataConnection _contexto;

        public HabilidadeRepositorio()
        {
            _contexto = new DataConnection(
                new DataOptions().UseSqlServer(ConfigurationManager.AppSettings["ConexaoPadrao"] ?? "Não Encontrado!")
            );
        }

        public IEnumerable<Habilidade> ObterTodos(string filtro = "")
        {
            return _contexto.GetTable<Habilidade>().Where(habilidade => habilidade.Nome.Contains(filtro));
        }

        public Habilidade ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Criar(Habilidade entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, Habilidade entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}