using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migrations
{
    [Migration(006)]
    public class PopularTabelaPersonagensHabilidades : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                INSERT INTO personagens_habilidades (id_personagem, id_habilidade) 
                VALUES
                    -- Ryu
                    ((SELECT id FROM personagens WHERE nome = 'Ryu'), 1),
                    ((SELECT id FROM personagens WHERE nome = 'Ryu'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Ryu'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Ryu'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'Ryu'), 7),

                    -- Ken
                    ((SELECT id FROM personagens WHERE nome = 'Ken'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Ken'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Ken'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'Ken'), 7),
                    ((SELECT id FROM personagens WHERE nome = 'Ken'), 13),

                    -- Chun-Li
                    ((SELECT id FROM personagens WHERE nome = 'Chun-Li'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Chun-Li'), 3),
                    ((SELECT id FROM personagens WHERE nome = 'Chun-Li'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Chun-Li'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Chun-Li'), 9),

                    -- Blanka
                    ((SELECT id FROM personagens WHERE nome = 'Blanka'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Blanka'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Blanka'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Blanka'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'Blanka'), 7),

                    -- E. Honda
                    ((SELECT id FROM personagens WHERE nome = 'E. Honda'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'E. Honda'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'E. Honda'), 8),
                    ((SELECT id FROM personagens WHERE nome = 'E. Honda'), 10),
                    ((SELECT id FROM personagens WHERE nome = 'E. Honda'), 11),

                    -- Guile
                    ((SELECT id FROM personagens WHERE nome = 'Guile'), 1),
                    ((SELECT id FROM personagens WHERE nome = 'Guile'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Guile'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Guile'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'Guile'), 11),

                    -- Zangief
                    ((SELECT id FROM personagens WHERE nome = 'Zangief'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Zangief'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Zangief'), 8),
                    ((SELECT id FROM personagens WHERE nome = 'Zangief'), 10),
                    ((SELECT id FROM personagens WHERE nome = 'Zangief'), 12),

                    -- Dhalsim
                    ((SELECT id FROM personagens WHERE nome = 'Dhalsim'), 1),
                    ((SELECT id FROM personagens WHERE nome = 'Dhalsim'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'Dhalsim'), 7),
                    ((SELECT id FROM personagens WHERE nome = 'Dhalsim'), 9),
                    ((SELECT id FROM personagens WHERE nome = 'Dhalsim'), 11),

                    -- Balrog
                    ((SELECT id FROM personagens WHERE nome = 'Balrog'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Balrog'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Balrog'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Balrog'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'Balrog'), 8),

                    -- Vega
                    ((SELECT id FROM personagens WHERE nome = 'Vega'), 3),
                    ((SELECT id FROM personagens WHERE nome = 'Vega'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Vega'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Vega'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'Vega'), 9),

                    -- Sagat
                    ((SELECT id FROM personagens WHERE nome = 'Sagat'), 1),
                    ((SELECT id FROM personagens WHERE nome = 'Sagat'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Sagat'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Sagat'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'Sagat'), 11),

                    -- M. Bison
                    ((SELECT id FROM personagens WHERE nome = 'M. Bison'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'M. Bison'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'M. Bison'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'M. Bison'), 10),
                    ((SELECT id FROM personagens WHERE nome = 'M. Bison'), 12),

                    -- Cammy
                    ((SELECT id FROM personagens WHERE nome = 'Cammy'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Cammy'), 3),
                    ((SELECT id FROM personagens WHERE nome = 'Cammy'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Cammy'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Cammy'), 13),

                    -- Akuma
                    ((SELECT id FROM personagens WHERE nome = 'Akuma'), 1),
                    ((SELECT id FROM personagens WHERE nome = 'Akuma'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Akuma'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Akuma'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'Akuma'), 10),

                    -- Sakura
                    ((SELECT id FROM personagens WHERE nome = 'Sakura'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Sakura'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Sakura'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Sakura'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'Sakura'), 13),

                    -- Alex
                    ((SELECT id FROM personagens WHERE nome = 'Alex'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Alex'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Alex'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Alex'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'Alex'), 8),

                    -- Ibuki
                    ((SELECT id FROM personagens WHERE nome = 'Ibuki'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Ibuki'), 3),
                    ((SELECT id FROM personagens WHERE nome = 'Ibuki'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Ibuki'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Ibuki'), 9),

                    -- Dudley
                    ((SELECT id FROM personagens WHERE nome = 'Dudley'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Dudley'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Dudley'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Dudley'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'Dudley'), 8),

                    -- Makoto
                    ((SELECT id FROM personagens WHERE nome = 'Makoto'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Makoto'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Makoto'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Makoto'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'Makoto'), 10),

                    -- C. Viper
                    ((SELECT id FROM personagens WHERE nome = 'C. Viper'), 1),
                    ((SELECT id FROM personagens WHERE nome = 'C. Viper'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'C. Viper'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'C. Viper'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'C. Viper'), 9),

                    -- Juri
                    ((SELECT id FROM personagens WHERE nome = 'Juri'), 1),
                    ((SELECT id FROM personagens WHERE nome = 'Juri'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Juri'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Juri'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'Juri'), 9),

                    -- Laura
                    ((SELECT id FROM personagens WHERE nome = 'Laura'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Laura'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Laura'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Laura'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'Laura'), 8),

                    -- Rashid
                    ((SELECT id FROM personagens WHERE nome = 'Rashid'), 1),
                    ((SELECT id FROM personagens WHERE nome = 'Rashid'), 3),
                    ((SELECT id FROM personagens WHERE nome = 'Rashid'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Rashid'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Rashid'), 9),

                    -- Necalli
                    ((SELECT id FROM personagens WHERE nome = 'Necalli'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Necalli'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Necalli'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Necalli'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'Necalli'), 12),

                    -- F.A.N.G
                    ((SELECT id FROM personagens WHERE nome = 'F.A.N.G'), 1),
                    ((SELECT id FROM personagens WHERE nome = 'F.A.N.G'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'F.A.N.G'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'F.A.N.G'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'F.A.N.G'), 11),

                    -- Kolin
                    ((SELECT id FROM personagens WHERE nome = 'Kolin'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Kolin'), 3),
                    ((SELECT id FROM personagens WHERE nome = 'Kolin'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Kolin'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Kolin'), 9),

                    -- Ed
                    ((SELECT id FROM personagens WHERE nome = 'Ed'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Ed'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Ed'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Ed'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'Ed'), 9),

                    -- Menat
                    ((SELECT id FROM personagens WHERE nome = 'Menat'), 1),
                    ((SELECT id FROM personagens WHERE nome = 'Menat'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Menat'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Menat'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'Menat'), 11),

                    -- Zeku
                    ((SELECT id FROM personagens WHERE nome = 'Zeku'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Zeku'), 3),
                    ((SELECT id FROM personagens WHERE nome = 'Zeku'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Zeku'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Zeku'), 9),

                    -- Falke
                    ((SELECT id FROM personagens WHERE nome = 'Falke'), 1),
                    ((SELECT id FROM personagens WHERE nome = 'Falke'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Falke'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Falke'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'Falke'), 11),

                    -- G
                    ((SELECT id FROM personagens WHERE nome = 'G'), 1),
                    ((SELECT id FROM personagens WHERE nome = 'G'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'G'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'G'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'G'), 10),

                    -- Kage
                    ((SELECT id FROM personagens WHERE nome = 'Kage'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Kage'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Kage'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Kage'), 6),
                    ((SELECT id FROM personagens WHERE nome = 'Kage'), 9),

                    -- Lucia
                    ((SELECT id FROM personagens WHERE nome = 'Lucia'), 2),
                    ((SELECT id FROM personagens WHERE nome = 'Lucia'), 3),
                    ((SELECT id FROM personagens WHERE nome = 'Lucia'), 4),
                    ((SELECT id FROM personagens WHERE nome = 'Lucia'), 5),
                    ((SELECT id FROM personagens WHERE nome = 'Lucia'), 8);"
            );
        }

        public override void Down()
        {
            Execute.Sql(@"
                DELETE FROM personagens_habilidades 
                WHERE id_personagem IN (
                    SELECT id FROM personagens 
                    WHERE nome IN (
                        'Ryu', 
                        'Ken', 
                        'Chun-Li', 
                        'Blanka', 
                        'E. Honda', 
                        'Guile', 
                        'Zangief', 
                        'Dhalsim', 
                        'Balrog', 
                        'Vega', 
                        'Sagat', 
                        'M. Bison', 
                        'Cammy', 
                        'Akuma', 
                        'Sakura', 
                        'Alex', 
                        'Ibuki', 
                        'Dudley', 
                        'Makoto', 
                        'C. Viper', 
                        'Juri', 
                        'Laura', 
                        'Rashid', 
                        'Necalli', 
                        'F.A.N.G', 
                        'Kolin', 
                        'Ed', 
                        'Menat', 
                        'Zeku', 
                        'Falke', 
                        'G', 
                        'Kage',
                        'Lucia'
                    )
                );"
            );
        }
    }
}
