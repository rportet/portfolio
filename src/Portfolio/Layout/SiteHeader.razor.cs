using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;
using Portfolio.Components;
using Portfolio.Resources;

namespace Portfolio.Layout;

public partial class SiteHeader
{
    private static readonly HeaderLink[] Links =
    [
        new(SectionIds.Formation, "SiteHeader_NavFormation"),
        new(SectionIds.Experiences, "SiteHeader_NavExperiences"),
        new(SectionIds.Projects, "SiteHeader_NavProjects"),
        new(SectionIds.Contact, "SiteHeader_NavContact")
    ];

    private ElementReference menuButton;
    private bool isMenuOpen;

    [Inject]
    private IStringLocalizer<SharedResource> Loc { get; set; } = default!;

    [Parameter]
    public EventCallback OnSkipToContent { get; set; }

    private string MenuExpanded => isMenuOpen ? "true" : "false";

    private IconName MenuIcon => isMenuOpen ? IconName.Close : IconName.Menu;

    private void ToggleMenu() => isMenuOpen = !isMenuOpen;

    private async Task CloseMenuAsync()
    {
        isMenuOpen = false;
        await menuButton.FocusAsync(preventScroll: true);
    }

    private async Task OnKeyDownAsync(KeyboardEventArgs args)
    {
        if (isMenuOpen && args.Key == "Escape")
        {
            await CloseMenuAsync();
        }
    }

    private sealed record HeaderLink(string Fragment, string ResourceKey);
}
