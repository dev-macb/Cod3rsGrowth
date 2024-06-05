using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;

namespace Cod3rsGrowth.Tests.Repositories
{
    public class HabilidadeRepositorio : IRepositorio<Habilidade>
    {
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;

        public List<Habilidade> ObterTodos(string filtro)
        {
            return _habilidades;
        }

        public Habilidade ObterPorId(int id)
        {
            return _habilidades.Find(habilidade => habilidade.Id == id) ?? throw new Exception("Habilidade não encontrada.");
        }

        public void Criar(Habilidade habilidade)
        {
            habilidade.Id = _habilidades.Any() ? _habilidades.Max(habilidade => habilidade.Id) + 1 : 1;
            _habilidades.Add(habilidade);
        }

        public void Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            var habilidadeExistente = _habilidades.Find(habilidade => habilidade.Id == id) ?? throw new Exception("Habilidade não encontrada.");
            habilidadeExistente.Nome = habilidadeAtualizada.Nome;
            habilidadeExistente.Descricao = habilidadeAtualizada.Descricao;
            habilidadeExistente.AtualizadoEm = DateTime.Now;
        }

        public void Remover(int id)
        {
            var habilidadeExistente = _habilidades.Find(habilidade => habilidade.Id == id) ?? throw new Exception("Habilidade não encontrada.");
            
            _habilidades.Remove(habilidadeExistente);
        }
    }
}
