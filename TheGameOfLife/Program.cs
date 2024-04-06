using TheGameOfLife;

static Grid SelectSize()
{
    Console.Write("Welcome to The Game of Life. Please input the size of the grid: ");
    string stringSize = Console.ReadLine();
    int size = 0;
    while (stringSize == null || !int.TryParse(stringSize, out size) || size < 3)
    {
        Console.WriteLine("\nPlease input an integer grid size starting from 3.");
        stringSize = Console.ReadLine();
    }
    size = int.Parse(stringSize);
    Console.WriteLine($"\nSize selected: {stringSize}");

    List<Cell> newCells = new List<Cell>();

    for (int i = 0; i < size*size; i++)
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

        if ( (i+1) % size == 0)
        {
            isRightEdge = true;
            if ( (i == ((size*size) - 1)) || i == (size - 1) )
                isCorner = true;
        }

        Cell cell = new Cell(false,isLeftEdge,isRightEdge,isCorner);

        //Console.WriteLine(i);
        //Console.WriteLine("---------------------------------");
        //Console.WriteLine(cell._alive);
        //Console.WriteLine(cell._isLeftEdge);
        //Console.WriteLine(cell._isRightEdge);
        //Console.WriteLine(cell._isCorner);
        //Console.WriteLine("---------------------------------");

        newCells.Add(cell);
    }

    Grid newGrid = new Grid(size, size, newCells);
    return newGrid;
}

Grid grid = SelectSize();
grid.SelectCells();
