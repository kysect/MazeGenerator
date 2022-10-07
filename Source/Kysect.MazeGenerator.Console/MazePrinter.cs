using Kysect.MazeGenerator.Entities;
using Kysect.MazeGenerator.Models;

namespace Kysect.MazeGenerator.Console;

public static class MazePrinter
{
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

        block[0][0] = '#';
        block[0][2] = '#';
        block[2][0] = '#';
        block[2][2] = '#';

        if (!cell.ConnectedWith(Directions.Left))
            block[1][0] = '#';

        if (!cell.ConnectedWith(Directions.Up))
            block[0][1] = '#';

        if (!cell.ConnectedWith(Directions.Right))
            block[1][2] = '#';

        if (!cell.ConnectedWith(Directions.Down))
            block[2][1] = '#';

        return block;
    }
}
