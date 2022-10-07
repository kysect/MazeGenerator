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

            if (!currentCell.GetPossibleConnections().Any())
            {
                cells.Remove(currentCell);
                continue;
            }

            Directions direction = currentCell.GetPossibleConnections().GetRandom();
            Cell nextCell = maze.GetCellAt(currentCell.Coordinate + direction.ToCoordinate());

            currentCell.ConnectTo(direction);
            nextCell.ConnectTo(direction.GetOpposite());

            cells.Remove(currentCell);
            cells.Add(nextCell);
        }

        return maze;
    }
}
