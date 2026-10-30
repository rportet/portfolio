using Microsoft.AspNetCore.Components;

namespace Portfolio.Components;

public partial class Icon
{
    [Parameter, EditorRequired]
    public IconName Name { get; set; }
}