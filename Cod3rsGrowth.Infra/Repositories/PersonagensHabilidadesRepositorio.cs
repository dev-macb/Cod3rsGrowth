using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositories
{
    public class PersonagensHabilidadesRepositorio : IRepositorio<PersonagensHabilidades>
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
    }
}