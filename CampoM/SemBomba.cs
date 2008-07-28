using Microsoft.Xna.Framework.Graphics;

namespace CampoM
{
    class SemBomba : Casa
    {

        public SemBomba(GraphicsDevice graficos, int x, int y, int localizacao)
            : base(graficos, x, y, localizacao)
        {
        }

        /// <summary>
        /// Muda o estado da casa, para visivel e sua respectiva imagem.
        /// </summary>
        /// <param name="img">Imagem que irá revelar seu valor.</param>
        public override void MudaEstado(Texture2D img)
        {
            base.MudaEstado(img);
            _imagem = img;
        }
    }

}
