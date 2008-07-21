using System;
using System.Collections.Generic;
using System.Text;

namespace CampoM
{
    class Posicao
    {
        private int linha, coluna;

        public Posicao(int coluna, int linha)
        {
            this.linha = linha;
            this.coluna = coluna;
        }

        public int GetLinha
        {
            get { return this.linha; }
        }

        public int GetColuna
        {
            get { return this.coluna; }
        }

    }
}
