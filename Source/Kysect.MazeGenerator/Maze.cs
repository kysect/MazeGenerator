namespace Kysect.MazeGenerator;

public static class Maze
{
    private static readonly Random Random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

    public static byte[][] CreateMaze(ushort width, ushort height)
    {
        int h = Random.Next(width, height);

        byte[][] maze = new byte[h][];

        for (int i = 0; i < h; i++)
        {
            maze[i] = new byte[h];
        }
        GenerateTWMaze_GrowingTree(maze);
        return LineToBlock(maze);
    }

    private static void GenerateTWMaze_GrowingTree(byte[][] maze)
    {
        var cells = new List<ushort[]>();

        ushort x = (byte)(Random.Next(maze.Length - 1) + 1);
        ushort y = (byte)(Random.Next(maze[0].Length - 1) + 1);

        cells.Add(new[]
        {
            x, y
        });

        while (cells.Count > 0)
        {
            short index = (short)ChooseIndex((ushort)cells.Count);
            ushort[] cellPicked = cells[index];

            x = cellPicked[0];
            y = cellPicked[1];

            foreach (Direction way in RandomizeDirection())
            {
                sbyte[] move = DoAStep(way);

                short nx = (short)(x + move[0]);
                short ny = (short)(y + move[1]);

                if (nx >= 0 && ny >= 0 && nx < maze.Length && ny < maze[0].Length && maze[nx][ny] == 0)
                {
                    maze[x][y] |= (byte)way;
                    maze[nx][ny] |= (byte)way.OppositeDirection();

                    cells.Add(new[]
                    {
                        (ushort) nx, (ushort) ny
                    });

                    index = -1;
                    break;
                }
            }

            if (index != -1) cells.RemoveAt(index);
        }
    }

    public static Direction OppositeDirection(this Direction direction)
    {
        return direction switch
        {
            Direction.North => Direction.South,
            Direction.South => Direction.North,
            Direction.East => Direction.West,
            Direction.West => Direction.East,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }


    private static ushort ChooseIndex(ushort max)
    {
        ushort index = 0;

        if (max >= 1)
            index = (ushort)(max - 1);
        else
            index = 0;

        return index;
    }

    private static Direction[] RandomizeDirection()
    {
        var directions = (Direction[])Enum.GetValues(typeof(Direction));
        Shuffle(directions);
        return directions;
    }

    // comes from http://www.dotnetperls.com/fisher-yates-shuffle
    private static void Shuffle<T>(T[] array)
    {
        int n = array.Length;

        for (int i = 0; i < n; i++)
        {
            int r = i + (int)(Random.NextDouble() * (n - i));
            (array[r], array[i]) = (array[i], array[r]);
        }
    }


    private static sbyte[] DoAStep(Direction facingDirection)
    {
        sbyte[] step =
        {
            0, 0
        };

        switch (facingDirection)
        {
            case Direction.North:
                step[0] = 0;
                step[1] = -1;
                break;
            case Direction.South:
                step[0] = 0;
                step[1] = 1;
                break;
            case Direction.East:
                step[0] = 1;
                step[1] = 0;
                break;
            case Direction.West:
                step[0] = -1;
                step[1] = 0;
                break;
        }

        return step;
    }


    private static byte[][] LineToBlock(byte[][] maze)
    {
        if (maze == null || (maze.GetLength(0) <= 1 && maze.GetLength(1) <= 1))
            throw new ArgumentException("");

        byte[][] lineToBlock = new byte[(2 * maze.Length) + 1][];

        for (int i = 0; i < lineToBlock.Length; i++)
            lineToBlock[i] = new byte[(2 * maze[0].Length) + 1];

        for (ushort wall = 0; wall < (2 * maze[0].Length) + 1; wall++) lineToBlock[0][wall] = 1;
        for (ushort wall = 0; wall < (2 * maze.Length) + 1; wall++) lineToBlock[wall][0] = 1;

        for (ushort y = 0; y < maze[0].Length; y++)
        {
            for (ushort x = 0; x < maze.Length; x++)
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