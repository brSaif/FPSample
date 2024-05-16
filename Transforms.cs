using FPSample.Data;
using FPSample.Models;

static class Transforms
{
    public static Func<string, Task<IEnumerable<BookType>>> For(this FilterF filter, Func<Task<IEnumerable<BookType>>> dataSource)
        => phrase => filter(dataSource, phrase);
}