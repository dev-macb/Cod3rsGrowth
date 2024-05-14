namespace CodersGrowth.Domain
{
    public class Habilidade
    {
        public int Id                { get; }
        public string Nome           { get; }
        public string Descricao      { get; set; }
        public DateTime CriadoEm     { get; set; }
        public DateTime AtualizadoEm { get; set; }

        public Habilidade(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
            CriadoEm = DateTime.Now;
            AtualizadoEm = DateTime.Now;
        }
    }
}