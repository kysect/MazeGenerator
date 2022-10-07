namespace Kysect.MazeGenerator.Models;

public readonly record struct Coordinate
{
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; init; }
    public int Y { get; init; }

    public static Coordinate operator +(Coordinate a, Coordinate b)
        => new Coordinate(a.X + b.X, a.Y + b.Y);

    public static Coordinate operator -(Coordinate a, Coordinate b)
        => new Coordinate(a.X - b.X, a.Y - b.Y);

    public static double Distance(Coordinate a, Coordinate b)
        => Math.Sqrt((a.X * a.X) + (a.Y * a.Y));

    public override string ToString()
        => $"({X}; {Y})";
}