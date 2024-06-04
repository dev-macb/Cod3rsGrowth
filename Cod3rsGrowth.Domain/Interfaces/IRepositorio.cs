namespace Cod3rsGrowth.Domain.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        public List<T> ObterTodos(string filtro);
        public T ObterPorId(int id);
        public void Criar(T entidade);
        public void Atualizar(int id, T entidade);
        public void Remover(int id);
    }
}