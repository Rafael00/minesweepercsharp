using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;

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


        public Jogo(string nomeJogador, int tamanhoTab, int qntBombas, GraphicsDevice graficos)
        {
            jogadorPC = new PC("Android");
            jogadorHumano = new Humano(nomeJogador);
            this.tamanhoTab = tamanhoTab;
            this.qntBombas = qntBombas;
            this.jogadorDaVez = HUMANO;
            this.tabuleiro = new Tabuleiro(graficos, this.tamanhoTab, this.qntBombas);

        }


        public int GetTamanhoTabuleiro
        {
            get {return this.tabuleiro.getTamanho; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.tabuleiro.draw(spriteBatch);
        }

        public void Update()
        {
            Casa casa;

            if (Mouse.GetState().LeftButton == ButtonStatePressed)
            {
                casa = this.tabuleiro.Update(Mouse.GetState().X, Mouse.GetState().Y);
                //Significa que nao houve nenhum clique.
                if (casa == null)
                    return;
                if (casa.ToString().Equals("CampoM.SemBomba"))
                    passaVez();
                else if (this.jogadorDaVez == PC)
                {
                    jogadorPC.GetBombasEncontradas = 1;
                    this.tabuleiro.JogadaPC(jogadorPC.Joga(), jogadorPC.Joga());
                }
                else jogadorHumano.GetBombasEncontradas = 1;
                
                if (jogadorPC.GetBombasEncontradas == this.qntBombas / 2 + 1)
                    FinalizaJogo(jogadorPC);
                else if (jogadorHumano.GetBombasEncontradas == this.qntBombas / 2 + 1)
                    FinalizaJogo(jogadorHumano);
            }
        }

        private void FinalizaJogo(Jogador jogador)
        {
            //Criar o Windows form mostrando o vencedor.
            //Application.Run(ti);
        }

        private void passaVez()
        {
            if (this.jogadorDaVez.Equals(HUMANO))
            {
                Console.WriteLine("Android jogou!!!");
                //.IsMouseVisible = true;
                this.jogadorDaVez = PC;
                this.tabuleiro.JogadaPC(jogadorPC.Joga(), jogadorPC.Joga());
            }
            else{
                this.jogadorDaVez = HUMANO;
                Console.WriteLine("Eu joguei!!!");
            }
        }

    }
}
