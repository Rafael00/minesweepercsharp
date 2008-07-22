
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CampoM
{
    class TelaFinal
    {
        private Texture2D imagem;
        private Rectangle retanguloContinue, retanguloSair;

        public TelaFinal(GraphicsDevice grafico)
        {
            imagem = Texture2D.FromFile(grafico, @"imagens\telafinal.png");
            retanguloContinue = new Rectangle(104,100,160,52);
            retanguloSair = new Rectangle(104, 160, 160, 52);
        }

        public Texture2D GetImagem
        {
            get { return imagem; }
        }

        public Rectangle GetRetanguloContinue
        {
            get { return retanguloContinue; }
        }

        public Rectangle GetRetanguloSair
        {
            get { return retanguloSair; }
        }
    }
}
