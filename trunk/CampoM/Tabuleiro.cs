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

        public Tabuleiro(GraphicsDevice graficos, int tamanho, int numBombas, int localizacao, ImageManager imageManager)
        {
            this.graficos = graficos;
            this.numBombas = numBombas;
            this.tamanho = tamanho;
            this.localizacao = localizacao;
            Im = imageManager;
            tela = new Casa[tamanho, tamanho];
            aleatorio = new Random();
            preencheTabuleiro();
        }

        private void preencheTabuleiro()
        {
            PreencheComCasaBomba();
            PreencheComCasaSemBomba();
            CalculaQntBombasVizinhas();
        }

        private void CalculaQntBombasVizinhas()
        {
            int linha, coluna, condicaoDeParadaI, condicaoDeParadaJ, qntBombasVizinhas = 0;

            for (int i = 0; i < tela.GetLength(0); i++)
                for (int j = 0; j < tela.GetLength(1); j++){
                    if (tela[i, j].GetType().FullName.Equals("CampoM.ComBomba"))
                    {
                        tela[i, j].GetQntDeBombasVizinhas = 9;
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
                    tela[i, j].GetQntDeBombasVizinhas = qntBombasVizinhas;
                    qntBombasVizinhas = 0;
                }
        }

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
  
        private void PreencheComCasaSemBomba(){
            for (int i = 0; i < tela.GetLength(0); i++)
                for (int j = 0; j < tela.GetLength(1); j++)
                    if (tela[i, j] == null)
                        tela[i, j] = new SemBomba(graficos, i, j, localizacao);
        }
        
        public int getTamanho
        {
            get { return tamanho; }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < tela.GetLength(0); i++)
                for (int j = 0; j < tela.GetLength(1); j++)
                    tela[i, j].draw(spriteBatch);
            spriteBatch.Draw(Im.GetImagemPlacar, new Rectangle(0, 20, 124, 518), Color.White);
        }
                   

        private void verificaVizinhos(int i, int j, string jogador)
        {
            if (i >= 0 && j >= 0 && i <= (tela.GetLength(0) - 1) && j <= (tela.GetLength(1) - 1))
                if (tela[i, j].GetEstado == "NAO_VISIVEL" && tela[i, j].GetQntDeBombasVizinhas == 0)
                {
                    tela[i, j].mudaEstado(this.Im.GetImagemCasa(0));
                    verificaVizinhos(i - 1, j - 1, jogador);
                    verificaVizinhos(i - 1, j, jogador);
                    verificaVizinhos(i - 1, j + 1, jogador);
                    verificaVizinhos(i, j - 1, jogador);
                    verificaVizinhos(i, j + 1, jogador);
                    verificaVizinhos(i + 1, j - 1, jogador);
                    verificaVizinhos(i + 1, j, jogador);
                    verificaVizinhos(i + 1, j + 1, jogador);
                }
                else if (tela[i, j].GetQntDeBombasVizinhas == 9 && jogador.Equals("PC"))
                        //Recebe bandeira vermelha.    
                        tela[i, j].mudaEstado(Im.GetImagemCasa(10));
                else if (tela[i, j].GetQntDeBombasVizinhas == 9 && jogador.Equals("HUMANO"))
                        //Recebe bandeira vermelha.    
                        tela[i, j].mudaEstado(Im.GetImagemCasa(11));
                else tela[i, j].mudaEstado(Im.GetImagemCasa(tela[i,j].GetQntDeBombasVizinhas));
        }

        public void JogadaPC(int i, int j)
        {
            verificaVizinhos(i, j, "PC");
        }

        public Casa UltimaCasaClicada
        {
            get { return ultimaCasaClicada; }
            set { ultimaCasaClicada = value; }
        }

        public Casa[,] GetTela
        {
            get { return tela; }
        }

        public bool CasaClicada(int mouseX, int mouseY)
        {
            for (int i = 0; i < tela.GetLength(0); i++)
                for (int j = 0; j < tela.GetLength(1); j++)
                    if (tela[i, j].getRetangulo.Contains(mouseX, mouseY))
                        if (tela[i, j].GetEstado.Equals("NAO_VISIVEL"))
                        {
                            verificaVizinhos(i, j, "HUMANO");
                            ultimaCasaClicada = tela[i, j];
                            return false;
                        }
                        //Retorna true se a casa ja tinha sido clicada antes.
                        else return true;
            return true;
        }
    }
}
