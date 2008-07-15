using System;
using System.Collections.Generic;
using System.Text;

namespace CampoM
{
    class PC : Jogador
    {
        public PC(string nomeJogador) : base (nomeJogador)
        {

        }

        public int Joga()
        {
            //Momentaneo.
            Random r = new Random();
            return r.Next(0, 14);
        }
    }
}
