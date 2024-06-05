namespace Cod3rsGrowth.Domain.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        public IEnumerable<T> ObterTodos(string filtro);
        public T ObterPorId(int id);
        public void Adicionar(T entidade);
        public void Atualizar(int id, T entidade);
        public void Deletar(int id);
    }
}