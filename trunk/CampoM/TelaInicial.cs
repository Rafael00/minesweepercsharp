using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CampoM
{
    public partial class TelaInicial : Form
    {
        private string nome;
        private int tamanho, qntBombas;
 
        public TelaInicial()
        {
            InitializeComponent();
        }

        private void nomeJogador_TextChanged(object sender, EventArgs e)
        {
            nome = nomeJogador.Text;
        }

        private void OkNome_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void easy_CheckStateChanged(object sender, EventArgs e)
        {
            if (easy.Checked == true)
            {
                tamanho = 5;
                qntBombas = 10;
            }

        }

        private void normal_CheckedChanged(object sender, EventArgs e)
        {
            if (normal.Checked == true)
            {
                tamanho = 10;
                qntBombas = 40;
            }
        }

        private void hard_CheckedChanged(object sender, EventArgs e)
        {
            if (hard.Checked == true)
            {
                tamanho = 15;
                qntBombas = 70;
            }
        }

        private void expert_CheckedChanged(object sender, EventArgs e)
        {
            if (expert.Checked == true)
            {
                tamanho = 20;
                qntBombas = 100;
            }
        }

        private void tabuleiro_TextChanged(object sender, EventArgs e)
        {
            tamanho = int.Parse(this.tabuleiro.Text);
        }

        private void qntBombasText_TextChanged(object sender, EventArgs e)
        {
            qntBombas = int.Parse(this.qntBombasText.Text);
        }
        

        public int getTamanho
        {
            get { return this.tamanho; }

        }

        private void TelaInicial_Load(object sender, EventArgs e)
        {

        }

        public int getQntBombas
        {
            get { return 5;}
        }
    }
}
