using CodersGrowth.Domain.Entities;

namespace Cod3rsGrowth.Infra
{
    public class PersonagemRepositorio : IPersonagemRepositorio
    {
        private readonly List<Personagem> personagens;

        public PersonagemRepositorio()
        {
            personagens = new List<Personagem>()
            {
                // new(1, "Ryu", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                // new(2, "Ken", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                // new(3, "Chun-Li", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                // new(4, "Blanka", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                // new(5, "Zangief", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                // new(6, "Guile", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                // new(7, "Dhalsim", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                // new(8, "Vega", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio)
            };
        }

        public List<Personagem> ObterTodos()
        {
            return personagens;
        }

        public Personagem ObterPorId(int id)
        {
            return personagens.Find(personagem => personagem.Id == id) ?? throw new Exception("Personagem não encontrado.");
        }

        public int Criar(Personagem personagem)
        {
            personagem.Id = personagens.Any() ? personagens.Max(personagem => personagem.Id) + 1 : 1;
            personagens.Add(personagem);

            return personagem.Id ?? throw new Exception("Erro ao criar id do personagem.");
        }

        public void Editar(int id, Personagem personagemAtualizado)
        {
            var personagemExistente = personagens.Find(personagem => personagem.Id == id) ?? throw new Exception("Personagem não encontrado");
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
    }
}