namespace Cod3rsGrowth.Domain.Interfaces
{
    public interface IFiltro
    {
        string? Nome { get; set; }
        bool? EVilao { get; set; }
        DateTime? DataBase { get; set; }
        DateTime? DataTeto { get; set; }
    }
}