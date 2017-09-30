using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileMy
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(args[0].ToString());
			DirectoryInfo di =new DirectoryInfo(args[0]);

            var files = di.GetFiles(); // "*.*", SearchOption);

			long size = 0;
			foreach(var i in files)
			{
				size += i.Length;
			}

			Console.WriteLine(size);
			Console.WriteLine("===== Directory Info =====");
			Console.WriteLine("FullName: {0}", di.FullName);

		}
	}
}
