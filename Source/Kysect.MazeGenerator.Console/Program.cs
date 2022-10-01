using Kysect.MazeGenerator;
using Kysect.MazeGenerator.MazeGenerators.GrowingTree;


ushort size = 2;
IMazeGenerator generator = new GrowingTreeGenerator();
var maze = new Maze(generator.Generate(size));
maze.AddExit();

for (int i = 0; i < maze.Size; i++)
{
    for (int j = 0; j < maze.Size; j++)
    {
        Console.Write(maze.Map[i][j] == Cells.Empty ? " " : "O");

        Console.Write(" ");
    }
    Console.WriteLine();
}