namespace Kysect.MazeGenerator.MazeGenerators.GrowingTree;

public struct Cell
{
    public int X { get; init; }
    public int Y { get; init; }

    public Cell(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static Cell operator +(Cell a, Cell b) => new(a.X + b.X, a.Y + b.Y);
}