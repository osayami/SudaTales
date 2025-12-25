namespace OsayamiBlog.Models;

public sealed class RegisteredAnnotation
{
    public string Id { get; init; } = Guid.NewGuid().ToString();

    public Annotation Annotation { get; init; } = default!;

    public AnnotationLocation Location { get; init; } = default!;
}
