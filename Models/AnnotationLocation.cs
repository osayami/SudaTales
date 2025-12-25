namespace SudaTales.Models;

public sealed class AnnotationLocation
{
    public string PostSlug { get; init; } = "";
    public string ParagraphId { get; init; } = "";
    public int Start { get; init; }
    public int Length { get; init; }
}
