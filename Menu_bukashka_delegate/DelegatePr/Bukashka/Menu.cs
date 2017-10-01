using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukashka
{


    class Menu
    {
        
        Game game = new Game();

        public Menu()
        {
            Console.WriteLine("1. Create bukashka");
            Console.WriteLine("2. Scare Bug");
            Console.WriteLine("3. Make move");
            Console.WriteLine("4. Curent position");
           

            // coll Listener ALARM
            Messenger.alarmInfoEvent += Listener.alarmInfoListener;

            
        }

        public void showMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Create bukashka");
            Console.WriteLine("2. Scare Bug");
            Console.WriteLine("3. Make move");
            Console.WriteLine("4. Curent position");

            waitForSelectItem();
        }

        private void waitForSelectItem()
        {
            Console.Write(" Select item menu: ");
            string readedLine = Console.ReadLine();

            bool isEnteredNumber = readedLine.Count() != 0;

            // Check to enter numbers
            foreach(char symb in readedLine )
            {
                if (!Char.IsDigit(symb))
                {
                    isEnteredNumber = false;
                    break;
                }
            }

            if(isEnteredNumber)
            {
                int item = int.Parse(readedLine);
                switch(item)
                {
                    case 1:
                        game.createBug();
                        break;
                    case 2:
                        game.scareBug();
                        break;
                    case 3:
                        game.makeMove();
                        break;
                    case 4:
                        game.showCurentPosBugs();
                        break;
                    default:
                        showMenu();
                        break;
                }
            }
            delay();
            showMenu();

        }

        private void delay()
        {
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }


    }
}
