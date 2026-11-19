using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using Portfolio.Components;
using Portfolio.Resources;
using Portfolio.Services;

namespace Portfolio.Pages;

public partial class Home : IAsyncDisposable
{
    private static readonly string[] ObservedSections =
    [
        SectionIds.Formation,
        SectionIds.Experiences,
        SectionIds.Projects,
        SectionIds.Contact
    ];

    private IJSObjectReference? module;
    private IJSObjectReference? scrollSpy;
    private DotNetObjectReference<Home>? selfReference;
    private bool isDisposed;

    [Inject]
    private IStringLocalizer<SharedResource> Loc { get; set; } = default!;

    [Inject]
    private IJSRuntime JS { get; set; } = default!;

    [Inject]
    private ActiveSectionState ActiveSection { get; set; } = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender)
        {
            return;
        }

        module = await JS.InvokeAsync<IJSObjectReference>("import", "./js/scrollspy.js");
        selfReference = DotNetObjectReference.Create(this);
        scrollSpy = await module.InvokeAsync<IJSObjectReference>("observe", selfReference, ObservedSections);

        if (isDisposed)
        {
            await StopAsync();
        }
    }

    [JSInvokable]
    public void SetActiveSection(string? sectionId) => ActiveSection.SectionId = sectionId;

    public async ValueTask DisposeAsync()
    {
        isDisposed = true;
        await StopAsync();
    }

    private async Task StopAsync()
    {
        if (scrollSpy is not null)
        {
            await scrollSpy.InvokeVoidAsync("disconnect");
            await scrollSpy.DisposeAsync();
            scrollSpy = null;
        }

        if (module is not null)
        {
            await module.DisposeAsync();
            module = null;
        }

        selfReference?.Dispose();
        selfReference = null;
        ActiveSection.SectionId = null;
    }
}
