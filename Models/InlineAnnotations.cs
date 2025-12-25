namespace SudaTales.Models;

public sealed class InlineAnnotation
{
    public string AnnotationId { get; init; } = "";

    public int Start { get; init; }
    public int Length { get; init; }
}
