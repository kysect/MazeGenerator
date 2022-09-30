namespace Kysect.MazeGenerator.MazeGenerators.GrowingTree;

public enum Direction
{
    North = 0x1,
    West = 0x2,
    South = 0x4,
    East = 0x8
}

public static class DirectionExtensions
{
    public static Direction GetOppositeDirection(this Direction direction)
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

    public static Direction[] GetRandomizedDirections(Random rnd)
    {
        Direction[] directions = Enum.GetValues<Direction>();

        for (int i = 0; i < directions.Length; i++)
        {
            int r = i + (int)(rnd.NextDouble() * (directions.Length - i));
            (directions[r], directions[i]) = (directions[i], directions[r]);
        }
        return directions;
    }

    public static Coordinate TransformDirectionToDelta(this Direction facingDirection)
    {
        return facingDirection switch
        {
            Direction.North => new Coordinate(0, -1),
            Direction.South => new Coordinate(0, 1),
            Direction.East => new Coordinate(1, 0),
            Direction.West => new Coordinate(-1, 0),
            _ => new Coordinate(0, 0)
        };
    }

    public static Coordinate TransformDirectionToCoordinate(this Direction facingDirection, int index, int size)
    {
        return facingDirection switch
        {
            Direction.North => new Coordinate(0, index),
            Direction.South => new Coordinate(size - 1, index),
            Direction.East => new Coordinate(index, size - 1),
            Direction.West => new Coordinate(index, 0),
            _ => new Coordinate(0, 0)
        };
    }
}


