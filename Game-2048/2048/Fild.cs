using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
	class Fild
	{
		private int n = 4;
		private int[ , ] fild;


		public Fild()
		{
			fild = new int[n, n];

		}
	

		public void showFild()
		{
			for(int i = 0; i < n; i++)
			{
				for(int j = 0; j < n; j++)
				{
					Console.Write($"  {fild[i , j]} |");
					
				}
				Console.Write("\n-------------------- ");
				Console.Write($"\n");
			}
		}
	}

	
}
