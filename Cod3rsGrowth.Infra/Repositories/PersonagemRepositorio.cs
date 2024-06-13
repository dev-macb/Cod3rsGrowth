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

        public IEnumerable<Personagem> ObterTodos(Filtro? filtro)
        {
            if (filtro == null) return _bancoDeDados.Personagens.ToList();

            var personagens = _bancoDeDados.Personagens.AsQueryable();
            if (!string.IsNullOrEmpty(filtro.Nome)) personagens = personagens.Where(habilidade => habilidade.Nome.Contains(filtro.Nome, StringComparison.OrdinalIgnoreCase));
            if (filtro.EVilao.HasValue) personagens = personagens.Where(habilidade => habilidade.EVilao == filtro.EVilao.Value);
            if (filtro.DataBase.HasValue) personagens = personagens.Where(habilidade => habilidade.CriadoEm >= filtro.DataBase.Value);
            if (filtro.DataTeto.HasValue) personagens = personagens.Where(habilidade => habilidade.CriadoEm <= filtro.DataTeto.Value);

            return personagens.ToList();
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