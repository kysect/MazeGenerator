
using Kysect.MazeGenerator.MazeGenerators.GrowingTree;

namespace Kysect.MazeGenerator;

public class Maze
{
    public Cells[][] Map { get; init; }

    public int Size { get; private set; }

    public Maze(Cells[][] map)
    {
        Map = map;
        Size = map.GetLength(0);
    }

    public Maze AddExit()
    {
        GenerateExit(new Random());
        return this;
    }

    public Maze AddExit(Random random)
    {
        GenerateExit(random);
        return this;
    }


    private void GenerateExit(Random random)
    {
        Coordinate exitPosition, nearExitPosition;

        do
        {
            Direction sideDirection = DirectionExtensions.GetRandomDirection(random);

            Coordinate d = sideDirection.TransformDirectionToDelta();
            int singleCoordinate = random.Next(1, Map.GetLength(0) - 2);
            exitPosition = sideDirection.TransformDirectionToCoordinate(singleCoordinate, Map.GetLength(0));

            var shift = new Coordinate { X = d.Y, Y = d.X, };
            nearExitPosition = exitPosition - shift;

        } while (Map[nearExitPosition.X][nearExitPosition.Y] == Cells.Wall);

        Map[exitPosition.X][exitPosition.Y] = Cells.Empty;

    }
}