﻿using FluentValidation;
using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Service.Services;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class FormularioPersonagem : Form
    {
        private readonly int _idPersonagem;
        private Personagem? _personagemExistente;
        private readonly PersonagemServico _personagemServico;
        private readonly HabilidadeServico _habilidadeServico;

        private const int ID_VAZIO = 0;
        private const string TITULO_CADASTRAR = "Personagem - Cadastrar";
        private const string TITULO_EDITAR = "Personagem - Editar";
        private const string TITULO_DIALOGO_ERRO = "Erro!";
        private const string BTN_CADASTRAR = "Cadastrar";
        private const string BTN_EDITAR = "Atualizar";
        private const string CELULA_ID = "Id";
        private const string CELULA_HABILIDADES_SELECIONADAS = "HabilidadesSelecionadas";

        public FormularioPersonagem(int? idPersonagem, PersonagemServico personagemServico, HabilidadeServico habilidadeServico)
        {
            InitializeComponent();
            _idPersonagem = idPersonagem ?? ID_VAZIO;
            _personagemServico = personagemServico;
            _habilidadeServico = habilidadeServico;
        }

        private void CarregarFormularioEditarPersonagem(object sender, EventArgs e)
        {
            if (_idPersonagem == ID_VAZIO) DefineFormularioParaCadastro();
            else DefineFormularioParaEdicao();
        }

        private void AoClicarEmSalvarPersonagem(object sender, EventArgs e)
        {
            if (_idPersonagem == ID_VAZIO) CadastrarPersonagem();
            else AtualizarPersonagem();
        }

        private void AoClicarEmCancelar(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private async void CadastrarPersonagem()
        {
            var habilidadesMarcadas = ObterHabilidadesMarcadas();
            var novoPersonagem = new Personagem
            {
                Nome = txtboxNome.Text,
                Vida = (int)numupdownVida.Value,
                Energia = (int)numupdownEnergia.Value,
                Velocidade = (double)numupdownVelocidade.Value,
                Forca = (CategoriasEnum)comboboxForca.SelectedIndex,
                Inteligencia = (CategoriasEnum)comboboxInteligencia.SelectedIndex,
                Habilidades = habilidadesMarcadas,
                EVilao = radioVilao.Checked
            };

            try 
            { 
                await _personagemServico.Adicionar(novoPersonagem);
                DialogResult = DialogResult.OK;
                Close();
            } 
            catch (ValidationException excecao)
            {
                var mensagem = string.Join('\n', excecao.Errors.Select(i => i.ErrorMessage));
                MessageBox.Show(mensagem, TITULO_DIALOGO_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void AtualizarPersonagem()
        {
            var habilidadesMarcadas = ObterHabilidadesMarcadas();
            var personagemAtualizado = new Personagem
            {
                Nome = txtboxNome.Text,
                Vida = (int)numupdownVida.Value,
                Energia = (int)numupdownEnergia.Value,
                Velocidade = (double)numupdownVelocidade.Value,
                Forca = (CategoriasEnum)comboboxForca.SelectedIndex,
                Inteligencia = (CategoriasEnum)comboboxInteligencia.SelectedIndex,
                Habilidades = habilidadesMarcadas,
                EVilao = radioVilao.Checked
            };

            try
            {
                await _personagemServico.Atualizar(_idPersonagem, personagemAtualizado);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ValidationException excecao)
            {
                var mensagem = string.Join('\n', excecao.Errors.Select(i => i.ErrorMessage));
                MessageBox.Show(mensagem, TITULO_DIALOGO_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void DefineFormularioParaCadastro()
        {
            Text = TITULO_CADASTRAR;
            btnSalvar.Text = BTN_CADASTRAR;
            radioHeroi.Checked = true;
            tabelaHabilidades.DataSource = await _habilidadeServico.ObterTodos(null);

            foreach (DataGridViewRow linha in tabelaHabilidades.Rows)
            {
                linha.Cells[CELULA_HABILIDADES_SELECIONADAS].Value = false;
            }
        }

        private async void DefineFormularioParaEdicao()
        {
            Text = TITULO_EDITAR;
            btnSalvar.Text = BTN_EDITAR;
            _personagemExistente = await _personagemServico.ObterPorId(_idPersonagem);
            if (_personagemExistente != null)
            {
                labelId.Text = $"Id: {_personagemExistente.Id}";
                txtboxNome.Text = _personagemExistente.Nome;
                numupdownVida.Value = _personagemExistente.Vida;
                numupdownEnergia.Value = _personagemExistente.Energia;
                numupdownVelocidade.Value = (decimal)_personagemExistente.Velocidade;
                comboboxForca.SelectedIndex = (int)_personagemExistente.Forca;
                comboboxInteligencia.SelectedIndex = (int)_personagemExistente.Inteligencia;
                radioHeroi.Checked = _personagemExistente.EVilao == false;
                radioVilao.Checked = _personagemExistente.EVilao == true;
                labelCriadoEm.Text = $"Criado em: {_personagemExistente.CriadoEm}";
                labelAtualizadoEm.Text = $"Atualizado em: {_personagemExistente.AtualizadoEm}";

                tabelaHabilidades.DataSource = await _habilidadeServico.ObterTodos(null);

                if (_personagemExistente.Habilidades != null)
                {
                    foreach (DataGridViewRow linha in tabelaHabilidades.Rows)
                    {
                        int idHabilidade = (int)linha.Cells[CELULA_ID].Value;
                        linha.Cells[CELULA_HABILIDADES_SELECIONADAS].Value = _personagemExistente.Habilidades.Contains(idHabilidade);
                    }
                }
            }
        }

        private List<int> ObterHabilidadesMarcadas()
        {
            var habilidadesMarcadas = new List<int>();
            foreach (DataGridViewRow linha in tabelaHabilidades.Rows)
            {
                if (Convert.ToBoolean(linha.Cells[CELULA_HABILIDADES_SELECIONADAS].Value))
                {
                    int habilidadeId = Convert.ToInt32(linha.Cells[CELULA_ID].Value);
                    habilidadesMarcadas.Add(habilidadeId);
                }
            }
            return habilidadesMarcadas;
        }
    }
}