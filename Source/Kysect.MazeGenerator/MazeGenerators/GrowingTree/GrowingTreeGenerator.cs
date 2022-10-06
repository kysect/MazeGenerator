
namespace Kysect.MazeGenerator.MazeGenerators.GrowingTree;

public class GrowingTreeGenerator : IMapGenerator
{
    private readonly Random _random;

    public GrowingTreeGenerator()
    {
        _random = new Random();
    }

    public GrowingTreeGenerator(Random random)
    {
        _random = random;
    }

    public Cells[][] Generate(int size)
    {
        if (size <= 1)
            throw new ArgumentException($"{nameof(size)} must be greater than 1");

        byte[][] maze = new byte[size][];

        for (int i = 0; i < size; i++) maze[i] = new byte[size];

        GenerateMazeGrowingTree(maze);
        Cells[][] map = TransformLineToBlock(maze);


        return map;
    }



    private void GenerateMazeGrowingTree(byte[][] maze)
    {
        var coordinates = new List<Coordinate>();

        int x = _random.Next(maze.Length - 1) + 1;
        int y = _random.Next(maze[0].Length - 1) + 1;

        coordinates.Add(new Coordinate(x, y));

        while (coordinates.Count > 0)
        {
            int index = Math.Max(coordinates.Count - 1, 0);
            Coordinate coordinatePicked = coordinates[index];

            foreach (Direction way in DirectionExtensions.GetRandomizedDirections(_random))
            {
                Coordinate move = way.TransformDirectionToDelta();

                Coordinate pos = coordinatePicked + move;

                if (IsCellInBounds(maze, pos) && maze[pos.X][pos.Y] == 0)
                {
                    maze[coordinatePicked.X][coordinatePicked.Y] |= (byte)way;
                    maze[pos.X][pos.Y] |= (byte)way.GetOppositeDirection();

                    coordinates.Add(pos);

                    index = -1;
                    break;
                }
            }

            if (index != -1)
                coordinates.RemoveAt(index);
        }
    }

    private static bool IsCellInBounds(byte[][] maze, Coordinate pos)
    {
        return pos.X >= 0 && pos.X < maze.Length &&
               pos.Y >= 0 && pos.Y < maze[0].Length;
    }

    private Cells[][] TransformLineToBlock(byte[][] maze)
    {
        var lineToBlock = new Cells[(2 * maze.Length) + 1][];

        for (int i = 0; i < lineToBlock.Length; i++)
            lineToBlock[i] = new Cells[(2 * maze[0].Length) + 1];

        for (int wall = 0; wall < (2 * maze[0].Length) + 1; wall++) lineToBlock[0][wall] = Cells.Wall;
        for (int wall = 0; wall < (2 * maze.Length) + 1; wall++) lineToBlock[wall][0] = Cells.Wall;

        for (int y = 0; y < maze[0].Length; y++)
        {
            for (int x = 0; x < maze.Length; x++)
            {
                lineToBlock[(2 * x) + 1][(2 * y) + 1] = Cells.Empty;

                if ((maze[x][y] & (byte)Direction.East) != 0)
                    lineToBlock[(2 * x) + 2][(2 * y) + 1] = Cells.Empty;
                else
                    lineToBlock[(2 * x) + 2][(2 * y) + 1] = Cells.Wall;

                if ((maze[x][y] & (byte)Direction.South) != 0)
                    lineToBlock[(2 * x) + 1][(2 * y) + 2] = Cells.Empty;
                else
                    lineToBlock[(2 * x) + 1][(2 * y) + 2] = Cells.Wall;


                lineToBlock[(2 * x) + 2][(2 * y) + 2] = Cells.Wall;
            }
        }

        return lineToBlock;
    }
}