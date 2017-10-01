using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukashka
{
    class Game
    {
        Swarm swarm = new Swarm();

        public Game()
        {
            Messenger.scareBugEvent += swarm.alarmForAllBuigsEvent;
        }

        public void createBug()
        {
            swarm.addBug();
            Console.WriteLine("Bug has been added!!!");
        }
        public void makeMove()
        {
            Console.WriteLine("Bugs has been moved!!!");
            swarm.moveAllBugs();
        }

        public void showCurentPosBugs()
        {
            swarm.showInfoAboutBugs();
        }

        public void scareBug()
        {
            Console.WriteLine($"Enter index bug: 0 - {swarm.Size - 1}  :");
            int ind = int.Parse(Console.ReadLine());

            swarm.getBugAt(ind).scare();

        }

  
    }
}
