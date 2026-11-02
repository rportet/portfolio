namespace Portfolio.Models;

public sealed record EducationStep(
    DateOnly Start,
    DateOnly End,
    LocalizedText Title,
    LocalizedText Subtitle,
    bool Compact);
