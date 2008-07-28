namespace CampoM
{
    class Posicao
    {
        private int linha, coluna;

        /// <summary>
        /// Cria um ponto.
        /// </summary>
        /// <param name="coluna">Valor da coluna.</param>
        /// <param name="linha">Valor da linha.</param>
        public Posicao(int coluna, int linha)
        {
            this.linha = linha;
            this.coluna = coluna;
        }

        /// <summary>
        /// Retorna a linha.
        /// </summary>
        public int GetLinha
        {
            get { return linha; }
        }

        /// <summary>
        /// Retorna a coluna.
        /// </summary>
        public int GetColuna
        {
            get { return coluna; }
        }

    }
}
