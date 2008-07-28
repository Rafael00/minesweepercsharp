using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CampoM
{
    class TelaFinal
    {
        private Texture2D imagem;
        private Rectangle retanguloSair;

        /// <summary>
        /// Cria uma tela que irá mostrar o vencendor do jogo.
        /// </summary>
        /// <param name="grafico"></param>
        public TelaFinal(GraphicsDevice grafico)
        {
            imagem = Texture2D.FromFile(grafico, @"Content\imagens\telafinal.png");
            retanguloSair = new Rectangle(102, 131, 160, 52);
        }

        /// <summary>
        /// Retorna imagem desta tela.
        /// </summary>
        public Texture2D GetImagem
        {
            get { return imagem; }
        }

        /// <summary>
        /// Retângulo que delimita o botão sair.
        /// </summary>
        public Rectangle GetRetanguloSair
        {
            get { return retanguloSair; }
        }
    }
}
