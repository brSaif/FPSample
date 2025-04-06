using System.Globalization;

namespace SlugsSample;

public class Author : IEquatable<Author>
{
    
    public int Id { get; private set; }
    public string FullName { get; private set; }
    public PersonalName Name { get; private set; }
    public string Key { get; private set; }
    public CultureInfo Culture { get; private set; }

    public static Author CreateNew(string fullName, PersonalName name, CultureInfo culture, string key)
    => new Author(0, fullName, name, culture, key);
    
    
    public static Author CreateExisting(int id, string fullName, PersonalName name, CultureInfo culture, string key) =>
        new( id < 0 ? throw new ArgumentException("Identity needs to be positive", nameof(id)) : id, fullName, name, culture, key);
    
    private Author(int id, string fullName, CultureInfo culture, string key)
    {
        Id = id;
        FullName = fullName;
        Culture = culture;
        Key = key;
    }
    
    private Author(int id, string fullName, PersonalName name, CultureInfo culture, string key)
        : this(id, fullName, culture, key)
    {
        Name = name;
    }
    
    public bool Equals(Author? other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Author)obj);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}