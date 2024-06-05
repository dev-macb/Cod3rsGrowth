using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;

namespace Cod3rsGrowth.Infra.Repositories
{
    public class HabilidadeRepositorio : IRepositorio<Habilidade>
    {
        private readonly ContextoConexao _bancoDeDados;

        public HabilidadeRepositorio(ContextoConexao bancoDeDados)
        {
            _bancoDeDados = bancoDeDados;
        }

        public IEnumerable<Habilidade> ObterTodos(string filtro)
        {
            return _bancoDeDados.Habilidades.Where(habilidade => habilidade.Nome.Contains(filtro)).ToList();
        }

        public Habilidade ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Adicionar(Habilidade habilidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, Habilidade habilidade)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}