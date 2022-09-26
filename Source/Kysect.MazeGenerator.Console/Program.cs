using Kysect.MazeGenerator;
using Kysect.MazeGenerator.MazeGenerators.GrowingTree;

ushort size = 2;
IMazeGenerator generator = new GrowingTreeGenerator(0);
byte[][] maze = generator.Generate(size);

for (int i = 0; i < maze.Length; i++)
{
    for (int j = 0; j < maze[0].Length; j++)
    {
        Console.Write(maze[i][j] == 0 ? " " : "O");

        Console.Write(" ");
    }
    Console.WriteLine();
}