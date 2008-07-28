
namespace CampoM
{
    class Jogador
    {
        private int numBombasEncontradas;
        private string nomeJogador;

        /// <summary>
        /// Cria um jogador.
        /// </summary>
        /// <param name="nomeJogador"></param>
        public Jogador(string nomeJogador)
        {
            this.nomeJogador = nomeJogador;
        }

        /// <summary>
        /// Retorna o nome do jogador
        /// </summary>
        public string GetNomeJogador
        {
            get { return nomeJogador; }
        }

        /// <summary>
        /// Retorna e atualiza a quantidade de bombas encontradas por este jogador até o momento.
        /// </summary>
        public int BombasEncontradas
        {
            get { return numBombasEncontradas; }
            set { numBombasEncontradas += value; }
        }
    }
}
