namespace SudaTales.Models;

public sealed class AnnotationLocation
{
    // Identifies the story (formerly PostSlug)
    public string StorySlug { get; init; } = "";

    // Identifies the chapter within the story
    public string ChapterId { get; init; } = "";

    // Identifies the paragraph
    public string ParagraphId { get; init; } = "";

    // Optional: character offsets inside the paragraph
    // (safe to keep even if unused for now)
    public int? StartOffset { get; init; }
    public int? EndOffset { get; init; }
}