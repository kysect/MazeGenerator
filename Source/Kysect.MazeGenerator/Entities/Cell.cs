using Kysect.MazeGenerator.Exceptions;
using Kysect.MazeGenerator.Extensions;
using Kysect.MazeGenerator.Models;

namespace Kysect.MazeGenerator.Entities;

public class Cell
{
    private readonly HashSet<Directions> _connections;

    public Cell(Maze maze, Coordinate coordinate)
    {
        ArgumentNullException.ThrowIfNull(maze);

        Maze = maze;
        Coordinate = coordinate;

        _connections = new HashSet<Directions>();
    }

    public Maze Maze { get; }
    public Coordinate Coordinate { get; }

    public IEnumerable<Directions> Connections => _connections.AsEnumerable();

    public void ConnectTo(Directions direction)
    {
        if (!Maze.Contains(Coordinate + direction.ToCoordinate()))
            throw new NotImplementedException();

        if (!_connections.Add(direction))
            throw InvalidCellOperationException.OnFailedConnection(direction);
    }

    public void SeparateFrom(Directions direction)
    {
        if (!_connections.Remove(direction))
            throw InvalidCellOperationException.OnFailedSeparation(direction);
    }

    public bool ConnectedWith(Directions direction)
    {
        return _connections.Contains(direction);
    }

    public IEnumerable<Directions> GetPossibleConnections()
    {
        foreach (Directions direction in Enum.GetValues<Directions>())
        {
            if (Maze.Contains(Coordinate + direction.ToCoordinate()) && !ConnectedWith(direction))
                yield return direction;
        }
    }
}
