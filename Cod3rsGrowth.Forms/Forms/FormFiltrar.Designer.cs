namespace Cod3rsGrowth.Forms.Forms
{
    partial class FormularioFiltros
    {
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
            datetimeFiltroDataBase = new DateTimePicker();
            datetimeFiltroDataTeto = new DateTimePicker();
            labelDataBase = new Label();
            labelDataTeto = new Label();
            radioVilao = new RadioButton();
            grupoDataCriacao = new GroupBox();
            grupoOutros = new GroupBox();
            radioHeroi = new RadioButton();
            btnAplicar = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            btnResetar = new Button();
            grupoDataCriacao.SuspendLayout();
            grupoOutros.SuspendLayout();
            SuspendLayout();
            // 
            // datetimeFiltroDataBase
            // 
            datetimeFiltroDataBase.Location = new Point(8, 37);
            datetimeFiltroDataBase.Name = "datetimeFiltroDataBase";
            datetimeFiltroDataBase.Size = new Size(250, 23);
            datetimeFiltroDataBase.TabIndex = 0;
            // 
            // datetimeFiltroDataTeto
            // 
            datetimeFiltroDataTeto.Location = new Point(8, 81);
            datetimeFiltroDataTeto.Name = "datetimeFiltroDataTeto";
            datetimeFiltroDataTeto.Size = new Size(250, 23);
            datetimeFiltroDataTeto.TabIndex = 1;
            // 
            // labelDataBase
            // 
            labelDataBase.AutoSize = true;
            labelDataBase.Location = new Point(8, 21);
            labelDataBase.Name = "labelDataBase";
            labelDataBase.Size = new Size(24, 15);
            labelDataBase.TabIndex = 2;
            labelDataBase.Text = "De:";
            // 
            // labelDataTeto
            // 
            labelDataTeto.AutoSize = true;
            labelDataTeto.Location = new Point(8, 63);
            labelDataTeto.Name = "labelDataTeto";
            labelDataTeto.Size = new Size(28, 15);
            labelDataTeto.TabIndex = 3;
            labelDataTeto.Text = "Até:";
            // 
            // radioVilao
            // 
            radioVilao.AutoSize = true;
            radioVilao.Location = new Point(68, 22);
            radioVilao.Name = "radioVilao";
            radioVilao.Size = new Size(51, 19);
            radioVilao.TabIndex = 5;
            radioVilao.TabStop = true;
            radioVilao.Text = "Vilão";
            radioVilao.UseVisualStyleBackColor = true;
            // 
            // grupoDataCriacao
            // 
            grupoDataCriacao.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grupoDataCriacao.Controls.Add(labelDataBase);
            grupoDataCriacao.Controls.Add(datetimeFiltroDataBase);
            grupoDataCriacao.Controls.Add(labelDataTeto);
            grupoDataCriacao.Controls.Add(datetimeFiltroDataTeto);
            grupoDataCriacao.Location = new Point(12, 12);
            grupoDataCriacao.Name = "grupoDataCriacao";
            grupoDataCriacao.Padding = new Padding(5);
            grupoDataCriacao.Size = new Size(270, 115);
            grupoDataCriacao.TabIndex = 6;
            grupoDataCriacao.TabStop = false;
            grupoDataCriacao.Text = "Data de Criação";
            // 
            // grupoOutros
            // 
            grupoOutros.Controls.Add(radioHeroi);
            grupoOutros.Controls.Add(radioVilao);
            grupoOutros.Location = new Point(12, 133);
            grupoOutros.Name = "grupoOutros";
            grupoOutros.Size = new Size(270, 50);
            grupoOutros.TabIndex = 8;
            grupoOutros.TabStop = false;
            grupoOutros.Text = "Outros";
            // 
            // radioHeroi
            // 
            radioHeroi.AutoSize = true;
            radioHeroi.Location = new Point(8, 22);
            radioHeroi.Name = "radioHeroi";
            radioHeroi.Size = new Size(54, 19);
            radioHeroi.TabIndex = 6;
            radioHeroi.TabStop = true;
            radioHeroi.Text = "Herói";
            radioHeroi.UseVisualStyleBackColor = true;
            // 
            // btnAplicar
            // 
            btnAplicar.Location = new Point(207, 189);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(75, 23);
            btnAplicar.TabIndex = 9;
            btnAplicar.Text = "Aplicar";
            btnAplicar.UseVisualStyleBackColor = true;
            btnAplicar.Click += AoClicarNoButaoAplcarFechaOsFiltros;
            // 
            // btnResetar
            // 
            btnResetar.Location = new Point(126, 189);
            btnResetar.Name = "btnResetar";
            btnResetar.Size = new Size(75, 23);
            btnResetar.TabIndex = 10;
            btnResetar.Text = "Resetar";
            btnResetar.UseVisualStyleBackColor = true;
            btnResetar.Click += AoClicarNoButaoResetarLimpaOsFiltros;
            // 
            // FormularioFiltros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(294, 224);
            Controls.Add(btnResetar);
            Controls.Add(btnAplicar);
            Controls.Add(grupoOutros);
            Controls.Add(grupoDataCriacao);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormularioFiltros";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Filtros";
            grupoDataCriacao.ResumeLayout(false);
            grupoDataCriacao.PerformLayout();
            grupoOutros.ResumeLayout(false);
            grupoOutros.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker datetimeFiltroDataBase;
        private DateTimePicker datetimeFiltroDataTeto;
        private Label labelDataBase;
        private Label labelDataTeto;
        private RadioButton radioVilao;
        private GroupBox grupoDataCriacao;
        private GroupBox grupoOutros;
        private Button btnAplicar;
        private RadioButton radioHeroi;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btnResetar;
    }
}