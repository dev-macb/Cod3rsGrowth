﻿using FluentValidation;
using Cod3rsGrowth.Domain.Enums;
using Cod3rsGrowth.Domain.Entities;
using Cod3rsGrowth.Service.Services;

namespace Cod3rsGrowth.Forms.Forms
{
    public partial class FormularioCadastroPersonagem : Form
    {
        private readonly PersonagemServico _personagemServico;
        private readonly HabilidadeServico _habilidadeServico;
        private readonly PersonagensHabilidadesServico _personagensHabilidadesServicos;

        const string ColunaId = "Id";
        const string TituloJanelaErro = "Erro de Validação";
        const string ColunaHabilidadesSelecionadas = "HabilidadesSelecionadas";

        public FormularioCadastroPersonagem(PersonagemServico personagemServico, HabilidadeServico habilidadeServico, PersonagensHabilidadesServico personagensHabilidadesServicos)
        {
            InitializeComponent();
            _personagemServico = personagemServico;
            _habilidadeServico = habilidadeServico;
            _personagensHabilidadesServicos = personagensHabilidadesServicos;
        }

        private void CarregarFormularioCadastroPersonagem(object sender, EventArgs e)
        {
            tabelaHabilidades.DataSource = _habilidadeServico.ObterTodos(null);
                
            foreach (DataGridViewRow linha in tabelaHabilidades.Rows)
            {
                linha.Cells[ColunaHabilidadesSelecionadas].Value = false;
            }
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
                foreach (DataGridViewRow linha in tabelaHabilidades.Rows)
                {
                    if (Convert.ToBoolean(linha.Cells[ColunaHabilidadesSelecionadas].Value))
                    {
                        int habilidadeId = Convert.ToInt32(linha.Cells[ColunaId].Value);
                        habilidadesMarcadas.Add(habilidadeId);
                    }
                }
                foreach (var habilidadeId in habilidadesMarcadas)
                {
                    var personagemHabilidade = new PersonagensHabilidades
                    {
                        IdPersonagem = idNovoPersonagem,
                        IdHabilidade = habilidadeId,
                        CriadoEm = DateTime.Now,
                        AtualizadoEm = DateTime.Now
                    };
                    _personagensHabilidadesServicos.Adicionar(personagemHabilidade);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ValidationException excecao)
            {
                MessageBox.Show(excecao.Message, TituloJanelaErro, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AoClicarEmCancelarFechaJanelaAtual(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
