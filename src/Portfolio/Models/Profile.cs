namespace Portfolio.Models;

public sealed record Profile(
    string FirstName,
    string LastName,
    LocalizedText Badge,
    LocalizedText Lead,
    IReadOnlyList<StackGroup> Stack,
    ProfileLinks Links);
