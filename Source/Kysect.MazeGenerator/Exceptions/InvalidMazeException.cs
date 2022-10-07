namespace Kysect.MazeGenerator.Exceptions;

public class InvalidMazeException : MazeGeneratorDomainException
{
    private InvalidMazeException(string? message)
        : base(message)
    { }

    public static InvalidMazeException OnInvalidSize(int size)
        => new InvalidMazeException($"Size ({size}) must be greater than 0");
}
