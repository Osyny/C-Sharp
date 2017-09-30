using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class GameController
    {
        private BinaryFormatter formater = new BinaryFormatter();

        private Game game = new Game();
        private Menu menu = new Menu();

        public GameController()
        {

        }

        public void mainLoop()
        {
            while(true)
            {
                Result result = menu.showMenu();
                if (result == Result.NEW_GAME)
                {
                    game.initFild();
                }
                else if (result == Result.LAST_GAME)
                {
                    FileStream stream = File.OpenRead("2048Data.dat");
                    game = formater.Deserialize(stream) as Game;

                    stream.Close();
                }
                else
                {
                    return;
                }

                gameLoop();

            }

        }


        public void gameLoop()
        { 
           game.showFild();

            while (true)
            {
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                {
                    // SERELIZATION
                    FileStream stream = File.Create("2048Data.dat");

                    formater.Serialize(stream, game);

                    stream.Close();

                    return;
                }
                else if(key == ConsoleKey.UpArrow)
                {
                    game.move(Direction.UP);
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    game.move(Direction.RIGHT);
                }
                else if (key == ConsoleKey.LeftArrow)
                {
                    game.move(Direction.LEFT);
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    game.move(Direction.DOWN);
                }

                //update game field
                game.showFild();

                if (game.IsGameOver)
                {
                    Console.WriteLine("\nGame OVER!!!");
                    Console.WriteLine("\nPress any key for go to menu....");
                    Console.ReadKey();
                    return;
                }
            }
         }
    }
}
