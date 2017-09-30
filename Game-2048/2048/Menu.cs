using _2048;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    enum Result
    {
        NEW_GAME = 1,
        LAST_GAME = 2,
        EXIT = 3,
        WRONG = 4
    }

    class Menu
    {
        const string ITEM1 = "1. New Game";
        const string ITEM2 = "2. Play last Game";
        const string ITEM3 = "3. Exit";

        public Menu()
        {

        }

        public Result showMenu()
        {
            Console.Clear();
            Console.WriteLine(ITEM1);
            Console.WriteLine(ITEM2);
            Console.WriteLine(ITEM3);

            Result result = waitForSelectItem();

            if (result == Result.WRONG)
            {
                showMenu();
            }

            return result;

        }

        private Result waitForSelectItem()
        {
            Console.Write(" Select item menu: ");
            string readedLine = Console.ReadLine();

            bool isEnteredNumber = readedLine.Count() != 0;

            // Check to enter numbers
            foreach (char symb in readedLine)
            {
                if (!Char.IsDigit(symb))
                {
                    isEnteredNumber = false;
                    break;
                }
            }

            if (isEnteredNumber)
            {
                int item = int.Parse(readedLine);
                switch (item)
                {
                    case 1:
                        return Result.NEW_GAME;
                    case 2:
                        return Result.LAST_GAME;
                    case 3:
                        return Result.EXIT;
                    default:
                        break;

                }
            }

            return Result.WRONG;
        }
    }
}
