namespace Kysect.MazeGenerator.Extensions;

public static class EnumerableExtensions
{
    public static T GetRandom<T>(this IEnumerable<T> collection)
    {
        var random = new Random((int)DateTime.Now.Ticks);

        int index = random.Next(collection.Count());

        return collection.ElementAt(index);
    }

    public static bool IsEmpty<T>(this IEnumerable<T> collection)
    {
        return !collection.Any();
    }
}
