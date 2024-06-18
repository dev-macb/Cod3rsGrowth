using Cod3rsGrowth.Forms.Forms;
using Cod3rsGrowth.Domain.Entities;
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
            DefinirFonteDeDadosDasTabelas();
        }

        private void DefinirFonteDeDadosDasTabelas()
        {
            tabelaPersonagens.DataSource = _personagemServico.ObterTodos(_personagemFiltro);
            lblTotalPersonagens.Text = $"Total: {tabelaPersonagens.Rows.Count}";

            tabelaHabilidades.DataSource = _habilidadeServico.ObterTodos(_habilidadeFiltro);
            lblTotalHabilidades.Text = $"Total: {tabelaHabilidades.Rows.Count}";
        }

        private void AoClicarEmMenuSuperiorCadastroPersonagemAbreFormularioCadastroPersonagem(object sender, EventArgs e)
        {
            var formularioCadastroPersonagem = new FormularioCadastroPersonagem(_personagemServico);
            formularioCadastroPersonagem.ShowDialog();
            DefinirFonteDeDadosDasTabelas();
        }

        private void AoClicarEmMenuSuperiorCadastroHabilidadeAbreFormularioCadastroHabilidade(object sender, EventArgs e)
        {
            var formularioCadastroHabilidade = new FormularioCadastroHabilidade(_habilidadeServico);
            formularioCadastroHabilidade.ShowDialog();
            DefinirFonteDeDadosDasTabelas();
        }

        private void AoClicarEmFiltrarPersonagemAbreFormularioFiltros(object sender, EventArgs e)
        {
            var formularioFiltros = new FormularioFiltros(_personagemFiltro);
            if (formularioFiltros.ShowDialog() == DialogResult.OK)
            {
                _personagemFiltro = formularioFiltros.ObterFiltros();
                DefinirFonteDeDadosDasTabelas();
            }
        }

        private void AoClicarEmFiltrarHabilidadeAbreFormularioFiltros(object sender, EventArgs e)
        {
            var formularioFiltros = new FormularioFiltros(_habilidadeFiltro);
            if (formularioFiltros.ShowDialog() == DialogResult.OK)
            {
                _habilidadeFiltro = formularioFiltros.ObterFiltros();
                DefinirFonteDeDadosDasTabelas();
            }
        }

        private void AoDigitarEnterEmFiltroNomeAtualizaFiltroPersonagem(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _personagemFiltro.Nome = txtboxFiltroPersonagemNome.Text;
                DefinirFonteDeDadosDasTabelas();
            }
        }

        private void AoDigitarEnterEmFiltroNomeAtualizaFiltroHabilidade(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _habilidadeFiltro.Nome = txtboxFiltroHabilidadeNome.Text;
                DefinirFonteDeDadosDasTabelas();
            }
        }

        private void AoClicarEmBuscaPersonagemAtualizaFiltroNome(object sender, EventArgs e)
        {
            _personagemFiltro.Nome = txtboxFiltroPersonagemNome.Text;
            DefinirFonteDeDadosDasTabelas();
        }

        private void AoClicarEmBuscarHabilidadeAtualizaFiltroNome(object sender, EventArgs e)
        {
            _habilidadeFiltro.Nome = txtboxFiltroHabilidadeNome.Text;
            DefinirFonteDeDadosDasTabelas();
        }
    }
}
