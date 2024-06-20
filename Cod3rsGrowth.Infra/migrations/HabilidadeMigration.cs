using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migrations
{
    [Migration(001)]
    public class HabilidadeMigration : Migration
    {
        public override void Up()
        {
            Create.Table("habilidades")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("nome").AsString(50).NotNullable()
                .WithColumn("descricao").AsString(200).Nullable()
                .WithColumn("criado_em").AsDateTime().NotNullable()
                .WithColumn("atualizado_em").AsDateTime().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("habilidades");
        }
    }
}