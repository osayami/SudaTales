namespace OsayamiBlog.Models;

public sealed class Paragraph
{
    public string Id { get; init; } = Guid.NewGuid().ToString();

    public string Text { get; set; } = "";

    public List<InlineAnnotation> Annotations { get; } = [];
}
