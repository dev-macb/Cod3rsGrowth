namespace CodersGrowth.Domain
{
    public enum ECategorias 
    {
        Fraco,
        Medio,
        Bom,
        Excepcional,
        Extraordinario
    }

    public class Personagem
    {
        public int Id { get; }
        public string Nome { get; }
        public int Vida { get; set; }
        public int Energia { get; set; }
        public float Velocidade { get; set; }
        public ECategorias Forca { get; set; }
        public ECategorias Inteligencia { get; set; }
        public List<Habilidade> Habilidades { get; set; }
        public bool EhVilao { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }


        public Personagem(string nome, int vida, int energia, float velocidade, ECategorias forca, ECategorias inteligencia, List<Habilidade> habilidades, bool EhVivao)
        {
            Nome = nome;
            Vida = vida;
            Energia = energia;
            Velocidade = velocidade;
            Forca = forca;
            Inteligencia = inteligencia;
            Habilidades = habilidades;
            EhVilao = ehVilao;
            CriadoEm = DateTime.Now;
            AtualizadoEm = DateTime.Now;
        }
    }
}