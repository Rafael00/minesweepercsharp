using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CampoM
{

    public class Casa
    {
        private Rectangle delimitador;
        private GraphicsDevice graficos;
        protected Texture2D _imagem;
        private int posicaoX, posicaoY, localizacao;
        private string estado = "NAO_VISIVEL";
        private int qntBombasVizinhas;

        public Casa(GraphicsDevice graficos, int x, int y, int localizacao)
        {
            posicaoX = x;
            posicaoY = y;
            this.graficos = graficos;
            this.localizacao = localizacao;
            _imagem = Texture2D.FromFile(graficos, @"imagens\casaEscondida.png");
            delimitador = new Rectangle(x * 28 + 124 + localizacao, y * 28 + localizacao, 28, 28);
        }

        public GraphicsDevice getGrafico
        {
            get { return this.graficos; }
        }

        public Texture2D getTexturaCasa
        {
            get { return this._imagem; }
        }

        public Rectangle getRetangulo
        {
            get{ return this.delimitador;}
        }

        public int GetPosicaoX
        {
            get { return posicaoX * 28 + 123 + localizacao; }
        }

        public int GetPosicaoY
        {
            get { return posicaoY * 28 + localizacao; }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(getTexturaCasa, new Rectangle(124 + getTexturaCasa.Width * posicaoX + localizacao, getTexturaCasa.Height * posicaoY + localizacao, getTexturaCasa.Width, getTexturaCasa.Height), Color.White);
        }

        public string GetEstado
        {

            get{ return this.estado;}
            set {this.estado = value; }
        }

        public virtual void mudaEstado(Texture2D img)
        {
            this.GetEstado = "VISIVEL";
        }
        
        public int GetQntDeBombasVizinhas
        {
            get { return qntBombasVizinhas; }
            set { qntBombasVizinhas = value; }
        }
    }
}
