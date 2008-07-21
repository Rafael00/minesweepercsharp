using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace CampoM
{
    class Jogo
    {
        private int qntBombas, tamanhoTab;
        private Tabuleiro tabuleiro;
        private const string HUMANO = "HUMANO";
        private const string PC = "PC";
        private string jogadorDaVez;
        private PC jogadorPC;
        private Humano jogadorHumano;
        private MouseState ultimoEstado, estadoAtual;
        private ImageManager Im;

        public Jogo(string nomeJogador, int tamanhoTab, int qntBombas, GraphicsDevice graficos)
        {
            jogadorPC = new PC("Android");
            jogadorHumano = new Humano(nomeJogador);
            this.tamanhoTab = tamanhoTab;
            this.qntBombas = qntBombas;
            Im = new ImageManager(graficos);
            jogadorDaVez = HUMANO;
            tabuleiro = new Tabuleiro(graficos, this.tamanhoTab, this.qntBombas, Im);
            
        }

        public int GetTamanhoTabuleiro
        {
            get {return tabuleiro.getTamanho; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            tabuleiro.draw(spriteBatch);
            jogadorPC.Draw(spriteBatch, Im);
            //jogadorHumano.Draw(spriteBatch, Im);
        }

        
        public void Update()
        {
            if (jogadorDaVez == PC)
            {
                //System.Threading.Thread.Sleep(1500);
                AndroidJoga();
                return;
            }
            estadoAtual = Mouse.GetState();
            if (estadoAtual.LeftButton == ButtonState.Pressed
                && ultimoEstado.LeftButton == ButtonState.Released)
                {
                    GerenciaJogada(Mouse.GetState().X, Mouse.GetState().Y);
                }
            ultimoEstado = estadoAtual;
        }

        private void FinalizaJogo(Jogador jogador)
        {
            //Criar o Windows form mostrando o vencedor.
            //Application.Run(ti);
            Console.WriteLine("{0} GANHOUUU!!!!", jogador.GetNomeJogador);
        }

        private void GerenciaJogada(int mouseX, int mouseY)
        {
            //Verifica se nenhuma casa foi clicada ou se a casa já foi clicada. Caso afirmativo nao faz nada.
            if (tabuleiro.CasaClicada(mouseX, mouseY))
                //Nao faz nada se a casa já tivesse sido clicada antes.
                return;
            //Se a casa clicada nao tiver bomba, eu passo a vez para android jogar.
            if (tabuleiro.GetTipoDaUltimaCasaClicada.Equals("CampoM.SemBomba"))
                jogadorDaVez = PC;
            else
            {
                jogadorDaVez = HUMANO;
                jogadorHumano.GetBombasEncontradas = 1;
            }
            VerificaFimDoJogo();
        }

        private void VerificaFimDoJogo()
        {
            if (jogadorPC.GetBombasEncontradas == qntBombas / 2 + 1)
                FinalizaJogo(jogadorPC);
            else if (jogadorHumano.GetBombasEncontradas == qntBombas / 2 + 1)
                FinalizaJogo(jogadorHumano);
        }
        
        private void AndroidJoga()
        {
            jogadorPC.Joga(tabuleiro.GetTela);
            tabuleiro.JogadaPC(jogadorPC.GetColunaJogada, jogadorPC.GetLinhaJogada);
            //Caso ele acerte uma bomba ele verifica se o jogo acabou e se nao estiver acabado joga novamente.
            if (!VerificaSeAcertou(jogadorPC.GetColunaJogada, jogadorPC.GetLinhaJogada))
                jogadorDaVez = HUMANO;
            Console.WriteLine("Android jogou!!! i: {0} j: {1}", jogadorPC.GetLinhaJogada, jogadorPC.GetColunaJogada);
            Console.WriteLine("Android Acertou {0} bombas", jogadorPC.GetBombasEncontradas);
            VerificaFimDoJogo();
        }

        private bool VerificaSeAcertou(int coluna, int linha)
        {
            if (tabuleiro.GetTela[coluna, linha].ToString().Equals("CampoM.ComBomba"))
            {
                Console.WriteLine("INCREMENTOU BOMBAS ANDROID");
                jogadorPC.GetBombasEncontradas = 1;
                return true;
            }
            return false;
        }
    }
}
