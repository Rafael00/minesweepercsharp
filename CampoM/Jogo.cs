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
        private MouseState ultimoEstado, estadoAtual;

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
            this.estadoAtual = Mouse.GetState();

            if (this.estadoAtual.LeftButton == ButtonState.Pressed
                && this.ultimoEstado.LeftButton == ButtonState.Released)
                {
                    GerenciaJogada(Mouse.GetState().X, Mouse.GetState().Y);
                }
            this.ultimoEstado = this.estadoAtual;
        }

        private void FinalizaJogo(Jogador jogador)
        {
            //Criar o Windows form mostrando o vencedor.
            //Application.Run(ti);
        }

        private void GerenciaJogada(int mouseX, int mouseY)
        {
            //Verifica se nenhuma casa foi clicada ou se a casa já foi clicada. Caso afirmativo nao faz nada.
            if (this.tabuleiro.CasaJaClicada(mouseX, mouseY))
                return;
             //Se a casa clicada nao tiver bomba.
            if (this.tabuleiro.GetTipoDaUltimaCasaClicada.Equals("CampoM.SemBomba"))
                passaVez();
            else if (this.jogadorDaVez == PC)
            {
                AndroidJoga();
            }
            else jogadorHumano.GetBombasEncontradas = 1;

            VerificaFimDoJogo();
        }

        private void VerificaFimDoJogo()
        {
            if (jogadorPC.GetBombasEncontradas == this.qntBombas / 2 + 1)
                FinalizaJogo(jogadorPC);
            else if (jogadorHumano.GetBombasEncontradas == this.qntBombas / 2 + 1)
                FinalizaJogo(jogadorHumano);
        }

        private void AndroidJoga()
        {
            int i = jogadorPC.Joga();
            int j = jogadorPC.Joga();
            this.tabuleiro.JogadaPC(i, j);
            Console.WriteLine("Android jogou!!! i: {0} j: {1}", i, j);
        }

        private void passaVez()
        {
            if (this.jogadorDaVez.Equals(HUMANO))
            {
                this.jogadorDaVez = PC;
                AndroidJoga();
            }
            else{
                this.jogadorDaVez = HUMANO;
                Console.WriteLine("Eu joguei!!!");
                AndroidJoga();
            }
        }

    }
}
