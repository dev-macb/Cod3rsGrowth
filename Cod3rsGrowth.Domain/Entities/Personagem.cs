using Cod3rsGrowth.Domain.Enums;
using LinqToDB.Mapping;

namespace Cod3rsGrowth.Domain.Entities
{
    [Table("personagens")]
    public class Personagem
    {
        public int? Id { get; set; }
        public required string Nome { get; set; }
        public int Vida { get; set; }
        public int Energia { get; set; }
        public double Velocidade { get; set; }
        public CategoriasEnum Forca { get; set; }
        public CategoriasEnum Inteligencia { get; set; }
        public List<int>? Habilidades { get; set; }
        public bool? EVilao { get; set; }
        public DateTime? CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }
    }
}