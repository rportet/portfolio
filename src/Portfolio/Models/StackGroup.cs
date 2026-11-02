namespace Portfolio.Models;

public sealed record StackGroup(LocalizedText Label, IReadOnlyList<string> Items);
