using Kysect.MazeGenerator.Entities;
using Kysect.MazeGenerator.Extensions;
using Kysect.MazeGenerator.Models;

namespace Kysect.MazeGenerator.Generators;

public class GrowingTreeMazeGenerator : IMazeGenerator
{
    public Maze CreateMaze(int size)
    {
        var maze = new Maze(size);

        var cells = new List<Cell>() { maze.GetCellAt(new Coordinate(0, 0)) };

        while (cells.Count > 0)
        {
            Cell currentCell = cells[^1];

            IEnumerable<Directions> possibleConnections = GetPossibleConnections(currentCell);

            if (!possibleConnections.Any())
            {
                cells.Remove(currentCell);
                continue;
            }

            Directions direction = GetPossibleConnections(currentCell).GetRandom();
            Cell nextCell = maze.GetCellAt(currentCell.Coordinate + direction.ToCoordinate());

            currentCell.ConnectTo(direction);
            nextCell.ConnectTo(direction.GetOpposite());

            cells.Remove(currentCell);
            cells.Add(nextCell);
        }

        return maze;
    }

    private IEnumerable<Directions> GetPossibleConnections(Cell cell)
    {
        foreach (Directions direction in Enum.GetValues<Directions>())
        {
            if (cell.Maze.Contains(cell.Coordinate + direction.ToCoordinate())
                && !cell.Maze.GetCellAt(cell.Coordinate + direction.ToCoordinate()).Connections.Any())
            {
                yield return direction;
            }
        }
    }
}
