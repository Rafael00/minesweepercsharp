using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CampoM
{
    class Humano : Jogador
    {
        private string nomeJogador;

        public Humano(string nomeJogador) : base (nomeJogador)
        {
            this.nomeJogador = nomeJogador;
        }


        public void Draw(SpriteBatch spriteBatch, SpriteFont contador, SpriteFont nome)
        {
            spriteBatch.DrawString(contador, "" + GetBombasEncontradas, new Vector2(34, 224), Color.Blue);
            spriteBatch.DrawString(nome, nomeJogador, new Vector2(15, 122), Color.Blue);
        }

    }
}
