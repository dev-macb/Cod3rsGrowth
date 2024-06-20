using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositories
{
    public class PersonagensHabilidadesRepositorio : IPersonagensHabilidadesRepositorio
    {
        private readonly ContextoConexao _bancoDeDados;

        public PersonagensHabilidadesRepositorio(ContextoConexao bancoDeDados)
        {
            _bancoDeDados = bancoDeDados;
        }

        public IEnumerable<PersonagensHabilidades> ObterTodos(Filtro? filtro)
        {
            return _bancoDeDados.PersonagensHabilidades.ToList();
        }

        public PersonagensHabilidades? ObterPorId(int id)
        {
            return _bancoDeDados.PersonagensHabilidades.FirstOrDefault(personagem => personagem.Id == id);
        }

        public List<int> ObterHabilidadesPorPersonagem(int idPersonagem)
        {
            return _bancoDeDados.PersonagensHabilidades
                .Where(personagemHabilidade => personagemHabilidade.IdPersonagem == idPersonagem)
                .Select(personagemHabilidade => personagemHabilidade.IdHabilidade)
                .ToList();
        }

        public int Adicionar(PersonagensHabilidades novoPersonagensHabilidades)
        {
            return Convert.ToInt32(_bancoDeDados.InsertWithIdentity(novoPersonagensHabilidades));
        }

        public void Atualizar(int id, PersonagensHabilidades personagensHabilidadesAtualizado)
        {
            _bancoDeDados.PersonagensHabilidades
                .Where(personagensHabilidades => personagensHabilidades.Id == id)
                .Set(personagensHabilidades => personagensHabilidades, personagensHabilidadesAtualizado)
                .Update();
        }

        public void Deletar(int id)
        {
            _bancoDeDados.PersonagensHabilidades
                .Where(personagensHabilidades => personagensHabilidades.Id == id)
                .Delete();
        }

        public void DeletarPorPersonagemEHabilidade(int idPersonagem, int idHabilidade)
        {
            var habilidades = ObterTodos(null).Where(personagensHabilidades => 
                personagensHabilidades.IdPersonagem == idPersonagem && 
                personagensHabilidades.IdHabilidade == idHabilidade
            );
            foreach (var habilidade in habilidades) Deletar(habilidade.Id);
        }
    }
}