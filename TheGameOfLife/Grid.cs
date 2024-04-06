using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameOfLife
{
    internal class Grid
    {
        private int _width {  get; set; }
        private int _height { get; set; }
        public List<Cell> Cells {  get; set; }

        public Grid(int width, int height, List<Cell> cells)
        {
            _width = width;
            _height = height;
            this.Cells = cells;
        }

        public void SelectCells()
        {
            Console.WriteLine("Please configure the initial cells in the grid. A = Alive, D = Dead\n");
            for (int i = 0; i < Cells.Count; i++)
            {
                Console.Write($"Cell #{i}: ");

                string stringAlive = Console.ReadLine().ToLower();
                bool boolAlive = false;

                while (stringAlive == null || ( !stringAlive.Equals("a") && !stringAlive.Equals("d") ) )
                {
                    Console.Write("\nPlease input the letter A or the letter D: ");
                    stringAlive = Console.ReadLine().ToLower();
                }

                if ( stringAlive.Equals("a") )
                    boolAlive = true;

                Cells[i].Alive = boolAlive;
            }

            Console.WriteLine("\nInitial cell state configured succesfully.");
        }

        public void Display(int generation)
        {
            Console.WriteLine($"Generation #{generation}");
            Console.WriteLine("\n");
            
            for (int i = 0; i < Cells.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (Cells[i].Alive)
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\t*");
                if ((i + 1) % _height == 0)
                    Console.Write("\n");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

    }
}
