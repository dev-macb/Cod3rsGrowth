using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Tests.RepositoriesMock;

namespace Cod3rsGrowth.Tests.Repositories
{
    public class PersonagemRepositorioMock
    {
        private readonly List<Personagem> _personagens = RepositorioMock.ObterInstancia.Personagens;

        public IEnumerable<Personagem> ObterTodos(string filtro)
        {
            return _personagens;
        }

        public Personagem ObterPorId(int id)
        {
            return _personagens.Find(personagem => personagem.Id == id) ?? throw new Exception("Personagem não encontrado.");
        }

        public int Adicionar(Personagem personagem)
        {
            personagem.Id = _personagens.Any() ? _personagens.Max(personagem => personagem.Id) + 1 : 1;
            _personagens.Add(personagem);
            return personagem.Id ?? throw new Exception("Erro oa gerar id do personagem.");
        }

        public void Atualizar(int id, Personagem personagemAtualizado)
        {
            var personagemExistente = _personagens.Find(personagem => personagem.Id == id) ?? throw new Exception("Personagem não encontrado.");
            personagemExistente.Nome = personagemAtualizado.Nome;
            personagemExistente.Vida = personagemAtualizado.Vida;
            personagemExistente.Energia = personagemAtualizado.Energia;
            personagemExistente.Velocidade = personagemAtualizado.Velocidade;
            personagemExistente.Forca = personagemAtualizado.Forca;
            personagemExistente.Inteligencia = personagemAtualizado.Inteligencia;
            personagemExistente.Habilidades = personagemAtualizado.Habilidades;
            personagemExistente.EVilao = personagemAtualizado.EVilao;
            personagemExistente.AtualizadoEm = DateTime.Now;
        }

        public void Deletar(int id)
        {
            var personagemExistente = _personagens.Find(personagem => personagem.Id == id) ?? throw new Exception("Personagem não encontrado.");

            _personagens.Remove(personagemExistente);
        }
    }
}