namespace OsayamiBlog.Models;
public sealed class Annotation
{
    public string Id { get; init; } = Guid.NewGuid().ToString();
    public string Label { get; init; } = "";
    public string Body { get; init; } = "";
}
