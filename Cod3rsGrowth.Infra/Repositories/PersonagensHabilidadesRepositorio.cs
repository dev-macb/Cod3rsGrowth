using LinqToDB;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;
using LinqToDB.SqlQuery;

namespace Cod3rsGrowth.Infra.Repositories
{
    public class PersonagensHabilidadesRepositorio : IRepositorio<PersonagensHabilidades>
    {
        private readonly ContextoConexao _bancoDeDados;

        public PersonagensHabilidadesRepositorio(ContextoConexao bancoDeDados)
        {
            _bancoDeDados = bancoDeDados;
        }

        public async Task<IEnumerable<PersonagensHabilidades>> ObterTodos(Filtro? filtro)
        {
            return await _bancoDeDados.PersonagensHabilidades.ToListAsync();
        }

        public async Task<PersonagensHabilidades?> ObterPorId(int id)
        {
            return await _bancoDeDados.PersonagensHabilidades.FirstOrDefaultAsync(personagem => personagem.Id == id);
        }

        public async Task<int> Adicionar(PersonagensHabilidades novoPersonagensHabilidades)
        {
            return await _bancoDeDados.InsertWithInt32IdentityAsync(novoPersonagensHabilidades);
        }

        public async Task Atualizar(int id, PersonagensHabilidades personagensHabilidadesAtualizado)
        {
            await _bancoDeDados.PersonagensHabilidades
                .Where(personagensHabilidades => personagensHabilidades.Id == id)
                .Set(personagensHabilidades => personagensHabilidades, personagensHabilidadesAtualizado)
                .UpdateAsync();
        }

        public async Task Deletar(int id)
        {
            await _bancoDeDados.PersonagensHabilidades
                .Where(personagensHabilidades => personagensHabilidades.Id == id)
                .DeleteAsync();
        }
    }
}