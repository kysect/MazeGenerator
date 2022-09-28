namespace Kysect.MazeGenerator.MazeGenerators.GrowingTree;

public class GrowingTreeGenerator : IMazeGenerator
{
    private readonly Random _random;

    public GrowingTreeGenerator(int seed)
    {
        _random = new Random(seed);
    }

    public byte[][] Generate(int size)
    {
        if (size < 2)
            throw new ArgumentException($"{nameof(size)} must be greater than 1");

        byte[][] maze = new byte[size][];

        for (int i = 0; i < size; i++) maze[i] = new byte[size];

        GenerateMazeGrowingTree(maze);
        return TransformLineToBlock(maze);
    }

    private void GenerateMazeGrowingTree(byte[][] maze)
    {
        var cells = new List<Cell>();

        int x = _random.Next(maze.Length - 1) + 1;
        int y = _random.Next(maze[0].Length - 1) + 1;

        cells.Add(new Cell(x, y));

        while (cells.Count > 0)
        {
            int index = Math.Max(cells.Count - 1, 0);
            Cell cellPicked = cells[index];

            foreach (Direction way in DirectionExtensions.GetRandomizedDirections(_random))
            {
                Cell move = way.TransformDirectionToDelta();

                Cell pos = cellPicked + move;

                if (IsCellInBounds(maze, pos) && maze[pos.X][pos.Y] == 0)
                {
                    maze[cellPicked.X][cellPicked.Y] |= (byte)way;
                    maze[pos.X][pos.Y] |= (byte)way.GetOppositeDirection();

                    cells.Add(pos);

                    index = -1;
                    break;
                }
            }

            if (index != -1)
                cells.RemoveAt(index);
        }
    }

    private static bool IsCellInBounds(byte[][] maze, Cell pos)
    {
        return pos.X >= 0 && pos.X < maze.Length &&
               pos.Y >= 0 && pos.Y < maze[0].Length;
    }

    private byte[][] TransformLineToBlock(byte[][] maze)
    {
        byte[][] lineToBlock = new byte[(2 * maze.Length) + 1][];

        for (int i = 0; i < lineToBlock.Length; i++)
            lineToBlock[i] = new byte[(2 * maze[0].Length) + 1];

        for (int wall = 0; wall < (2 * maze[0].Length) + 1; wall++) lineToBlock[0][wall] = 1;
        for (int wall = 0; wall < (2 * maze.Length) + 1; wall++) lineToBlock[wall][0] = 1;

        for (int y = 0; y < maze[0].Length; y++)
        {
            for (int x = 0; x < maze.Length; x++)
            {
                lineToBlock[(2 * x) + 1][(2 * y) + 1] = 0;

                if ((maze[x][y] & (byte)Direction.East) != 0)
                    lineToBlock[(2 * x) + 2][(2 * y) + 1] = 0; // B
                else
                    lineToBlock[(2 * x) + 2][(2 * y) + 1] = 1;

                if ((maze[x][y] & (byte)Direction.South) != 0)
                    lineToBlock[(2 * x) + 1][(2 * y) + 2] = 0; // C
                else
                    lineToBlock[(2 * x) + 1][(2 * y) + 2] = 1;


                lineToBlock[(2 * x) + 2][(2 * y) + 2] = 1;
            }
        }

        return lineToBlock;
    }
}