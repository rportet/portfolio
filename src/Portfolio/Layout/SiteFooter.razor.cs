using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Portfolio.Resources;

namespace Portfolio.Layout;

public partial class SiteFooter
{
    [Inject]
    private IStringLocalizer<SharedResource> Loc { get; set; } = default!;

    private string Copyright => Loc["SiteFooter_Copyright", DateTime.Now.Year];
}
