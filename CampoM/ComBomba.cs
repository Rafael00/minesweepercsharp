using Microsoft.Xna.Framework.Graphics;


namespace CampoM
{
    class ComBomba : Casa
    {
        /// <summary>
        /// Cria uma casa com bomba, que herda da classe Casa.
        /// </summary>
        /// <param name="graficos"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="localizacao"></param>
        public ComBomba(GraphicsDevice graficos, int x, int y, int localizacao) : base(graficos, x, y, localizacao)
        {
        }

        public override void MudaEstado(Texture2D img)
        {
            base.MudaEstado(img);
            _imagem = img;
        }
    }
}
