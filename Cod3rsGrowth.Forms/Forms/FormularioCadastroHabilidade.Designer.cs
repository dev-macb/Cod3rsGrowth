namespace Cod3rsGrowth.Forms.Forms
{
    partial class FormularioCadastroHabilidade
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
            txtboxNomeHabilidadeCadastro = new TextBox();
            labelNomeHabilidadeCadastro = new Label();
            labelDescricaoHabilidadeCadastro = new Label();
            txtboxDescricaoHabilidadeCadastro = new TextBox();
            btnCancelarHabilidadeCadastro = new Button();
            btnSalvarHabilidadeCadastro = new Button();
            SuspendLayout();
            // 
            // txtboxNomeHabilidadeCadastro
            // 
            txtboxNomeHabilidadeCadastro.Location = new Point(12, 27);
            txtboxNomeHabilidadeCadastro.Name = "txtboxNomeHabilidadeCadastro";
            txtboxNomeHabilidadeCadastro.PlaceholderText = "Digite um nome...";
            txtboxNomeHabilidadeCadastro.Size = new Size(400, 23);
            txtboxNomeHabilidadeCadastro.TabIndex = 0;
            // 
            // labelNomeHabilidadeCadastro
            // 
            labelNomeHabilidadeCadastro.AutoSize = true;
            labelNomeHabilidadeCadastro.Location = new Point(12, 9);
            labelNomeHabilidadeCadastro.Name = "labelNomeHabilidadeCadastro";
            labelNomeHabilidadeCadastro.Size = new Size(43, 15);
            labelNomeHabilidadeCadastro.TabIndex = 1;
            labelNomeHabilidadeCadastro.Text = "Nome:";
            // 
            // labelDescricaoHabilidadeCadastro
            // 
            labelDescricaoHabilidadeCadastro.AutoSize = true;
            labelDescricaoHabilidadeCadastro.Location = new Point(12, 53);
            labelDescricaoHabilidadeCadastro.Name = "labelDescricaoHabilidadeCadastro";
            labelDescricaoHabilidadeCadastro.Size = new Size(61, 15);
            labelDescricaoHabilidadeCadastro.TabIndex = 2;
            labelDescricaoHabilidadeCadastro.Text = "Descrição:";
            // 
            // txtboxDescricaoHabilidadeCadastro
            // 
            txtboxDescricaoHabilidadeCadastro.Location = new Point(12, 71);
            txtboxDescricaoHabilidadeCadastro.Multiline = true;
            txtboxDescricaoHabilidadeCadastro.Name = "txtboxDescricaoHabilidadeCadastro";
            txtboxDescricaoHabilidadeCadastro.PlaceholderText = "Digite uma descrição para a habilidade...";
            txtboxDescricaoHabilidadeCadastro.Size = new Size(400, 150);
            txtboxDescricaoHabilidadeCadastro.TabIndex = 3;
            // 
            // btnCancelarHabilidadeCadastro
            // 
            btnCancelarHabilidadeCadastro.Location = new Point(256, 227);
            btnCancelarHabilidadeCadastro.Name = "btnCancelarHabilidadeCadastro";
            btnCancelarHabilidadeCadastro.Size = new Size(75, 23);
            btnCancelarHabilidadeCadastro.TabIndex = 4;
            btnCancelarHabilidadeCadastro.Text = "Cancelar";
            btnCancelarHabilidadeCadastro.UseVisualStyleBackColor = true;
            btnCancelarHabilidadeCadastro.Click += btnCancelarHabilidadeCadastro_Click;
            // 
            // btnSalvarHabilidadeCadastro
            // 
            btnSalvarHabilidadeCadastro.Location = new Point(337, 227);
            btnSalvarHabilidadeCadastro.Name = "btnSalvarHabilidadeCadastro";
            btnSalvarHabilidadeCadastro.Size = new Size(75, 23);
            btnSalvarHabilidadeCadastro.TabIndex = 5;
            btnSalvarHabilidadeCadastro.Text = "Salvar";
            btnSalvarHabilidadeCadastro.UseVisualStyleBackColor = true;
            btnSalvarHabilidadeCadastro.Click += btnSalvarHabilidadeCadastro_Click;
            // 
            // FormularioCadastroHabilidade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 261);
            Controls.Add(btnSalvarHabilidadeCadastro);
            Controls.Add(btnCancelarHabilidadeCadastro);
            Controls.Add(txtboxDescricaoHabilidadeCadastro);
            Controls.Add(labelDescricaoHabilidadeCadastro);
            Controls.Add(labelNomeHabilidadeCadastro);
            Controls.Add(txtboxNomeHabilidadeCadastro);
            Name = "FormularioCadastroHabilidade";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro - Habilidade";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtboxNomeHabilidadeCadastro;
        private Label labelNomeHabilidadeCadastro;
        private Label labelDescricaoHabilidadeCadastro;
        private TextBox txtboxDescricaoHabilidadeCadastro;
        private Button btnCancelarHabilidadeCadastro;
        private Button btnSalvarHabilidadeCadastro;
    }
}