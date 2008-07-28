using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace CampoM
{
    /// <summary>
    /// Está classe é responsável por controlar todo o jogo.
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
        /// Inicializa o jogo, mostrando a tela inicial para escolha do tamanho do tabuleiro, nível e quantidade de bombas.
        /// </summary>
        protected override void Initialize()
        {
            TelaInicial ti = new TelaInicial();
            ti.ShowDialog();
            //Cria um jogo com as informações obtidas.
            jogo = new Jogo(ti.GetNomeJogador(), ti.getTamanho, ti.getQntBombas, ti.getLocalizao, GraphicsDevice);
            SetTamanhoTela(560 + ti.getAumentaTela * 28, 684 + ti.getAumentaTela * 28);
            base.Initialize();
        }


        /// <summary>
        /// Incializa todos os componentes que serão utilizados para desenhar fontes e figuras na tela.
        /// </summary>
        protected override void LoadContent()
        {
            // Cria um spriteBatch responsável por desenhar texturas 2D.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Cria um spriteFont reponsável por desenhar fontes na tela.
            contador = Content.Load<SpriteFont>("FonteArial");
            nome = Content.Load<SpriteFont>("Nome");
            //Instancia uma telaFinal que será utilizada no momento em que o jogo for finalizado.
            telaFinal = new TelaFinal(GraphicsDevice);
        }

        /// <summary>
        /// Seta o tamanho da tela.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void SetTamanhoTela(int x, int y)
        {
            graphics.PreferredBackBufferHeight = x;
            graphics.PreferredBackBufferWidth = y;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Permite que o jogo seja atualizado, obtendo os cliques do mouse.
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            //Permite sair do jogo.
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();
            estadoAtual = Mouse.GetState();
            if (estadoAtual.LeftButton == ButtonState.Pressed && ultimoEstado.LeftButton == ButtonState.Released)
               if (telaFinal.GetRetanguloSair.Contains(Mouse.GetState().X, Mouse.GetState().Y))
                  Exit();
          
            ultimaAtualizacao += gameTime.ElapsedGameTime.Milliseconds;
            //Possibilita dá um delay entre as jogadas do PC, facilitando a visualização das mesmas.
            if (jogo.GetJogadorDaVez.Equals("PC") && (ultimaAtualizacao >= 1000))
                {
                    jogo.Update();
                    ultimaAtualizacao = 0;
                }
            else if (jogo.GetJogadorDaVez.Equals("HUMANO"))
                    if (estadoAtual.LeftButton == ButtonState.Pressed && ultimoEstado.LeftButton == ButtonState.Released)
                       jogo.Update();
           ultimoEstado = estadoAtual;
           base.Update(gameTime);
        }

        /// <summary>
        /// É chamado quando o jogo deve se desenhar.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            //Verifica se o jogo acabou.
            if (jogo.VerificaFimDoJogo())
            {
                //Mostrar a tela de final do jogo.
                spriteBatch.Draw(telaFinal.GetImagem, new Rectangle(0, 0, 367, 231), Color.White);
                spriteBatch.DrawString(nome, jogo.GetVencedor.GetNomeJogador + " Ganhou!!!", new Vector2(112,70), Color.Blue);
                SetTamanhoTela(231, 367);
            //Caso contrário desenha a tela normalmente.
            }else jogo.Draw(spriteBatch, contador, nome);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
