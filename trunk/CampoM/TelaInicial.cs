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
        private int tamanho;
 
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
                tamanho = 5;

        }

        private void normal_CheckedChanged(object sender, EventArgs e)
        {
            if (normal.Checked == true)
                tamanho = 10;
        }

        private void hard_CheckedChanged(object sender, EventArgs e)
        {
            if (hard.Checked == true)
                tamanho = 15;
        }

        private void expert_CheckedChanged(object sender, EventArgs e)
        {
            if (expert.Checked == true)
                tamanho = 20;
        }

//        public Tabuleiro getTabuleiro
//        {
//            get { return this.tabuleiro; }
     //  }
      
        public int getTamanho
        {
            get { return this.tamanho; }
        }

   //     public int getQntBombas
    //    {
//            get { return this.qntBombas.Text;}
     //   }

    }
}
