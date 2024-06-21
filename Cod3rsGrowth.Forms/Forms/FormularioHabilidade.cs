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

        private const int ID_VAZIO = 0;
        private const string TITULO_CADASTRAR = "Habilidades - Cadastrar";
        private const string TITULO_EDITAR = "Habilidades - Editar";
        private const string TITULO_DIALOGO_ERRO = "Erro!";
        private const string BTN_CADASTRAR = "Cadastrar";
        private const string BTN_EDITAR = "Atualizar";

        public FormularioHabilidade(int? idHabilidade, HabilidadeServico habilidadeServico)
        {
            InitializeComponent();
            _idHabilidade = idHabilidade ?? ID_VAZIO;
            _habilidadeServico = habilidadeServico;
        }

        private void CarregarFormularioHabilidade(object sender, EventArgs e)
        {
            if (_idHabilidade == ID_VAZIO) DefineFormularioParaCadastro();
            else DefineFormularioParaEdicao();
        }

        private void AoClicarEmSalvarHabilidade(object sender, EventArgs e)
        {
            try
            {
                if (_idHabilidade == ID_VAZIO) CadastrarHabilidade();
                else AtualizarHabilidade();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ValidationException excecao)
            {
                MessageBox.Show(excecao.Message, TITULO_DIALOGO_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AoClicarEmCancelar(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private async void CadastrarHabilidade()
        {
            var novaHabilidade = new Habilidade
            {
                Nome = txtboxNome.Text,
                Descricao = txtboxDescricao.Text,
                CriadoEm = DateTime.Now,
                AtualizadoEm = DateTime.Now
            };

            await _habilidadeServico.Adicionar(novaHabilidade);
        }

        private async void AtualizarHabilidade()
        {
            var habilidadeAtualizada = new Habilidade
            {
                Nome = txtboxNome.Text,
                Descricao = txtboxDescricao.Text,
                CriadoEm = _habilidadeExistente.CriadoEm,
                AtualizadoEm = DateTime.Now
            };

            await _habilidadeServico.Atualizar(_idHabilidade, habilidadeAtualizada);
        }

        private void DefineFormularioParaCadastro()
        {
            this.Text = TITULO_CADASTRAR;
            btnSalvar.Text = BTN_CADASTRAR;
        }

        private async void DefineFormularioParaEdicao()
        {
            this.Text = TITULO_EDITAR;
            btnSalvar.Text = BTN_EDITAR;
            _habilidadeExistente = await _habilidadeServico.ObterPorId(_idHabilidade);
            if (_habilidadeExistente != null)
            {
                labelId.Text = $"Id: {_habilidadeExistente.Id}";
                txtboxNome.Text = _habilidadeExistente.Nome;
                txtboxDescricao.Text = _habilidadeExistente.Descricao;
                labelCriadoEm.Text = $"Criado em: {_habilidadeExistente.CriadoEm}";
                labelAtualizadoEm.Text = $"Atualizado em: {_habilidadeExistente.AtualizadoEm}";
            }
        }
    }
}
