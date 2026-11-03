using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Portfolio.Models;
using Portfolio.Resources;
using Portfolio.Services;

namespace Portfolio.Components;

public partial class Hero
{
    private Profile? profile;

    [Inject]
    private IContentService Content { get; set; } = default!;

    [Inject]
    private IStringLocalizer<SharedResource> Loc { get; set; } = default!;

    private string EmailHref => $"mailto:{profile?.Links.Email}";

    protected override async Task OnInitializedAsync()
    {
        profile = await Content.GetProfileAsync();
    }
}
