namespace Cod3rsGrowth.Domain.Interfaces
{
    public interface IFiltro<T> where T : class
    {
        public string? Nome { get; set; }
        public bool? EVilao { get; set; }
        public DateTime? CriadoEm { get; set; }
    }
}