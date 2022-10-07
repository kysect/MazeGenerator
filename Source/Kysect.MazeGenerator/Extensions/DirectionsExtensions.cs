using Kysect.MazeGenerator.Models;

namespace Kysect.MazeGenerator.Extensions;

public static class DirectionsExtensions
{
    public static Directions GetOpposite(this Directions direction) => direction switch
    {
        Directions.Up => Directions.Down,
        Directions.Down => Directions.Up,
        Directions.Left => Directions.Right,
        Directions.Right => Directions.Left,
        _ => throw new ArgumentOutOfRangeException(nameof(direction))
    };

    public static Coordinate ToCoordinate(this Directions direction) => direction switch
    {
        Directions.Up => new Coordinate(-1, 0),
        Directions.Down => new Coordinate(1, 0),
        Directions.Left => new Coordinate(0, -1),
        Directions.Right => new Coordinate(0, 1),
        _ => throw new ArgumentOutOfRangeException(nameof(direction))
    };
}
