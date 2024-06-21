namespace Cod3rsGrowth.Forms.Forms
{
    partial class FormularioPersonagem
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
            tabelaHabilidades = new DataGridView();
            HabilidadesSelecionadas = new DataGridViewCheckBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descricaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            habilidadeBindingSource = new BindingSource(components);
            btnSalvar = new Button();
            btnCancelar = new Button();
            labelHabilidades = new Label();
            radioVilao = new RadioButton();
            radioHeroi = new RadioButton();
            comboboxInteligencia = new ComboBox();
            comboboxForca = new ComboBox();
            labelInteligencia = new Label();
            labelForca = new Label();
            labelVelocidade = new Label();
            labelEnergia = new Label();
            numupdownVelocidade = new NumericUpDown();
            numupdownEnergia = new NumericUpDown();
            numupdownVida = new NumericUpDown();
            labelVida = new Label();
            txtboxNome = new TextBox();
            labelNome = new Label();
            labelId = new Label();
            labelCriadoEm = new Label();
            labelAtualizadoEm = new Label();
            ((System.ComponentModel.ISupportInitialize)tabelaHabilidades).BeginInit();
            ((System.ComponentModel.ISupportInitialize)habilidadeBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numupdownVelocidade).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numupdownEnergia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numupdownVida).BeginInit();
            SuspendLayout();
            // 
            // tabelaHabilidades
            // 
            tabelaHabilidades.AllowUserToAddRows = false;
            tabelaHabilidades.AllowUserToDeleteRows = false;
            tabelaHabilidades.AutoGenerateColumns = false;
            tabelaHabilidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabelaHabilidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaHabilidades.Columns.AddRange(new DataGridViewColumn[] { HabilidadesSelecionadas, Id, nomeDataGridViewTextBoxColumn, descricaoDataGridViewTextBoxColumn });
            tabelaHabilidades.DataSource = habilidadeBindingSource;
            tabelaHabilidades.Location = new Point(12, 174);
            tabelaHabilidades.Name = "tabelaHabilidades";
            tabelaHabilidades.RowHeadersVisible = false;
            tabelaHabilidades.RowTemplate.Height = 25;
            tabelaHabilidades.Size = new Size(400, 150);
            tabelaHabilidades.TabIndex = 36;
            // 
            // HabilidadesSelecionadas
            // 
            HabilidadesSelecionadas.FillWeight = 20F;
            HabilidadesSelecionadas.HeaderText = "";
            HabilidadesSelecionadas.Name = "HabilidadesSelecionadas";
            HabilidadesSelecionadas.Resizable = DataGridViewTriState.False;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.Visible = false;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.FillWeight = 80F;
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            // 
            // descricaoDataGridViewTextBoxColumn
            // 
            descricaoDataGridViewTextBoxColumn.DataPropertyName = "Descricao";
            descricaoDataGridViewTextBoxColumn.FillWeight = 120F;
            descricaoDataGridViewTextBoxColumn.HeaderText = "Descricao";
            descricaoDataGridViewTextBoxColumn.Name = "descricaoDataGridViewTextBoxColumn";
            // 
            // habilidadeBindingSource
            // 
            habilidadeBindingSource.DataSource = typeof(Domain.Entities.Habilidade);
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(337, 359);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 35;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += AoClicarEmSalvarPersonagem;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(256, 359);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 34;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += AoClicarEmCancelar;
            // 
            // labelHabilidades
            // 
            labelHabilidades.AutoSize = true;
            labelHabilidades.Location = new Point(12, 156);
            labelHabilidades.Name = "labelHabilidades";
            labelHabilidades.Size = new Size(72, 15);
            labelHabilidades.TabIndex = 33;
            labelHabilidades.Text = "Habilidades:";
            // 
            // radioVilao
            // 
            radioVilao.AutoSize = true;
            radioVilao.Location = new Point(72, 330);
            radioVilao.Name = "radioVilao";
            radioVilao.Size = new Size(51, 19);
            radioVilao.TabIndex = 32;
            radioVilao.TabStop = true;
            radioVilao.Text = "Vilão";
            radioVilao.UseVisualStyleBackColor = true;
            // 
            // radioHeroi
            // 
            radioHeroi.AutoSize = true;
            radioHeroi.Location = new Point(12, 330);
            radioHeroi.Name = "radioHeroi";
            radioHeroi.Size = new Size(54, 19);
            radioHeroi.TabIndex = 31;
            radioHeroi.TabStop = true;
            radioHeroi.Text = "Herói";
            radioHeroi.UseVisualStyleBackColor = true;
            // 
            // comboboxInteligencia
            // 
            comboboxInteligencia.FormattingEnabled = true;
            comboboxInteligencia.Items.AddRange(new object[] { "Fraco", "Medio", "Bom", "Excepcional", "Extraordinario" });
            comboboxInteligencia.Location = new Point(217, 130);
            comboboxInteligencia.Name = "comboboxInteligencia";
            comboboxInteligencia.Size = new Size(195, 23);
            comboboxInteligencia.TabIndex = 30;
            // 
            // comboboxForca
            // 
            comboboxForca.FormattingEnabled = true;
            comboboxForca.Items.AddRange(new object[] { "Fraco", "Medio", "Bom", "Excepcional", "Extraordinario" });
            comboboxForca.Location = new Point(12, 130);
            comboboxForca.Name = "comboboxForca";
            comboboxForca.Size = new Size(195, 23);
            comboboxForca.TabIndex = 29;
            // 
            // labelInteligencia
            // 
            labelInteligencia.AutoSize = true;
            labelInteligencia.Location = new Point(217, 112);
            labelInteligencia.Name = "labelInteligencia";
            labelInteligencia.Size = new Size(71, 15);
            labelInteligencia.TabIndex = 28;
            labelInteligencia.Text = "Inteligência:";
            // 
            // labelForca
            // 
            labelForca.AutoSize = true;
            labelForca.Location = new Point(12, 112);
            labelForca.Name = "labelForca";
            labelForca.Size = new Size(39, 15);
            labelForca.TabIndex = 27;
            labelForca.Text = "Força:";
            // 
            // labelVelocidade
            // 
            labelVelocidade.AutoSize = true;
            labelVelocidade.Location = new Point(283, 68);
            labelVelocidade.Name = "labelVelocidade";
            labelVelocidade.Size = new Size(67, 15);
            labelVelocidade.TabIndex = 26;
            labelVelocidade.Text = "Velocidade:";
            // 
            // labelEnergia
            // 
            labelEnergia.AutoSize = true;
            labelEnergia.Location = new Point(147, 68);
            labelEnergia.Name = "labelEnergia";
            labelEnergia.Size = new Size(49, 15);
            labelEnergia.TabIndex = 25;
            labelEnergia.Text = "Energia:";
            // 
            // numupdownVelocidade
            // 
            numupdownVelocidade.DecimalPlaces = 2;
            numupdownVelocidade.Location = new Point(283, 86);
            numupdownVelocidade.Name = "numupdownVelocidade";
            numupdownVelocidade.Size = new Size(129, 23);
            numupdownVelocidade.TabIndex = 24;
            // 
            // numupdownEnergia
            // 
            numupdownEnergia.Location = new Point(147, 86);
            numupdownEnergia.Name = "numupdownEnergia";
            numupdownEnergia.Size = new Size(130, 23);
            numupdownEnergia.TabIndex = 23;
            // 
            // numupdownVida
            // 
            numupdownVida.Location = new Point(12, 86);
            numupdownVida.Name = "numupdownVida";
            numupdownVida.Size = new Size(129, 23);
            numupdownVida.TabIndex = 22;
            // 
            // labelVida
            // 
            labelVida.AutoSize = true;
            labelVida.Location = new Point(12, 68);
            labelVida.Name = "labelVida";
            labelVida.Size = new Size(33, 15);
            labelVida.TabIndex = 21;
            labelVida.Text = "Vida:";
            // 
            // txtboxNome
            // 
            txtboxNome.Location = new Point(12, 42);
            txtboxNome.Name = "txtboxNome";
            txtboxNome.PlaceholderText = "Digite o nome do personagem...";
            txtboxNome.Size = new Size(400, 23);
            txtboxNome.TabIndex = 20;
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Location = new Point(12, 24);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(43, 15);
            labelNome.TabIndex = 19;
            labelNome.Text = "Nome:";
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.ForeColor = SystemColors.ControlDark;
            labelId.Location = new Point(12, 9);
            labelId.Name = "labelId";
            labelId.Size = new Size(32, 15);
            labelId.TabIndex = 37;
            labelId.Text = "Id: ...";
            // 
            // labelCriadoEm
            // 
            labelCriadoEm.AutoSize = true;
            labelCriadoEm.ForeColor = SystemColors.ControlDark;
            labelCriadoEm.Location = new Point(12, 352);
            labelCriadoEm.Name = "labelCriadoEm";
            labelCriadoEm.Size = new Size(77, 15);
            labelCriadoEm.TabIndex = 38;
            labelCriadoEm.Text = "Criado em: ...";
            // 
            // labelAtualizadoEm
            // 
            labelAtualizadoEm.AutoSize = true;
            labelAtualizadoEm.ForeColor = SystemColors.ControlDark;
            labelAtualizadoEm.Location = new Point(12, 367);
            labelAtualizadoEm.Name = "labelAtualizadoEm";
            labelAtualizadoEm.Size = new Size(98, 15);
            labelAtualizadoEm.TabIndex = 39;
            labelAtualizadoEm.Text = "Atualizado em: ...";
            // 
            // FormularioPersonagem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 393);
            Controls.Add(labelAtualizadoEm);
            Controls.Add(labelCriadoEm);
            Controls.Add(labelId);
            Controls.Add(tabelaHabilidades);
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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormularioPersonagem";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Editar - Personagem";
            Load += CarregarFormularioEditarPersonagem;
            ((System.ComponentModel.ISupportInitialize)tabelaHabilidades).EndInit();
            ((System.ComponentModel.ISupportInitialize)habilidadeBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)numupdownVelocidade).EndInit();
            ((System.ComponentModel.ISupportInitialize)numupdownEnergia).EndInit();
            ((System.ComponentModel.ISupportInitialize)numupdownVida).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView tabelaHabilidades;
        private Button btnSalvar;
        private Button btnCancelar;
        private Label labelHabilidades;
        private RadioButton radioVilao;
        private RadioButton radioHeroi;
        private ComboBox comboboxInteligencia;
        private ComboBox comboboxForca;
        private Label labelInteligencia;
        private Label labelForca;
        private Label labelVelocidade;
        private Label labelEnergia;
        private NumericUpDown numupdownVelocidade;
        private NumericUpDown numupdownEnergia;
        private NumericUpDown numupdownVida;
        private Label labelVida;
        private TextBox txtboxNome;
        private Label labelNome;
        private Label labelId;
        private Label labelCriadoEm;
        private Label labelAtualizadoEm;
        private DataGridViewCheckBoxColumn HabilidadesSelecionadas;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private BindingSource habilidadeBindingSource;
        private DataGridViewTextBoxColumn Id;
    }
}