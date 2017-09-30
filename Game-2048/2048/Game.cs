using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    [Serializable]
    class Cell
    {
        public int I { get; set; }
        public int J { get; set; }
        public int Value { get; set; }

        public Cell(int i, int j, int value = 0)
        {
            I = i;
            J = j;
            Value = value;
        }
    }

    [Serializable]
    enum Direction
    {
        UP,
        DOWN,
        RIGHT,
        LEFT,
    }

    [Serializable]
    class Game
    {
        private int n = 4;
        private int[,] fild;

        private bool isGameOver = false;

        public bool IsGameOver {get {return isGameOver;}}

        public Game()
        {
            
            
        }

        public void showFild()
        {
            Console.Clear();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (fild[i, j] != 0)
                        Console.Write($"  {fild[ i, j]} |");
                    else
                        Console.Write("    |");


                }
                Console.Write("\n --------------------- ");
                Console.Write($"\n");
              
            }
            Console.WriteLine("\n\n\n Esc - exit to menu!!!");
        }

        public void initFild()
        {
            fild = new int[n, n];
            isGameOver = false;

            addRndCell();
            addRndCell();
        }

        public bool move(Direction direction)
        {
            int[] group = new int[n];

            bool wasMoved = false;

            //Perform move
            for (int i = 0; i < n; i++)
            {
                getGroup(group, direction, i);
                bool moved = moveGroup(group);
                setGroup(group, direction, i);

                if (!wasMoved)
                    wasMoved = moved;
            }

            if (wasMoved)
                addRndCell();

            return wasMoved; 
        }

        //Private methods
        
        private void getGroup(int[] group, Direction direction, int groupIndex)
        {
            int index = direction == Direction.UP || direction == Direction.LEFT ? 0 : n - 1;
            int incr = index == 0 ? 1 : -1;

            for (int i = 0; i < n; i++, index+=incr)
            {
                if( direction == Direction.RIGHT || direction == Direction.LEFT )
                {
                    group[i] = fild[groupIndex, index];
                }
                else
                {
                    group[i] = fild[index, groupIndex];
                }
                    
            }
        }

        private void setGroup(int[] group, Direction direction, int groupIndex)
        {
            int index = direction == Direction.UP || direction == Direction.LEFT ? 0 : n - 1;
            int incr = index == 0 ? 1 : -1;

            for (int i = 0; i < n; i++, index += incr)
            {
                if (direction == Direction.RIGHT || direction == Direction.LEFT)
                {
                    fild[groupIndex, index] = group[i];
                }
                else
                {
                    fild[index, groupIndex] = group[i];
                }
            }
        }


        private bool moveGroup(int[] group)
        {
            bool result = false;
            bool isNeedToCheck = true;
            while (isNeedToCheck)
            {
                isNeedToCheck = false;
                for (int i = 1; i < n; i++)
                {
                    if (group[i] != 0)
                    {
                        if (group[i - 1] == 0 || group[i - 1] == group[i])
                        {
                            group[i - 1] += group[i];
                            group[i] = 0;
                            isNeedToCheck = true;
                            result = true;
                        }
                    }
                }
            }

            return result;
        }

        private void addRndCell()
        {
            Random random = new Random();
            List<Cell> freeCells = getFreeCells();

            if (freeCells.Count > 0)
            {
                int rndIndex = random.Next(0, freeCells.Count - 1);
                Cell cell = freeCells[rndIndex];

                fild[cell.I, cell.J] = random.Next(100) < 70 ? 2 : 4;
            }

            if (freeCells.Count == 1)
                isGameOver = true;
        }

        private List<Cell> getFreeCells()
        {
            List<Cell> freeCells = new List<Cell>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (fild[i, j] == 0)
                    {
                        Cell freeCell = new Cell(i, j);
                        freeCells.Add(freeCell);
                    }
                }
            }

            return freeCells;
        }

    }
}
