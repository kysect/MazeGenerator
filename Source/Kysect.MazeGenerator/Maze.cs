
namespace Kysect.MazeGenerator;

public class Maze
{
    public Cells[][] Map { get; init; }

    public int Size { get; set; }

    public Maze(Cells[][] map)
    {
        Map = map;
        Size = map.GetLength(0);
    }
}
