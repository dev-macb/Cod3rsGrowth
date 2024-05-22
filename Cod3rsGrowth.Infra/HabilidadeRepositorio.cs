using CodersGrowth.Domain.Entities;

namespace Cod3rsGrowth.Infra
{
    public class HabilidadeRepositorio : IHabilidadeRepositorio
    {
        private readonly List<Habilidade> personagens;

        public HabilidadeRepositorio()
        {
            personagens = new List<Habilidade>()
            {
                new(1, "Talento", "Descrevem todas as Habilidades intuitivas. Não precisam ser praticados per se e não podem ser estudados ou aprendidos em livros. Costumam ser adquiridos através da experiência direta."),
                new(2, "Perícia", "são habilidades adquiridas através de rigoroso treinamento. Esta categoria inclui qualquer Habilidade que deve ser aprendida passo-a-passo através da prática, mas que pode ser ensinada e aprendida"),
                new(3, "Conhecimento", "Incluem todas as Habilidades que requerem a aplicação rigorosa da mente. Estas Habilidades são geralmente aprendidas através da escola, aulas, livros e professores, mas podem ser adquiridas através da experiência.")
            };
        }

        public List<Habilidade> ObterTodos()
        {
            return personagens;
        }
    }
}
