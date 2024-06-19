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
            tabelaHabilidades = new DataGridView();
            habilidadeBindingSource = new BindingSource(components);
            HabilidadesSelecionadas = new DataGridViewCheckBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descricaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)numupdownVida).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numupdownEnergia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numupdownVelocidade).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabelaHabilidades).BeginInit();
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
            // tabelaHabilidades
            // 
            tabelaHabilidades.AllowUserToAddRows = false;
            tabelaHabilidades.AllowUserToDeleteRows = false;
            tabelaHabilidades.AutoGenerateColumns = false;
            tabelaHabilidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabelaHabilidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaHabilidades.Columns.AddRange(new DataGridViewColumn[] { HabilidadesSelecionadas, Id, nomeDataGridViewTextBoxColumn, descricaoDataGridViewTextBoxColumn });
            tabelaHabilidades.DataSource = habilidadeBindingSource;
            tabelaHabilidades.Location = new Point(12, 159);
            tabelaHabilidades.Name = "tabelaHabilidades";
            tabelaHabilidades.RowHeadersVisible = false;
            tabelaHabilidades.RowTemplate.Height = 25;
            tabelaHabilidades.Size = new Size(400, 150);
            tabelaHabilidades.TabIndex = 18;
            // 
            // habilidadeBindingSource
            // 
            habilidadeBindingSource.DataSource = typeof(Domain.Entities.Habilidade);
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
            // FormularioCadastroPersonagem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 376);
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
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormularioCadastroPersonagem";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro - Personagem";
            Load += CarregarFormularioCadastroPersonagem;
            ((System.ComponentModel.ISupportInitialize)numupdownVida).EndInit();
            ((System.ComponentModel.ISupportInitialize)numupdownEnergia).EndInit();
            ((System.ComponentModel.ISupportInitialize)numupdownVelocidade).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabelaHabilidades).EndInit();
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
        private DataGridView tabelaHabilidades;
        private BindingSource habilidadeBindingSource;
        private DataGridViewCheckBoxColumn HabilidadesSelecionadas;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Id;
    }
}