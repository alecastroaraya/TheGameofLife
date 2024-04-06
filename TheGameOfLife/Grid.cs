using System;
using System.Collections.Generic;
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
            Console.WriteLine("Please select the alive cells in the initial grid.");

        }

        void Display()
        {
            Console.WriteLine("Grid goes here");
        }
    }
}
