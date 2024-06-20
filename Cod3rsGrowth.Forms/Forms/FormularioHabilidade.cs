using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Service.Services;
using FluentValidation;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class FormularioHabilidade : Form
    {
        private readonly int _idHabilidade;
        private Habilidade? _habilidadeExistente;
        private readonly HabilidadeServico _habilidadeServico;

        private const string TITULO_CADASTRAR = "Habilidades - Cadastrar";
        private const string TITULO_EDITAR = "Habilidades - Editar";
        private const string TITULO_DIALOGO_ERRO = "Erro!";
        private const string BTN_CADASTRAR = "Cadastrar";
        private const string BTN_EDITAR = "Atualizar";

        public FormularioHabilidade(int? idHabilidade, HabilidadeServico habilidadeServico)
        {
            InitializeComponent();
            _idHabilidade = idHabilidade ?? 0;
            _habilidadeServico = habilidadeServico;
        }

        private void CarregarFormularioEditarHabilidade(object sender, EventArgs e)
        {
            if (_idHabilidade == 0)
            {
                this.Text = TITULO_CADASTRAR;
                btnSalvar.Text = BTN_CADASTRAR;
                return;
            }

            this.Text = TITULO_EDITAR;
            btnSalvar.Text = BTN_EDITAR;
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

        private void AoClicarEmSalvarAtualizaHabilidade(object sender, EventArgs e)
        {
            try
            {
                if (_idHabilidade == 0)
                {
                    var novaHabilidade = new Habilidade
                    {
                        Nome = txtboxNome.Text,
                        Descricao = txtboxDescricao.Text,
                        CriadoEm = DateTime.Now,
                        AtualizadoEm = DateTime.Now
                    };

                    _habilidadeServico.Adicionar(novaHabilidade);
                }
                else
                {
                    var habilidadeAtualizada = new Habilidade
                    {
                        Nome = txtboxNome.Text,
                        Descricao = txtboxDescricao.Text,
                        CriadoEm = _habilidadeExistente.CriadoEm,
                        AtualizadoEm = DateTime.Now
                    };

                    _habilidadeServico.Atualizar(_idHabilidade, habilidadeAtualizada);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ValidationException excecao)
            {
                MessageBox.Show(excecao.Message, TITULO_DIALOGO_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AoClicarEmCancelarFechaFormularioEditarHabilidade(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
