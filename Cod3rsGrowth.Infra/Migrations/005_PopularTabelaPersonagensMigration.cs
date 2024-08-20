using FluentMigrator;

namespace Cod3rsGrowth.Infra.Migrations
{
    [Migration(005)]
    public class PopularTabelaPersonagensMigration : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                INSERT INTO personagens (nome, vida, energia, velocidade, forca, inteligencia, e_vilao) 
				VALUES ('Ryu', 80, 40, 1.5, 3, 2, 0),
					   ('Ken', 80, 40, 1.8, 2, 2, 0),
					   ('Chun-Li', 75, 35, 2.0, 2, 3, 0),
					   ('Blanka', 90, 30, 1.2, 4, 1, 0),
					   ('E. Honda', 95, 30, 0.8, 4, 1, 0),
					   ('Guile', 85, 35, 1.4, 2, 3, 0),
					   ('Zangief', 100, 30, 0.8, 4, 1, 0),
					   ('Dhalsim', 70, 35, 1.2, 1, 4, 0),
					   ('Balrog', 95, 30, 1.2, 4, 1, 1),
					   ('Vega', 80, 35, 2.0, 2, 2, 1),
					   ('Sagat', 95, 40, 1.4, 4, 2, 1),
					   ('M. Bison', 85, 50, 1.5, 3, 4, 1),
					   ('Cammy', 75, 35, 2.0, 2, 2, 0),
					   ('Akuma', 90, 45, 1.8, 4, 4, 1),
					   ('Sakura', 75, 35, 1.8, 2, 2, 0),
					   ('Alex', 90, 35, 1.2, 4, 2, 0),
					   ('Ibuki', 75, 35, 2.0, 2, 3, 0),
					   ('Dudley', 85, 35, 1.4, 3, 3, 0),
					   ('Makoto', 80, 35, 1.4, 4, 2, 0),
					   ('C. Viper', 75, 35, 1.8, 3, 4, 1),
					   ('Juri', 80, 35, 2.0, 3, 4, 1),
					   ('Laura', 80, 35, 1.8, 3, 2, 0),
					   ('Rashid', 80, 35, 2.0, 2, 2, 0),
					   ('Necalli', 95, 45, 1.8, 4, 1, 1),
					   ('F.A.N.G', 80, 45, 1.4, 1, 4, 1),
					   ('Kolin', 80, 35, 1.8, 2, 4, 1),
					   ('Ed', 80, 35, 1.4, 2, 2, 1),
					   ('Menat', 75, 35, 1.8, 2, 4, 0),
					   ('Zeku', 80, 35, 2.0, 2, 4, 0),
					   ('Falke', 80, 35, 1.4, 2, 4, 0),
					   ('G', 95, 45, 1.4, 4, 4, 1),
					   ('Kage', 80, 35, 2.0, 3, 2, 1),
					   ('Lucia', 80, 35, 1.8, 2, 2, 0);"
            );
        }

        public override void Down()
        {
            Execute.Sql(@"
                DELETE FROM personagens 
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
				);"
            );
        }
    }
}