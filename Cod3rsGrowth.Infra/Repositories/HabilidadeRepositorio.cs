using LinqToDB;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Interfaces;

namespace Cod3rsGrowth.Infra.Repositories
{
    public class HabilidadeRepositorio : IRepositorio<Habilidade>
    {
        private readonly ContextoConexao _bancoDeDados;

        public HabilidadeRepositorio(ContextoConexao bancoDeDados)
        {
            _bancoDeDados = bancoDeDados;
        }

        public async Task<IEnumerable<Habilidade>> ObterTodos(Filtro? filtro)
        {
            if (filtro == null) return await _bancoDeDados.Habilidades.ToListAsync();

            var habilidades = _bancoDeDados.Habilidades.AsQueryable();
            if (!string.IsNullOrEmpty(filtro.Nome)) habilidades = habilidades.Where(habilidade => habilidade.Nome.Contains(filtro.Nome, StringComparison.OrdinalIgnoreCase));
            if (filtro.DataBase.HasValue) habilidades = habilidades.Where(habilidade => habilidade.CriadoEm >= filtro.DataBase.Value);
            if (filtro.DataTeto.HasValue) habilidades = habilidades.Where(habilidade => habilidade.CriadoEm <= filtro.DataTeto.Value);

            return await habilidades.ToListAsync();
        }

        public async Task<Habilidade?> ObterPorId(int id)
        {
            return await _bancoDeDados.Habilidades.FirstOrDefaultAsync(habilidade => habilidade.Id == id);
        }

        public async Task<int> Adicionar(Habilidade novaHabilidade)
        {
            return await _bancoDeDados.InsertWithInt32IdentityAsync(novaHabilidade);
        }

        public async Task Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            await _bancoDeDados.Habilidades
                .Where(habilidade => habilidade.Id == id)
                .Set(habilidade => habilidade.Nome, habilidadeAtualizada.Nome)
                .Set(habilidade => habilidade.Descricao, habilidadeAtualizada.Descricao)
                .Set(habilidade => habilidade.AtualizadoEm, habilidadeAtualizada.AtualizadoEm)
                .UpdateAsync();
        }

        public async Task Deletar(int id)
        {
            await _bancoDeDados.Habilidades.Where(habilidade => habilidade.Id == id).DeleteAsync();
        }
    }
}