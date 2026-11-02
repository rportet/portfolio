using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using Portfolio.Resources;

namespace Portfolio.Components;

public partial class LanguageToggle
{
    [Inject]
    private IJSRuntime JS { get; set; } = default!;

    [Inject]
    private NavigationManager Navigation { get; set; } = default!;

    [Inject]
    private IStringLocalizer<SharedResource> Loc { get; set; } = default!;

    private static string CurrentCulture => CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

    private static string TargetCulture => CurrentCulture == "en" ? "fr" : "en";

    private static string CurrentCode => CurrentCulture.ToUpperInvariant();

    private string Label => Loc["LanguageToggle_Switch"];

    private async Task ToggleAsync()
    {
        await using var module = await JS.InvokeAsync<IJSObjectReference>("import", "./js/culture.js");
        await module.InvokeVoidAsync("setCulture", CurrentCulture == "en" ? "fr" : "en");

        Navigation.NavigateTo(Navigation.Uri, forceLoad: true);
    }
}
