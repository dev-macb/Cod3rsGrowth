using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Service.Services;
using FluentValidation;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class FormularioCadastroPersonagem : Form
    {
        private readonly PersonagemServico _personagemServico;
        private readonly HabilidadeServico _habilidadeServico;

        public FormularioCadastroPersonagem(PersonagemServico personagemServico, HabilidadeServico habilidadeServico)
        {
            InitializeComponent();
            _personagemServico = personagemServico;
            _habilidadeServico = habilidadeServico;
        }

        private void FormularioCadastroPersonagem_Load(object sender, EventArgs e)
        {
            tabelaPersonagensHabilidades.DataSource = _habilidadeServico.ObterTodos(null);
            foreach (DataGridViewRow linha in tabelaPersonagensHabilidades.Rows)
            {
                linha.Cells["HabilidadesSelecionadas"].Value = false;
            }
        }

        private void AoClicarEmCancelarFechaJanelaAtual(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void AoClicarEmSalvarAdicionaPersonagem(object sender, EventArgs e)
        {
            try
            {
                var novoPersonagem = new Personagem
                {
                    Nome = txtboxNome.Text,
                    Vida = (int)numupdownVida.Value,
                    Energia = (int)numupdownEnergia.Value,
                    Velocidade = (double)numupdownVelocidade.Value,
                    Forca = (CategoriasEnum)comboboxForca.SelectedIndex,
                    Inteligencia = (CategoriasEnum)comboboxInteligencia.SelectedIndex,
                    EVilao = radioVilao.Checked,
                    CriadoEm = DateTime.Now,
                    AtualizadoEm = DateTime.Now
                };

                int idNovoPersonagem = _personagemServico.Adicionar(novoPersonagem);

                var habilidadesMarcadas = new List<int>();
                foreach (DataGridViewRow linha in tabelaPersonagensHabilidades.Rows)
                {
                    if (Convert.ToBoolean(linha.Cells["HabilidadesSelecionadas"].Value))
                    {
                        int habilidadeId = Convert.ToInt32(linha.Cells["Id"].Value);
                        habilidadesMarcadas.Add(habilidadeId);
                    }
                }
                foreach (var habilidadeId in habilidadesMarcadas)
                {
                    var personagemHabilidade = new PersonagensHabilidades
                    {
                        IdPersonagem = idNovoPersonagem,
                        IdHabilidade = habilidadeId
                    };
                    _personagemServico.Adicionar(personagemHabilidade);
                }

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
