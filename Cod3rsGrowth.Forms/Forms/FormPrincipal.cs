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

        private const string TITULO_AVISO = "Aviso";
        private const string MSG_TABELA_PERSONAGENS_VAZIA = "A tabela personagens está vazia.";
        private const string MSG_PESONAGEM_NAO_SELECIONADO = "Nenhum personagem foi selecionado!";
        private const string MSG_TABELA_HABILIDADES_VAZIA = "A tabela habilidades está vazia.";
        private const string MSG_HABILIDADE_NAO_SELECIONADA = "Nenhuma habilidade foi selecionada!";

        public FormularioPrincipal(PersonagemServico personagemServico, HabilidadeServico habilidadeServico)
        {
            InitializeComponent();

            _personagemFiltro = new Filtro();
            _habilidadeFiltro = new Filtro();

            _personagemServico = personagemServico;
            _habilidadeServico = habilidadeServico;
        }

        private async void CarregarFormularioPrincipal(object sender, EventArgs e)
        {
            await DefinirFonteDeDadosDasTabelas();
        }

        private async Task DefinirFonteDeDadosDasTabelas()
        {
            tabelaPersonagens.DataSource = await _personagemServico.ObterTodos(_personagemFiltro);
            lblTotalPersonagens.Text = $"Total: {tabelaPersonagens.Rows.Count}";

            tabelaHabilidades.DataSource = await _habilidadeServico.ObterTodos(_habilidadeFiltro);
            lblTotalHabilidades.Text = $"Total: {tabelaHabilidades.Rows.Count}";
        }

        // Adicionar
        private async void AoClicarEmAdicionarPersonagem(object sender, EventArgs e)
        {
            var formularioCadastroPersonagem = new FormularioPersonagem(null, _personagemServico, _habilidadeServico);
            if (formularioCadastroPersonagem.ShowDialog() == DialogResult.OK)
            {
                await DefinirFonteDeDadosDasTabelas();
            }
        }

        private async void AoClicarEmAdicionarHabilidade(object sender, EventArgs e)
        {
            var formularioCadastroHabilidade = new FormularioHabilidade(null, _habilidadeServico);
            if (formularioCadastroHabilidade.ShowDialog() == DialogResult.OK)
            {
                await DefinirFonteDeDadosDasTabelas();
            }
        }

        // Editar
        private async void AoClicarEmEditarAbreFormularioPersonagem(object sender, EventArgs e)
        {
            const int celulaId = 0;

            try
            {
                string? conteudoCelula = tabelaPersonagens.Rows[tabelaPersonagens.CurrentCell.RowIndex].Cells[celulaId].Value.ToString();
                if (conteudoCelula != null)
                {
                    int idPersonagem = int.Parse(conteudoCelula);
                    var formularioEditarPersonagem = new FormularioPersonagem(idPersonagem, _personagemServico, _habilidadeServico);
                    formularioEditarPersonagem.ShowDialog();
                    await DefinirFonteDeDadosDasTabelas();
                }
                else
                {
                    MessageBox.Show(MSG_TABELA_PERSONAGENS_VAZIA, TITULO_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(MSG_PESONAGEM_NAO_SELECIONADO, TITULO_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void AoClicarEmEditarAbreFormularioHabilidade(object sender, EventArgs e)
        {
            const int celulaId = 0;

            try
            {
                string? conteudoCelula = tabelaHabilidades.Rows[tabelaHabilidades.CurrentCell.RowIndex].Cells[celulaId].Value.ToString();
                if (conteudoCelula != null)
                {
                    int idHabilidade = int.Parse(conteudoCelula);
                    var formularioEditarHabilidade = new FormularioHabilidade(idHabilidade, _habilidadeServico);
                    formularioEditarHabilidade.ShowDialog();
                    await DefinirFonteDeDadosDasTabelas();
                }
                else
                {
                    MessageBox.Show(MSG_TABELA_HABILIDADES_VAZIA, TITULO_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(MSG_HABILIDADE_NAO_SELECIONADA, TITULO_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Remover
        private async void AoClicarEmRemoverExcluiPersonagem(object sender, EventArgs e)
        {
            const int celulaId = 0;

            try
            {
                if (tabelaPersonagens.CurrentCell == null) throw new Exception("Nenhum personagem selecionado.");

                string? conteudoCelula = tabelaPersonagens.Rows[tabelaPersonagens.CurrentCell.RowIndex].Cells[celulaId].Value.ToString();
                if (conteudoCelula != null)
                {
                    int idPersonagem = int.Parse(conteudoCelula);
                    string msgConfirmarExclusaoHabilidade = $"Deseja excluir o personagem {idPersonagem}?";

                    DialogResult msgConfirmacao = MessageBox.Show(msgConfirmarExclusaoHabilidade, TITULO_AVISO, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (msgConfirmacao == DialogResult.Yes)
                    {
                        await _personagemServico.Deletar(idPersonagem);
                        await DefinirFonteDeDadosDasTabelas();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(MSG_PESONAGEM_NAO_SELECIONADO, TITULO_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void AoClicarEmRemoverExcluiHabilidade(object sender, EventArgs e)
        {
            const int celulaId = 0;

            try
            {
                if (tabelaPersonagens.CurrentCell == null) throw new Exception("Nenhuma habilidade selecionada.");

                string? conteudoCelula = tabelaHabilidades.Rows[tabelaHabilidades.CurrentCell.RowIndex].Cells[celulaId].Value.ToString();
                if (conteudoCelula != null)
                {
                    int idHabilidade = int.Parse(conteudoCelula);
                    string msgConfirmarExclusaoHabilidade = $"Deseja excluir a habilidade {idHabilidade}?";

                    DialogResult msgConfirmacao = MessageBox.Show(msgConfirmarExclusaoHabilidade, TITULO_AVISO, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (msgConfirmacao == DialogResult.Yes)
                    {
                        await _habilidadeServico.Deletar(idHabilidade);
                        await DefinirFonteDeDadosDasTabelas();
                    }
                }
            }
            catch
            {
                MessageBox.Show(MSG_HABILIDADE_NAO_SELECIONADA, TITULO_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Filtros
        private async void AoDigitarEnterEmFiltroNomeAtualizaFiltroPersonagem(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _personagemFiltro.Nome = txtboxFiltroPersonagemNome.Text;
                await DefinirFonteDeDadosDasTabelas();
            }
        }

        private async void AoDigitarEnterEmFiltroNomeAtualizaFiltroHabilidade(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _habilidadeFiltro.Nome = txtboxFiltroHabilidadeNome.Text;
                await DefinirFonteDeDadosDasTabelas();
            }
        }

        private async void AoClicarEmFiltrarPersonagemAbreFormularioFiltros(object sender, EventArgs e)
        {
            var formularioFiltros = new FormularioFiltros(_personagemFiltro);
            if (formularioFiltros.ShowDialog() == DialogResult.OK)
            {
                _personagemFiltro = formularioFiltros.ObterFiltros();
                await DefinirFonteDeDadosDasTabelas();
            }
        }

        private async void AoClicarEmFiltrarHabilidadeAbreFormularioFiltros(object sender, EventArgs e)
        {
            var formularioFiltros = new FormularioFiltros(_habilidadeFiltro);
            if (formularioFiltros.ShowDialog() == DialogResult.OK)
            {
                _habilidadeFiltro = formularioFiltros.ObterFiltros();
                await DefinirFonteDeDadosDasTabelas();
            }
        }

        private async void AoClicarEmBuscaPersonagemAtualizaFiltroNome(object sender, EventArgs e)
        {
            _personagemFiltro.Nome = txtboxFiltroPersonagemNome.Text;
            await DefinirFonteDeDadosDasTabelas();
        }

        private async void AoClicarEmBuscarHabilidadeAtualizaFiltroNome(object sender, EventArgs e)
        {
            _habilidadeFiltro.Nome = txtboxFiltroHabilidadeNome.Text;
            await DefinirFonteDeDadosDasTabelas();
        }
    }
}
