using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukashka
{
    delegate void HendlerAlarmInfo();

    class Messenger
    {

        //  ************* EVENTS ***********************   
        static public event HendlerAlarmInfo alarmInfoEvent;
        static public event HendlerAlarmInfo scareBugEvent;

        //SENDERS ALARM_INFO
        static public void sendAlarmInfoEvent()
        {
            alarmInfoEvent?.Invoke();
        }

        static public void sendScareBugEvent()
        {
            scareBugEvent?.Invoke();
        }
    }
}
