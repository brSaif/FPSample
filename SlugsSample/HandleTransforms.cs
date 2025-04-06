using System.Globalization;

namespace SlugsSample;

public static class HandleTransforms
{
    public static TransformHandle ToLowercase(CultureInfo cultureInfo)
        => handle => new Handle(handle.Components.Select(x => cultureInfo.TextInfo.ToLower(x)).ToArray());

    public static TransformHandle IntoLetterAndDigitRuns
        => handle => new(handle.Components.SelectMany(SplitLetterAndDigitRuns).ToArray());

    private static IEnumerable<string> SplitLetterAndDigitRuns(string s)
    {
        int start = 0;
     
        while (start < s.Length && !char.IsLetterOrDigit(s[start])) start += 1;

        while (start < s.Length)
        {
            int end = start + 1;

            while (end < s.Length && !char.IsLetterOrDigit(s[end])) end =+ 1;

            yield return s[start..end];
            
            start = end;
        }
    }
    
    public static TransformHandle StopAtColon =>
        handle => new Handle(StopStringAtColon(handle.Components).ToArray());

    private static IEnumerable<string> StopStringAtColon(IEnumerable<string> strings)
    {
        foreach (var s in strings)
        {
            int colon = s.IndexOf(':');
            if (colon >= 0)
            {
                yield return s [..colon];
                yield break;
            }
            
            yield return s;
        }
    }
}