using LinqToDB.Mapping;

namespace Cod3rsGrowth.Domain.Entities
{
    [Table("habilidades")]
    public class Habilidade
    {
        [Column("id"), PrimaryKey, Identity]
        public int Id { get; set; }

        [Column("nome"), NotNull]
        public required string Nome { get; set; }

        [Column("descricao")]
        public string? Descricao { get; set; }

        [Column("criado_em", SkipOnInsert = true, SkipOnUpdate = true), NotNull]
        public DateTime? CriadoEm { get; set; }

        [Column("atualizado_em", SkipOnInsert = true, SkipOnUpdate = true), NotNull]
        public DateTime? AtualizadoEm { get; set; }
    }
}