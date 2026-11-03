using Microsoft.AspNetCore.Components;

namespace Portfolio.Components;

public partial class SectionTitle
{
    [Parameter, EditorRequired]
    public string Text { get; set; } = default!;
}
