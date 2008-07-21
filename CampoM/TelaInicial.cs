using System;
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
                qntBombas = 7;
            }

        }

        private void normal_CheckedChanged(object sender, EventArgs e)
        {
            if (normal.Checked == true)
            {
                tamanho = 10;
                qntBombas = 27;
            }
        }

        private void hard_CheckedChanged(object sender, EventArgs e)
        {
            if (hard.Checked == true)
            {
                tamanho = 15;
                qntBombas = 51;
            }
        }

        private void expert_CheckedChanged(object sender, EventArgs e)
        {
            if (expert.Checked == true)
            {
                tamanho = 20;
                qntBombas = 79;
            }
        }

        private void tabuleiro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tamanho = int.Parse(this.tabuleiro.Text);
            }
            catch
            {
                //if (tabuleiro.Text.Length > 0)
                   //tabuleiro.Text = tabuleiro.Text.Substring(0, tabuleiro.Text.Length - 1);
                tabuleiro.Text = "";
            }
        }

        private void qntBombasText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                qntBombas = int.Parse(this.qntBombasText.Text);
            }
            catch 
            {
                qntBombasText.Text = "";
            }
        }
        
        public int getTamanho
        {
            get { return this.tamanho; }

        }

        public int getQntBombas
        {
            get { return this.qntBombas; }
        }

        public string getNomeJogador
        {
            get { return this.nome; }
        }

        private void TelaInicial_Load(object sender, EventArgs e)
        {

        }


    }
}
