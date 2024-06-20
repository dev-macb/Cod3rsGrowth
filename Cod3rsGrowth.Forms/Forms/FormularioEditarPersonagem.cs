using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Service.Services;
using FluentValidation;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class FormularioEditarPersonagem : Form
    {
        private const string CelulaId = "Id";
        private const string CelulaHabilidadesSelecionadas = "HabilidadesSelecionadas";

        private readonly int _idPersonagem;
        private Personagem? _personagemExistente;
        private readonly PersonagemServico _personagemServico;
        private readonly HabilidadeServico _habilidadeServico;
        private readonly PersonagensHabilidadesServico _personagensHabilidadesServico;

        public FormularioEditarPersonagem(int idPersonagem, PersonagemServico personagemServico, HabilidadeServico habilidadeServico, PersonagensHabilidadesServico personagensHabilidadesServico)
        {
            InitializeComponent();
            _idPersonagem = idPersonagem;
            _personagemServico = personagemServico;
            _habilidadeServico = habilidadeServico;
            _personagensHabilidadesServico = personagensHabilidadesServico;
        }

        private void CarregarFormularioEditarPersonagem(object sender, EventArgs e)
        {
            _personagemExistente = _personagemServico.ObterPorId(_idPersonagem);
            if (_personagemExistente != null)
            {
                labelId.Text = $"Id: {_personagemExistente.Id}";
                txtboxNome.Text = _personagemExistente.Nome;
                numupdownVida.Value = _personagemExistente.Vida;
                numupdownEnergia.Value = _personagemExistente.Energia;
                numupdownVelocidade.Value = (decimal)_personagemExistente.Velocidade;
                comboboxForca.SelectedIndex = (int)_personagemExistente.Forca;
                comboboxInteligencia.SelectedIndex = (int)_personagemExistente.Inteligencia;

                tabelaHabilidades.DataSource = _habilidadeServico.ObterTodos(null);
                var habilidadesPersonagem = _personagensHabilidadesServico.ObterHabilidadesPorPersonagem(_idPersonagem);
                foreach (DataGridViewRow linha in tabelaHabilidades.Rows)
                {
                    int idHabilidade = (int)linha.Cells[CelulaId].Value;
                    linha.Cells[CelulaHabilidadesSelecionadas].Value = habilidadesPersonagem.Contains(idHabilidade);
                }

                radioHeroi.Checked = _personagemExistente.EVilao == false;
                radioVilao.Checked = _personagemExistente.EVilao == true;
                labelCriadoEm.Text = $"Criado em: {_personagemExistente.CriadoEm}";
                labelAtualizadoEm.Text = $"Atualizado em: {_personagemExistente.AtualizadoEm}";
            }
        }

        private void AoClicarEmSalvarAtualizaPersonagem(object sender, EventArgs e)
        {
            const string tituloJanela = "Erro";

            try
            {
                // Atualizar tabela personagens
                var personagemAtualizado = new Personagem
                {
                    Nome = txtboxNome.Text,
                    Vida = (int)numupdownVida.Value,
                    Energia = (int)numupdownEnergia.Value,
                    Velocidade = (int)numupdownVelocidade.Value,
                    Forca = (CategoriasEnum)comboboxForca.SelectedIndex,
                    Inteligencia = (CategoriasEnum)comboboxInteligencia.SelectedIndex,
                    EVilao = radioVilao.Checked,
                    CriadoEm = _personagemExistente.CriadoEm,
                    AtualizadoEm = DateTime.Now
                };
                _personagemServico.Atualizar(_idPersonagem, personagemAtualizado);

                // Atualizar tabela personagens_habilidades
                var habilidadesMarcadas = new List<int>();
                foreach (DataGridViewRow linha in tabelaHabilidades.Rows)
                {
                    if (Convert.ToBoolean(linha.Cells[CelulaHabilidadesSelecionadas].Value))
                    {
                        int habilidadeId = Convert.ToInt32(linha.Cells[CelulaId].Value);
                        habilidadesMarcadas.Add(habilidadeId);
                    }
                }
                var habilidadesExistentes = _personagensHabilidadesServico.ObterHabilidadesPorPersonagem(_idPersonagem);
                foreach (var habilidadeId in habilidadesExistentes)
                {
                    if (!habilidadesMarcadas.Contains(habilidadeId))
                    {
                        _personagensHabilidadesServico.DeletarPorPersonagemEHabilidade(_idPersonagem, habilidadeId);
                    }
                }
                foreach (var habilidadeId in habilidadesMarcadas)
                {
                    if (!habilidadesExistentes.Contains(habilidadeId))
                    {
                        var personagemHabilidade = new PersonagensHabilidades
                        {
                            IdPersonagem = _idPersonagem,
                            IdHabilidade = habilidadeId,
                            CriadoEm = DateTime.Now,
                            AtualizadoEm = DateTime.Now
                        };
                        _personagensHabilidadesServico.Adicionar(personagemHabilidade);
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ValidationException excecao)
            {
                MessageBox.Show(excecao.Message, tituloJanela, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AoClicarEmCancelarFechaFormularioEditarPersonagem(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
