namespace SudaTales.Models;
public sealed class StoryModel
{
    public string Slug { get; init; } = "";
    public string Title { get; init; } = "";
    public string Author { get; init; } = "";
    public string Language { get; init; } = "";
    public string? Summary { get; init; }
    public DateTime Published { get; init; }
    public List<ChapterModel> Chapters { get; init; } = [];
}