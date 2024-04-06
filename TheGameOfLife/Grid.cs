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
        private List<Cell> cells {  get; set; }

        public Grid(int width, int height, List<Cell> cells)
        {
            _width = width;
            _height = height;
            this.cells = cells;
        }

        public void SelectCells()
        {
            Console.WriteLine("Please configure the initial cells in the grid. A = Alive, D = Dead\n");
            for (int i = 0; i < cells.Count; i++)
            {
                Console.Write($"Cell #{i}: ");

                string stringAlive = Console.ReadLine().ToLower();
                bool boolAlive = false;

                while (stringAlive == null || ( !stringAlive.Equals("a") && !stringAlive.Equals("d") ) )
                {
                    Console.Write("\nPlease input the letter A or the letter D: ");
                    stringAlive = Console.ReadLine().ToLower();
                }

                if ( stringAlive.Equals('a') )
                    boolAlive = true;

                cells[i].Alive = boolAlive;
            }

            Console.WriteLine("\nInitial cell state configured succesfully.");
            Console.WriteLine("The Game of Life will start. Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
            Display();
        }

        void Display()
        {
            Console.WriteLine("Grid goes here");
        }
    }
}
