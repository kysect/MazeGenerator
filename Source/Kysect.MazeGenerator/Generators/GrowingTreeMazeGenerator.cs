using Kysect.MazeGenerator.Entities;
using Kysect.MazeGenerator.Extensions;
using Kysect.MazeGenerator.Models;

namespace Kysect.MazeGenerator.Generators;

public class GrowingTreeMazeGenerator : IMazeGenerator
{
    public Maze CreateMaze(int size)
    {
        var maze = new Maze(size);

        var cells = new Stack<Cell>();
        cells.Push(GetRandomCell(maze));

        while (cells.Count > 0)
        {
            Cell currentCell = cells.Peek();

            if (!GetPossibleDirections(currentCell).Any())
            {
                cells.Pop();
                continue;
            }

            Directions nextCellDirection = GetPossibleDirections(currentCell).GetRandom();
            Cell nextCell = maze.GetCellAt(currentCell.Coordinate + nextCellDirection.ToCoordinate());

            currentCell.ConnectWith(nextCellDirection);
            nextCell.ConnectWith(nextCellDirection.GetOpposite());

            cells.Push(nextCell);
        }

        return maze;
    }

    private Cell GetRandomCell(Maze maze)
    {
        var random = new Random((int)DateTime.Now.Ticks);

        int x = random.Next(maze.Size);
        int y = random.Next(maze.Size);

        return maze.GetCellAt(x, y);
    }

    private IEnumerable<Directions> GetPossibleDirections(Cell cell)
    {
        return Enum.GetValues<Directions>()
            .Where(d => cell.Maze.Contains(cell.Coordinate + d.ToCoordinate()))
            .Where(d => !IsVisitedCell(cell.Maze.GetCellAt(cell.Coordinate + d.ToCoordinate())));
    }

    private bool IsVisitedCell(Cell cell)
    {
        return cell.Connections.Any();
    }
}
