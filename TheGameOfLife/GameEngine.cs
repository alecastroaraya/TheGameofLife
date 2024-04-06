using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameOfLife
{
    internal class GameEngine
    {
        private Grid _grid {  get; set; }
        private int _generation {  get; set; }

        private bool _active {  get; set; }

        public GameEngine(Grid grid, int generation, bool active)
        {
            _grid = grid;
            _generation = generation;
            _active = active;
        }

        public GameEngine(int generation, bool active)
        {
            _grid = null;
            _generation = generation;
            _active = active;
        }

        public Grid Grid
        {
            get { return _grid; }
            set { _grid = value; }
        }

        public int Generation
        {
            get { return _generation; }
            set { _generation = value; }
        }

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public void SelectSize()
        {
            Console.Write("Welcome to The Game of Life. Please input the size of the grid: ");
            string stringSize = Console.ReadLine();
            int size = 0;
            while (stringSize == null || !int.TryParse(stringSize, out size) || size < 3)
            {
                Console.Write("\nPlease input an integer grid size starting from 3: ");
                stringSize = Console.ReadLine();
            }
            size = int.Parse(stringSize);
            Console.WriteLine($"\nSize selected: {stringSize}");

            List<Cell> newCells = new List<Cell>();

            for (int i = 0; i < size * size; i++)
            {
                bool isCorner = false;
                bool isLeftEdge = false;
                bool isRightEdge = false;

                if (i % size == 0)
                {
                    isLeftEdge = true;
                    if (i == 0 || i == (((size * size) - 1) - size + 1))
                        isCorner = true;
                }

                if ((i + 1) % size == 0)
                {
                    isRightEdge = true;
                    if ((i == ((size * size) - 1)) || i == (size - 1))
                        isCorner = true;
                }

                Cell cell = new Cell(false, isLeftEdge, isRightEdge, isCorner);

                //Console.WriteLine(i);
                //Console.WriteLine("---------------------------------");
                //Console.WriteLine(cell.Alive);
                //Console.WriteLine(cell.IsLeftEdge);
                //Console.WriteLine(cell.IsRightEdge);
                //Console.WriteLine(cell.IsCorner);
                //Console.WriteLine("---------------------------------");

                newCells.Add(cell);
            }

            Grid newGrid = new Grid(size, size, newCells);
            _grid = newGrid;
        }

        public void GameStart()
        {
            Console.WriteLine("The Game of Life will start. Press any key to continue.");
            Console.ReadKey();
        }

        public void GameLoop()
        {
            while ( _active)
            {
                Console.Clear();
                _grid.Display(_generation);
                _generation = _generation + 1;
                Console.WriteLine("\nTo stop The Game of Life, press ESC.");
                Thread.Sleep(1000);

                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                        GameStop();
                }).Start();
            }
        }

        public void GameStop()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Thank you for playing The Game of Life.");
            Console.WriteLine($"Total generations: {_generation}");
            Console.WriteLine("Game over!");
            _active = false;
        }
    }
}
