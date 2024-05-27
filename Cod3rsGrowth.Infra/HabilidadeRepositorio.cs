using Cod3rsGrowth.Domain.Entities;

namespace Cod3rsGrowth.Infra
{
    public class HabilidadeRepositorio : IHabilidadeRepositorio
    {
        private readonly List<Habilidade> _habilidades = RepositorioMock.ObterInstancia.Habilidades;

        public List<Habilidade> ObterTodos()
        {
            return _habilidades;
        }

        public Habilidade ObterPorId(int id)
        {
            return _habilidades.Find(habilidade => habilidade.Id == id) ?? throw new Exception("Habilidade não encontrada.");
        }

        public int Criar(Habilidade habilidade)
        {
            habilidade.Id = _habilidades.Any() ? _habilidades.Max(habilidade => habilidade.Id) + 1 : 1;
            _habilidades.Add(habilidade);

            return habilidade.Id ?? throw new Exception("Erro ao criar id da habilidade.");
        }

        public void Editar(int id, Habilidade habilidadeAtualizada)
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
