using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Service.Services;
using FluentValidation;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class FormularioEditarHabilidade : Form
    {
        private readonly int _idHabilidade;
        private Habilidade? _habilidadeExistente;
        private readonly HabilidadeServico _habilidadeServico;

        public FormularioEditarHabilidade(HabilidadeServico habilidadeServico, int idHabilidade)
        {
            InitializeComponent();
            _idHabilidade = idHabilidade;
            _habilidadeServico = habilidadeServico;
        }

        private void CarregarFormularioEditarHabilidade(object sender, EventArgs e)
        {
            _habilidadeExistente = _habilidadeServico.ObterPorId(_idHabilidade);
            if (_habilidadeExistente != null)
            {
                labelId.Text = $"Id: {_habilidadeExistente.Id}";
                txtboxNome.Text = _habilidadeExistente.Nome;
                txtboxDescricao.Text = _habilidadeExistente.Descricao;
                labelCriadoEm.Text = $"Criado em: {_habilidadeExistente.CriadoEm}";
                labelAtualizadoEm.Text = $"Atualizado em: {_habilidadeExistente.AtualizadoEm}";
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            const string tituloJanela = "Erro";

            try
            {
                var habilidadeAtualizada = new Habilidade
                {
                    Nome = txtboxNome.Text,
                    Descricao = txtboxDescricao.Text,
                    CriadoEm = _habilidadeExistente.CriadoEm,
                    AtualizadoEm = DateTime.Now
                };

                _habilidadeServico.Atualizar(_idHabilidade, habilidadeAtualizada);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ValidationException excecao)
            {
                MessageBox.Show(excecao.Message, tituloJanela, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AoClicarEmCancelarFechaFormularioEditarHabilidade(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
