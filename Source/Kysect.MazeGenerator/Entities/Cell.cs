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

    public void ConnectWith(Directions direction)
    {
        if (!Maze.Contains(Coordinate + direction.ToCoordinate()))
            throw InvalidCellOperationException.OnConnectionWithNonExistentCell(Coordinate + direction.ToCoordinate());

        if (!_connections.Add(direction))
            throw InvalidCellOperationException.OnFailedConnection(direction);
    }

    public void SeparateFrom(Directions direction)
    {
        if (!_connections.Remove(direction))
            throw InvalidCellOperationException.OnFailedSeparation(direction);
    }

    public bool IsConnectedWith(Directions direction)
    {
        return _connections.Contains(direction);
    }
}
