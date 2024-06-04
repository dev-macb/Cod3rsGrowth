using LinqToDB;
using LinqToDB.Data;
using System.Configuration;
using Cod3rsGrowth.Domain.Entities;

namespace Cod3rsGrowth.Service.Repositories
{
    public class PersonagemRepositorio
    {
        private readonly DataConnection _contexto;

        public PersonagemRepositorio()
        {
            _contexto = new DataConnection(
                new DataOptions().UseSqlServer(ConfigurationManager.AppSettings["ConexaoPadrao"] ?? "Não Encontrado!")
            );
        }

        public IEnumerable<Habilidade> ObterTodos(string? filtro = "")
        {
            throw new NotImplementedException();
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