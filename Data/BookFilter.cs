using FPSample.Models;

namespace FPSample.Data;

public delegate Task<IEnumerable<BookType>> FilterF(Func<Task<IEnumerable<BookType>>> dataSource, string phrase);

public class BookFilter
{
    public static  FilterF Filter
        => async (dataSource, phrase)
        => (await dataSource()).Where(b => b.Title.Contains(phrase, StringComparison.OrdinalIgnoreCase));
    
    
}