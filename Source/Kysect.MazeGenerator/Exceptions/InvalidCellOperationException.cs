using Kysect.MazeGenerator.Models;

namespace Kysect.MazeGenerator.Exceptions;

public class InvalidCellOperationException : MazeGeneratorDomainException
{
    private InvalidCellOperationException(string? message)
        : base(message)
    { }

    public static InvalidCellOperationException OnFailedConnection(Directions direction)
        => new InvalidCellOperationException($"Failed connecting cell to {direction}");

    public static InvalidCellOperationException OnFailedSeparation(Directions direction)
        => new InvalidCellOperationException($"Failed separating call from {direction}");

    public static InvalidCellOperationException OnConnectionWithNonExistentCell(Coordinate coordinate)
        => new InvalidCellOperationException($"Unable connect, maze hasn't cell with coordinate {coordinate}");
}
