using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukashka
{
    class Swarm
    {
        private List<Bug> swarmList;

        public int Size { get { return swarmList.Count; } }

        public Swarm()
        {
            swarmList = new List<Bug>();
        }

        public void addBug()
        {
            Bug bug = new Bug("#" + (swarmList.Count + 1));
            swarmList.Add(bug);
            
            // listener
            Messenger.alarmInfoEvent += bug.alarm;
        }


        public void moveAllBugs()
        {
            foreach (Bug bug in swarmList)
                bug.move();
        }

        public void showInfoAboutBugs()
        {
            foreach (var item in swarmList)
                Console.WriteLine(item);
        }


        public void alarmForAllBuigsEvent()
        {

            Messenger.sendAlarmInfoEvent();

        }

        public Bug getBugAt(int index)
        {
            return swarmList[index];
        }
    }
}
