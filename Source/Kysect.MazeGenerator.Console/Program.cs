using Kysect.MazeGenerator;
using Kysect.MazeGenerator.MazeGenerators.GrowingTree;


int size = 5;
IMapGenerator generator = new GrowingTreeGenerator();
var maze = new Maze(generator.Generate(size));
maze.AddExit();

for (int i = 0; i < maze.Size; i++)
{
    for (int j = 0; j < maze.Size; j++)
    {
        Console.Write(CellToString(maze.Map[i][j]));

        Console.Write(" ");
    }
    Console.WriteLine();
}

string CellToString(Cells cellType)
{
    return cellType switch
    {
        Cells.Wall => "0",
        Cells.Empty => " ",
        Cells.Exit => "#",
        _ => throw new ArgumentOutOfRangeException(nameof(cellType), cellType, null)
    };
}