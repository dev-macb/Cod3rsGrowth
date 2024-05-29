namespace Cod3rsGrowth.Domain.Entities
{
    public class Habilidade
    {
        public int? Id { get; set; }
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime? CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }
    }
}