namespace Portfolio.Models;

public sealed record Experience(
    ExperienceType Type,
    LocalizedText Badge,
    DateOnly Start,
    DateOnly End,
    LocalizedText Title,
    string Company,
    LocalizedText Description,
    IReadOnlyList<string> Tags);
