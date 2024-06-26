using LinqToDB.Mapping;
using Cod3rsGrowth.Domain.Enums;

namespace Cod3rsGrowth.Domain.Entities
{
    [Table("personagens")]
    public class Personagem
    {
        [Column("id"), PrimaryKey, Identity]
        public int? Id { get; set; }

        [Column("nome"), NotNull]
        public required string Nome { get; set; }

        [Column("vida")]
        public int Vida { get; set; }

        [Column("energia"), NotNull]
        public int Energia { get; set; }

        [Column("velocidade"), NotNull]
        public double Velocidade { get; set; }

        [Column("forca"), NotNull]
        public CategoriasEnum Forca { get; set; }

        [Column("inteligencia"), NotNull]
        public CategoriasEnum Inteligencia { get; set; }

        [Column("e_vilao")]
        public bool? EVilao { get; set; }

        [Column("criado_em", SkipOnInsert = true, SkipOnUpdate = true), NotNull]
        public DateTime? CriadoEm { get; set; }

        [Column("atualizado_em", SkipOnInsert = true, SkipOnUpdate = true), NotNull]
        public DateTime? AtualizadoEm { get; set; }

        public List<int>? Habilidades { get; set; }
    }
}