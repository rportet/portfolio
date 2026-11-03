using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Portfolio.Resources;

namespace Portfolio.Pages;

public partial class Home
{
    [Inject]
    private IStringLocalizer<SharedResource> Loc { get; set; } = default!;
}
