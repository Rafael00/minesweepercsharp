using Microsoft.Xna.Framework.Graphics;


namespace CampoM
{
    class ComBomba : Casa
    {

        public ComBomba(GraphicsDevice graficos, int x, int y, int localizacao) : base(graficos, x, y, localizacao)
        {
        }

        public override void mudaEstado(Texture2D img)
        {
            base.mudaEstado(img);
            _imagem = img;
        }
    }
}
