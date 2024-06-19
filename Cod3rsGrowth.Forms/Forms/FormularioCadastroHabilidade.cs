using FluentValidation;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Service.Services;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class FormularioCadastroHabilidade : Form
    {
        private readonly HabilidadeServico _habilidadeServico;

        public FormularioCadastroHabilidade(HabilidadeServico habilidadeServico)
        {
            InitializeComponent();
            _habilidadeServico = habilidadeServico;
        }

        private void btnCancelarHabilidadeCadastro_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSalvarHabilidadeCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                var novaHabilidade = new Habilidade
                {
                    Nome = txtboxNomeHabilidadeCadastro.Text,
                    Descricao = txtboxDescricaoHabilidadeCadastro.Text,
                    CriadoEm = DateTime.Now,
                    AtualizadoEm = DateTime.Now
                };
                
                _habilidadeServico.Adicionar(novaHabilidade);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ValidationException excecao)
            {
                MessageBox.Show(excecao.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
