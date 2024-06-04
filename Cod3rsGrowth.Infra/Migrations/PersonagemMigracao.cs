using FluentMigrator;

namespace Cod3rsGrowth.Migrations
{
    [Migration(20240605)]
    public class CreatePersonagemTable : Migration
    {
        public override void Up()
        {
            Create.Table("Personagem")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Vida").AsInt32().NotNullable()
                .WithColumn("Energia").AsInt32().NotNullable()
                .WithColumn("Velocidade").AsDouble().NotNullable()
                .WithColumn("Forca").AsInt32().NotNullable()
                .WithColumn("Inteligencia").AsInt32().NotNullable()
                .WithColumn("EVilao").AsBoolean().Nullable()
                .WithColumn("CriadoEm").AsDateTime().Nullable()
                .WithColumn("AtualizadoEm").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("Personagem");
        }
    }
}
