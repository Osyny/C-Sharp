using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    delegate void HandlerMenuItemDelegate(MenuItem item);
    delegate void MenuShowDelegate();

    class Messager
    {
        //  ************* EVENTS ***********************      
        public event HandlerMenuItemDelegate activateCounterEvent;

        public event HandlerMenuItemDelegate enterTextEvent;

        //SENDERS (simple method with same signture due to coresponds event)
        public void sendActivateCounterEvent(MenuItem item)
        {
            activateCounterEvent?.Invoke(item);
        }

        public void sendEnterTextEvent(MenuItem item = null)
        {
            enterTextEvent?.Invoke(item);
        }
    }

    class Listener
    {
        bool[] countersEnabled = new bool[3];

        public Listener()
        {
            for(int i = 0; i < 3; i++)
                countersEnabled[i] = false;
        }

        public void activateCounterListener(MenuItem item)
        {
            bool willEnabled = item.Prefix == "Add";
            item.Prefix = willEnabled ? "Remove" : "Add";
            countersEnabled[item.Id - 1] = willEnabled;
        }

        public void enterTextListener(MenuItem i)
        {
            int countSumb = 0;
            int countNumber = 0;
            int countWorld = 0;

            /* Console.WriteLine("Enter the text:");
             string str = Console.ReadLine();*/
            string str = "Здравствуй, европейское лето 1816 года!";

            //Calculate symbols count
            if (countersEnabled[0])
                countSumb = str.Length;

            //Calculate numbers count
            if (countersEnabled[1])
            {
                foreach (Char s in str)
                {
                    if (char.IsDigit(s))
                        countNumber++;
                }
            }

            //Calculate words
            if (countersEnabled[2])
            {
                string[] strArr = str.Split(' ');
                countWorld = strArr.Length;
            }

            Console.WriteLine($"Str : {str}");
            if (countSumb != 0)
                Console.WriteLine($"Count symbol : {countSumb}");
            if (countNumber != 0)
                Console.WriteLine($"Count number : {countNumber}");
            if (countWorld != 0)
                Console.WriteLine($"Countr world : {countWorld}");
            delay();
        }


        private void delay()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }

    class MenuItem
    {
        private int id;
        private string prefix;
        private string title;
        public string Title { get { return id.ToString() + ". " + prefix + title; } }

        public string Prefix { get { return prefix; }  set { prefix = value; } }
        public int Id { get { return id; } }

        public MenuItem(int id, string title, string prefix = "")
        {
            this.id = id;
            this.prefix = prefix;
            this.title = title;
        }
    }

    class Menu
    {
        Messager messeger = new Messager();
        Listener listener = new Listener();

        List<MenuItem> items = new List<MenuItem>();

        public Menu()
        {
            items.Add(new MenuItem(1, " symbols counter", "Add"));
            items.Add(new MenuItem(2, " numbers counter", "Add"));
            items.Add(new MenuItem(3, " words counter", "Add"));
            items.Add(new MenuItem(4, "Enter text"));
            items.Add(new MenuItem(0, "Exit"));

            //Here perform subscrib the LISTENER: "listener.activateListener" to EVENT: "messeger.activateEvent"
            //Method "messeger.sendActivateEvent" perform call the "Invoke" method of EVENT: "messeger.activateEvent"(i.e. sended EVENT)
            //As result will be invoked(call) the LISTENER: "listener.activateListener"
            //
            // Do send EVENT -> will be invoked LISTENER
            //
            messeger.activateCounterEvent += listener.activateCounterListener;

            //Listener Text
            messeger.enterTextEvent += listener.enterTextListener;

        }

        public void show()
        {
            Console.Clear();
            foreach (MenuItem item in items)
            {
                Console.WriteLine(item.Title);
            }
            waitForSelectItem();
        }

        private void waitForSelectItem()
        {
            Console.Write(" Select item menu: ");
            string readedLine = Console.ReadLine();
            bool isEnteredNumber = readedLine.Count() != 0;

            // 
            foreach (char symbol in readedLine)
            {
                if (!Char.IsDigit(symbol))
                {
                    isEnteredNumber = false;
                    break;
                }
            }

            if (isEnteredNumber)
            {
                int itemId = int.Parse(readedLine);

                switch (itemId)
                {
                    case 0:
                        break;
                    case 1:
                    case 2:
                    case 3:
                        messeger.sendActivateCounterEvent(items[itemId - 1]);
                        break;
                    case 4:
                        messeger.sendEnterTextEvent();
                        break;

                }
            }
            show();
        }
    }

 

    class Program
    {      
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.show();
        }
    }
}

