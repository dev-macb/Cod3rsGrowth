using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Forms.Forms;
using Cod3rsGrowth.Service.Services;

namespace Cod3rsGrowth.Forms
{
    public partial class FormularioPrincipal : Form
    {
        private Filtro _personagemFiltro;
        private Filtro _habilidadeFiltro;
        private readonly PersonagemServico _personagemServico;
        private readonly HabilidadeServico _habilidadeServico;

        public FormularioPrincipal(PersonagemServico personagemServico, HabilidadeServico habilidadeServico)
        {
            InitializeComponent();

            _personagemFiltro = new Filtro();
            _personagemServico = personagemServico;

            _habilidadeFiltro = new Filtro();
            _habilidadeServico = habilidadeServico;
        }

        private void CarregarFormularioPrincipal(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            tabelaPersonagens.DataSource = _personagemServico.ObterTodos(_personagemFiltro);
            lblTotalPersonagens.Text = $"Total: {tabelaPersonagens.Rows.Count}";

            tabelaHabilidades.DataSource = _habilidadeServico.ObterTodos(_habilidadeFiltro);
            lblTotalHabilidades.Text = $"Total: {tabelaHabilidades.Rows.Count}";
        }

        private void AoClicarNoBotaoDeFiltrarPersonagem(object sender, EventArgs e)
        {
            var formularioFiltros = new FormFiltros(_personagemFiltro);
            if (formularioFiltros.ShowDialog() == DialogResult.OK)
            {
                _personagemFiltro = formularioFiltros.ObterFiltros();
                AplicarFiltros();
            }
        }

        private void txtboxFiltroPersonagemNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _personagemFiltro.Nome = txtboxFiltroPersonagemNome.Text;
                AplicarFiltros();
            }
        }

        private void btnBuscarPersonagem_Click(object sender, EventArgs e)
        {
            _personagemFiltro.Nome = txtboxFiltroPersonagemNome.Text;
            AplicarFiltros();
        }

        private void btnBuscarHabilidade_Click(object sender, EventArgs e)
        {
            _habilidadeFiltro.Nome = txtboxFiltroHabilidadeNome.Text;
            AplicarFiltros();
        }

        private void btnFiltrarHabilidade_Click(object sender, EventArgs e)
        {
            var formularioFiltros = new FormFiltros(_habilidadeFiltro);
            if (formularioFiltros.ShowDialog() == DialogResult.OK)
            {
                _habilidadeFiltro = formularioFiltros.ObterFiltros();
                AplicarFiltros();
            }
        }

        private void txtboxFiltroHabilidadeNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _habilidadeFiltro.Nome = txtboxFiltroHabilidadeNome.Text;
                AplicarFiltros();
            }
        }
    }
}
