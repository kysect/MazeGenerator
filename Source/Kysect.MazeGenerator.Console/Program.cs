using Kysect.MazeGenerator.Console;
using Kysect.MazeGenerator.Entities;
using Kysect.MazeGenerator.Generators;

IMazeGenerator generator = new GrowingTreeMazeGenerator();

Maze maze = generator.CreateMaze(3);

char[][] gameMap = MazePresenter.MazeToGameMap(maze);

for (int i = 0; i < gameMap.Length; ++i)
{
    for (int j = 0; j < gameMap[i].Length; ++j)
        Console.Write(gameMap[i][j]);

    Console.WriteLine();
}