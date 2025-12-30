using SudaTales.Models;

namespace SudaTales.Services;

public sealed class AnnotationRegistry
{
    private readonly List<Annotation> _annotations = [];

    public void Add(Annotation annotation)
    {
        _annotations.Add(annotation);
    }

    public IReadOnlyList<Annotation> GetAll()
        => _annotations;

    public IEnumerable<Annotation> GetByStory(string storySlug)
        => _annotations.Where(a => a.Location.StorySlug == storySlug);

    public IEnumerable<Annotation> GetByChapter(string storySlug, string chapterId)
        => _annotations.Where(a =>
            a.Location.StorySlug == storySlug &&
            a.Location.ChapterId == chapterId);
}
