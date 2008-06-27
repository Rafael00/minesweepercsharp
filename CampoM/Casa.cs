﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CampoM
{

    public class Casa
    {
        private Rectangle delimitador;
        private GraphicsDevice graficos;
        protected Texture2D _imagem;
        private int posicaoX, posicaoY;
        private string estado = "NAO_VISIVEL";
        private int qntBombasVizinhas;

        public Casa(GraphicsDevice graficos, int x, int y)
        {
            posicaoX = x;
            posicaoY = y;
            this.graficos = graficos;
            _imagem = Texture2D.FromFile(graficos, @"imagens\casaEscondida.png");
            delimitador = new Rectangle(x * 24, y * 24, 24, 24);
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

        public void draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(getTexturaCasa, new Rectangle(getTexturaCasa.Width * posicaoX, getTexturaCasa.Height * posicaoY, getTexturaCasa.Width, getTexturaCasa.Height), Color.White);
        }

        public string getEstado
        {
            get{ return this.estado;}
        }

        public virtual void mudaEstado(Texture2D img) {
            this.estado = "VISIVEL";
        }

        public int QntDeBombasVizinhas
        {
            get { return this.qntBombasVizinhas; }
            set { this.qntBombasVizinhas = value; }
        }
    }
}