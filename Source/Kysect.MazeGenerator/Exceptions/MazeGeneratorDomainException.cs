namespace Kysect.MazeGenerator.Exceptions;

public abstract class MazeGeneratorDomainException : Exception
{
    protected MazeGeneratorDomainException(string? message)
        : base(message)
    { }
}
