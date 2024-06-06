using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositories
{
    public class PersonagemRepositorio : IRepositorio<Personagem>
    {
        private readonly ContextoConexao _bancoDeDados;

        public PersonagemRepositorio(ContextoConexao bancoDeDados)
        {
            _bancoDeDados = bancoDeDados;
        }

        public IEnumerable<Personagem> ObterTodos(string filtro)
        {
            if (filtro == null) return _bancoDeDados.Personagens;

            return _bancoDeDados.Personagens.Where(personagem => personagem.Nome.Contains(filtro)).ToList();
        }

        public Personagem? ObterPorId(int id)
        {
            return _bancoDeDados.Personagens.FirstOrDefault(personagem => personagem.Id == id);
        }

        public int Adicionar(Personagem novoPersonagem)
        {
            return _bancoDeDados.Insert(novoPersonagem);
        }

        public void Atualizar(int id, Personagem personagemAtualizado)
        {
            _bancoDeDados.Personagens
                .Where(personagem => personagem.Id == id)
                .Set(personagem => personagem, personagemAtualizado)
                .Update();
        }

        public void Deletar(int id)
        {
            _bancoDeDados.Personagens.Where(habilidade => habilidade.Id == id).Delete();
        }
    }
}