using System.Globalization;

namespace SlugsSample;

public record PersonalName(string Firstname, string MiddleName, string Lastname);

public delegate Slug PersonalNameToSlug(CultureInfo cultureInfo, PersonalName personalName);