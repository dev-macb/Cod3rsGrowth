using System.Data;
using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migrations
{
    [Migration(003)]
    public class CriarTabelaPersongensHabilidades : Migration
    {
        public override void Up()
        {
            Create.Table("personagens_habilidades")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("id_personagem").AsInt32().NotNullable()
                .WithColumn("id_habilidade").AsInt32().NotNullable()
                .WithColumn("criado_em").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime)
                .WithColumn("atualizado_em").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);

            Create.ForeignKey("fk_id_personagem")
                .FromTable("personagens_habilidades").ForeignColumns("id_personagem")
                .ToTable("personagens").PrimaryColumn("id")
                .OnDeleteOrUpdate(Rule.Cascade);

            Create.ForeignKey("fk_id_habilidade")
                .FromTable("personagens_habilidades").ForeignColumns("id_habilidade")
                .ToTable("habilidades").PrimaryColumn("id")
                .OnDeleteOrUpdate(Rule.Cascade);
        }

        public override void Down()
        {
            Delete.ForeignKey("fk_id_personagem").OnTable("personagens_habilidades");
            Delete.ForeignKey("fk_id_habilidade").OnTable("personagens_habilidades");
            Delete.Table("personagens_habilidades");
        }
    }
}