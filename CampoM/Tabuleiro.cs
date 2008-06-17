using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace CampoM
{
    class Tabuleiro
    {
        private Casa[,]tela;
        private int _numBombas;
        private Random aleatorio;
        private GraphicsDevice graficos;

        public Tabuleiro(GraphicsDevice graficos, int tamanho, int numBombas)
        {
            this.graficos = graficos;
            _numBombas = numBombas * (tamanho/2) ;
            tela = new Casa[tamanho, tamanho];
            aleatorio = new Random();
            preenche();
        }

        private void preenche()
        {
            for (int i = 0; i < tela.GetLength(0); i++)
                for (int j = 0; j < tela.GetLength(1); j++)
                {
                    tela[i, j] = escolhe(i, j);
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


        public void draw(SpriteBatch _spriteBatch)
        {
            for (int i = 0; i < tela.GetLength(0); i++)
                for (int j = 0; j < tela.GetLength(1); j++)
                    tela[i, j].draw(_spriteBatch);
        }


        public void Update(GameTime gameTime)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                for (int i = 0; i < tela.GetLength(0); i++)
                    for (int j = 0; j < tela.GetLength(1); j++)
                        if (tela[i,j].getRetangulo.Contains(Mouse.GetState().X, Mouse.GetState().Y) == true)
                            {
                                tela[i, j].mudaEstado();
                            }
        }

    }
}
