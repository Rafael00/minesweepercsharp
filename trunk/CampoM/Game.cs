using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace CampoM
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        private MouseState ultimoEstado, estadoAtual;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SpriteFont contador, nome;
        private Jogo jogo;
        private TelaFinal telaFinal;
        private int ultimaAtualizacao;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "Campo Minado - Paradigmas de Linguagem de Programação";
            IsMouseVisible = true;
         }



        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            TelaInicial ti = new TelaInicial();
            ti.ShowDialog();
            jogo = new Jogo(ti.GetNomeJogador(), ti.getTamanho, ti.getQntBombas, ti.getLocalizao, GraphicsDevice);
            SetTamanhoTela(560 + ti.getAumentaTela * 28, 684 + ti.getAumentaTela * 28);
            base.Initialize();
        }


        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            contador = Content.Load<SpriteFont>("FonteArial");
            nome = Content.Load<SpriteFont>("Nome");
            telaFinal = new TelaFinal(GraphicsDevice);
        }

        private void SetTamanhoTela(int x, int y)
        {
            graphics.PreferredBackBufferHeight = x;
            graphics.PreferredBackBufferWidth = y;
            graphics.ApplyChanges();
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                this.Exit();
            estadoAtual = Mouse.GetState();
            if (estadoAtual.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed
                && ultimoEstado.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
                {
                    if (telaFinal.GetRetanguloSair.Contains(Mouse.GetState().X, Mouse.GetState().Y))
                    {
                        Exit();
                    }
                }
            ultimoEstado = estadoAtual;
            ultimaAtualizacao += gameTime.ElapsedGameTime.Milliseconds;
            if (jogo.GetJogadorDaVez.Equals("PC") && (ultimaAtualizacao >= 1000))
            {
                jogo.Update();
                ultimaAtualizacao = 0;
            }
            else if (jogo.GetJogadorDaVez.Equals("HUMANO"))
                jogo.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            if (jogo.VerificaFimDoJogo())
            {
                //Mostrar a tela de final do jogo.
                spriteBatch.Draw(telaFinal.GetImagem, new Rectangle(0, 0, 367, 231), Color.White);
                spriteBatch.DrawString(nome, jogo.GetVencedor.GetNomeJogador + " Ganhou!!!", new Vector2(112,70), Color.Blue);
                SetTamanhoTela(231, 367);
            }else jogo.Draw(spriteBatch, contador, nome);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
