using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CampoM
{
    class Jogo
    {
        private int qntBombasRestantes, tamanhoTab, qntTotalDeBombas;
        private Tabuleiro tabuleiro;
        private const string HUMANO = "HUMANO";
        private const string PC = "PC";
        private string jogadorDaVez;
        private PC jogadorPC;
        private Humano jogadorHumano;
        private Jogador vencedor;
        private MouseState ultimoEstado, estadoAtual;
        private ImageManager Im;

        public Jogo(string nomeJogador, int tamanhoTab, int qntBombas, int localizacao, GraphicsDevice graficos)
        {
            jogadorPC = new PC("Android");
            jogadorHumano = new Humano(nomeJogador);
            this.tamanhoTab = tamanhoTab;
            qntTotalDeBombas = qntBombas;
            qntBombasRestantes = qntBombas;
            Im = new ImageManager(graficos);
            jogadorDaVez = HUMANO;
            tabuleiro = new Tabuleiro(graficos, this.tamanhoTab, qntTotalDeBombas, localizacao, Im);
            
        }

        public int GetTamanhoTabuleiro
        {
            get {return tabuleiro.getTamanho; }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont contador, SpriteFont nome)
        {
            tabuleiro.draw(spriteBatch);
            jogadorPC.Draw(spriteBatch, contador, nome);
            jogadorHumano.Draw(spriteBatch, contador, nome);
            spriteBatch.DrawString(contador, "" + qntBombasRestantes, new Vector2(49, 265), Color.White);
            if (jogadorDaVez == PC)
                spriteBatch.Draw(Im.GetSetaPC, new Rectangle(10, 320, 29, 29), Color.White);
            else spriteBatch.Draw(Im.GetSetaHumano, new Rectangle(10, 67, 29, 29), Color.White);
        }
        
        public void Update()
        {
            if (jogadorDaVez == PC)
            {
                System.Threading.Thread.Sleep(1000);
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
                qntBombasRestantes -= 1;
                jogadorHumano.GetBombasEncontradas = 1;
            }
            VerificaFimDoJogo();
        }

        public Jogador GetVencedor
        {
            get { return vencedor; }
        }

        public bool VerificaFimDoJogo()
        {
            if (jogadorPC.GetBombasEncontradas >= qntTotalDeBombas / 2 + 1)
            {
                vencedor = jogadorPC;
                return true;
            }
            if (jogadorHumano.GetBombasEncontradas >= qntTotalDeBombas / 2 + 1)
            {
                vencedor = jogadorHumano;
                return true;
            }
            return false;
        }
        
        private void AndroidJoga()
        {
            jogadorPC.Joga(tabuleiro.GetTela);
            tabuleiro.JogadaPC(jogadorPC.GetColunaJogada, jogadorPC.GetLinhaJogada);
            //Caso ele acerte uma bomba ele verifica se o jogo acabou e se nao estiver acabado joga novamente.
            if (!VerificaSeAcertou(jogadorPC.GetColunaJogada, jogadorPC.GetLinhaJogada))
                jogadorDaVez = HUMANO;
            VerificaFimDoJogo();
        }

        private bool VerificaSeAcertou(int coluna, int linha)
        {
            if (tabuleiro.GetTela[coluna, linha].ToString().Equals("CampoM.ComBomba"))
            {
                Console.WriteLine("INCREMENTOU BOMBAS ANDROID");
                qntBombasRestantes -= 1;
                jogadorPC.GetBombasEncontradas = 1;
                return true;
            }
            return false;
        }
    }
}
