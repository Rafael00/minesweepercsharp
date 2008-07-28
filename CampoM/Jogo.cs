using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CampoM
{
    /// <summary>
    /// Classe que administrará o jogo.
    /// </summary>
    class Jogo
    {
        private int qntBombasRestantes, qntTotalDeBombas, posicaoSelecaoY, posicaoSelecaoX;
        private Tabuleiro tabuleiro;
        private const string HUMANO = "HUMANO";
        private const string PC = "PC";
        private string jogadorDaVez;
        private PC jogadorPC;
        private Humano jogadorHumano;
        private Jogador vencedor;
        private ImageManager Im;

        /// <summary>
        /// Instancia o jogo.
        /// </summary>
        /// <param name="nomeJogador">Nome do jogador humano</param>
        /// <param name="tamanhoTab">Tamanho do tabuleiro. Neste caso quadrado.</param>
        /// <param name="qntBombas">Quantidade de bombas</param>
        /// <param name="localizacao">É determinado a partir da escolha de dificudade escolhida.</param>
        /// <param name="graficos">Possibilitará que as texturas sejam desenhadas na tela.</param>
        public Jogo(string nomeJogador, int tamanhoTab, int qntBombas, int localizacao, GraphicsDevice graficos)
        {
            jogadorPC = new PC("Android");
            jogadorHumano = new Humano(nomeJogador);
            qntTotalDeBombas = qntBombas;
            qntBombasRestantes = qntBombas;
            Im = new ImageManager(graficos);
            jogadorDaVez = HUMANO;
            //Cria um tabuleiro com os parâmetros recebidos.
            tabuleiro = new Tabuleiro(graficos, tamanhoTab, qntTotalDeBombas, localizacao, Im);
            
        }

        /// <summary>
        /// Retorna o tamanho do tabuleiro.
        /// </summary>
        public int GetTamanhoTabuleiro
        {
            get {return tabuleiro.GetTamanho; }
        }

        /// <summary>
        /// Desenha o jogo na tela. Atribuindo a cada objeto a responsabilidade de se desenhar.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="contador">Responsável por desenhar a quantidade restante de bombas.</param>
        /// <param name="nome">Responsável por desenhar os nomes dos jogadores.</param>
        public void Draw(SpriteBatch spriteBatch, SpriteFont contador, SpriteFont nome)
        {
            tabuleiro.Draw(spriteBatch);
            jogadorPC.Draw(spriteBatch, contador, nome);
            jogadorHumano.Draw(spriteBatch, contador, nome);
            UltimaCasaClicada(spriteBatch);
            spriteBatch.DrawString(contador, "" + qntBombasRestantes, new Vector2(49, 265), Color.White);

            if (jogadorDaVez == PC)
            {
                spriteBatch.Draw(Im.GetSetaPC, new Rectangle(10, 320, 29, 29), Color.White);
                
            }
            else spriteBatch.Draw(Im.GetSetaHumano, new Rectangle(10, 67, 29, 29), Color.White);
        }

        /// <summary>
        /// Marca qual foi a posição da última jogada de cada jogador.
        /// </summary>
        /// <param name="spriteBatch"></param>
        private void UltimaCasaClicada(SpriteBatch spriteBatch)
        {
            Casa casa = tabuleiro.UltimaCasaClicada;
            if (casa != null)
            {
                spriteBatch.Draw(Im.GetSelecaoAzul, new Rectangle(casa.GetPosicaoX, casa.GetPosicaoY, 30, 30), Color.White);
                spriteBatch.Draw(Im.GetSelecaoVermelha, new Rectangle(posicaoSelecaoX, posicaoSelecaoY, 30, 30), Color.White);
            }
        }
        
        /// <summary>
        /// Verifica de quem é a vez de jogar.
        /// </summary>
        public void Update()
        {
            if (jogadorDaVez == PC)
            {
                AndroidJoga();
                return;
            }
            GerenciaJogada(Mouse.GetState().X, Mouse.GetState().Y);
        }

        /// <summary>
        /// Retorna o jogador da vez.
        /// </summary>
        public string GetJogadorDaVez
        {
            get { return jogadorDaVez; }
        }

        /// <summary>
        /// Gerencia a jogada do jogador humano.
        /// </summary>
        /// <param name="mouseX">Posição X do clique do mouse.</param>
        /// <param name="mouseY">Posição Y do clique do mouse.</param>
        private void GerenciaJogada(int mouseX, int mouseY)
        {
            //Verifica se nenhuma casa foi clicada ou se a casa já foi clicada. Caso afirmativo nao faz nada.
            //Caso negativo, a jogada é efetuada.
            if (tabuleiro.CasaClicada(mouseX, mouseY))
                //Nao faz nada se a casa já tivesse sido clicada antes.
                return;
            //Se a casa clicada nao tiver bomba, eu passo a vez para android jogar.
            if (tabuleiro.UltimaCasaClicada.ToString().Equals("CampoM.SemBomba"))
                jogadorDaVez = PC;
            else
            {
                jogadorDaVez = HUMANO;
                qntBombasRestantes -= 1;
                jogadorHumano.BombasEncontradas = 1;
            }
            VerificaFimDoJogo();
        }

        /// <summary>
        /// Retorna o vencedor do jogo.
        /// </summary>
        public Jogador GetVencedor
        {
            get { return vencedor; }
        }

        /// <summary>
        /// Verifica se algum dos jogadores já obteve a métade + 1 da quantidade de bombas.
        /// </summary>
        /// <returns>True se o jogo acabou.</returns>
        public bool VerificaFimDoJogo()
        {
            if (jogadorPC.BombasEncontradas >= qntTotalDeBombas / 2 + 1)
            {
                vencedor = jogadorPC;
                return true;
            }
            if (jogadorHumano.BombasEncontradas >= qntTotalDeBombas / 2 + 1)
            {
                vencedor = jogadorHumano;
                return true;
            }
            return false;
        }
        

        /// <summary>
        /// Possibilita ao jogador PC fazer sua jogada.
        /// </summary>
        private void AndroidJoga()
        {
            jogadorPC.Joga(tabuleiro.GetTela);
            tabuleiro.JogadaPC(jogadorPC.GetColunaJogada, jogadorPC.GetLinhaJogada);
            posicaoSelecaoX = tabuleiro.GetTela[jogadorPC.GetColunaJogada, jogadorPC.GetLinhaJogada].GetPosicaoX;
            posicaoSelecaoY = tabuleiro.GetTela[jogadorPC.GetColunaJogada, jogadorPC.GetLinhaJogada].GetPosicaoY;
            //Caso ele acerte uma bomba ele verifica se o jogo acabou e se nao estiver acabado joga novamente.
            if (!VerificaSeAcertou(jogadorPC.GetColunaJogada, jogadorPC.GetLinhaJogada))
                jogadorDaVez = HUMANO;
            VerificaFimDoJogo();
        }

        /// <summary>
        /// Verifica se o jogador acertou uma casa com bomba.
        /// </summary>
        /// <param name="coluna">Coluna da casa clicada.</param>
        /// <param name="linha">Linha da casa clicada.</param>
        /// <returns>True se o jogador acertou.</returns>
        private bool VerificaSeAcertou(int coluna, int linha)
        {
            if (tabuleiro.GetTela[coluna, linha].ToString().Equals("CampoM.ComBomba"))
            {
                qntBombasRestantes -= 1;
                jogadorPC.BombasEncontradas = 1;
                return true;
            }
            return false;
        }
    }
}
