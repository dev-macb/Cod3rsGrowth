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
                VALUES ('Ataque à Distância', 'Capacidade de atacar oponentes à distância'),
                       ('Defesa', 'Capacidade de bloquear ou mitigar ataques'),
                       ('Velocidade de Movimento', 'Rapidez com que o personagem se move pelo cenário'),
                       ('Velocidade de Ataque', 'Rapidez com que o personagem executa ataques'),
                       ('Combos', 'Capacidade de executar sequências de ataques eficazes'),
                       ('Ataque Especial', 'Potência e eficácia dos ataques especiais'),
                       ('Recuperação', 'Capacidade de se recuperar rapidamente após sofrer um golpe ou cair'),
                       ('Agarre', 'Eficácia em técnicas de agarrar e lançar o oponente'),
                       ('Esquiva', 'Capacidade de evitar ataques adversários'),
                       ('Super Ataque', 'Potência dos ataques mais poderosos disponíveis para o personagem'),
                       ('Controle de Zona', 'Capacidade de controlar e dominar áreas específicas do cenário'),
                       ('Resistência', 'Capacidade de resistir a múltiplos ataques antes de ser derrotado'),
                       ('Técnica Aérea', 'Eficácia em ataques e movimentos realizados no ar');"
            );
        }

        public override void Down()
        {
            Execute.Sql(@"
                DELETE FROM habilidades 
                WHERE nome IN (
                    'Ataque à Distância', 
                    'Defesa', 
                    'Velocidade de Movimento', 
                    'Velocidade de Ataque', 
                    'Combos', 
                    'Ataque Especial', 
                    'Recuperação', 
                    'Agarre', 
                    'Esquiva', 
                    'Super Ataque', 
                    'Controle de Zona',
                    'Resistência',
                    'Técnica Aérea');"
            );
        }
    }
}