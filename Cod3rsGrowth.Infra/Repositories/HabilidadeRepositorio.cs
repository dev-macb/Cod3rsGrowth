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

        public IEnumerable<Habilidade> ObterTodos(Filtro? filtro)
        {
            if (filtro == null) return _bancoDeDados.Habilidades;

            var habilidades = _bancoDeDados.Habilidades.AsQueryable();
            if (!string.IsNullOrEmpty(filtro.Nome)) habilidades = habilidades.Where(habilidade => habilidade.Nome.Contains(filtro.Nome, StringComparison.OrdinalIgnoreCase));
            if (filtro.DataBase.HasValue) habilidades = habilidades.Where(habilidade => habilidade.CriadoEm >= filtro.DataBase.Value);
            if (filtro.DataTeto.HasValue) habilidades = habilidades.Where(habilidade => habilidade.CriadoEm <= filtro.DataTeto.Value);

            return habilidades.ToList();
        }

        public Habilidade? ObterPorId(int id)
        {
            return _bancoDeDados.Habilidades.FirstOrDefault(habilidade => habilidade.Id == id);
        }

        public int Adicionar(Habilidade novaHabilidade)
        {
            return _bancoDeDados.Insert(novaHabilidade);
        }

        public void Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            _bancoDeDados.Habilidades
                .Where(habilidade => habilidade.Id == id)
                .Set(habilidade => habilidade, habilidadeAtualizada)
                .Update();
        }

        public void Deletar(int id)
        {
            _bancoDeDados.Habilidades.Where(habilidade => habilidade.Id == id).Delete();
        }
    }
}