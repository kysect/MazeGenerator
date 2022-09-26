using Kysect.MazeGenerator;

ushort size = 5;
byte[][] maze = Maze.CreateMaze(size, size);

for (int i = 0; i < maze.Length; i++)
{
    for (int j = 0; j < maze[0].Length; j++)
    {
        Console.Write(maze[i][j] == 0 ? " " : "O");

        Console.Write(" ");
    }
    Console.WriteLine();
}