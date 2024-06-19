namespace Cod3rsGrowth.Forms.Forms
{
    partial class FormularioCadastroPersonagem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            labelNome = new Label();
            txtboxNome = new TextBox();
            labelVida = new Label();
            numupdownVida = new NumericUpDown();
            numupdownEnergia = new NumericUpDown();
            numupdownVelocidade = new NumericUpDown();
            labelEnergia = new Label();
            labelVelocidade = new Label();
            labelForca = new Label();
            labelInteligencia = new Label();
            comboboxForca = new ComboBox();
            comboboxInteligencia = new ComboBox();
            radioHeroi = new RadioButton();
            radioVilao = new RadioButton();
            labelHabilidades = new Label();
            btnCancelar = new Button();
            btnSalvar = new Button();
            tabelaPersonagensHabilidades = new DataGridView();
            habilidadeBindingSource = new BindingSource(components);
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descricaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            criadoEmDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            atualizadoEmDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)numupdownVida).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numupdownEnergia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numupdownVelocidade).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabelaPersonagensHabilidades).BeginInit();
            ((System.ComponentModel.ISupportInitialize)habilidadeBindingSource).BeginInit();
            SuspendLayout();
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Location = new Point(12, 9);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(43, 15);
            labelNome.TabIndex = 0;
            labelNome.Text = "Nome:";
            // 
            // txtboxNome
            // 
            txtboxNome.Location = new Point(12, 27);
            txtboxNome.Name = "txtboxNome";
            txtboxNome.PlaceholderText = "Digite o nome do personagem...";
            txtboxNome.Size = new Size(400, 23);
            txtboxNome.TabIndex = 1;
            // 
            // labelVida
            // 
            labelVida.AutoSize = true;
            labelVida.Location = new Point(12, 53);
            labelVida.Name = "labelVida";
            labelVida.Size = new Size(33, 15);
            labelVida.TabIndex = 2;
            labelVida.Text = "Vida:";
            // 
            // numupdownVida
            // 
            numupdownVida.Location = new Point(12, 71);
            numupdownVida.Name = "numupdownVida";
            numupdownVida.Size = new Size(129, 23);
            numupdownVida.TabIndex = 3;
            // 
            // numupdownEnergia
            // 
            numupdownEnergia.Location = new Point(147, 71);
            numupdownEnergia.Name = "numupdownEnergia";
            numupdownEnergia.Size = new Size(130, 23);
            numupdownEnergia.TabIndex = 4;
            // 
            // numupdownVelocidade
            // 
            numupdownVelocidade.Location = new Point(283, 71);
            numupdownVelocidade.Name = "numupdownVelocidade";
            numupdownVelocidade.Size = new Size(129, 23);
            numupdownVelocidade.TabIndex = 5;
            // 
            // labelEnergia
            // 
            labelEnergia.AutoSize = true;
            labelEnergia.Location = new Point(147, 53);
            labelEnergia.Name = "labelEnergia";
            labelEnergia.Size = new Size(49, 15);
            labelEnergia.TabIndex = 6;
            labelEnergia.Text = "Energia:";
            // 
            // labelVelocidade
            // 
            labelVelocidade.AutoSize = true;
            labelVelocidade.Location = new Point(283, 53);
            labelVelocidade.Name = "labelVelocidade";
            labelVelocidade.Size = new Size(67, 15);
            labelVelocidade.TabIndex = 7;
            labelVelocidade.Text = "Velocidade:";
            // 
            // labelForca
            // 
            labelForca.AutoSize = true;
            labelForca.Location = new Point(12, 97);
            labelForca.Name = "labelForca";
            labelForca.Size = new Size(39, 15);
            labelForca.TabIndex = 8;
            labelForca.Text = "Força:";
            // 
            // labelInteligencia
            // 
            labelInteligencia.AutoSize = true;
            labelInteligencia.Location = new Point(217, 97);
            labelInteligencia.Name = "labelInteligencia";
            labelInteligencia.Size = new Size(71, 15);
            labelInteligencia.TabIndex = 9;
            labelInteligencia.Text = "Inteligência:";
            // 
            // comboboxForca
            // 
            comboboxForca.FormattingEnabled = true;
            comboboxForca.Items.AddRange(new object[] { "Fraco", "Medio", "Bom", "Excepcional", "Extraordinario" });
            comboboxForca.Location = new Point(12, 115);
            comboboxForca.Name = "comboboxForca";
            comboboxForca.Size = new Size(195, 23);
            comboboxForca.TabIndex = 10;
            // 
            // comboboxInteligencia
            // 
            comboboxInteligencia.FormattingEnabled = true;
            comboboxInteligencia.Items.AddRange(new object[] { "Fraco", "Medio", "Bom", "Excepcional", "Extraordinario" });
            comboboxInteligencia.Location = new Point(217, 115);
            comboboxInteligencia.Name = "comboboxInteligencia";
            comboboxInteligencia.Size = new Size(195, 23);
            comboboxInteligencia.TabIndex = 11;
            // 
            // radioHeroi
            // 
            radioHeroi.AutoSize = true;
            radioHeroi.Location = new Point(12, 315);
            radioHeroi.Name = "radioHeroi";
            radioHeroi.Size = new Size(54, 19);
            radioHeroi.TabIndex = 12;
            radioHeroi.TabStop = true;
            radioHeroi.Text = "Herói";
            radioHeroi.UseVisualStyleBackColor = true;
            // 
            // radioVilao
            // 
            radioVilao.AutoSize = true;
            radioVilao.Location = new Point(72, 315);
            radioVilao.Name = "radioVilao";
            radioVilao.Size = new Size(51, 19);
            radioVilao.TabIndex = 13;
            radioVilao.TabStop = true;
            radioVilao.Text = "Vilão";
            radioVilao.UseVisualStyleBackColor = true;
            // 
            // labelHabilidades
            // 
            labelHabilidades.AutoSize = true;
            labelHabilidades.Location = new Point(12, 141);
            labelHabilidades.Name = "labelHabilidades";
            labelHabilidades.Size = new Size(72, 15);
            labelHabilidades.TabIndex = 14;
            labelHabilidades.Text = "Habilidades:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(256, 340);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += AoClicarEmCancelarFechaJanelaAtual;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(337, 340);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 17;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += AoClicarEmSalvarAdicionaPersonagem;
            // 
            // tabelaPersonagensHabilidades
            // 
            tabelaPersonagensHabilidades.AllowUserToAddRows = false;
            tabelaPersonagensHabilidades.AllowUserToDeleteRows = false;
            tabelaPersonagensHabilidades.AutoGenerateColumns = false;
            tabelaPersonagensHabilidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabelaPersonagensHabilidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaPersonagensHabilidades.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, descricaoDataGridViewTextBoxColumn, criadoEmDataGridViewTextBoxColumn, atualizadoEmDataGridViewTextBoxColumn });
            tabelaPersonagensHabilidades.DataSource = habilidadeBindingSource;
            tabelaPersonagensHabilidades.Location = new Point(12, 159);
            tabelaPersonagensHabilidades.Name = "tabelaPersonagensHabilidades";
            tabelaPersonagensHabilidades.ReadOnly = true;
            tabelaPersonagensHabilidades.RowHeadersVisible = false;
            tabelaPersonagensHabilidades.RowTemplate.Height = 25;
            tabelaPersonagensHabilidades.Size = new Size(400, 150);
            tabelaPersonagensHabilidades.TabIndex = 18;
            // 
            // habilidadeBindingSource
            // 
            habilidadeBindingSource.DataSource = typeof(Domain.Entities.Habilidade);
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descricaoDataGridViewTextBoxColumn
            // 
            descricaoDataGridViewTextBoxColumn.DataPropertyName = "Descricao";
            descricaoDataGridViewTextBoxColumn.HeaderText = "Descricao";
            descricaoDataGridViewTextBoxColumn.Name = "descricaoDataGridViewTextBoxColumn";
            descricaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // criadoEmDataGridViewTextBoxColumn
            // 
            criadoEmDataGridViewTextBoxColumn.DataPropertyName = "CriadoEm";
            criadoEmDataGridViewTextBoxColumn.HeaderText = "CriadoEm";
            criadoEmDataGridViewTextBoxColumn.Name = "criadoEmDataGridViewTextBoxColumn";
            criadoEmDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // atualizadoEmDataGridViewTextBoxColumn
            // 
            atualizadoEmDataGridViewTextBoxColumn.DataPropertyName = "AtualizadoEm";
            atualizadoEmDataGridViewTextBoxColumn.HeaderText = "AtualizadoEm";
            atualizadoEmDataGridViewTextBoxColumn.Name = "atualizadoEmDataGridViewTextBoxColumn";
            atualizadoEmDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FormularioCadastroPersonagem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 376);
            Controls.Add(tabelaPersonagensHabilidades);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Controls.Add(labelHabilidades);
            Controls.Add(radioVilao);
            Controls.Add(radioHeroi);
            Controls.Add(comboboxInteligencia);
            Controls.Add(comboboxForca);
            Controls.Add(labelInteligencia);
            Controls.Add(labelForca);
            Controls.Add(labelVelocidade);
            Controls.Add(labelEnergia);
            Controls.Add(numupdownVelocidade);
            Controls.Add(numupdownEnergia);
            Controls.Add(numupdownVida);
            Controls.Add(labelVida);
            Controls.Add(txtboxNome);
            Controls.Add(labelNome);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormularioCadastroPersonagem";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro - Personagem";
            Load += CarregarFormularioCadastroPersonagem;
            ((System.ComponentModel.ISupportInitialize)numupdownVida).EndInit();
            ((System.ComponentModel.ISupportInitialize)numupdownEnergia).EndInit();
            ((System.ComponentModel.ISupportInitialize)numupdownVelocidade).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabelaPersonagensHabilidades).EndInit();
            ((System.ComponentModel.ISupportInitialize)habilidadeBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNome;
        private TextBox txtboxNome;
        private Label labelVida;
        private NumericUpDown numupdownVida;
        private NumericUpDown numupdownEnergia;
        private NumericUpDown numupdownVelocidade;
        private Label labelEnergia;
        private Label labelVelocidade;
        private Label labelForca;
        private Label labelInteligencia;
        private ComboBox comboboxForca;
        private ComboBox comboboxInteligencia;
        private RadioButton radioHeroi;
        private RadioButton radioVilao;
        private Label labelHabilidades;
        private Button btnCancelar;
        private Button btnSalvar;
        private DataGridView tabelaPersonagensHabilidades;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn criadoEmDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn atualizadoEmDataGridViewTextBoxColumn;
        private BindingSource habilidadeBindingSource;
    }
}