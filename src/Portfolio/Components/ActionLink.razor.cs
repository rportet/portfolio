using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Portfolio.Resources;

namespace Portfolio.Components;

public partial class ActionLink
{
    [Inject]
    private IStringLocalizer<SharedResource> Loc { get; set; } = default!;

    [Parameter, EditorRequired]
    public string Href { get; set; } = string.Empty;

    [Parameter, EditorRequired]
    public string Text { get; set; } = string.Empty;

    [Parameter, EditorRequired]
    public IconName Icon { get; set; }

    [Parameter, EditorRequired]
    public ActionLinkVariant Variant { get; set; }

    [Parameter]
    public LinkBehavior Behavior { get; set; }

    private bool IsNewTab => Behavior == LinkBehavior.NewTab;

    private bool IsDownload => Behavior == LinkBehavior.Download;

    private string? Target => IsNewTab ? "_blank" : null;

    private string? Rel => IsNewTab ? "noopener" : null;

    private string VariantClass => Variant switch
    {
        ActionLinkVariant.Tile => "btn rp-tile rp-tile-surface",
        ActionLinkVariant.TileAccent => "btn btn-rp-accent rp-tile",
        ActionLinkVariant.ContrastOutline => "btn btn-outline-rp-contrast rp-action-link-pill",
        ActionLinkVariant.Accent => "btn btn-rp-accent rp-action-link-pill",
        _ => throw new InvalidOperationException($"Unknown action link variant '{Variant}'.")
    };
}
