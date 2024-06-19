using Cod3rsGrowth.Domain.Enums;
using LinqToDB.Mapping;

namespace Cod3rsGrowth.Domain.Entities
{
    [Table("personagens_habilidades")]
    public class PersonagensHabilidades
    {
        [Column("id"), PrimaryKey, Identity]
        public int? Id { get; set; }

        [Column("id_personagem"), NotNull]
        public int IdPersonagem { get; set; }
        
        [Column("id_habilidade")]
        public int IdHabilidade { get; set; }

        [Column("criado_em"), NotNull]
        public DateTime CriadoEm { get; set; }

        [Column("atualizado_em"), NotNull]
        public DateTime AtualizadoEm { get; set; }
    }
}