using System;
using System.Collections.Generic;

namespace OsayamiBlog.Models;

public sealed class BlogPost
{
    public string Slug { get; init; } = "";
    public string Title { get; init; } = "";
    public DateTime Published { get; init; }

    /// <summary>
    /// Ordered paragraphs that make up the blog post body.
    /// Each paragraph owns its own text and annotations.
    /// </summary>
    public List<Paragraph> Paragraphs { get; init; } = [];
}
