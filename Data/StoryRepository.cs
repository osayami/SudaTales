using System.Net.Http;
using SudaTales.Models;

namespace SudaTales.Data;

public sealed class StoryRepository
{
    private readonly HttpClient _http;
    private readonly Dictionary<string, StoryModel> _cache = [];

    public StoryRepository(HttpClient http)
    {
        _http = http;
    }

private static StoryMeta ParseMeta(string text)
{
    var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

    foreach (var rawLine in text.Split('\n'))
    {
        var line = rawLine.Trim();
        if (string.IsNullOrEmpty(line))
            continue;

        var parts = line.Split(':', 2);
        if (parts.Length != 2)
            continue;

        dict[parts[0].Trim()] = parts[1].Trim();
    }
return new StoryMeta
{
    Title = dict.GetValueOrDefault("title", ""),
    Slug = dict.GetValueOrDefault("slug", ""),
    Author = dict.GetValueOrDefault("author", ""),
    Language = dict.GetValueOrDefault("language", ""),
    Summary = dict.GetValueOrDefault("summary", "")
};

}
private static ChapterModel ParseChapter(string filename, string content)
{
    // Expected filename format:
    // 01_peacock-island_ch01_the-arrival.txt

    var nameWithoutExt = Path.GetFileNameWithoutExtension(filename);

    // Order = numeric prefix before first underscore
    var orderPart = nameWithoutExt.Split('_', 2)[0];
    var order = int.TryParse(orderPart, out var parsed) ? parsed : 0;

    // Chapter title = everything after last underscore
    var title = nameWithoutExt.Contains('_')
        ? nameWithoutExt.Substring(nameWithoutExt.LastIndexOf('_') + 1)
        : nameWithoutExt;

    var paragraphs = content
        .Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
        .Select(p => new Paragraph
        {
            Text = p.Trim()
        })
        .ToList();

    return new ChapterModel
    {
        Order = order,
        Title = title.Replace('-', ' '),
        Paragraphs = paragraphs
    };
}
    public async Task<List<StoryModel>> GetAllAsync()
    {
        var slugsText = await TryLoadText("submissions/index.txt");
        if (slugsText is null)
            return [];

        var slugs = slugsText
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.Trim());

        var stories = new List<StoryModel>();

        foreach (var slug in slugs)
        {
            var story = await GetAsync(slug);
            if (story is not null)
                stories.Add(story);
        }

        return stories;
    }

    public async Task<StoryModel?> GetAsync(string slug)
    {
        if (_cache.TryGetValue(slug, out var cached))
            return cached;

        var basePath = $"submissions/{slug}";

        var metaText = await TryLoadText($"{basePath}/meta.txt");
        if (metaText is null)
            return null;

        var meta = ParseMeta(metaText);

        var chapterFilesText = await TryLoadText($"{basePath}/index.txt");
        if (chapterFilesText is null)
            return null;

        var chapters = new List<ChapterModel>();

        foreach (var file in chapterFilesText.Split('\n', StringSplitOptions.RemoveEmptyEntries))
        {
            var content = await TryLoadText($"{basePath}/{file.Trim()}");
            if (content is null)
                continue;

            chapters.Add(ParseChapter(file.Trim(), content));
        }

    var story = new StoryModel
{
    Slug = meta.Slug,
    Title = meta.Title,
    Author = meta.Author,
    Language = meta.Language,
    Summary = meta.Summary,
    Published = DateTime.Today,
    Chapters = chapters.OrderBy(c => c.Order).ToList()
};

        _cache[slug] = story;
        return story;
    }

    private async Task<string?> TryLoadText(string path)
    {
        try
        {
            return await _http.GetStringAsync(path);
        }
        catch
        {
            return null;
        }
    }

    // ParseMeta + ParseChapter unchanged
}
