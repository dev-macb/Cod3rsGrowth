using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;

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
            return _bancoDeDados.Personagens.Where(personagem => personagem.Id == id).FirstOrDefault();
        }

        public void Adicionar(Personagem personagem)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, Personagem personagem)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}