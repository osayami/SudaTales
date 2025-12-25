using System;
using System.Collections.Generic;

namespace SudaTales.Models;

public sealed class StoryModel
{
    public string Slug { get; init; } = "";
    public string Title { get; init; } = "";
    public string? Summary { get; init; }
    public DateTime Published { get; init; }

    public List<Paragraph> Paragraphs { get; init; } = [];
}
