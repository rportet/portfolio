using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using Portfolio.Resources;

namespace Portfolio.Components;

public partial class ThemeToggle : IAsyncDisposable
{
    private IJSObjectReference? module;
    private string theme = "light";

    [Inject]
    private IJSRuntime JS { get; set; } = default!;

    [Inject]
    private IStringLocalizer<SharedResource> Loc { get; set; } = default!;

    private string Label => theme == "dark"
        ? Loc["ThemeToggle_SwitchToLight"]
        : Loc["ThemeToggle_SwitchToDark"];

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            module = await JS.InvokeAsync<IJSObjectReference>("import", "./js/theme.js");
            theme = await module.InvokeAsync<string>("getTheme");
            StateHasChanged();
        }
    }

    private async Task ToggleAsync()
    {
        if (module is null)
        {
            return;
        }

        theme = theme == "dark" ? "light" : "dark";
        await module.InvokeVoidAsync("setTheme", theme);
    }

    public async ValueTask DisposeAsync()
    {
        if (module is not null)
        {
            await module.DisposeAsync();
        }
    }
}
