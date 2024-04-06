using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            while (stringSize == null || !int.TryParse(stringSize, out size))
            {
                Console.Write("\nPlease input an integer grid size: ");
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

                Cell cell = new Cell(false, isLeftEdge, isRightEdge, isCorner, false);

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
                CheckAlive(_grid);
                Console.WriteLine("\nTo stop The Game of Life, press ESC. For a new generation, press any other key.");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    GameStop();
            }
        }

        public void GameStop()
        {
            Console.WriteLine("\nTThank you for playing The Game of Life.");
            Console.WriteLine($"Total generations: {_generation}");
            Console.WriteLine("Game over!");
            _active = false;
        }

        public static void CheckAlive(Grid grid)
        {
            for (int i = 0; i < grid.Cells.Count; i++)
            {
                int liveNeighbors = 0;

                Cell currentCell = grid.Cells[i];
                Cell neighborCell = null;

                int gridSize = grid.Width;

                if ( !currentCell.IsLeftEdge && ( (i - gridSize) - 1) >= 0) // Upper left diagonal
                {
                    neighborCell = grid.Cells[ (i - gridSize) - 1];
                    if (neighborCell.Alive)
                    {
                        //Console.WriteLine("a");
                        liveNeighbors = liveNeighbors + 1;
                    }
                }

                if ( (i - gridSize) >= 0) // Up
                {
                    neighborCell = grid.Cells[i - gridSize];
                    if (neighborCell.Alive)
                    {
                        //Console.WriteLine("b");
                        liveNeighbors = liveNeighbors + 1;
                    }
                }

                if (!currentCell.IsRightEdge && ((i - gridSize) + 1) >= 0) // Upper right diagonal
                {
                    neighborCell = grid.Cells[(i - gridSize) + 1];
                    if (neighborCell.Alive)
                    {
                        //Console.WriteLine("c");
                        liveNeighbors = liveNeighbors + 1;
                    }
                }

                if ( !currentCell.IsLeftEdge &&  (i - 1) >= 0 ) // Left
                {
                    neighborCell = grid.Cells[i - 1];
                    if (neighborCell.Alive)
                    {
                        //Console.WriteLine("d");
                        liveNeighbors = liveNeighbors + 1;
                    }
                }

                if ( !currentCell.IsRightEdge &&  (i + 1) < (gridSize*gridSize) ) // Right
                {
                    neighborCell = grid.Cells[i + 1];
                    if (neighborCell.Alive)
                    {
                        //Console.WriteLine("e");
                        liveNeighbors = liveNeighbors + 1;
                    }
                }

                if ( !currentCell.IsLeftEdge && ((i + gridSize) - 1) < (gridSize * gridSize) ) // Lower left diagonal
                {
                    neighborCell = grid.Cells[(i + gridSize) - 1];
                    if (neighborCell.Alive)
                    {
                        //Console.WriteLine("f");
                        liveNeighbors = liveNeighbors + 1;
                    }
                }

                if ( (i + gridSize) < (gridSize * gridSize) ) // Down
                {
                    neighborCell = grid.Cells[i + gridSize];
                    if (neighborCell.Alive)
                    {
                        //Console.WriteLine("g");
                        liveNeighbors = liveNeighbors + 1;
                    }
                }

                if (!currentCell.IsRightEdge && ((i + gridSize) + 1) < (gridSize * gridSize) ) // Lower right diagonal
                {
                    neighborCell = grid.Cells[(i + gridSize) + 1];
                    if (neighborCell.Alive)
                    {
                        //Console.WriteLine("h");
                        liveNeighbors = liveNeighbors + 1;
                    }
                }

                //Console.WriteLine($"\nTest {i}---------------------------------");
                //Console.WriteLine(currentCell.Alive);
                //Console.WriteLine(currentCell.IsLeftEdge);
                //Console.WriteLine(currentCell.IsRightEdge);
                //Console.WriteLine(liveNeighbors);
                //Console.WriteLine("Test---------------------------------\n");
                //Console.ReadKey();

                // Determine if the cell lives, dies, or reproduces depending on the neighbor count

                if (!currentCell.Alive)
                {
                    if (liveNeighbors == 3)
                        currentCell.NewStatus = true;
                    else if (liveNeighbors != 3)
                        currentCell.NewStatus = false;
                }

                if (currentCell.Alive)
                {
                    bool status = liveNeighbors switch
                    {
                        < 2 => false,
                        2 => true,
                        3 => true,
                        > 3 => false
                    };

                    currentCell.NewStatus = status;
                }

            }

            for (int i = 0; i < grid.Cells.Count; i++)
            {
                Cell currentCell = grid.Cells[i];

                if (grid.Height == 1)
                    currentCell.NewStatus = currentCell.Alive;

                currentCell.Alive = currentCell.NewStatus;
            }
        }
    }
}
