using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CampoM
{
    class PC : Jogador
    {
        private Posicao posicao;
        private int qntVizinhosVisiveisNaoBombas;

        /// <summary>
        /// Cria um jogador PC.
        /// </summary>
        /// <param name="nomeJogador"></param>
        public PC(string nomeJogador)
            : base(nomeJogador)
        {
        }

        /// <summary>
        /// Reponsável por dá inteligência as jogadas do PC.
        /// </summary>
        /// <param name="tela">Recebe a tela atual.</param>
        public void Joga(Casa[,] tela)
        {
            Random aleatorio = new Random();
            //Caso 1. Único vizinho. Retorna a posicao da casa a ser jogada.
            for (int i = 0; i < tela.GetLength(0); i++)
                for (int j = 0; j < tela.GetLength(1); j++)
                    if (tela[j, i].Estado.Equals("VISIVEL") && tela[j, i].ToString().Equals("CampoM.SemBomba") && tela[j, i].QntDeBombasVizinhas != 0)
                    {
                        posicao = UnicoVizinho(tela, j, i);
                        if (posicao != null)
                        {
                            int qntBombas = QntVizinhosVisivelBombas(tela, j, i);
                            if (qntBombas != tela[j, i].QntDeBombasVizinhas)
                            {
                                Console.WriteLine("CASO 1.");
                                return;
                            }
                        }
                    }

            //Caso 2. Todos os vizinhos são bombas.
            for (int i = 0; i < tela.GetLength(0); i++)
                for (int j = 0; j < tela.GetLength(1); j++)
                    if (tela[j, i].Estado.Equals("VISIVEL") && tela[j, i].ToString().Equals("CampoM.SemBomba") && tela[j, i].QntDeBombasVizinhas != 0)
                    {
                        posicao = TodosVizinhosBombas(tela, j, i);
                        if (posicao != null)
                        {
                            Console.WriteLine("CASO 2.");
                            return;
                        }
                    }

            //Caso nenhum dos casos seja satisfeito ele joga aleatório.
            posicao = new Posicao(aleatorio.Next(0, tela.GetLength(0)), aleatorio.Next(0, tela.GetLength(0)));
            Console.WriteLine("JOGOU ALEATORIO.");
            while (tela[posicao.GetColuna, posicao.GetLinha].Estado.Equals("VISIVEL"))
            {
                //caso nenhum dos casos seja satisfeito ele joga aleatório.
                posicao = new Posicao(aleatorio.Next(0, tela.GetLength(0)), aleatorio.Next(0, tela.GetLength(0)));
                Console.WriteLine("JOGOU ALEATORIO.");
            }

        }

        /// <summary>
        /// Retorna a linha escolhida para esta jogada.
        /// </summary>
        public int GetLinhaJogada
        {
            get { return posicao.GetLinha; }
        }

        /// <summary>
        /// Retorna a coluna escolhida para esta jogada.
        /// </summary>
        public int GetColunaJogada
        {
            get { return posicao.GetColuna; }
        }

        /// <summary>
        /// Verifica se todos os vizinhos não visiveis da casa são bombas.
        /// </summary>
        /// <param name="tela"></param>
        /// <param name="coluna"></param>
        /// <param name="linha"></param>
        /// <returns></returns>
        private Posicao TodosVizinhosBombas(Casa[,] tela, int coluna, int linha)
        {
            int vizinhosVisiveisBombas = QntVizinhosVisivelBombas(tela, coluna, linha);
            int qntTotalDeVizinhosVisiveis = vizinhosVisiveisBombas + qntVizinhosVisiveisNaoBombas;
            //Total de casas 8 menos a qnt de casas vizinhas visiveis.
            int qntVizinhosNaoVisiveis = 8 - qntTotalDeVizinhosVisiveis;
            if (tela[coluna, linha].QntDeBombasVizinhas - vizinhosVisiveisBombas > 0 && tela[coluna, linha].QntDeBombasVizinhas - vizinhosVisiveisBombas == qntVizinhosNaoVisiveis)
                //Esta posicao aqui retornada é de uma(aleatorio) das casas visiveis dessa bomba(já que todas são bombas).
                return posicao;
            //if (qntVizinhosNaoVisiveis == tela[coluna, linha].GetQntDeBombasVizinhas && vizinhosVisiveisBombas == 0)
            //Cria uma probabilidade de erro. Caso ela seja menor que 33% ele arisca.
            //float proporcao = vizinhosVisiveisBombas / qntTotalDeVizinhosVisiveis;
            //if (8 - qntVizinhosVisiveisNaoBombas == tela[coluna, linha].GetQntDeBombasVizinhas || (proporcao <= 0.33 && proporcao > 0))
            //    return posicao;
            //Esta casa não satisfaz esse caso.
            return null;                
        }

        /// <summary>
        /// Verifica se a casa posicão um unico vizinho visivel e se ele é bomba.
        /// </summary>
        /// <param name="tela"></param>
        /// <param name="coluna"></param>
        /// <param name="linha"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Calcula a quantidade de vizinhos visiveis que são bombas.
        /// </summary>
        /// <param name="tela"></param>
        /// <param name="j"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private int QntVizinhosVisivelBombas(Casa[,] tela, int j, int i)
        {
            qntVizinhosVisiveisNaoBombas = 0;
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
                    //Incrementa a qnt de casa vizinhas a esta que é bombas e está visível.
                    if (tela[j + coluna, i + linha].ToString().Equals("CampoM.ComBomba") && tela[j + coluna, i + linha].Estado.Equals("VISIVEL"))
                        qntVizinhosBombas++;
                    //Incrementa a qnt de casa vizinhas a esta que nao é bomba e está visível.
                    else if (tela[j + coluna, i + linha].Estado.Equals("VISIVEL"))
                            qntVizinhosVisiveisNaoBombas++;
                    //Guarda uma posicao de uma casa que não é visível.
                    if (tela[j + coluna, i + linha].Estado.Equals("NAO_VISIVEL"))
                        //Neste caso essa posição só será usada se a escolha da jogada for o caso 2.
                        posicao = new Posicao(j + coluna, i + linha);
                    linha += 1;
                }
                coluna += 1;
                if ( i == 0)
                    linha = 0;
                else linha = -1;
            }
            return qntVizinhosBombas;
        }
    
        /// <summary>
        /// Verifica se uma casa possui apenas um vizinho.
        /// </summary>
        /// <param name="tela">Tela atual do jogo.</param>
        /// <param name="j">Posição j da casa.</param>
        /// <param name="i">Posição i da casa.</param>
        /// <param name="quina">Verifica qual quina única que nao está visível.</param>
        /// <returns>True se for uma quina única.(Apenas ela não é visível.)</returns>
        private bool VerificaVizinhoUnico(Casa[,] tela, int j, int i, string quina)
        {
            string Q1, Q2, Q3, Q4;
            try
            {
                //Verifica se todos os vizinhos laterais sao visiveis. Só após ele verifica a respectiva quina.
                if (tela[j, i - 1].Estado.Equals("VISIVEL") &&
                    tela[j - 1, i].Estado.Equals("VISIVEL") &&
                    tela[j + 1, i].Estado.Equals("VISIVEL") &&
                    tela[j, i + 1].Estado.Equals("VISIVEL"))
                {
                    switch (quina)
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
                    if (tela[j - 1, i - 1].Estado.Equals(Q1) &&
                        tela[j + 1, i - 1].Estado.Equals(Q2) &&
                        tela[j - 1, i + 1].Estado.Equals(Q3) &&
                        tela[j + 1, i + 1].Estado.Equals(Q4))
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

        /// <summary>
        /// Desenha a quantidade de bombas encontradas até o momento e o seu nome.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="contador"></param>
        /// <param name="nome"></param>
        public void Draw(SpriteBatch spriteBatch, SpriteFont contador, SpriteFont nome)
        {
            //Imprime na tela a quantidade de bombas encontradas ate o momento.
            spriteBatch.DrawString(contador, ""+ BombasEncontradas, new Vector2(34, 479), Color.Red);
            //Imprime o nome do jogador.
            spriteBatch.DrawString(nome, GetNomeJogador, new Vector2(22, 378), Color.DarkRed);
        }
    }
}
