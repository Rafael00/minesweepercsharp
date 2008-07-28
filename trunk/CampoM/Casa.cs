using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CampoM
{

    public class Casa
    {
        private Rectangle delimitador;
        protected Texture2D _imagem;
        private int posicaoX, posicaoY, localizacao;
        private string estado = "NAO_VISIVEL";
        private int qntBombasVizinhas;

        /// <summary>
        /// Cria uma casa. Onde os parâmetros x, y determina a posição da casa e o parâmetro localização serve para centralizar a casa no meio da tela.
        /// </summary>
        /// <param name="graficos"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="localizacao"></param>
        public Casa(GraphicsDevice graficos, int x, int y, int localizacao)
        {
            posicaoX = x;
            posicaoY = y;
            this.localizacao = localizacao;
            //Iniciamente todas as casas possuem a mesma imagem. Pois estão escondidas.
            _imagem = Texture2D.FromFile(graficos, @"Content\imagens\casaEscondida.png");
            //Retangulo responsável pela delimitação da casa. Tornando possível saber se o clique do mouse foi nesta casa.
            delimitador = new Rectangle(x * 28 + 124 + localizacao, y * 28 + localizacao, 28, 28);
        }
        /// <summary>
        /// 
        /// </summary>
/*        public GraphicsDevice GetGrafico
        {
            get { return graficos; }
        }
        */

        /// <summary>
        /// Retorna a imagem atual da casa.
        /// </summary>
        public Texture2D GetTexturaCasa
        {
            get { return _imagem; }
        }

        /// <summary>
        /// Retorna o retangulo delimitador desta casa.
        /// </summary>
        public Rectangle GetRetangulo
        {
            get{ return delimitador;}
        }

        /// <summary>
        /// Retorna a posição X desta casa. Onde 28 é a largura da casa, o 123 é a largura do placar e a localização é o ajuste para centralizar a casa.
        /// </summary>
        public int GetPosicaoX
        {
            get { return posicaoX * 28 + 123 + localizacao; }
        }

        /// <summary>
        /// Retorna a posição Y desta casa.
        /// </summary>
        public int GetPosicaoY
        {
            get { return posicaoY * 28 + localizacao; }
        }

        /// <summary>
        /// Desenha está casa na tela.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(GetTexturaCasa, new Rectangle(124 + GetTexturaCasa.Width * posicaoX + localizacao, GetTexturaCasa.Height * posicaoY + localizacao, GetTexturaCasa.Width, GetTexturaCasa.Height), Color.White);
        }

        /// <summary>
        /// Retorna ou altera estado atual da casa. Visível ou não visível.
        /// </summary>
        public string Estado
        {
            get{ return estado;}
            set {estado = value; }
        }

        /// <summary>
        /// Atualiza o estado da casa no momento em que ela é clicada, mudando o seu estado e sua imagem.
        /// </summary>
        /// <param name="img"></param>
        public virtual void MudaEstado(Texture2D img)
        {
            Estado = "VISIVEL";
        }
        
        /// <summary>
        /// Retorna ou atribui a quantidade de bombas vizinhas a esta casa.
        /// </summary>
        public int QntDeBombasVizinhas
        {
            get { return qntBombasVizinhas; }
            set { qntBombasVizinhas = value; }
        }
    }
}
