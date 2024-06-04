using FluentMigrator;

namespace Cod3rsGrowth.Migrations
{
    [Migration(20240605)]
    public class PersonagemHabilidadeMigracao : Migration
    {
        public override void Up()
        {
            Create.Table("PersonagemHabilidade")
                .WithColumn("PersonagemId").AsInt32().ForeignKey("Personagem", "Id")
                .WithColumn("HabilidadeId").AsInt32().ForeignKey("Habilidade", "Id");

            Create.Index("Index_PersonagemHabilidade")
                .OnTable("PersonagemHabilidade")
                .OnColumn("PersonagemId").Ascending()
                .OnColumn("HabilidadeId").Ascending()
                .WithOptions().NonClustered();
        }

        public override void Down()
        {
            Delete.Table("PersonagemHabilidade");
        }
    }
}
