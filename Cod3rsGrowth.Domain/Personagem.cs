namespace CodersGrowth.Domain
{
    public class Personagem
    {
        public int Id { get; }
        public string Nome { get; }
        public int Vida { get; set; }
        public int Energia { get; set; }
        public float Velocidade { get; set; }
        public CategoriasEnum Forca { get; set; }
        public CategoriasEnum Inteligencia { get; set; }
        public List<Habilidade> Habilidades { get; set; }
        public bool EVilao { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }


        public Personagem(string nome, int vida, int energia, float velocidade, CategoriasEnum forca, CategoriasEnum inteligencia, List<Habilidade> habilidades, bool EVilao)
        {
            Nome = nome;
            Vida = vida;
            Energia = energia;
            Velocidade = velocidade;
            Forca = forca;
            Inteligencia = inteligencia;
            Habilidades = habilidades;
            EVilao = ehVilao;
            CriadoEm = DateTime.Now;
            AtualizadoEm = DateTime.Now;
        }
    }
}