namespace FPSample.Models;

public record NameType(string Name);

public static class Name
{
    public static NameType[]? CreateMany(params NameType[] authors)
        => authors.ToArray();

    public static NameType? Create(string firstName, string lastName)
        => string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName)
            ? null
            : new NameType($"{lastName} {firstName}");

    public static NameType? Create(string name)
        => string.IsNullOrWhiteSpace(name)
            ? null
            : new NameType(name);
}