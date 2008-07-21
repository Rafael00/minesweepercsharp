using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CampoM
{
    class PC : Jogador
    {
        private Posicao posicao;
        //private Texture2D jogada;

        public PC(string nomeJogador)
            : base(nomeJogador)
        {
          //  this.jogada = jogada;
        }

        public void Joga(Casa[,] tela)
        {
            Random aleatorio = new Random();
            for (int i = 0; i < tela.GetLength(0); i++)
                for (int j = 0; j < tela.GetLength(1); j++)
                    if (tela[j, i].GetEstado.Equals("VISIVEL") && tela[j, i].ToString().Equals("CampoM.SemBomba") && tela[j, i].GetQntDeBombasVizinhas != 0)
                    {
                       //Caso 1. Único vizinho. Retorna a posicao da casa a ser jogada.
                       posicao = UnicoVizinho(tela, j, i);
                       if (posicao != null)
                       {
                           int qntBombas = QntVizinhosVisivelBombas(tela, j, i);
                           Console.WriteLine("BOMBAS VISIVEIS VIZINHAS A: [{0}, {1}] é: {2}", j, i, qntBombas);
                           if (qntBombas != tela[j, i].GetQntDeBombasVizinhas)
                           {
                               Console.WriteLine("ANALISOU A CASA: {0}, {1}", i, j);
                               return;
                           }
                       }
                    }
            //caso nenhum dos casos seja satisfeito ele joga aleatório.
            posicao = new Posicao(aleatorio.Next(0, tela.GetLength(0)), aleatorio.Next(0, tela.GetLength(0)));
            while (tela[posicao.GetColuna, posicao.GetLinha].GetEstado.Equals("VISIVEL"))
                //caso nenhum dos casos seja satisfeito ele joga aleatório.
                posicao = new Posicao(aleatorio.Next(0, tela.GetLength(0)), aleatorio.Next(0, tela.GetLength(0)));

        }

        public int GetLinhaJogada
        {
            get { return posicao.GetLinha; }
        }

        public int GetColunaJogada
        {
            get { return posicao.GetColuna; }
        }

        private Posicao UnicoVizinho(Casa[,] tela, int coluna, int linha)
        {
            if (VerificaVizinhoUnico(tela, coluna, linha, "QUINA1"))
                return new Posicao(coluna - 1, linha - 1);
            if (VerificaVizinhoUnico(tela, coluna, linha, "QUINA2"))
                return new Posicao(coluna + 1, linha - 1);
            if (VerificaVizinhoUnico(tela, coluna, linha, "QUINA3"))
                return new Posicao(coluna - 1, linha + 1);
            if (VerificaVizinhoUnico(tela, coluna, linha, "QUINA4"))
                return new Posicao(coluna + 1, linha + 1);
            return null;
        }

        private int QntVizinhosVisivelBombas(Casa[,] tela, int j, int i)
        {
            int linha, coluna, condicaoDeParadaI, condicaoDeParadaJ, qntVizinhosBombas = 0;
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
                    if (tela[i + linha, j + coluna].ToString().Equals("CampoM.ComBomba") && tela[i + linha, j + coluna].GetEstado.Equals("VISIVEL"))
                        qntVizinhosBombas++;
                    linha += 1;
                }
                coluna += 1;
                if ( i == 0)
                    linha = 0;
                else linha = -1;
            }
            return qntVizinhosBombas;
        }
    
        private bool VerificaVizinhoUnico(Casa[,] tela, int j, int i, string vizinho)
        {
            string Q1, Q2, Q3, Q4;
            try
            {
                //Verifica se todos os vizinhos laterais sao visiveis. Só após ele verifica a respectiva quina.
                if (tela[j, i - 1].GetEstado.Equals("VISIVEL") &&
                    tela[j - 1, i].GetEstado.Equals("VISIVEL") &&
                    tela[j + 1, i].GetEstado.Equals("VISIVEL") &&
                    tela[j, i + 1].GetEstado.Equals("VISIVEL"))
                {
                    switch (vizinho)
                    {
                        case "QUINA1":
                            Q1 = "NAO_VISIVEL";
                            Q2 = Q3 = Q4 = "VISIVEL";
                            break;
                        case "QUINA2":
                            Q2 = "NAO_VISIVEL";
                            Q1 = Q3 = Q4 = "VISIVEL";
                            break;
                        case "QUINA3":
                            Q3 = "NAO_VISIVEL";
                            Q2 = Q1 = Q4 = "VISIVEL";
                            break;
                        default:
                            Q4 = "NAO_VISIVEL";
                            Q2 = Q1 = Q3 = "VISIVEL";
                            break;
                    }
                    if (tela[j - 1, i - 1].GetEstado.Equals(Q1) &&
                        tela[ j + 1, i - 1].GetEstado.Equals(Q2) &&
                        tela[j - 1, i + 1].GetEstado.Equals(Q3) &&
                        tela[j + 1, i + 1].GetEstado.Equals(Q4))
                        return true;
                return false;
                }
                return false;
            }
            catch
            {
                return false;
            }
       }

        public void Draw(SpriteBatch spriteBatch, ImageManager Im)
        {
            int dezena = GetBombasEncontradas / 10;
            int unidade = GetBombasEncontradas - (dezena * 10);
            spriteBatch.Draw(Im.GetImagemContador(dezena), new Rectangle(0, 270, 29, 28), Color.White);
            spriteBatch.Draw(Im.GetImagemContador(unidade), new Rectangle(0, 0, 29, 28), Color.White);
        }
    }
}
