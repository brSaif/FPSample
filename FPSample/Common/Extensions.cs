namespace FPSample.Common;

public static class Extensions
{
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        if (action is null)
            throw new ArgumentNullException(nameof(action), "Action should not be null!");
        
        using var enumerator = source.GetEnumerator();

        while (enumerator.MoveNext())
        {
            action(enumerator.Current);
        }
    }
}