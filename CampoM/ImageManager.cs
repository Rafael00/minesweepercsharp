using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Text;

namespace CampoM
{
    class ImageManager
    {
        private GraphicsDevice graficos;
        private Texture2D[] imagens;
        private Texture2D placar, setaPC, setaHumano;

        public ImageManager(GraphicsDevice graficos)
        {
            this.graficos = graficos;
            imagens = new Texture2D[12];
            placar = Texture2D.FromFile(graficos, @"imagens\Placar.png");
            setaHumano = Texture2D.FromFile(graficos, @"imagens\seta_blue.png");
            setaPC = Texture2D.FromFile(graficos, @"imagens\seta_red.png");
            preencheArrayCasas();
        }

        private void preencheArrayCasas()
        {
            imagens[0] = Texture2D.FromFile(graficos, @"imagens\casaVazia.png");
            imagens[1] = Texture2D.FromFile(graficos, @"imagens\casa1.png");
            imagens[2] = Texture2D.FromFile(graficos, @"imagens\casa2.png");
            imagens[3] = Texture2D.FromFile(graficos, @"imagens\casa3.png");
            imagens[4] = Texture2D.FromFile(graficos, @"imagens\casa4.png");
            imagens[5] = Texture2D.FromFile(graficos, @"imagens\casa5.png");
            imagens[6] = Texture2D.FromFile(graficos, @"imagens\casa6.png");
            imagens[7] = Texture2D.FromFile(graficos, @"imagens\casa7.png");
            imagens[8] = Texture2D.FromFile(graficos, @"imagens\casa8.png");
            imagens[9] = Texture2D.FromFile(graficos, @"imagens\casaBomba.png");
            imagens[10] = Texture2D.FromFile(graficos, @"imagens\BandeiraVermelha.png");
            imagens[11] = Texture2D.FromFile(graficos, @"imagens\BandeiraAzul.png");
        }

        public Texture2D GetSetaPC
        {
            get { return setaPC; }
        }

        public Texture2D GetSetaHumano
        {
            get { return setaHumano; }
        }

        public Texture2D GetImagemCasa(int index)
        {
           return imagens[index]; 
        }

        public Texture2D GetImagemPlacar
        {
            get { return placar; }
        }

    }
}

