using Cod3rsGrowth.Domain.Enums;

namespace Cod3rsGrowth.Domain.Entities
{
    public class Personagem
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public int Vida { get; set; }
        public int Energia { get; set; }
        public double Velocidade { get; set; }
        public CategoriasEnum Forca { get; set; }
        public CategoriasEnum Inteligencia { get; set; }
        public List<Habilidade>? Habilidades { get; set; }
        public bool? EVilao { get; set; }
        public DateTime? CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }

        public Personagem(int? id, string nome, int vida, int energia, double velocidade, CategoriasEnum forca, CategoriasEnum inteligencia)
        {
            Id = id;
            Nome = nome;
            Vida = vida;
            Energia = energia;
            Velocidade = velocidade;
            Forca = forca;
            Inteligencia = inteligencia;
            CriadoEm = DateTime.Now;
        }
    }
}