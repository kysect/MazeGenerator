namespace Kysect.MazeGenerator;

public interface IMazeGenerator
{
    Cells[][] Generate(int size);
}