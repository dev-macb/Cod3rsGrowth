using FluentMigrator;

namespace Cod3rsGrowth.Migrations
{
    [Migration(20240604)]
    public class CreateHabilidadeTable : Migration
    {
        public override void Up()
        {
            Create.Table("Habilidade")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Descricao").AsString().Nullable()
                .WithColumn("CriadoEm").AsDateTime().Nullable()
                .WithColumn("AtualizadoEm").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("Habilidade");
        }
    }
}
