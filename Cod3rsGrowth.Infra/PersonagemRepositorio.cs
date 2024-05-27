using Cod3rsGrowth.Domain.Entities;

namespace Cod3rsGrowth.Infra
{
    public class PersonagemRepositorio : IPersonagemRepositorio
    {
        private readonly List<Personagem> _personagens = RepositorioMock.ObterInstancia.Personagens;

        public List<Personagem> ObterTodos()
        {
            return _personagens;
        }

        public Personagem ObterPorId(int id)
        {
            return _personagens.Find(personagem => personagem.Id == id) ?? throw new Exception("Personagem não encontrado.");
        }

        public int Criar(Personagem personagem)
        {
            personagem.Id = _personagens.Any() ? _personagens.Max(personagem => personagem.Id) + 1 : 1;
            _personagens.Add(personagem);

            return personagem.Id ?? throw new Exception("Erro ao criar id do personagem.");
        }

        public void Editar(int id, Personagem personagemAtualizado)
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

        public void Remover(int id)
        {
            var personagemExistente = _personagens.Find(personagem => personagem.Id == id) ?? throw new Exception("Personagem não encontrado.");
            
            _personagens.Remove(personagemExistente);
        }
    }
}