namespace SudaTales.Models;

public sealed class Annotation
{
    public string Id { get; init; } = Guid.NewGuid().ToString();
    public string Text { get; set; } = "";
    public AnnotationLocation Location { get; init; } = default!;
}