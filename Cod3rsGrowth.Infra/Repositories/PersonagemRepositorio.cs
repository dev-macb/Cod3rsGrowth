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

        public async Task<IEnumerable<Personagem>> ObterTodos(Filtro? filtro)
        {
            if (filtro == null) return await _bancoDeDados.Personagens.ToListAsync();

            var personagens = _bancoDeDados.Personagens.AsQueryable();
            if (!string.IsNullOrEmpty(filtro.Nome)) personagens = personagens.Where(habilidade => habilidade.Nome.Contains(filtro.Nome, StringComparison.OrdinalIgnoreCase));
            if (filtro.EVilao.HasValue) personagens = personagens.Where(habilidade => habilidade.EVilao == filtro.EVilao.Value);
            if (filtro.DataBase.HasValue) personagens = personagens.Where(habilidade => habilidade.CriadoEm >= filtro.DataBase.Value);
            if (filtro.DataTeto.HasValue) personagens = personagens.Where(habilidade => habilidade.CriadoEm <= filtro.DataTeto.Value);

            return await personagens.ToListAsync();
        }

        public async Task<Personagem?> ObterPorId(int id)
        {
            return await _bancoDeDados.Personagens.FirstOrDefaultAsync(personagem => personagem.Id == id);
        }

        public async Task<int> Adicionar(Personagem novoPersonagem)
        {
            var idPersonagemCriado = await _bancoDeDados.InsertWithInt32IdentityAsync(novoPersonagem);

            foreach(var idHabilidade in novoPersonagem.Habilidades)
            {
                
                await _bancoDeDados.InsertWithInt32IdentityAsync(new PersonagensHabilidades
                {
                    IdPersonagem = idPersonagemCriado,
                    IdHabilidade = idHabilidade
                });
            }

            return idPersonagemCriado;
        }

        public async Task Atualizar(int id, Personagem personagemAtualizado)
        {
            await _bancoDeDados.Personagens
                .Where(personagem => personagem.Id == id)
                .Set(personagem => personagem.Nome, personagemAtualizado.Nome)
                .Set(personagem => personagem.Vida, personagemAtualizado.Vida)
                .Set(personagem => personagem.Energia, personagemAtualizado.Energia)
                .Set(personagem => personagem.Velocidade, personagemAtualizado.Velocidade)
                .Set(personagem => personagem.Forca, personagemAtualizado.Forca)
                .Set(personagem => personagem.Inteligencia, personagemAtualizado.Inteligencia)
                .Set(personagem => personagem.EVilao, personagemAtualizado.EVilao)
                .Set(personagem => personagem.CriadoEm, personagemAtualizado.CriadoEm)
                .Set(personagem => personagem.AtualizadoEm, personagemAtualizado.AtualizadoEm)
                .UpdateAsync();
        }

        public async Task Deletar(int id)
        {
            await _bancoDeDados.Personagens
                .Where(habilidade => habilidade.Id == id)
                .DeleteAsync();
        }
    }
}