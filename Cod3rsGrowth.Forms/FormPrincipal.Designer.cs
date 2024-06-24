using Cod3rsGrowth.Service.Services;

namespace Cod3rsGrowth.Forms
{
    partial class FormularioPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            menuSuperior = new MenuStrip();
            menuSuperiorAplicacao = new ToolStripMenuItem();
            menuSuperiorAplicacaoCadastro = new ToolStripMenuItem();
            menuSuperiorCadastroPersonagem = new ToolStripMenuItem();
            menuSuperiorCadastroHabilidade = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            menuSuperiorAplicacaoSair = new ToolStripMenuItem();
            txtboxFiltroPersonagemId = new TextBox();
            tabelaPersonagens = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            vidaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            energiaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            velocidadeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            forcaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            inteligenciaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            eVilaoDataGridViewTextBoxColumn = new DataGridViewCheckBoxColumn();
            personagemBindingSource = new BindingSource(components);
            txtboxFiltroPersonagemNome = new TextBox();
            personagemServicoBindingSource1 = new BindingSource(components);
            personagemServicoBindingSource = new BindingSource(components);
            AbasInicio = new TabControl();
            AbaPersonagem = new TabPage();
            btnEditarPersonagem = new Button();
            btnRemoverPersonagem = new Button();
            btnBuscar = new Button();
            btnFiltrarPersonagem = new Button();
            lblTotalPersonagens = new Label();
            AbaHabilidade = new TabPage();
            btnEditarHabilidade = new Button();
            btnRemoverHabilidade = new Button();
            lblTotalHabilidades = new Label();
            tabelaHabilidades = new DataGridView();
            idDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            descricaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            habilidadeBindingSource = new BindingSource(components);
            btnFiltrarHabilidade = new Button();
            btnBuscarHabilidade = new Button();
            txtboxFiltroHabilidadeNome = new TextBox();
            txtboxFiltroHabilidadeId = new TextBox();
            fbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            menuSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tabelaPersonagens).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personagemServicoBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personagemServicoBindingSource).BeginInit();
            AbasInicio.SuspendLayout();
            AbaPersonagem.SuspendLayout();
            AbaHabilidade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tabelaHabilidades).BeginInit();
            ((System.ComponentModel.ISupportInitialize)habilidadeBindingSource).BeginInit();
            SuspendLayout();
            // 
            // menuSuperior
            // 
            menuSuperior.Items.AddRange(new ToolStripItem[] { menuSuperiorAplicacao });
            menuSuperior.Location = new Point(0, 0);
            menuSuperior.Name = "menuSuperior";
            menuSuperior.Size = new Size(784, 24);
            menuSuperior.TabIndex = 0;
            menuSuperior.Text = "menuStrip1";
            // 
            // menuSuperiorAplicacao
            // 
            menuSuperiorAplicacao.DropDownItems.AddRange(new ToolStripItem[] { menuSuperiorAplicacaoCadastro, toolStripSeparator1, menuSuperiorAplicacaoSair });
            menuSuperiorAplicacao.Name = "menuSuperiorAplicacao";
            menuSuperiorAplicacao.Size = new Size(71, 20);
            menuSuperiorAplicacao.Text = "Aplicação";
            // 
            // menuSuperiorAplicacaoCadastro
            // 
            menuSuperiorAplicacaoCadastro.DropDownItems.AddRange(new ToolStripItem[] { menuSuperiorCadastroPersonagem, menuSuperiorCadastroHabilidade });
            menuSuperiorAplicacaoCadastro.Name = "menuSuperiorAplicacaoCadastro";
            menuSuperiorAplicacaoCadastro.Size = new Size(180, 22);
            menuSuperiorAplicacaoCadastro.Text = "Cadastro";
            // 
            // menuSuperiorCadastroPersonagem
            // 
            menuSuperiorCadastroPersonagem.Name = "menuSuperiorCadastroPersonagem";
            menuSuperiorCadastroPersonagem.Size = new Size(180, 22);
            menuSuperiorCadastroPersonagem.Text = "Personagem";
            menuSuperiorCadastroPersonagem.Click += AoClicarEmMenuSuperiorCadastroPersonagemAbreFormularioPersonagem;
            // 
            // menuSuperiorCadastroHabilidade
            // 
            menuSuperiorCadastroHabilidade.Name = "menuSuperiorCadastroHabilidade";
            menuSuperiorCadastroHabilidade.Size = new Size(180, 22);
            menuSuperiorCadastroHabilidade.Text = "Habilidade";
            menuSuperiorCadastroHabilidade.Click += AoClicarEmMenuSuperiorCadastroHabilidadeAbreFormularioHabilidade;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // menuSuperiorAplicacaoSair
            // 
            menuSuperiorAplicacaoSair.Name = "menuSuperiorAplicacaoSair";
            menuSuperiorAplicacaoSair.Size = new Size(180, 22);
            menuSuperiorAplicacaoSair.Text = "Sair";
            menuSuperiorAplicacaoSair.Click += AoClicarEmMenuSuperiorSairFechaFormularioPrincipal;
            // 
            // txtboxFiltroPersonagemId
            // 
            txtboxFiltroPersonagemId.ForeColor = SystemColors.WindowFrame;
            txtboxFiltroPersonagemId.Location = new Point(8, 6);
            txtboxFiltroPersonagemId.Name = "txtboxFiltroPersonagemId";
            txtboxFiltroPersonagemId.PlaceholderText = "Id...";
            txtboxFiltroPersonagemId.Size = new Size(50, 23);
            txtboxFiltroPersonagemId.TabIndex = 7;
            txtboxFiltroPersonagemId.KeyDown += txtboxFiltroPersonagemId_KeyDown;
            // 
            // tabelaPersonagens
            // 
            tabelaPersonagens.AllowUserToAddRows = false;
            tabelaPersonagens.AllowUserToDeleteRows = false;
            tabelaPersonagens.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabelaPersonagens.AutoGenerateColumns = false;
            tabelaPersonagens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabelaPersonagens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaPersonagens.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, vidaDataGridViewTextBoxColumn, energiaDataGridViewTextBoxColumn, velocidadeDataGridViewTextBoxColumn, forcaDataGridViewTextBoxColumn, inteligenciaDataGridViewTextBoxColumn, eVilaoDataGridViewTextBoxColumn });
            tabelaPersonagens.DataSource = personagemBindingSource;
            tabelaPersonagens.Location = new Point(8, 36);
            tabelaPersonagens.Name = "tabelaPersonagens";
            tabelaPersonagens.ReadOnly = true;
            tabelaPersonagens.RowHeadersVisible = false;
            tabelaPersonagens.RowTemplate.Height = 25;
            tabelaPersonagens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabelaPersonagens.Size = new Size(762, 347);
            tabelaPersonagens.TabIndex = 6;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.FillWeight = 30F;
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
            // vidaDataGridViewTextBoxColumn
            // 
            vidaDataGridViewTextBoxColumn.DataPropertyName = "Vida";
            vidaDataGridViewTextBoxColumn.FillWeight = 80F;
            vidaDataGridViewTextBoxColumn.HeaderText = "Vida";
            vidaDataGridViewTextBoxColumn.Name = "vidaDataGridViewTextBoxColumn";
            vidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // energiaDataGridViewTextBoxColumn
            // 
            energiaDataGridViewTextBoxColumn.DataPropertyName = "Energia";
            energiaDataGridViewTextBoxColumn.FillWeight = 80F;
            energiaDataGridViewTextBoxColumn.HeaderText = "Energia";
            energiaDataGridViewTextBoxColumn.Name = "energiaDataGridViewTextBoxColumn";
            energiaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // velocidadeDataGridViewTextBoxColumn
            // 
            velocidadeDataGridViewTextBoxColumn.DataPropertyName = "Velocidade";
            velocidadeDataGridViewTextBoxColumn.FillWeight = 80F;
            velocidadeDataGridViewTextBoxColumn.HeaderText = "Velocidade";
            velocidadeDataGridViewTextBoxColumn.Name = "velocidadeDataGridViewTextBoxColumn";
            velocidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // forcaDataGridViewTextBoxColumn
            // 
            forcaDataGridViewTextBoxColumn.DataPropertyName = "Forca";
            forcaDataGridViewTextBoxColumn.FillWeight = 80F;
            forcaDataGridViewTextBoxColumn.HeaderText = "Forca";
            forcaDataGridViewTextBoxColumn.Name = "forcaDataGridViewTextBoxColumn";
            forcaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // inteligenciaDataGridViewTextBoxColumn
            // 
            inteligenciaDataGridViewTextBoxColumn.DataPropertyName = "Inteligencia";
            inteligenciaDataGridViewTextBoxColumn.FillWeight = 80F;
            inteligenciaDataGridViewTextBoxColumn.HeaderText = "Inteligencia";
            inteligenciaDataGridViewTextBoxColumn.Name = "inteligenciaDataGridViewTextBoxColumn";
            inteligenciaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eVilaoDataGridViewTextBoxColumn
            // 
            eVilaoDataGridViewTextBoxColumn.DataPropertyName = "EVilao";
            eVilaoDataGridViewTextBoxColumn.FillWeight = 50F;
            eVilaoDataGridViewTextBoxColumn.HeaderText = "Vilão";
            eVilaoDataGridViewTextBoxColumn.Name = "eVilaoDataGridViewTextBoxColumn";
            eVilaoDataGridViewTextBoxColumn.ReadOnly = true;
            eVilaoDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True;
            eVilaoDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // personagemBindingSource
            // 
            personagemBindingSource.DataSource = typeof(Domain.Entities.Personagem);
            // 
            // txtboxFiltroPersonagemNome
            // 
            txtboxFiltroPersonagemNome.ForeColor = SystemColors.WindowFrame;
            txtboxFiltroPersonagemNome.Location = new Point(64, 6);
            txtboxFiltroPersonagemNome.Name = "txtboxFiltroPersonagemNome";
            txtboxFiltroPersonagemNome.PlaceholderText = "Pesquise pelo nome...";
            txtboxFiltroPersonagemNome.Size = new Size(200, 23);
            txtboxFiltroPersonagemNome.TabIndex = 5;
            txtboxFiltroPersonagemNome.KeyDown += AoDigitarEnterEmFiltroNomeAtualizaFiltroPersonagem;
            // 
            // AbasInicio
            // 
            AbasInicio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AbasInicio.Controls.Add(AbaPersonagem);
            AbasInicio.Controls.Add(AbaHabilidade);
            AbasInicio.Location = new Point(0, 27);
            AbasInicio.Name = "AbasInicio";
            AbasInicio.SelectedIndex = 0;
            AbasInicio.Size = new Size(784, 434);
            AbasInicio.TabIndex = 8;
            // 
            // AbaPersonagem
            // 
            AbaPersonagem.Controls.Add(btnEditarPersonagem);
            AbaPersonagem.Controls.Add(btnRemoverPersonagem);
            AbaPersonagem.Controls.Add(btnBuscar);
            AbaPersonagem.Controls.Add(btnFiltrarPersonagem);
            AbaPersonagem.Controls.Add(lblTotalPersonagens);
            AbaPersonagem.Controls.Add(txtboxFiltroPersonagemNome);
            AbaPersonagem.Controls.Add(txtboxFiltroPersonagemId);
            AbaPersonagem.Controls.Add(tabelaPersonagens);
            AbaPersonagem.Location = new Point(4, 24);
            AbaPersonagem.Name = "AbaPersonagem";
            AbaPersonagem.Padding = new Padding(3);
            AbaPersonagem.Size = new Size(776, 406);
            AbaPersonagem.TabIndex = 0;
            AbaPersonagem.Text = "Personagens";
            AbaPersonagem.UseVisualStyleBackColor = true;
            // 
            // btnEditarPersonagem
            // 
            btnEditarPersonagem.Location = new Point(351, 6);
            btnEditarPersonagem.Name = "btnEditarPersonagem";
            btnEditarPersonagem.Size = new Size(75, 23);
            btnEditarPersonagem.TabIndex = 12;
            btnEditarPersonagem.Text = "Editar";
            btnEditarPersonagem.UseVisualStyleBackColor = true;
            btnEditarPersonagem.Click += AoClicarEmEditarAbreFormularioPersonagem;
            // 
            // btnRemoverPersonagem
            // 
            btnRemoverPersonagem.Location = new Point(432, 6);
            btnRemoverPersonagem.Name = "btnRemoverPersonagem";
            btnRemoverPersonagem.Size = new Size(75, 23);
            btnRemoverPersonagem.TabIndex = 11;
            btnRemoverPersonagem.Text = "Remover";
            btnRemoverPersonagem.UseVisualStyleBackColor = true;
            btnRemoverPersonagem.Click += AoClicarEmRemoverExcluiPersonagem;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(270, 6);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 10;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += AoClicarEmBuscaPersonagemAtualizaFiltroNome;
            // 
            // btnFiltrarPersonagem
            // 
            btnFiltrarPersonagem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFiltrarPersonagem.Location = new Point(695, 6);
            btnFiltrarPersonagem.Name = "btnFiltrarPersonagem";
            btnFiltrarPersonagem.Size = new Size(75, 23);
            btnFiltrarPersonagem.TabIndex = 9;
            btnFiltrarPersonagem.Text = "Filtrar";
            btnFiltrarPersonagem.UseVisualStyleBackColor = true;
            btnFiltrarPersonagem.Click += AoClicarEmFiltrarPersonagemAbreFormularioFiltros;
            // 
            // lblTotalPersonagens
            // 
            lblTotalPersonagens.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotalPersonagens.AutoSize = true;
            lblTotalPersonagens.ForeColor = SystemColors.ControlDarkDark;
            lblTotalPersonagens.Location = new Point(6, 386);
            lblTotalPersonagens.Name = "lblTotalPersonagens";
            lblTotalPersonagens.Size = new Size(47, 15);
            lblTotalPersonagens.TabIndex = 8;
            lblTotalPersonagens.Text = "Total: ...";
            // 
            // AbaHabilidade
            // 
            AbaHabilidade.Controls.Add(btnEditarHabilidade);
            AbaHabilidade.Controls.Add(btnRemoverHabilidade);
            AbaHabilidade.Controls.Add(lblTotalHabilidades);
            AbaHabilidade.Controls.Add(tabelaHabilidades);
            AbaHabilidade.Controls.Add(btnFiltrarHabilidade);
            AbaHabilidade.Controls.Add(btnBuscarHabilidade);
            AbaHabilidade.Controls.Add(txtboxFiltroHabilidadeNome);
            AbaHabilidade.Controls.Add(txtboxFiltroHabilidadeId);
            AbaHabilidade.Location = new Point(4, 24);
            AbaHabilidade.Name = "AbaHabilidade";
            AbaHabilidade.Padding = new Padding(3);
            AbaHabilidade.Size = new Size(776, 406);
            AbaHabilidade.TabIndex = 1;
            AbaHabilidade.Text = "Habilidades";
            AbaHabilidade.UseVisualStyleBackColor = true;
            // 
            // btnEditarHabilidade
            // 
            btnEditarHabilidade.Location = new Point(351, 6);
            btnEditarHabilidade.Name = "btnEditarHabilidade";
            btnEditarHabilidade.Size = new Size(75, 23);
            btnEditarHabilidade.TabIndex = 7;
            btnEditarHabilidade.Text = "Editar";
            btnEditarHabilidade.UseVisualStyleBackColor = true;
            btnEditarHabilidade.Click += AoClicarEmEditarAbreFormularioHabilidade;
            // 
            // btnRemoverHabilidade
            // 
            btnRemoverHabilidade.Location = new Point(432, 6);
            btnRemoverHabilidade.Name = "btnRemoverHabilidade";
            btnRemoverHabilidade.Size = new Size(75, 23);
            btnRemoverHabilidade.TabIndex = 6;
            btnRemoverHabilidade.Text = "Remover";
            btnRemoverHabilidade.UseVisualStyleBackColor = true;
            btnRemoverHabilidade.Click += AoClicarEmRemoverExcluiHabilidade;
            // 
            // lblTotalHabilidades
            // 
            lblTotalHabilidades.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotalHabilidades.AutoSize = true;
            lblTotalHabilidades.ForeColor = SystemColors.ControlDarkDark;
            lblTotalHabilidades.Location = new Point(6, 386);
            lblTotalHabilidades.Name = "lblTotalHabilidades";
            lblTotalHabilidades.Size = new Size(47, 15);
            lblTotalHabilidades.TabIndex = 5;
            lblTotalHabilidades.Text = "Total: ...";
            // 
            // tabelaHabilidades
            // 
            tabelaHabilidades.AllowUserToAddRows = false;
            tabelaHabilidades.AllowUserToDeleteRows = false;
            tabelaHabilidades.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabelaHabilidades.AutoGenerateColumns = false;
            tabelaHabilidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            tabelaHabilidades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tabelaHabilidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaHabilidades.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn1, nomeDataGridViewTextBoxColumn1, descricaoDataGridViewTextBoxColumn });
            tabelaHabilidades.DataSource = habilidadeBindingSource;
            tabelaHabilidades.Location = new Point(8, 36);
            tabelaHabilidades.Name = "tabelaHabilidades";
            tabelaHabilidades.ReadOnly = true;
            tabelaHabilidades.RowHeadersVisible = false;
            tabelaHabilidades.RowTemplate.Height = 25;
            tabelaHabilidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabelaHabilidades.Size = new Size(762, 347);
            tabelaHabilidades.TabIndex = 4;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn1.FillWeight = 20F;
            idDataGridViewTextBoxColumn1.HeaderText = "Id";
            idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            idDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn1
            // 
            nomeDataGridViewTextBoxColumn1.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn1.FillWeight = 80F;
            nomeDataGridViewTextBoxColumn1.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn1.Name = "nomeDataGridViewTextBoxColumn1";
            nomeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // descricaoDataGridViewTextBoxColumn
            // 
            descricaoDataGridViewTextBoxColumn.DataPropertyName = "Descricao";
            descricaoDataGridViewTextBoxColumn.FillWeight = 120F;
            descricaoDataGridViewTextBoxColumn.HeaderText = "Descricao";
            descricaoDataGridViewTextBoxColumn.Name = "descricaoDataGridViewTextBoxColumn";
            descricaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // habilidadeBindingSource
            // 
            habilidadeBindingSource.DataSource = typeof(Domain.Entities.Habilidade);
            // 
            // btnFiltrarHabilidade
            // 
            btnFiltrarHabilidade.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFiltrarHabilidade.Location = new Point(695, 6);
            btnFiltrarHabilidade.Name = "btnFiltrarHabilidade";
            btnFiltrarHabilidade.Size = new Size(75, 23);
            btnFiltrarHabilidade.TabIndex = 3;
            btnFiltrarHabilidade.Text = "Filtrar";
            btnFiltrarHabilidade.UseVisualStyleBackColor = true;
            btnFiltrarHabilidade.Click += AoClicarEmFiltrarHabilidadeAbreFormularioFiltros;
            // 
            // btnBuscarHabilidade
            // 
            btnBuscarHabilidade.Location = new Point(270, 6);
            btnBuscarHabilidade.Name = "btnBuscarHabilidade";
            btnBuscarHabilidade.Size = new Size(75, 23);
            btnBuscarHabilidade.TabIndex = 2;
            btnBuscarHabilidade.Text = "Buscar";
            btnBuscarHabilidade.UseVisualStyleBackColor = true;
            btnBuscarHabilidade.Click += AoClicarEmBuscarHabilidadeAtualizaFiltroNome;
            // 
            // txtboxFiltroHabilidadeNome
            // 
            txtboxFiltroHabilidadeNome.ForeColor = SystemColors.WindowFrame;
            txtboxFiltroHabilidadeNome.Location = new Point(64, 6);
            txtboxFiltroHabilidadeNome.Name = "txtboxFiltroHabilidadeNome";
            txtboxFiltroHabilidadeNome.PlaceholderText = "Pesquise pelo nome...";
            txtboxFiltroHabilidadeNome.Size = new Size(200, 23);
            txtboxFiltroHabilidadeNome.TabIndex = 1;
            txtboxFiltroHabilidadeNome.KeyDown += AoDigitarEnterEmFiltroNomeAtualizaFiltroHabilidade;
            // 
            // txtboxFiltroHabilidadeId
            // 
            txtboxFiltroHabilidadeId.ForeColor = SystemColors.WindowFrame;
            txtboxFiltroHabilidadeId.Location = new Point(8, 6);
            txtboxFiltroHabilidadeId.Name = "txtboxFiltroHabilidadeId";
            txtboxFiltroHabilidadeId.PlaceholderText = "Id...";
            txtboxFiltroHabilidadeId.Size = new Size(50, 23);
            txtboxFiltroHabilidadeId.TabIndex = 0;
            // 
            // FormularioPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(AbasInicio);
            Controls.Add(menuSuperior);
            MainMenuStrip = menuSuperior;
            Name = "FormularioPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Coder's Growth";
            Load += CarregarFormularioPrincipal;
            menuSuperior.ResumeLayout(false);
            menuSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tabelaPersonagens).EndInit();
            ((System.ComponentModel.ISupportInitialize)personagemBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)personagemServicoBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)personagemServicoBindingSource).EndInit();
            AbasInicio.ResumeLayout(false);
            AbaPersonagem.ResumeLayout(false);
            AbaPersonagem.PerformLayout();
            AbaHabilidade.ResumeLayout(false);
            AbaHabilidade.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tabelaHabilidades).EndInit();
            ((System.ComponentModel.ISupportInitialize)habilidadeBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuSuperior;
        private ToolStripMenuItem menuSuperiorAplicacao;
        private TextBox txtboxFiltroPersonagemNome;
        private DataGridView tabelaPersonagens;
        private BindingSource personagemServicoBindingSource;
        private BindingSource personagemServicoBindingSource1;
        private BindingSource personagemBindingSource;
        private ToolStripMenuItem menuSuperiorAplicacaoCadastro;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem menuSuperiorAplicacaoSair;
        private TextBox txtboxFiltroPersonagemId;
        private TabControl AbasInicio;
        private TabPage AbaPersonagem;
        private TabPage AbaHabilidade;
        private ToolStripMenuItem menuSuperiorCadastroPersonagem;
        private ToolStripMenuItem menuSuperiorCadastroHabilidade;
        private Label lblTotalPersonagens;
        private Button btnFiltrarHabilidade;
        private Button btnBuscarHabilidade;
        private TextBox txtboxFiltroHabilidadeNome;
        private TextBox txtboxFiltroHabilidadeId;
        private Button btnFiltrarPersonagem;
        private Label lblTotalHabilidades;
        private DataGridView tabelaHabilidades;
        private BindingSource habilidadeBindingSource;
        private FirebirdSql.Data.FirebirdClient.FbCommand fbCommand1;
        private Button btnBuscar;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn vidaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn energiaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn velocidadeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn forcaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn inteligenciaDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn eVilaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private Button btnRemoverHabilidade;
        private Button btnRemoverPersonagem;
        private Button btnEditarPersonagem;
        private Button btnEditarHabilidade;
    }
}
