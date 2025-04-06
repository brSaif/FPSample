//using static SlugsSample;

using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using SlugsSample;
using static SlugsSample.HandleSlugConversions;
using static SlugsSample.HandleTransforms;

Console.WriteLine("Hello, World!");

var collection = new ServiceCollection();

collection.AddSingleton<PersonalNameToSlug>(_ => ((info, name) => 
        new Handle(name.Firstname, name.Lastname)
            .Transform(ToLowercase(info), IntoLetterAndDigitRuns)
            .ToSlug(Hyphenate)));
            
var serviceProvider =  collection.BuildServiceProvider();

var name = new PersonalName("John", String.Empty, "Doe");

var culture = CultureInfo.CurrentCulture; 

var personalNameToSlug = serviceProvider.GetRequiredService<PersonalNameToSlug>();

var slug = personalNameToSlug(culture, name).Value;