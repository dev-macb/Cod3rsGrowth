using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;

namespace Cod3rsGrowth.Tests.RepositoriesMock
{
    public class PersonagemRepositorioMock  : IRepositorio<Personagem>
    {
        private readonly List<Personagem> _personagens = RepositorioMock.ObterInstancia.Personagens;

        public Task<IEnumerable<Personagem>> ObterTodos(Filtro? filtro)
        {
            return Task.FromResult((IEnumerable<Personagem>)_personagens);
        }

        public Task<Personagem> ObterPorId(int id)
        {
            var personagem = _personagens.Find(p => p.Id == id);
            return Task.FromResult(personagem ?? throw new Exception("Personagem não encontrado."));
        }

        public Task<int> Adicionar(Personagem personagem)
        {
            personagem.Id = _personagens.Any() ? _personagens.Max(p => p.Id) + 1 : 1;
            _personagens.Add(personagem);
            return Task.FromResult(personagem.Id ?? throw new Exception("Erro oa gerar id do personagem."));
        }

        public Task Atualizar(int id, Personagem personagemAtualizado)
        {
            var personagemExistente = _personagens.Find(p => p.Id == id) ?? throw new Exception("Personagem não encontrado.");

            personagemExistente.Nome = personagemAtualizado.Nome;
            personagemExistente.Vida = personagemAtualizado.Vida;
            personagemExistente.Energia = personagemAtualizado.Energia;
            personagemExistente.Velocidade = personagemAtualizado.Velocidade;
            personagemExistente.Forca = personagemAtualizado.Forca;
            personagemExistente.Inteligencia = personagemAtualizado.Inteligencia;
            personagemExistente.Habilidades = personagemAtualizado.Habilidades;
            personagemExistente.EVilao = personagemAtualizado.EVilao;
            personagemExistente.AtualizadoEm = DateTime.Now;

            return Task.CompletedTask;
        }

        public Task Deletar(int id)
        {
            var personagemExistente = _personagens.Find(p => p.Id == id) ?? throw new Exception("Personagem não encontrado.");

            _personagens.Remove(personagemExistente);
            return Task.CompletedTask;
        }
    }
}