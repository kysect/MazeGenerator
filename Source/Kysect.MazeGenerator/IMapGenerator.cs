namespace Kysect.MazeGenerator;

public interface IMapGenerator
{
    Cells[][] Generate(int size);
}