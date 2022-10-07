using Kysect.MazeGenerator.Console;
using Kysect.MazeGenerator.Entities;
using Kysect.MazeGenerator.Generators;
using Kysect.MazeGenerator.Models;

IMazeGenerator generator = new GrowingTreeMazeGenerator();

Maze maze = generator.CreateMaze(2);

char[][] block = MazePrinter.CellToBlock(maze.GetCellAt(new Coordinate(0, 0)));

for (int i = 0; i < 3; ++i)
{
    for (int j = 0; j < 3; ++j)
    {
        Console.Write(block[i][j]);
    }
    Console.WriteLine();
}

block = MazePrinter.CellToBlock(maze.GetCellAt(new Coordinate(1, 0)));
for (int i = 0; i < 3; ++i)
{
    for (int j = 0; j < 3; ++j)
    {
        Console.Write(block[i][j]);
    }
    Console.WriteLine();
}

block = MazePrinter.CellToBlock(maze.GetCellAt(new Coordinate(0, 1)));
for (int i = 0; i < 3; ++i)
{
    for (int j = 0; j < 3; ++j)
    {
        Console.Write(block[i][j]);
    }
    Console.WriteLine();
}

block = MazePrinter.CellToBlock(maze.GetCellAt(new Coordinate(1, 1)));
for (int i = 0; i < 3; ++i)
{
    for (int j = 0; j < 3; ++j)
    {
        Console.Write(block[i][j]);
    }
    Console.WriteLine();
}