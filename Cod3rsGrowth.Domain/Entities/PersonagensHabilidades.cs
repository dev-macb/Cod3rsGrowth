using LinqToDB.Mapping;

namespace Cod3rsGrowth.Domain.Entities
{
    [Table("personagens_habilidades")]
    public class PersonagensHabilidades
    {
        [Column("id"), PrimaryKey, Identity]
        public int Id { get; set; }

        [Column("id_personagem"), NotNull]
        public required int IdPersonagem { get; set; }

        [Column("id_habilidade")]
        public required int IdHabilidade { get; set; }

        [Column("criado_em", SkipOnInsert = true, SkipOnUpdate = true), NotNull]
        public DateTime? CriadoEm { get; set; }

        [Column("atualizado_em", SkipOnInsert = true, SkipOnUpdate = true), NotNull]
        public DateTime? AtualizadoEm { get; set; }
    }
}