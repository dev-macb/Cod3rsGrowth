namespace CodersGrowth.Domain.Entities
{
    public class Habilidade
    {
        public int? Id { get; }
        public string Nome { get; }
        public string? Descricao { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }

        public Habilidade(int? id, string nome, string? descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            CriadoEm = DateTime.Now;
            AtualizadoEm = DateTime.Now;
        }
    }
}