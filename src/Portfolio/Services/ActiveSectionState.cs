namespace Portfolio.Services;

public sealed class ActiveSectionState
{
    private string? sectionId;

    public string? SectionId
    {
        get => sectionId;
        set
        {
            if (sectionId == value)
            {
                return;
            }

            sectionId = value;
            NotifyStateChanged();
        }
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}
