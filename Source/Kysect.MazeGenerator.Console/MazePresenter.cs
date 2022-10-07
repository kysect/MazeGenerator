using Kysect.MazeGenerator.Entities;
using Kysect.MazeGenerator.Models;

namespace Kysect.MazeGenerator.Console;

public static class MazePresenter
{
    public static char[][] MazeToGameMap(Maze maze)
    {
        char[][] gameMap;

        gameMap = new char[3 * maze.Size][];

        for (int i = 0; i < 3 * maze.Size; ++i)
        {
            gameMap[i] = new char[3 * maze.Size];
        }

        for (int i = 0; i < maze.Size; ++i)
        {
            char[][][] blocks = new char[maze.Size][][];

            for (int j = 0; j < maze.Size; ++j)
            {
                blocks[j] = CellToBlock(maze.GetCellAt(new Coordinate(i, j)));
            }

            for (int j = 0; j < maze.Size; ++j)
            {
                for (int k = 0; k < 3; ++k)
                {
                    for (int l = 0; l < 3; ++l)
                    {
                        gameMap[(3 * i) + k][(3 * j) + l] = blocks[j][k][l];
                    }
                }
            }
        }

        return gameMap;
    }

    public static char[][] CellToBlock(Cell cell)
    {
        char[][] block = new char[3][];

        for (int i = 0; i < 3; ++i)
        {
            block[i] = new char[3];
        }

        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                block[i][j] = ' ';
            }
        }

        block[0][0] = 'O';
        block[0][2] = 'O';
        block[2][0] = 'O';
        block[2][2] = 'O';

        if (!cell.IsConnectedWith(Directions.Left))
            block[1][0] = 'O';

        if (!cell.IsConnectedWith(Directions.Up))
            block[0][1] = 'O';

        if (!cell.IsConnectedWith(Directions.Right))
            block[1][2] = 'O';

        if (!cell.IsConnectedWith(Directions.Down))
            block[2][1] = 'O';

        return block;
    }
}
