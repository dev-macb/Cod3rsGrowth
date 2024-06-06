using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;
using LinqToDB;

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
            if (filtro == null) return _bancoDeDados.Habilidades;

            return _bancoDeDados.Habilidades.Where(habilidade => habilidade.Nome.Contains(filtro)).ToList();
        }

        public Habilidade? ObterPorId(int id)
        {
            return _bancoDeDados.Habilidades.FirstOrDefault(habilidade => habilidade.Id == id);
        }

        public int Adicionar(Habilidade novaHabilidade)
        {
            return _bancoDeDados.Insert(novaHabilidade);
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