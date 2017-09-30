using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KomandConsole
{
	class ComConsol
	{
        private string curDir = Directory.GetCurrentDirectory();


        public void help()
		{
			Console.WriteLine(" cd - Change current directory! ");
			Console.WriteLine(" dir - Show the Directory! ");
			Console.WriteLine(" cls - Clear the console! ");
			Console.WriteLine(" copy - Copy File! ");
			Console.WriteLine(" delete - Delete File! ");
			Console.WriteLine(" mkdir - Create directory! ");

            delay();
        }
        public void cd(string destination)
        {
            string path = "";

            if (destination == "..")
            {
                int index = path.LastIndexOf('\\');
                path = path.Substring(0, index + 1);
            }
            else
            {
                path = destination;
            }

            if (Directory.Exists(path))
            {
                Directory.SetCurrentDirectory(path);
                curDir = Directory.GetCurrentDirectory();
                Console.WriteLine(curDir);
            }
            else
            {
                Console.WriteLine($"Error. Directory: {path} does not exist!");
            }
        }

		public void dir(string parameters)
		{
            string path = parameters.Length > 0 ? parameters : curDir;

            if (Directory.Exists(path))
            {
                IEnumerable<string> items = Directory.EnumerateFileSystemEntries(path);

                Console.WriteLine();
                foreach (string i in items)
                {
                    Console.WriteLine(i);
                }
            }
		}

		public void clear()
		{
			Console.Clear();
		}

		public void createDirect(string dirName)
		{
            string path = curDir;
            string destDir = (dirName.ToUpper()).Trim();

            if (destDir.Length > 0)
            {
                path += "\\" + destDir;

                DirectoryInfo dir = new DirectoryInfo(path);

                if (!dir.Exists)
                    dir.Create();
            }
			
		}
        public void deleteFile(string target)
        {
            FileInfo fileInfo = new FileInfo(target);
            if (fileInfo.Exists)
            {
                File.Delete(target);
            }
            else if (Directory.Exists(target))
            {
                Directory.Delete(target);
            }
            else
            {
                Console.WriteLine($"Delete error. {target} does not exist!");
            }
        } 
        public void copy(string source, string destination)
        {

            FileInfo fileInfo = new FileInfo(source);

            if(fileInfo.Exists)
            {
                fileInfo.CopyTo(destination, true);
            }
          /*  else if (Directory.Exists(source))
            {

            }*/
            else
            {
                Console.WriteLine($"Copy error. Source path: {source} does not exist!");
            }
        }

        public void delay()
        {
            Console.Write($" \n{curDir}> ");
        }
		
	}

	class Program
	{


		static void Main(string[] args)
		{
			ComConsol comand = new ComConsol();
            comand.delay();

            while (true)
			{
                string cmd = "";
                string parameter1 = "";
                string parameter2 = "";

                string inputString = Console.ReadLine();
                string[] parsedInput = inputString.Split(' ');

                if (parsedInput.Length > 0)
                {
                    cmd = parsedInput[0];
                    if (parsedInput.Length > 1)
                    {
                        parameter1 = parsedInput[1];

                        if (parsedInput.Length > 2)
                            parameter2 = parsedInput[2];
                    }
                }

                switch (cmd)
				{
					
					case "help":
						comand.help();
						break;
					case "cd":
                        comand.cd(parameter1);
                        comand.delay();
						break;
                    case "cd..":
                        comand.cd("..");
                        break;
					case "dir":
                        comand.dir(parameter1);
                        comand.delay();
                        break;
                    case "cls":
                        comand.clear();
                        comand.delay();
                        break;
                    case "copy":
                        comand.copy(parameter1, parameter2);
                        comand.delay();
                        break;
					case "delete":
                        comand.deleteFile(parameter1);
                        comand.delay();
                        break;
					case "mkdir":
                        comand.createDirect(parameter1);
                        comand.delay();
                        break;
                    case "":
                        comand.delay();
                        break;
                    default:
                        Console.WriteLine("Command not found!!!");
                        comand.delay();
                        break;
				}

                //Console.ReadKey();
			}
		}
	}
}
