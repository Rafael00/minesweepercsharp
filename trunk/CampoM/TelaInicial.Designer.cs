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
            this.qntBombasEscolhida = new System.Windows.Forms.TextBox();
            this.outroTamanho = new System.Windows.Forms.TextBox();
            this.easy = new System.Windows.Forms.RadioButton();
            this.normal = new System.Windows.Forms.RadioButton();
            this.dificil = new System.Windows.Forms.RadioButton();
            this.expert = new System.Windows.Forms.RadioButton();
            this.outro = new System.Windows.Forms.RadioButton();
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
            this.nomeJogador.MaxLength = 10;
            this.nomeJogador.Name = "nomeJogador";
            this.nomeJogador.Size = new System.Drawing.Size(74, 20);
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
            // qntBombasEscolhida
            // 
            this.qntBombasEscolhida.Location = new System.Drawing.Point(166, 59);
            this.qntBombasEscolhida.Name = "qntBombasEscolhida";
            this.qntBombasEscolhida.Size = new System.Drawing.Size(36, 20);
            this.qntBombasEscolhida.TabIndex = 1;
            this.qntBombasEscolhida.TextChanged += new System.EventHandler(this.qntBombasEscolhida_TextChanged);
            // 
            // outroTamanho
            // 
            this.outroTamanho.Enabled = false;
            this.outroTamanho.Location = new System.Drawing.Point(166, 179);
            this.outroTamanho.Name = "outroTamanho";
            this.outroTamanho.Size = new System.Drawing.Size(32, 20);
            this.outroTamanho.TabIndex = 1;
            this.outroTamanho.TextChanged += new System.EventHandler(this.outroTamanho_TextChanged);
            // 
            // easy
            // 
            this.easy.AutoSize = true;
            this.easy.Checked = true;
            this.easy.Location = new System.Drawing.Point(104, 95);
            this.easy.Name = "easy";
            this.easy.Size = new System.Drawing.Size(47, 17);
            this.easy.TabIndex = 4;
            this.easy.TabStop = true;
            this.easy.Text = "Fácil";
            this.easy.UseVisualStyleBackColor = true;
            this.easy.CheckedChanged += new System.EventHandler(this.facil_CheckedChanged);
            // 
            // normal
            // 
            this.normal.AutoSize = true;
            this.normal.Location = new System.Drawing.Point(104, 118);
            this.normal.Name = "normal";
            this.normal.Size = new System.Drawing.Size(58, 17);
            this.normal.TabIndex = 4;
            this.normal.Text = "Normal";
            this.normal.UseVisualStyleBackColor = true;
            this.normal.CheckedChanged += new System.EventHandler(this.normal_CheckedChanged);
            // 
            // dificil
            // 
            this.dificil.AutoSize = true;
            this.dificil.Location = new System.Drawing.Point(104, 141);
            this.dificil.Name = "dificil";
            this.dificil.Size = new System.Drawing.Size(52, 17);
            this.dificil.TabIndex = 4;
            this.dificil.Text = "Díficil";
            this.dificil.UseVisualStyleBackColor = true;
            this.dificil.CheckedChanged += new System.EventHandler(this.dificil_CheckedChanged);
            // 
            // expert
            // 
            this.expert.AutoSize = true;
            this.expert.Location = new System.Drawing.Point(104, 161);
            this.expert.Name = "expert";
            this.expert.Size = new System.Drawing.Size(55, 17);
            this.expert.TabIndex = 4;
            this.expert.Text = "Expert";
            this.expert.UseVisualStyleBackColor = true;
            this.expert.CheckedChanged += new System.EventHandler(this.expert_CheckedChanged);
            // 
            // outro
            // 
            this.outro.AutoSize = true;
            this.outro.Location = new System.Drawing.Point(104, 182);
            this.outro.Name = "outro";
            this.outro.Size = new System.Drawing.Size(51, 17);
            this.outro.TabIndex = 4;
            this.outro.Text = "Outro";
            this.outro.UseVisualStyleBackColor = true;
            this.outro.CheckedChanged += new System.EventHandler(this.outro_CheckedChanged);
            // 
            // TelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.ControlBox = false;
            this.Controls.Add(this.outro);
            this.Controls.Add(this.expert);
            this.Controls.Add(this.dificil);
            this.Controls.Add(this.normal);
            this.Controls.Add(this.easy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outroTamanho);
            this.Controls.Add(this.qntBombasEscolhida);
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
        private System.Windows.Forms.TextBox qntBombasEscolhida;
        private System.Windows.Forms.TextBox outroTamanho;
        private System.Windows.Forms.RadioButton easy;
        private System.Windows.Forms.RadioButton normal;
        private System.Windows.Forms.RadioButton dificil;
        private System.Windows.Forms.RadioButton expert;
        private System.Windows.Forms.RadioButton outro;
    }
}