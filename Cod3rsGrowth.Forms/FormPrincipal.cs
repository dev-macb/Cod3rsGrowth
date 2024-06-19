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
        private readonly PersonagensHabilidadesServico _personagensHabilidadesServico;

        public FormularioPrincipal(PersonagemServico personagemServico, HabilidadeServico habilidadeServico, PersonagensHabilidadesServico personagensHabilidadesServico)
        {
            InitializeComponent();

            _personagemFiltro = new Filtro();
            _personagemServico = personagemServico;

            _habilidadeFiltro = new Filtro();
            _habilidadeServico = habilidadeServico;
            _personagensHabilidadesServico = personagensHabilidadesServico;
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
            var formularioCadastroPersonagem = new FormularioCadastroPersonagem(_personagemServico, _habilidadeServico, _personagensHabilidadesServico);
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

        private void AoClicarEmRemoverExcluiPersonagem(object sender, EventArgs e)
        {
            const int celulaId = 0;
            const string tituloJanela = "Aviso";
            const string msgTabelaPersonagemVazia = "A tabela personagens est� vazia.";
            const string msgPersonagemNaoSelecionada = "Nenhum personagem foi selecionado!";

            try
            {
                string? conteudoCelula = tabelaPersonagens.Rows[tabelaPersonagens.CurrentCell.RowIndex].Cells[celulaId].Value.ToString();
                if (conteudoCelula != null)
                {
                    int idPersonagem = int.Parse(conteudoCelula);
                    string msgConfirmarExclusaoHabilidade = $"Deseja excluir o personagem {idPersonagem}?";

                    DialogResult msgConfirmacao = MessageBox.Show(msgConfirmarExclusaoHabilidade, tituloJanela, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (msgConfirmacao == DialogResult.Yes)
                    {
                        _personagemServico.Deletar(idPersonagem);
                        DefinirFonteDeDadosDasTabelas();
                    }
                }
                else
                {
                    MessageBox.Show(msgTabelaPersonagemVazia, tituloJanela, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(msgPersonagemNaoSelecionada, tituloJanela, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AoClicarEmRemoverExcluiHabilidade(object sender, EventArgs e)
        {
            const int celulaId = 0;
            const string tituloJanela = "Aviso";
            const string msgTabelaHabilidadesVazia = "A tabela habilidades est� vazia.";
            const string msgHabilidadeNaoSelecionada = "Nenhuma habilidade foi selecionada!";

            try
            {
                string? conteudoCelula = tabelaHabilidades.Rows[tabelaHabilidades.CurrentCell.RowIndex].Cells[celulaId].Value.ToString();
                if (conteudoCelula != null)
                {
                    int idHabilidade = int.Parse(conteudoCelula);
                    string msgConfirmarExclusaoHabilidade = $"Deseja excluir a habilidade {idHabilidade}?";

                    DialogResult msgConfirmacao = MessageBox.Show(msgConfirmarExclusaoHabilidade, tituloJanela, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (msgConfirmacao == DialogResult.Yes)
                    {
                        _habilidadeServico.Deletar(idHabilidade);
                        DefinirFonteDeDadosDasTabelas();
                    }
                }
                else
                {
                    MessageBox.Show(msgTabelaHabilidadesVazia, tituloJanela, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show(msgHabilidadeNaoSelecionada, tituloJanela, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
