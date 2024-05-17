using CodersGrowth.Domain.Enum;
using CodersGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;


namespace Cod3rsGrowth.Tests.Repositories
{
    public class PersonagemRepositorio : IPersonagemRepositorio
    {
        public List<Personagem> personagens;

        public PersonagemRepositorio()
        {
            personagens = new List<Personagem>()
            {
                new(1, "Ryu", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(2, "Ken", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(3, "Chun-Li", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(4, "Blanka", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(5, "Zangief", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(6, "Guile", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(7, "Dhalsim", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio),
                new(8, "Vega", 100, 50, 1.0f, CategoriasEnum.Bom, CategoriasEnum.Medio)
            };
        }

        public List<Personagem> ObterTodos()
        {
            return personagens;
        }

        public Personagem? ObterPorId(int id)
        {
            var personagem = personagens.Find(p => p.Id == id);
            return personagem;
        }

        public int Criar(string nome, int vida, int energia, double velocidade, CategoriasEnum forca, CategoriasEnum inteligencia)
        {
            int novoId = personagens.Last().Id + 1;
            var novoPersonagem = new Personagem(novoId, nome, vida, energia, velocidade, forca, inteligencia);
            personagens.Add(novoPersonagem);

            return novoPersonagem.Id;
        }

        public void Editar(int id, int vida, int energia, double velocidade, CategoriasEnum forca, CategoriasEnum inteligencia)
        {
            var personagem = personagens.Find(p => p.Id == id);
            if(personagem != null)
            {
                personagem.Vida = vida;
                personagem.Energia = energia;
                personagem.Velocidade = velocidade;
                personagem.Forca = forca;
                personagem.Inteligencia = inteligencia;
            }
        }

        public void Remover(int id)
        {
            var personagem = personagens.Find(p => p.Id == id);
            if(personagem != null)
            {
                personagens.Remove(personagem);
            }
        }
    }
}