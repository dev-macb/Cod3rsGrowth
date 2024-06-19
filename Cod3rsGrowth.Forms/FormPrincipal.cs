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

        private void AoClicarEmEditarAbreFormularioEditarPersonagem(object sender, EventArgs e)
        {

        }

        private void AoClicarEmEditarAbreFormularioEditarHabilidade(object sender, EventArgs e)
        {
            const int celulaId = 0;
            const string tituloJanela = "Aviso";

            try
            {
                string? conteudoCelula = tabelaHabilidades.Rows[tabelaHabilidades.CurrentCell.RowIndex].Cells[celulaId].Value.ToString();
                if (conteudoCelula != null)
                {
                    int idHabilidade = int.Parse(conteudoCelula);
                    var formularioEditarHabilidade = new FormularioEditarHabilidade(_habilidadeServico, idHabilidade);
                    formularioEditarHabilidade.ShowDialog();
                    DefinirFonteDeDadosDasTabelas();
                }
                else
                {
<<<<<<< Updated upstream
                    MessageBox.Show("A tabela habilidades estï¿½ vazia.", tituloJanela, MessageBoxButtons.OK, MessageBoxIcon.Information);
=======
                    MessageBox.Show("A tabela habilidades está vazia.", tituloJanela, MessageBoxButtons.OK, MessageBoxIcon.Information);
>>>>>>> Stashed changes
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nenhuma habilidade foi selecionada!", tituloJanela, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
<<<<<<< Updated upstream
=======



            
>>>>>>> Stashed changes
        }

        private void AoClicarEmRemoverExcluiPersonagem(object sender, EventArgs e)
        {
            const int celulaId = 0;
            const string tituloJanela = "Aviso";

            try
            {
                string? conteudoCelula = tabelaPersonagens.Rows[tabelaPersonagens.CurrentCell.RowIndex].Cells[celulaId].Value.ToString();
                if (conteudoCelula != null)
                {
                    int idHabilidade = int.Parse(conteudoCelula);

                    DialogResult msgConfirmacao = MessageBox.Show($"Deseja excluir o personagem {idHabilidade}?", tituloJanela, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (msgConfirmacao == DialogResult.Yes)
                    {
                        _personagemServico.Deletar(idHabilidade);
                        DefinirFonteDeDadosDasTabelas();
                    }
                }
                else
                {
                    MessageBox.Show("A tabela personagens estï¿½ vazia.", tituloJanela, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nenhum personagem foi selecionado!", tituloJanela, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AoClicarEmRemoverExcluiHabilidade(object sender, EventArgs e)
        {
            const int celulaId = 0;
            const string tituloJanela = "Aviso";

            try
            {
                string? conteudoCelula = tabelaHabilidades.Rows[tabelaHabilidades.CurrentCell.RowIndex].Cells[celulaId].Value.ToString();
                if (conteudoCelula != null)
                {
                    int idHabilidade = int.Parse(conteudoCelula);

                    DialogResult msgConfirmacao = MessageBox.Show($"Deseja excluir a habilidade {idHabilidade}?", tituloJanela, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (msgConfirmacao == DialogResult.Yes)
                    {
                        _habilidadeServico.Deletar(idHabilidade);
                        DefinirFonteDeDadosDasTabelas();
                    }
                }
                else
                {
                    MessageBox.Show("A tabela habilidades estï¿½ vazia.", tituloJanela, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Nenhuma habilidade foi selecionada!", tituloJanela, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
