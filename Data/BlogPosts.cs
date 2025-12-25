using Microsoft.AspNetCore.Components;
using OsayamiBlog.Models;
using OsayamiBlog.Components;

namespace OsayamiBlog.Data;

public static class BlogPosts
{
    public static readonly IReadOnlyList<BlogPost> All =
    [
   new BlogPost
{
    Slug = "user-annotations",
    Title = "User Annotations",
    Published = DateTime.Today,
    Paragraphs =
    [
        new Paragraph
        {
            Text = "This paragraph can be annotated by selecting text."
        }
    ]
}

    ];

    public static BlogPost? Get(string slug)
        => All.FirstOrDefault(p => p.Slug == slug);
}
