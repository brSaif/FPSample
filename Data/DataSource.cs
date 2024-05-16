using FPSample.Models;

namespace FPSample.Data;

public class DataSource
{
    public static Task<IEnumerable<BookType>> GetBooks()
    {
        var a = Book.Create("Design Patterns", Name.CreateMany(
            Name.Create("Erick", "Gamma"), Name.Create("Richard", "Helm"),
            Name.Create("Ralph", "Johnson"), Name.Create("Kernighan"),
            Name.Create("Ritchie")));

        var b = Book.Create("The C Programming Language", Name.CreateMany(
            Name.Create("Kernighan"), Name.Create("Ritchie"))!);

        return Task.FromResult<IEnumerable<BookType>>([a!, b!]);
    }
}