using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework;

namespace CampoM
{
    class Tabuleiro
    {
        private Casa[,] tela;
        private Texture2D[] imagens;
        private int _numBombas, tamanho;
        private Random aleatorio;
        private GraphicsDevice graficos;
        private string tipoUltimaCasa;

        public Tabuleiro(GraphicsDevice graficos, int tamanho, int numBombas)
        {
            this.graficos = graficos;
            _numBombas = 250 /*numBombas * (tamanho/2)*/;
            this.tamanho = tamanho;
            tela = new Casa[tamanho, tamanho];
            aleatorio = new Random();
            preencheArrayImagens();
            preencheTabuleiro();
        }

        private void preencheArrayImagens()
        {
            imagens = new Texture2D[12];
            imagens[0] = Texture2D.FromFile(graficos, @"imagens\casaVazia.png");
            imagens[1] = Texture2D.FromFile(graficos, @"imagens\casa1.png");
            imagens[2] = Texture2D.FromFile(graficos, @"imagens\casa2.png");
            imagens[3] = Texture2D.FromFile(graficos, @"imagens\casa3.png");
            imagens[4] = Texture2D.FromFile(graficos, @"imagens\casa4.png");
            imagens[5] = Texture2D.FromFile(graficos, @"imagens\casa5.png");
            imagens[6] = Texture2D.FromFile(graficos, @"imagens\casa6.png");
            imagens[7] = Texture2D.FromFile(graficos, @"imagens\casa7.png");
            imagens[8] = Texture2D.FromFile(graficos, @"imagens\casa8.png");
            imagens[9] = Texture2D.FromFile(graficos, @"imagens\casaBomba.png");
            imagens[10] = Texture2D.FromFile(graficos, @"imagens\BandeiraVermelha.png");
            imagens[11] = Texture2D.FromFile(graficos, @"imagens\BandeiraAzul.png");
        }

        private void preencheTabuleiro()
        {
            for (int i = 0; i < tela.GetLength(0); i++)
                for (int j = 0; j < tela.GetLength(1); j++)
                {
                    tela[i, j] = escolhe(i, j);
                     
                }
            calculaQntBombasVizinhas();
        }

        private void calculaQntBombasVizinhas()
        {
            int linha, coluna, condicaoDeParadaI, condicaoDeParadaJ;
            int qntBombasVizinhas = 0;

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

        private Casa escolhe(int x, int y)
        {
            Casa casa;

            int tipo = aleatorio.Next(0, 7);
            if (tipo <= 2 && _numBombas > 0)
            {
                casa = new ComBomba(this.graficos, x, y);
                _numBombas--;
            }
            else
            {
                casa = new SemBomba(this.graficos, x, y);
            }
            return (casa);
        }

        public int getTamanho
        {
            get { return this.tamanho; }
        }

        public void draw(SpriteBatch _spriteBatch)
        {
            for (int i = 0; i < tela.GetLength(0); i++)
                for (int j = 0; j < tela.GetLength(1); j++)
                    tela[i, j].draw(_spriteBatch);
        }

        private void verificaVizinhos(int i, int j, string jogador)
        {
            if (i >= 0 && j >= 0 && i <= (tela.GetLength(0) - 1) && j <= (tela.GetLength(1) - 1))
                if (tela[i, j].GetEstado == "NAO_VISIVEL" && tela[i, j].QntDeBombasVizinhas == 0)
                {
                    tela[i, j].mudaEstado(this.imagens[0]);
                    verificaVizinhos(i - 1, j - 1, jogador);
                    verificaVizinhos(i - 1, j, jogador);
                    verificaVizinhos(i - 1, j + 1, jogador);
                    verificaVizinhos(i, j - 1, jogador);
                    verificaVizinhos(i, j + 1, jogador);
                    verificaVizinhos(i + 1, j - 1, jogador);
                    verificaVizinhos(i + 1, j, jogador);
                    verificaVizinhos(i + 1, j + 1, jogador);
                }
                else if (tela[i, j].QntDeBombasVizinhas == 9 && jogador.Equals("PC"))
                        //Recebe bandeira vermelha.    
                        tela[i, j].mudaEstado(this.imagens[10]);
                else if (tela[i, j].QntDeBombasVizinhas == 9 && jogador.Equals("HUMANO"))
                        //Recebe bandeira vermelha.    
                        tela[i, j].mudaEstado(this.imagens[11]);
                else tela[i, j].mudaEstado(this.imagens[tela[i,j].QntDeBombasVizinhas]);
        }

        public void JogadaPC(int i, int j)
        {
            verificaVizinhos(i, j, "PC");
        }

        public void Update()
        {/*
            for (int i = 0; i < tela.GetLength(0); i++)
                for (int j = 0; j < tela.GetLength(1); j++)
                    if (tela[i, j].getRetangulo.Contains(mouseX, mouseY) == true)
                    {
                        verificaVizinhos(i, j, "HUMANO");
                        return tela[i, j];
                    }
            return null;*/
        }

        public string GetTipoDaUltimaCasaClicada
        {
            get { return tipoUltimaCasa; }
            set { this.tipoUltimaCasa = value; }
        }


        public bool CasaJaClicada(int mouseX, int mouseY)
        {
            for (int i = 0; i < tela.GetLength(0); i++)
                for (int j = 0; j < tela.GetLength(1); j++)
                    if (tela[i, j].getRetangulo.Contains(mouseX, mouseY) == true)
                        if (tela[i, j].GetEstado.Equals("NAO_VISIVEL"))
                        {
                            verificaVizinhos(i, j, "HUMANO");
                            tipoUltimaCasa = tela[i,j].ToString();
                            return false;
                        }
                        else return true;
            return true;
        }
    }
}
