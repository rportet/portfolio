namespace Portfolio.Models;

public sealed record Project(
    string Slug,
    LocalizedText Title,
    LocalizedText Tagline,
    IReadOnlyList<string> Tags,
    string? Image,
    string? RepositoryUrl,
    string? DemoUrl);
