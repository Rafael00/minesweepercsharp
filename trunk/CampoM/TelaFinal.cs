using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CampoM
{
    class TelaFinal
    {
        private Texture2D imagem;
        private Rectangle retanguloSair;

        public TelaFinal(GraphicsDevice grafico)
        {
            imagem = Texture2D.FromFile(grafico, @"imagens\telafinal.png");
            retanguloSair = new Rectangle(102, 131, 160, 52);
        }

        public Texture2D GetImagem
        {
            get { return imagem; }
        }

        public Rectangle GetRetanguloSair
        {
            get { return retanguloSair; }
        }
    }
}
