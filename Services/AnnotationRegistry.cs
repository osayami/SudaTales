using OsayamiBlog.Models;

namespace OsayamiBlog.Services;

public sealed class AnnotationRegistry
{
    private readonly Dictionary<string, RegisteredAnnotation> _byId = [];

    public IReadOnlyCollection<RegisteredAnnotation> All
        => _byId.Values;

    public void Register(
        Annotation annotation,
        AnnotationLocation location)
    {
        var entry = new RegisteredAnnotation
        {
            Annotation = annotation,
            Location = location
        };

        _byId[entry.Id] = entry;
    }

    public RegisteredAnnotation? Get(string id)
        => _byId.TryGetValue(id, out var a) ? a : null;
}
