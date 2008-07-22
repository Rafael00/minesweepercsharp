using System;
using System.Windows.Forms;

namespace CampoM
{
    public partial class TelaInicial : Form
    {
        private string nome;
        private int tamanho, qntBombas, localizacao, aumentaTela;
 
        public TelaInicial()
        {
            InitializeComponent();
            nome = "";
        }

        private void nomeJogador_TextChanged(object sender, EventArgs e)
        {
            nome = nomeJogador.Text;
        }

        private void OkNome_Click(object sender, EventArgs e)
        {
            if (!outroTamanho.Text.Equals(""))
            {
                int valor = int.Parse(outroTamanho.Text);
                if (valor > 20)
                {
                    aumentaTela = valor - 20;
                    localizacao = 0;
                }else
                    localizacao = (560 - valor * 28)/2;
                if (qntBombasEscolhida.Text.Equals(""))
                    qntBombas = (int) (valor * valor * 0.2);
            }
            Close();
        }

        private void facil_CheckedChanged(object sender, EventArgs e)
        {
                //Tamanho do tabuleiro. 5x5;
                tamanho = 5;
                //Utilizado para imprimir as casa no meio da tela.
                localizacao = (560 - 5*28)/2;
                if (qntBombasEscolhida.Text.Equals(""))
                    //Quantidade de bombas referente a esse nivel.
                    qntBombas = 7;
        }

        private void normal_CheckedChanged(object sender, EventArgs e)
        {
                tamanho = 10;
                localizacao = (560 - 10 * 28) / 2;
                if (qntBombasEscolhida.Text.Equals(""))
                    qntBombas = 27;
        }

        private void dificil_CheckedChanged(object sender, EventArgs e)
        {
                tamanho = 15;
                localizacao = (560 - 15 * 28) / 2;
                if (qntBombasEscolhida.Text.Equals(""))
                    qntBombas = 51;
        }

        private void expert_CheckedChanged(object sender, EventArgs e)
        {
                tamanho = 20;
                localizacao = 0;
                //79 bombas proporcao correta.
                if (qntBombasEscolhida.Text.Equals(""))     
                    qntBombas = 79;
        }

        private void outroTamanho_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tamanho = int.Parse(outroTamanho.Text);
            }
            catch
            {
                outroTamanho.Text = "";
            }
        }

        private void qntBombasEscolhida_TextChanged(object sender, EventArgs e)
        {
            try
            {
                qntBombas = int.Parse(qntBombasEscolhida.Text);
            }
            catch 
            {
                qntBombasEscolhida.Text = "";
            }
        }
        
        public int getTamanho
        {
            get { return tamanho; }

        }

        public int getQntBombas
        {
            get { return qntBombas; }
        }

        public int getLocalizao
        {
            get { return localizacao; }
        }

        public int getAumentaTela
        {
            get { return aumentaTela; }
        }

        public string GetNomeJogador()
        {
            if (nome.Equals(""))
                return "Guest";
            return nome;
        }

        private void outro_CheckedChanged(object sender, EventArgs e)
        {
            if(outro.Checked)
                outroTamanho.Enabled = true;
            else outroTamanho.Enabled = false;
        }

        private void TelaInicial_Load(object sender, EventArgs e)
        {
            //Tamanho do tabuleiro. 5x5;
            tamanho = 5;
            //Utilizado para imprimir as casa no meio da tela.
            localizacao = (560 - 5 * 28) / 2;
            //Quantidade de bombas referente a esse nivel.
            qntBombas = 7;
        }
    }
}
