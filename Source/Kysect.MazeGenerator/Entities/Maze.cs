using Kysect.MazeGenerator.Exceptions;
using Kysect.MazeGenerator.Models;

namespace Kysect.MazeGenerator.Entities;

public class Maze
{
    private readonly Cell[][] _cells;

    public Maze(int size)
    {
        if (size <= 0)
            throw InvalidMazeException.OnInvalidSize(size);

        Size = size;

        _cells = new Cell[size][];

        for (int i = 0; i < size; i++)
        {
            _cells[i] = new Cell[size];
        }

        for (int i = 0; i < size; ++i)
        {
            for (int j = 0; j < size; ++j)
            {
                _cells[i][j] = new Cell(this, new Coordinate(i, j));
            }
        }
    }

    public int Size { get; }

    public Cell GetCellAt(Coordinate coordinate)
    {
        if (!Contains(coordinate))
            throw new NotImplementedException();

        return _cells[coordinate.X][coordinate.Y];
    }

    public bool Contains(Coordinate coordinate)
    {
        return coordinate.X >= 0
            && coordinate.Y >= 0
            && coordinate.X < Size
            && coordinate.Y < Size;
    }
}