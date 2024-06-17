namespace Cod3rsGrowth.Forms.Forms
{
    partial class Form1
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
            labelNomePersonagemCadastro = new Label();
            textBox1 = new TextBox();
            labelVidaPersonagemCadastro = new Label();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            SuspendLayout();
            // 
            // labelNomePersonagemCadastro
            // 
            labelNomePersonagemCadastro.AutoSize = true;
            labelNomePersonagemCadastro.Location = new Point(12, 9);
            labelNomePersonagemCadastro.Name = "labelNomePersonagemCadastro";
            labelNomePersonagemCadastro.Size = new Size(43, 15);
            labelNomePersonagemCadastro.TabIndex = 0;
            labelNomePersonagemCadastro.Text = "Nome:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(400, 23);
            textBox1.TabIndex = 1;
            // 
            // labelVidaPersonagemCadastro
            // 
            labelVidaPersonagemCadastro.AutoSize = true;
            labelVidaPersonagemCadastro.Location = new Point(12, 53);
            labelVidaPersonagemCadastro.Name = "labelVidaPersonagemCadastro";
            labelVidaPersonagemCadastro.Size = new Size(33, 15);
            labelVidaPersonagemCadastro.TabIndex = 2;
            labelVidaPersonagemCadastro.Text = "Vida:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(12, 71);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(129, 23);
            numericUpDown1.TabIndex = 3;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(147, 71);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(130, 23);
            numericUpDown2.TabIndex = 4;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(283, 71);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(129, 23);
            numericUpDown3.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(147, 53);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 6;
            label1.Text = "Energia:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(283, 53);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 7;
            label2.Text = "Velocidade:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 97);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 8;
            label3.Text = "Força:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(217, 97);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 9;
            label4.Text = "Inteligência:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 115);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(195, 23);
            comboBox1.TabIndex = 10;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(217, 115);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(195, 23);
            comboBox2.TabIndex = 11;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(12, 144);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(54, 19);
            radioButton1.TabIndex = 12;
            radioButton1.TabStop = true;
            radioButton1.Text = "Herói";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(72, 144);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(51, 19);
            radioButton2.TabIndex = 13;
            radioButton2.TabStop = true;
            radioButton2.Text = "Vilão";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 450);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(labelVidaPersonagemCadastro);
            Controls.Add(textBox1);
            Controls.Add(labelNomePersonagemCadastro);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNomePersonagemCadastro;
        private TextBox textBox1;
        private Label labelVidaPersonagemCadastro;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
    }
}