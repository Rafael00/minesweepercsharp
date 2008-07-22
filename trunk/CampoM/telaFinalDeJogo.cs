using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CampoM
{
    public partial class telaFinalDeJogo : Form
    {
        private string nomeVencedor;

        public telaFinalDeJogo(string nomeVencedor)
        {
            this.nomeVencedor = nomeVencedor;
            InitializeComponent();
        }

        private void telaFinalDeJogo_Load(object sender, EventArgs e)
        {
            vencedor.Text = nomeVencedor;
        }

        private void Jogar_Click(object sender, EventArgs e)
        {

        }

        private void Sair_Click(object sender, EventArgs e)
        {

        }
    }
}
