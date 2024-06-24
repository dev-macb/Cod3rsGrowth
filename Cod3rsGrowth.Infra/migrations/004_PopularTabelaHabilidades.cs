using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migrations
{
    [Migration(004)]
    public class PopularTabelaHabilidades : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                INSERT INTO habilidades (nome, descricao) 
                VALUES ('Ataque � Dist�ncia', 'Capacidade de atacar oponentes � dist�ncia'),
                       ('Defesa', 'Capacidade de bloquear ou mitigar ataques'),
                       ('Velocidade de Movimento', 'Rapidez com que o personagem se move pelo cen�rio'),
                       ('Velocidade de Ataque', 'Rapidez com que o personagem executa ataques'),
                       ('Combos', 'Capacidade de executar sequ�ncias de ataques eficazes'),
                       ('Ataque Especial', 'Pot�ncia e efic�cia dos ataques especiais'),
                       ('Recupera��o', 'Capacidade de se recuperar rapidamente ap�s sofrer um golpe ou cair'),
                       ('Agarre', 'Efic�cia em t�cnicas de agarrar e lan�ar o oponente'),
                       ('Esquiva', 'Capacidade de evitar ataques advers�rios'),
                       ('Super Ataque', 'Pot�ncia dos ataques mais poderosos dispon�veis para o personagem'),
                       ('Controle de Zona', 'Capacidade de controlar e dominar �reas espec�ficas do cen�rio'),
                       ('Resist�ncia', 'Capacidade de resistir a m�ltiplos ataques antes de ser derrotado'),
                       ('T�cnica A�rea', 'Efic�cia em ataques e movimentos realizados no ar');"
            );
        }

        public override void Down()
        {
            Execute.Sql(@"
                DELETE FROM habilidades 
                WHERE nome IN (
                    'Ataque � Dist�ncia', 
                    'Defesa', 
                    'Velocidade de Movimento', 
                    'Velocidade de Ataque', 
                    'Combos', 
                    'Ataque Especial', 
                    'Recupera��o', 
                    'Agarre', 
                    'Esquiva', 
                    'Super Ataque', 
                    'Controle de Zona',
                    'Resist�ncia',
                    'T�cnica A�rea');"
            );
        }
    }
}