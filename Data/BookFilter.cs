using FPSample.Models;

namespace FPSample.Data;

public class BookFilter
{
    public static async Task<IEnumerable<BookType>> Filter(Func<Task<IEnumerable<BookType>>> dataSource, string phrase)
        => (await dataSource()).Where(b => b.Title.Contains(phrase, StringComparison.OrdinalIgnoreCase));
    
    
}