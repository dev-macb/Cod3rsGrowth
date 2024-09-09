using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;

namespace Cod3rsGrowth.Tests.RepositoriesMock
{
    public class HabilidadeRepositorioMock : IRepositorio<Habilidade>
    {
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;

        public Task<IEnumerable<Habilidade>> ObterTodos(Filtro? filtro)
        {
            return Task.FromResult((IEnumerable<Habilidade>)_habilidades);
        }

        public Task<Habilidade> ObterPorId(int id)
        {
            var habilidade = _habilidades.Find(h => h.Id == id);
            return Task.FromResult(habilidade ?? throw new Exception("Habilidade não encontrada."));
        }

        public Task<int> Adicionar(Habilidade habilidade)
        {
            habilidade.Id = _habilidades.Any() ? _habilidades.Max(habilidade => habilidade.Id) + 1 : 1;
            _habilidades.Add(habilidade);
            return Task.FromResult(habilidade.Id);
        }

        public Task Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            var habilidadeExistente = _habilidades.FirstOrDefault(h => h.Id == id) ?? throw new Exception("Habilidade não encontrada.");
            
            habilidadeExistente.Nome = habilidadeAtualizada.Nome;
            habilidadeExistente.Descricao = habilidadeAtualizada.Descricao;
            habilidadeExistente.AtualizadoEm = DateTime.Now;

            return Task.CompletedTask;
        }

        public Task Deletar(int id)
        {
            var habilidadeExistente = _habilidades.Find(habilidade => habilidade.Id == id) ?? throw new Exception("Habilidade não encontrada.");

            _habilidades.Remove(habilidadeExistente);
            return Task.CompletedTask;
        }
    }
}