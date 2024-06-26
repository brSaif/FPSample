﻿using FPSample.Common;
using FPSample.Data;
using FPSample.Models;
using static FPSample.Data.DataSource;
using static FPSample.Data.BookFilter;

Console.WriteLine("Hello world!");

FilterF filter = Filter;

await PromptAndReport(filter.For(GetBooks));

// -----
await PromptAndReport(phrase => Filter(GetBooks, phrase));

async Task PromptAndReport(Func<string, Task<IEnumerable<BookType>>> dataSource)
{
    Console.Write("Enter search phrase : ");
    string phrase = Console.ReadLine() ?? string.Empty;
    
    if (string.IsNullOrWhiteSpace(phrase)) return;

    (await dataSource(phrase)).ForEach(Console.WriteLine);
}