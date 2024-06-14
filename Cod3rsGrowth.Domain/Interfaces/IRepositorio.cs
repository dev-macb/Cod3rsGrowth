using Cod3rsGrowth.Domain.Entities;

namespace Cod3rsGrowth.Domain.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        public IEnumerable<T> ObterTodos(Filtro? filtro);
        public T? ObterPorId(int id);
        public int Adicionar(T entidade);
        public void Atualizar(int id, T entidade);
        public void Deletar(int id);
    }
}