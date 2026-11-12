namespace Portfolio.Models;

public sealed record Project(
    string Slug,
    LocalizedText Title,
    LocalizedText Tagline,
    IReadOnlyList<string> Tags,
    string? Image,
    LocalizedText? ImageAlt,
    string? RepositoryUrl,
    string? DemoUrl,
    LocalizedText Context,
    IReadOnlyList<ProjectHighlight> Highlights);
