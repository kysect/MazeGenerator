namespace Kysect.MazeGenerator.MazeGenerators.GrowingTree;

[Flags]
#pragma warning disable CA1028 // Enum Storage should be Int32
public enum Direction : byte
#pragma warning restore CA1028 // Enum Storage should be Int32
{
    North = 0x1,
    West = 0x2,
    South = 0x4,
    East = 0x8
}