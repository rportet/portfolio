using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using Portfolio.Resources;

namespace Portfolio.Components;

public partial class LanguageSelector
{
    private static readonly Language[] Languages =
    [
        new("fr", "LanguageSelector_CodeFr", "LanguageSelector_NameFr"),
        new("en", "LanguageSelector_CodeEn", "LanguageSelector_NameEn")
    ];

    [Inject]
    private IJSRuntime JS { get; set; } = default!;

    [Inject]
    private NavigationManager Navigation { get; set; } = default!;

    [Inject]
    private IStringLocalizer<SharedResource> Loc { get; set; } = default!;

    private static string CurrentCulture => CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

    private static string TargetCulture => CurrentCulture == "en" ? "fr" : "en";

    private static string CurrentCodeKey => CurrentCulture == "en" ? "LanguageSelector_CodeEn" : "LanguageSelector_CodeFr";

    private static string AriaPressed(Language language) => language.Culture == CurrentCulture ? "true" : "false";

    private async Task SwitchToAsync(string culture)
    {
        if (culture == CurrentCulture)
        {
            return;
        }

        await using var module = await JS.InvokeAsync<IJSObjectReference>("import", "./js/culture.js");
        await module.InvokeVoidAsync("setCulture", culture);

        Navigation.NavigateTo(Navigation.Uri, forceLoad: true);
    }

    private sealed record Language(string Culture, string CodeKey, string NameKey);
}
