
using Kysect.MazeGenerator.MazeGenerators.GrowingTree;

namespace Kysect.MazeGenerator;

public class Maze
{
    private readonly List<SpecialCell> _specialCells;

    public Cells[][] Map { get; init; }

    public IReadOnlyCollection<SpecialCell> SpecialCells => _specialCells;

    public int Size { get; private set; }

    public Maze(Cells[][] map)
    {
        Map = map;
        Size = map.GetLength(0);
        _specialCells = new List<SpecialCell>();
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
            int singleCoordinate = random.Next(0, Size);
            exitPosition = sideDirection.GetSideCoordinate(singleCoordinate, Size);

            var shift = new Coordinate { X = d.Y, Y = d.X, };
            nearExitPosition = exitPosition - shift;

        } while (Map[nearExitPosition.X][nearExitPosition.Y] == Cells.Wall &&
                 Map[exitPosition.X][exitPosition.Y] != Cells.Exit);

        Map[exitPosition.X][exitPosition.Y] = Cells.Exit;

        _specialCells.Add(new SpecialCell(Cells.Exit, exitPosition));

    }
}