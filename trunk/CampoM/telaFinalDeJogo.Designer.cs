namespace CampoM
{
    partial class telaFinalDeJogo
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
            this.resultado = new System.Windows.Forms.Label();
            this.Jogar = new System.Windows.Forms.Button();
            this.Sair = new System.Windows.Forms.Button();
            this.vencedor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // resultado
            // 
            this.resultado.AutoSize = true;
            this.resultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultado.Location = new System.Drawing.Point(55, 33);
            this.resultado.Name = "resultado";
            this.resultado.Size = new System.Drawing.Size(0, 24);
            this.resultado.TabIndex = 0;
            this.resultado.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Jogar
            // 
            this.Jogar.Location = new System.Drawing.Point(111, 79);
            this.Jogar.Name = "Jogar";
            this.Jogar.Size = new System.Drawing.Size(75, 23);
            this.Jogar.TabIndex = 1;
            this.Jogar.Text = "Jogar";
            this.Jogar.UseVisualStyleBackColor = true;
            this.Jogar.Click += new System.EventHandler(this.Jogar_Click);
            // 
            // Sair
            // 
            this.Sair.Location = new System.Drawing.Point(111, 108);
            this.Sair.Name = "Sair";
            this.Sair.Size = new System.Drawing.Size(75, 23);
            this.Sair.TabIndex = 1;
            this.Sair.Text = "Sair";
            this.Sair.UseVisualStyleBackColor = true;
            this.Sair.Click += new System.EventHandler(this.Sair_Click);
            // 
            // vencedor
            // 
            this.vencedor.AutoSize = true;
            this.vencedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vencedor.Location = new System.Drawing.Point(62, 13);
            this.vencedor.Name = "vencedor";
            this.vencedor.Size = new System.Drawing.Size(0, 29);
            this.vencedor.TabIndex = 2;
            this.vencedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // telaFinalDeJogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 164);
            this.Controls.Add(this.vencedor);
            this.Controls.Add(this.Sair);
            this.Controls.Add(this.Jogar);
            this.Controls.Add(this.resultado);
            this.Name = "telaFinalDeJogo";
            this.Text = "Campo Minado";
            this.Load += new System.EventHandler(this.telaFinalDeJogo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label resultado;
        private System.Windows.Forms.Button Jogar;
        private System.Windows.Forms.Button Sair;
        private System.Windows.Forms.Label vencedor;
    }
}