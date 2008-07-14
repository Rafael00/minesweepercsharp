using System;
using System.Collections.Generic;
using System.Text;

namespace CampoM
{
    class Jogador
    {
        private int numBombasEncontradas = 0;
        private string nomeJogador;

        public Jogador(string nomeJogador)
        {
            this.nomeJogador = nomeJogador;
        }


        public string GetNomeJogador
        {
            get { return this.nomeJogador; }
        }


        public int GetBombasEncontradas
        {
            get { return this.numBombasEncontradas; }
            set { this.numBombasEncontradas += value; }
        }
        

    }

   

}
