using FluentMigrator;

[Migration(000)]
public class ResetarBancoDeDados : Migration
{
    public override void Up() { }

    public override void Down()
    {
        Delete.Table("personagens_habilidades");
        Delete.Table("personagens");
        Delete.Table("habilidades");
        Delete.Table("VersionInfo");
    }
}