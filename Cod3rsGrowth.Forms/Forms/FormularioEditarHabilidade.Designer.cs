namespace Cod3rsGrowth.Forms.Forms
{
    partial class FormularioEditarHabilidade
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
            btnSalvar = new Button();
            btnCancelar = new Button();
            txtboxDescricao = new TextBox();
            labelDescricao = new Label();
            labelNome = new Label();
            txtboxNome = new TextBox();
            labelId = new Label();
            labelCriadoEm = new Label();
            labelAtualizadoEm = new Label();
            SuspendLayout();
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(337, 246);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 11;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(256, 246);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += AoClicarEmCancelarFechaFormularioEditarHabilidade;
            // 
            // txtboxDescricao
            // 
            txtboxDescricao.Location = new Point(12, 86);
            txtboxDescricao.Multiline = true;
            txtboxDescricao.Name = "txtboxDescricao";
            txtboxDescricao.PlaceholderText = "Digite uma descrição para a habilidade...";
            txtboxDescricao.Size = new Size(400, 150);
            txtboxDescricao.TabIndex = 9;
            // 
            // labelDescricao
            // 
            labelDescricao.AutoSize = true;
            labelDescricao.Location = new Point(12, 68);
            labelDescricao.Name = "labelDescricao";
            labelDescricao.Size = new Size(61, 15);
            labelDescricao.TabIndex = 8;
            labelDescricao.Text = "Descrição:";
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Location = new Point(12, 24);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(43, 15);
            labelNome.TabIndex = 7;
            labelNome.Text = "Nome:";
            // 
            // txtboxNome
            // 
            txtboxNome.Location = new Point(12, 42);
            txtboxNome.Name = "txtboxNome";
            txtboxNome.PlaceholderText = "Digite um nome...";
            txtboxNome.Size = new Size(400, 23);
            txtboxNome.TabIndex = 6;
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.ForeColor = SystemColors.ControlDark;
            labelId.Location = new Point(12, 9);
            labelId.Name = "labelId";
            labelId.Size = new Size(32, 15);
            labelId.TabIndex = 12;
            labelId.Text = "Id: ...";
            // 
            // labelCriadoEm
            // 
            labelCriadoEm.AutoSize = true;
            labelCriadoEm.ForeColor = SystemColors.ControlDark;
            labelCriadoEm.Location = new Point(12, 239);
            labelCriadoEm.Name = "labelCriadoEm";
            labelCriadoEm.Size = new Size(77, 15);
            labelCriadoEm.TabIndex = 13;
            labelCriadoEm.Text = "Criado em: ...";
            // 
            // labelAtualizadoEm
            // 
            labelAtualizadoEm.AutoSize = true;
            labelAtualizadoEm.ForeColor = SystemColors.ControlDark;
            labelAtualizadoEm.Location = new Point(12, 254);
            labelAtualizadoEm.Name = "labelAtualizadoEm";
            labelAtualizadoEm.Size = new Size(98, 15);
            labelAtualizadoEm.TabIndex = 14;
            labelAtualizadoEm.Text = "Atualizado em: ...";
            // 
            // FormularioEditarHabilidade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 276);
            Controls.Add(labelAtualizadoEm);
            Controls.Add(labelCriadoEm);
            Controls.Add(labelId);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Controls.Add(txtboxDescricao);
            Controls.Add(labelDescricao);
            Controls.Add(labelNome);
            Controls.Add(txtboxNome);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormularioEditarHabilidade";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Editar - Habilidade";
            Load += CarregarFormularioEditarHabilidade;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalvar;
        private Button btnCancelar;
        private TextBox txtboxDescricao;
        private Label labelDescricao;
        private Label labelNome;
        private TextBox txtboxNome;
        private Label labelId;
        private Label labelCriadoEm;
        private Label labelAtualizadoEm;
    }
}