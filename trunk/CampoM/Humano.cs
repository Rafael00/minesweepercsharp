using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CampoM
{
    class Humano : Jogador
    {

        /// <summary>
        /// Cria um jogador Humano.
        /// </summary>
        /// <param name="nomeJogador">Nome do jogador.</param>
        public Humano(string nomeJogador) : base (nomeJogador)
        {
        }

        /// <summary>
        /// Desenha a quantidade de bombas acertadas por este jogador e o seu nome na tela.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="contador"></param>
        /// <param name="nome"></param>
        public void Draw(SpriteBatch spriteBatch, SpriteFont contador, SpriteFont nome)
        {
            spriteBatch.DrawString(contador, "" + BombasEncontradas, new Vector2(34, 224), Color.Blue);
            spriteBatch.DrawString(nome, GetNomeJogador, new Vector2(15, 122), Color.Blue);
        }

    }
}
