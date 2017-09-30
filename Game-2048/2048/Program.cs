using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
	class Program
	{
        public static object BinaryFormater { get; private set; }

        static void Main(string[] args)
		{
            GameController controller = new GameController();
            controller.mainLoop();
        }
	}
}
