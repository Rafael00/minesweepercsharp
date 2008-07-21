using System;
using System.Collections.Generic;
using System.Text;

namespace CampoM
{
    class Jogador
    {
        private int numBombasEncontradas;
        private string nomeJogador;

        public Jogador(string nomeJogador)
        {
            this.nomeJogador = nomeJogador;
        }


        public string GetNomeJogador
        {
            get { return nomeJogador; }
        }


        public int GetBombasEncontradas
        {
            get { return numBombasEncontradas; }
            set { numBombasEncontradas += value; }
        }
        

    }

   

}
