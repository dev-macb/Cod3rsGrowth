using CodersGrowth.Domain.Enum;

namespace CodersGrowth.Domain.Entities
{
    public class Personagem
    {
        public int Id { get; }
        public string Nome { get; }
        public int Vida { get; set; }
        public int Energia { get; set; }
        public double Velocidade { get; set; }
        public CategoriasEnum Forca { get; set; }
        public CategoriasEnum Inteligencia { get; set; }
        public List<Habilidade>? Habilidades { get; set; }
        public bool? EVilao { get; set; }
        public DateTime? CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }

        public Personagem(string nome, int vida, int energia, double velocidade, CategoriasEnum forca, CategoriasEnum inteligencia)
        {
            Nome = nome;
            Vida = vida;
            Energia = energia;
            Velocidade = velocidade;
            Forca = forca;
            Inteligencia = inteligencia;
        }

        public int Atacar()
        {
            return (int)Forca * Energia;
        }

        public int Defender()
        {
            return (int)Inteligencia * Energia;
        }

        public void Descansar()
        {
            Energia += 10;
        }
    }
}