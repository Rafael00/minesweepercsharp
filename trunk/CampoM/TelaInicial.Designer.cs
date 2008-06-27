namespace CampoM
{
    partial class TelaInicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaInicial));
            this.OkNome = new System.Windows.Forms.Button();
            this.nomeJogador = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.qntBombasText = new System.Windows.Forms.TextBox();
            this.easy = new System.Windows.Forms.CheckBox();
            this.normal = new System.Windows.Forms.CheckBox();
            this.hard = new System.Windows.Forms.CheckBox();
            this.expert = new System.Windows.Forms.CheckBox();
            this.tabuleiro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OkNome
            // 
            this.OkNome.Location = new System.Drawing.Point(100, 223);
            this.OkNome.Name = "OkNome";
            this.OkNome.Size = new System.Drawing.Size(75, 23);
            this.OkNome.TabIndex = 0;
            this.OkNome.TabStop = false;
            this.OkNome.Text = "OK";
            this.OkNome.UseVisualStyleBackColor = true;
            this.OkNome.Click += new System.EventHandler(this.OkNome_Click);
            // 
            // nomeJogador
            // 
            this.nomeJogador.Location = new System.Drawing.Point(128, 30);
            this.nomeJogador.Name = "nomeJogador";
            this.nomeJogador.Size = new System.Drawing.Size(100, 20);
            this.nomeJogador.TabIndex = 1;
            this.nomeJogador.TextChanged += new System.EventHandler(this.nomeJogador_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quantidade de bombas:";
            // 
            // qntBombasText
            // 
            this.qntBombasText.Location = new System.Drawing.Point(192, 59);
            this.qntBombasText.Name = "qntBombasText";
            this.qntBombasText.Size = new System.Drawing.Size(36, 20);
            this.qntBombasText.TabIndex = 1;
            this.qntBombasText.TextChanged += new System.EventHandler(this.qntBombasText_TextChanged);
            // 
            // easy
            // 
            this.easy.AutoSize = true;
            this.easy.Location = new System.Drawing.Point(116, 95);
            this.easy.Name = "easy";
            this.easy.Size = new System.Drawing.Size(49, 17);
            this.easy.TabIndex = 3;
            this.easy.Text = "Easy";
            this.easy.UseVisualStyleBackColor = true;
            this.easy.CheckStateChanged += new System.EventHandler(this.easy_CheckStateChanged);
            // 
            // normal
            // 
            this.normal.AutoSize = true;
            this.normal.Location = new System.Drawing.Point(116, 118);
            this.normal.Name = "normal";
            this.normal.Size = new System.Drawing.Size(59, 17);
            this.normal.TabIndex = 3;
            this.normal.Text = "Normal";
            this.normal.UseVisualStyleBackColor = true;
            this.normal.CheckedChanged += new System.EventHandler(this.normal_CheckedChanged);
            // 
            // hard
            // 
            this.hard.AutoSize = true;
            this.hard.Location = new System.Drawing.Point(116, 141);
            this.hard.Name = "hard";
            this.hard.Size = new System.Drawing.Size(49, 17);
            this.hard.TabIndex = 3;
            this.hard.Text = "Hard";
            this.hard.UseVisualStyleBackColor = true;
            this.hard.CheckedChanged += new System.EventHandler(this.hard_CheckedChanged);
            // 
            // expert
            // 
            this.expert.AutoSize = true;
            this.expert.Location = new System.Drawing.Point(116, 164);
            this.expert.Name = "expert";
            this.expert.Size = new System.Drawing.Size(56, 17);
            this.expert.TabIndex = 3;
            this.expert.Text = "Expert";
            this.expert.UseVisualStyleBackColor = true;
            this.expert.CheckedChanged += new System.EventHandler(this.expert_CheckedChanged);
            // 
            // tabuleiro
            // 
            this.tabuleiro.Location = new System.Drawing.Point(140, 184);
            this.tabuleiro.Name = "tabuleiro";
            this.tabuleiro.Size = new System.Drawing.Size(32, 20);
            this.tabuleiro.TabIndex = 1;
            this.tabuleiro.TextChanged += new System.EventHandler(this.tabuleiro_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Outro:";
            // 
            // TelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.expert);
            this.Controls.Add(this.hard);
            this.Controls.Add(this.normal);
            this.Controls.Add(this.easy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabuleiro);
            this.Controls.Add(this.qntBombasText);
            this.Controls.Add(this.nomeJogador);
            this.Controls.Add(this.OkNome);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TelaInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Campo Minado";
            this.Load += new System.EventHandler(this.TelaInicial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkNome;
        private System.Windows.Forms.TextBox nomeJogador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox qntBombasText;
        private System.Windows.Forms.CheckBox easy;
        private System.Windows.Forms.CheckBox normal;
        private System.Windows.Forms.CheckBox hard;
        private System.Windows.Forms.CheckBox expert;
        private System.Windows.Forms.TextBox tabuleiro;
        private System.Windows.Forms.Label label3;
    }
}