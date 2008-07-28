using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CampoM
{
    class Tabuleiro
    {
        private Casa[,] tela;
        private int numBombas, tamanho, localizacao;
        private Random aleatorio;
        private GraphicsDevice graficos;
        private Casa ultimaCasaClicada;
        private ImageManager Im;

        /// <summary>
        /// Cria um tabuleiro do jogo.
        /// </summary>
        /// <param name="graficos"></param>
        /// <param name="tamanho">Tamanho do tabuleiro.</param>
        /// <param name="numBombas">Número de bombas deste tabuleiro.</param>
        /// <param name="localizacao">Centralização das casas.</param>
        /// <param name="imageManager">Manipulador das imagens.</param>
        public Tabuleiro(GraphicsDevice graficos, int tamanho, int numBombas, int localizacao, ImageManager imageManager)
        {
            this.graficos = graficos;
            this.numBombas = numBombas;
            this.tamanho = tamanho;
            this.localizacao = localizacao;
            Im = imageManager;
            tela = new Casa[tamanho, tamanho];
            aleatorio = new Random();
            PreencheTabuleiro();
        }

        /// <summary>
        /// Preenche o tabuleiro.
        /// </summary>
        private void PreencheTabuleiro()
        {
            PreencheComCasaBomba();
            PreencheComCasaSemBomba();
            CalculaQntBombasVizinhas();
        }

        /// <summary>
        /// Calcula a quantidade de bombas vizinhas a cada casa.
        /// </summary>
        private void CalculaQntBombasVizinhas()
        {
            int linha, coluna, condicaoDeParadaI, condicaoDeParadaJ, qntBombasVizinhas = 0;

            for (int i = 0; i < tela.GetLength(0); i++)
                for (int j = 0; j < tela.GetLength(1); j++){
                    if (tela[i, j].GetType().FullName.Equals("CampoM.ComBomba"))
                    {
                        tela[i, j].QntDeBombasVizinhas = 9;
                        continue;
                    }
                    if ( i == 0)
                        linha = 0;
                    else linha = -1;
                    if ( j == 0)
                        coluna = 0;
                    else coluna = -1;

                    if ( i == tela.GetLength(0) - 1)
                        condicaoDeParadaI = 0;
                    else condicaoDeParadaI = 1;
                    if ( j == tela.GetLength(1) - 1)
                        condicaoDeParadaJ = 0;
                    else condicaoDeParadaJ = 1;

                    while (coluna <= condicaoDeParadaJ)
                    {
                        while (linha <= condicaoDeParadaI)
                        {
                            if (tela[i + linha, j + coluna].GetType().FullName.Equals("CampoM.ComBomba"))
                                qntBombasVizinhas += 1;
                            linha += 1;
                        }
                        coluna += 1;
                        if ( i == 0)
                            linha = 0;
                        else linha = -1;
                    }
                    tela[i, j].QntDeBombasVizinhas = qntBombasVizinhas;
                    qntBombasVizinhas = 0;
                }
        }

        /// <summary>
        /// Preenche o tabuleiro com casas bombas. Com igual probabilidade de cada ser bomba. 
        /// </summary>
        private void PreencheComCasaBomba()
        {
            int linha, coluna, numBombasAux = numBombas;
            while (numBombasAux > 0)
            {
                linha = aleatorio.Next(0, tamanho);
                coluna = aleatorio.Next(0, tamanho);
                if (tela[linha, coluna] == null)
                {
                    tela[linha, coluna] = new ComBomba(graficos, linha, coluna, localizacao);
                    numBombasAux--;
                }
            }
        }
  
        /// <summary>
        /// Preenche o restante(casas que não foram escolhidas no método PreencheComCasaBomba) do tabuleiro com casas sem bombas.
        /// </summary>
        private void PreencheComCasaSemBomba(){
            for (int i = 0; i < tela.GetLength(0); i++)
                for (int j = 0; j < tela.GetLength(1); j++)
                    if (tela[i, j] == null)
                        tela[i, j] = new SemBomba(graficos, i, j, localizacao);
        }

        /// <summary>
        /// Retorna o tamanho do tabuleiro.
        /// </summary>
        public int GetTamanho
        {
            get { return tamanho; }
        }

        /// <summary>
        /// Desenha cada casa e o placar do jogo.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < tela.GetLength(0); i++)
                for (int j = 0; j < tela.GetLength(1); j++)
                    tela[i, j].Draw(spriteBatch);
            spriteBatch.Draw(Im.GetImagemPlacar, new Rectangle(0, 20, 124, 518), Color.White);
        }
        
        /// <summary>
        /// Verifica recursivamente, caso a casa seja vazia, se os vizinhos desta casa também são vazios. E muda o estado desta casa.
        /// </summary>
        /// <param name="i">Posição i da casa.</param>
        /// <param name="j">Posição j da casa.</param>
        /// <param name="jogador">Jogador da vez.</param>
        private void VerificaVizinhos(int i, int j, string jogador)
        {
            if (i >= 0 && j >= 0 && i <= (tela.GetLength(0) - 1) && j <= (tela.GetLength(1) - 1))
                if (tela[i, j].Estado == "NAO_VISIVEL" && tela[i, j].QntDeBombasVizinhas == 0)
                {
                    tela[i, j].MudaEstado(Im.GetImagemCasa(0));
                    //Chamadas recursivas para verificar se  os vizinhos desta casa também são vazios.
                    VerificaVizinhos(i - 1, j - 1, jogador);
                    VerificaVizinhos(i - 1, j, jogador);
                    VerificaVizinhos(i - 1, j + 1, jogador);
                    VerificaVizinhos(i, j - 1, jogador);
                    VerificaVizinhos(i, j + 1, jogador);
                    VerificaVizinhos(i + 1, j - 1, jogador);
                    VerificaVizinhos(i + 1, j, jogador);
                    VerificaVizinhos(i + 1, j + 1, jogador);
                }
                else if (tela[i, j].QntDeBombasVizinhas == 9 && jogador.Equals("PC"))
                        //Recebe bandeira vermelha.    
                        tela[i, j].MudaEstado(Im.GetImagemCasa(10));
                else if (tela[i, j].QntDeBombasVizinhas == 9 && jogador.Equals("HUMANO"))
                        //Recebe bandeira vermelha.    
                        tela[i, j].MudaEstado(Im.GetImagemCasa(11));
                else tela[i, j].MudaEstado(Im.GetImagemCasa(tela[i,j].QntDeBombasVizinhas));
        }

        /// <summary>
        /// Processa a jogada do PC.
        /// </summary>
        /// <param name="i">Posição i da jogada.</param>
        /// <param name="j">Posição j da jogada.</param>
        public void JogadaPC(int i, int j)
        {
            VerificaVizinhos(i, j, "PC");
        }

        /// <summary>
        /// Retorna a última casa clicada.
        /// </summary>
        public Casa UltimaCasaClicada
        {
            get { return ultimaCasaClicada; }
            set { ultimaCasaClicada = value; }
        }

        /// <summary>
        /// Retorna a tela atual do jogo.
        /// </summary>
        public Casa[,] GetTela
        {
            get { return tela; }
        }

        /// <summary>
        /// Verifica se uma casa já foi clicada. Caso contrário faz as verificações nesta casa.
        /// </summary>
        /// <param name="mouseX"></param>
        /// <param name="mouseY"></param>
        /// <returns>True se a casa já tinha sido clicada.</returns>
        public bool CasaClicada(int mouseX, int mouseY)
        {
            for (int i = 0; i < tela.GetLength(0); i++)
                for (int j = 0; j < tela.GetLength(1); j++)
                    //Verifica se a posição do clique está dentro do quadrado delimitador desta casa.
                    if (tela[i, j].GetRetangulo.Contains(mouseX, mouseY))
                        if (tela[i, j].Estado.Equals("NAO_VISIVEL"))
                        {
                            VerificaVizinhos(i, j, "HUMANO");
                            UltimaCasaClicada = tela[i, j];
                            return false;
                        }
                        //Retorna true se a casa ja tinha sido clicada antes.
                        else return true;
            return true;
        }
    }
}
