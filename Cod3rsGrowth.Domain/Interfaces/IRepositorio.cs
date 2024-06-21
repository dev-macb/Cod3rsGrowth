using Cod3rsGrowth.Domain.Entities;

namespace Cod3rsGrowth.Domain.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        Task<IEnumerable<T>> ObterTodos(Filtro? filtro);
        Task<T?> ObterPorId(int id);
        Task<int> Adicionar(T entidade);
        Task Atualizar(int id, T entidade);
        Task Deletar(int id);
    }
}