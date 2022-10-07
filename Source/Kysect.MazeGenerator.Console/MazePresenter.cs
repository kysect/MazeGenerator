using Kysect.MazeGenerator.Entities;
using Kysect.MazeGenerator.Models;

namespace Kysect.MazeGenerator.Console;

public static class MazePresenter
{
    private const char WALL = '@';

    public static char[][] MazeToGameMap(Maze maze)
    {
        char[][] gameMap;

        int gameMapSize = (2 * maze.Size) + 1;
        gameMap = new char[gameMapSize][];

        for (int i = 0; i < gameMapSize; ++i)
        {
            gameMap[i] = new char[gameMapSize];
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
                for (int k = 0; k < 2; ++k)
                {
                    for (int l = 0; l < 2; ++l)
                    {
                        gameMap[(2 * i) + k][(2 * j) + l] = blocks[j][k][l];
                    }
                }
            }
        }

        for (int i = 0; i < gameMapSize; ++i)
        {
            gameMap[i][^1] = WALL;
            gameMap[^1][i] = WALL;
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

        block[0][0] = WALL;
        block[0][2] = WALL;
        block[2][0] = WALL;
        block[2][2] = WALL;

        if (!cell.IsConnectedWith(Directions.Left))
            block[1][0] = WALL;

        if (!cell.IsConnectedWith(Directions.Up))
            block[0][1] = WALL;

        if (!cell.IsConnectedWith(Directions.Right))
            block[1][2] = WALL;

        if (!cell.IsConnectedWith(Directions.Down))
            block[2][1] = WALL;

        return block;
    }
}
