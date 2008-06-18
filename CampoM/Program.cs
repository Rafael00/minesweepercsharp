using System;


namespace CampoM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
  //          TelaInicial ti = new TelaInicial();

//            Application.Run(new TelaInicial());

            using (Game game = new Game())
            {    
                game.Run();
            }
        }
    }
}

