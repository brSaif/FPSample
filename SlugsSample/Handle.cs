namespace SlugsSample;

public record Handle(params string[] Components);

// declare operations
public delegate Slug HandleToSlug(Handle handle);

public delegate Handle TransformHandle(Handle handle);

public static class HandleTransformationCompositions
{
    // e.g. ToLowercase.Then(StopAtColon)
    public static TransformHandle Then(this TransformHandle first, TransformHandle second) =>
    handle => second(first(handle));
    
    //e.g. handle.Transform(ToLowercase, StopAtColon)
    public static Handle Transform(this Handle handle, params TransformHandle[] transforms) =>
    transforms.Aggregate(handle, (current, transform) => transform(current));

    //e.g. handle.Transform(ToLowercase, StopAtColon).ToSlug(Hyphenate)
    public static Slug ToSlug(this Handle handle, HandleToSlug conversion) =>
        conversion(handle);
}

public static class HandleSlugConversions
{
    public static HandleToSlug Concatenate => 
        handle => new Slug(string.Join(String.Empty, handle.Components));
    
    public static HandleToSlug Hyphenate =>
    hadle => new Slug(string.Join('-', hadle.Components));
}