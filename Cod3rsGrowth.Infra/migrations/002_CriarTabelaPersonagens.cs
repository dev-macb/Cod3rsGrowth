using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migrations
{
    [Migration(002)]
    public class CriarTabelaPersonagens : Migration
    {
        public override void Up()
        {
            Create.Table("personagens")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("nome").AsString().NotNullable()
                .WithColumn("vida").AsInt32().NotNullable()
                .WithColumn("energia").AsInt32().NotNullable()
                .WithColumn("velocidade").AsDouble().NotNullable()
                .WithColumn("forca").AsInt32().NotNullable()
                .WithColumn("inteligencia").AsInt32().NotNullable()
                .WithColumn("e_vilao").AsBoolean().Nullable()
                .WithColumn("criado_em").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime)
                .WithColumn("atualizado_em").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }

        public override void Down()
        {
            Delete.Table("personagens");
        }
    }
}