using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Portfolio.Resources;

namespace Portfolio.Components;

public partial class TagList
{
    [Inject]
    private IStringLocalizer<SharedResource> Loc { get; set; } = default!;

    [Parameter, EditorRequired]
    public IReadOnlyList<string> Tags { get; set; } = [];
}
