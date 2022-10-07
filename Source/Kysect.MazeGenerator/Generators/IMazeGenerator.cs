using Kysect.MazeGenerator.Entities;

namespace Kysect.MazeGenerator.Generators;

public interface IMazeGenerator
{
    Maze CreateMaze(int size);
}
