using SudaTales.Models;

namespace SudaTales.Data;

public static class StoryRepository
{
    public static readonly IReadOnlyList<StoryModel> All =
    [
        new StoryModel
        {
            Slug = "test-story",
            Title = "Test Story",
            Summary = "A short test story.",
            Published = DateTime.Today,
            Paragraphs =
            [
                new Paragraph
                {
                    Text = "This is the opening paragraph of the story."
                }
            ]
        }
    ];

    public static StoryModel? Get(string slug)
        => All.FirstOrDefault(s => s.Slug == slug);
}
