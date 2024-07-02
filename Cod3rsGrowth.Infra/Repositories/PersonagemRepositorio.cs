using LinqToDB;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;
using Microsoft.Data.SqlClient;

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
            var personagem = await _bancoDeDados.Personagens.FirstOrDefaultAsync(p => p.Id == id);

            if (personagem != null)
            {
                personagem.Habilidades = await _bancoDeDados.PersonagensHabilidades
                    .Where(ph => ph.IdPersonagem == id)
                    .Select(ph => ph.IdHabilidade)
                    .ToListAsync();
            }

            return personagem;
        }

        public async Task<int> Adicionar(Personagem novoPersonagem)
        {
            var idPersonagemCriado = await _bancoDeDados.InsertWithInt32IdentityAsync(novoPersonagem);

            if (novoPersonagem.Habilidades != null)
            {
                foreach (var idHabilidade in novoPersonagem.Habilidades)
                {
                    await _bancoDeDados.InsertWithInt32IdentityAsync(new PersonagensHabilidades
                    {
                        IdPersonagem = idPersonagemCriado,
                        IdHabilidade = idHabilidade
                    });
                }
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
                .Set(personagem => personagem.AtualizadoEm, DateTime.Now)
                .UpdateAsync();

            var habilidadesExistentes = await _bancoDeDados.PersonagensHabilidades
                .Where(ph => ph.IdPersonagem == id)
                .Select(ph => ph.IdHabilidade)
                .ToListAsync();

            if (personagemAtualizado.Habilidades != null)
            {
                var habilidadesParaAdicionar = personagemAtualizado.Habilidades.Except(habilidadesExistentes).ToList();
                foreach (var idHabilidade in habilidadesParaAdicionar)
                {
                    await _bancoDeDados.InsertWithInt32IdentityAsync(new PersonagensHabilidades
                    {
                        IdPersonagem = id,
                        IdHabilidade = idHabilidade
                    });
                }

                var habilidadesParaRemover = habilidadesExistentes.Except(personagemAtualizado.Habilidades).ToList();
                if (habilidadesParaRemover.Any())
                {
                    await _bancoDeDados.PersonagensHabilidades
                        .Where(ph => ph.IdPersonagem == id && habilidadesParaRemover.Contains(ph.IdHabilidade))
                        .DeleteAsync();
                }
            }
        }

        public async Task Deletar(int id)
        {
            await _bancoDeDados.Personagens
                .Where(habilidade => habilidade.Id == id)
                .DeleteAsync();
        }
    }
}