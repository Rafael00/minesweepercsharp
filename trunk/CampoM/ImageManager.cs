using Microsoft.Xna.Framework.Graphics;

namespace CampoM
{
    /// <summary>
    /// Classe reponsável por administrar as imagens que serão utilizadas no decorrer do jogo.
    /// </summary>
    class ImageManager
    {
        private GraphicsDevice graficos;
        private Texture2D[] imagens;
        private Texture2D placar, setaPC, setaHumano, selecaoAzul, selecaoVermelha;


        public ImageManager(GraphicsDevice graficos)
        {
            this.graficos = graficos;
            imagens = new Texture2D[12];
            selecaoVermelha = Texture2D.FromFile(graficos, @"Content\imagens\selecao_vermelha.png");
            selecaoAzul = Texture2D.FromFile(graficos, @"Content\imagens\selecao_azul.png");
            placar = Texture2D.FromFile(graficos, @"Content\imagens\Placar.png");
            setaHumano = Texture2D.FromFile(graficos, @"Content\imagens\seta_blue.png");
            setaPC = Texture2D.FromFile(graficos, @"Content\imagens\seta_red.png");
            preencheArrayCasas();
        }

        private void preencheArrayCasas()
        {
            imagens[0] = Texture2D.FromFile(graficos, @"Content\imagens\casaVazia.png");
            imagens[1] = Texture2D.FromFile(graficos, @"Content\imagens\casa1.png");
            imagens[2] = Texture2D.FromFile(graficos, @"Content\imagens\casa2.png");
            imagens[3] = Texture2D.FromFile(graficos, @"Content\imagens\casa3.png");
            imagens[4] = Texture2D.FromFile(graficos, @"Content\imagens\casa4.png");
            imagens[5] = Texture2D.FromFile(graficos, @"Content\imagens\casa5.png");
            imagens[6] = Texture2D.FromFile(graficos, @"Content\imagens\casa6.png");
            imagens[7] = Texture2D.FromFile(graficos, @"Content\imagens\casa7.png");
            imagens[8] = Texture2D.FromFile(graficos, @"Content\imagens\casa8.png");
            imagens[9] = Texture2D.FromFile(graficos, @"Content\imagens\casaBomba.png");
            imagens[10] = Texture2D.FromFile(graficos, @"Content\imagens\BandeiraVermelha.png");
            imagens[11] = Texture2D.FromFile(graficos, @"Content\imagens\BandeiraAzul.png");
        }

        /// <summary>
        /// Retorna a setaPC que indica que está na vez do jogador PC jogar.
        /// </summary>
        public Texture2D GetSetaPC
        {
            get { return setaPC; }
        }

        /// <summary>
        /// Retorna a textura selecaoVermelha que irá marcar onde o jogador PC jogou na última jogada.
        /// </summary>
        public Texture2D GetSelecaoVermelha
        {
            get { return selecaoVermelha; }
        }

        /// <summary>
        /// Retorna a textura selecaoAzul que irá marcar onde o jogador Humano jogou na última jogada.
        /// </summary>
        public Texture2D GetSelecaoAzul
        {
            get { return selecaoAzul; }
        }

        /// <summary>
        /// Retorna a textura que indica que está na vez do jogador humano.
        /// </summary>
        public Texture2D GetSetaHumano
        {
            get { return setaHumano; }
        }

        /// <summary>
        /// Retornará a respectiva textura de acordo com a quantidade de bombas vizinhas a esta casa.
        /// </summary>
        /// <param name="index">O valor do index corresponde a quantidade de bombas vizinhas. Neste caso 9 significa que esta casa é bomba.</param>
        /// <returns></returns>
        public Texture2D GetImagemCasa(int index)
        {
           return imagens[index]; 
        }

        /// <summary>
        /// Retorna a textura do placar.
        /// </summary>
        public Texture2D GetImagemPlacar
        {
            get { return placar; }
        }

    }
}

