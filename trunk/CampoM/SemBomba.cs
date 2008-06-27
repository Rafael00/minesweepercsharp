using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CampoM
{
    class SemBomba : Casa
    {

        public SemBomba(GraphicsDevice graficos, int x, int y)
            : base(graficos, x, y)
        {
        }

        public override void mudaEstado(Texture2D img)
        {
            this._imagem = img;
        }
    }

}
