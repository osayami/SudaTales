namespace SudaTales.Models;

public sealed class ChapterModel
{
    public string Id { get; init; } = Guid.NewGuid().ToString();
    public string Title { get; init; } = "";
    public int Order { get; init; }

    public List<Paragraph> Paragraphs { get; init; } = [];
}
