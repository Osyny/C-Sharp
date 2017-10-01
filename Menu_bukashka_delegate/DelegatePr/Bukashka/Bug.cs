using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukashka
{

    class Bug
    {

        private int x;
        private int y;
        private int speed = 2;
        private string name;

        private int alarmMovesCount = 0;

        public int X { get; set; }
        public int Y { get; set; }

        public Bug(string name)
        {
            Random n = new Random();

            x = n.Next(1, 50);
            y = n.Next(1,50);
            this.name = name;
        }
        public Bug(string name, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }

        public void move()
        {
            if (alarmMovesCount > 0)
            {
                alarmMovesCount--;
                Console.WriteLine($"Bug {name} cannot move, ALARMED!!!");
            }
            else
            {
                x += speed;
                y += speed;
                Console.WriteLine($"Bug {name} has been moved");
            }
        }

        public void alarm()
        {
            alarmMovesCount = 3;

            Console.WriteLine($"Bug {name} alarmed!!!");
        }

        public void scare()
        {
            Console.WriteLine($"Bug {name} scared!!!");
            Messenger.sendScareBugEvent();
        }

        public override string ToString()
        {

            return String.Format($"Name: {name} - X: {x}; Y: {y};");
        }
    }
}
