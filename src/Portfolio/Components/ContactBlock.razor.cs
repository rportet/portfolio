using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using Portfolio.Models;
using Portfolio.Resources;
using Portfolio.Services;

namespace Portfolio.Components;

public partial class ContactBlock : IAsyncDisposable
{
    private static readonly TimeSpan StatusDuration = TimeSpan.FromSeconds(3);

    private IJSObjectReference? module;
    private Profile? profile;
    private string email = string.Empty;
    private string emailLocalPart = string.Empty;
    private string emailDomain = string.Empty;
    private string? copyStatus;
    private int copyAttempt;

    [Inject]
    private IContentService Content { get; set; } = default!;

    [Inject]
    private IJSRuntime JS { get; set; } = default!;

    [Inject]
    private IStringLocalizer<SharedResource> Loc { get; set; } = default!;

    private string EmailHref => $"mailto:{email}";

    protected override async Task OnInitializedAsync()
    {
        profile = await Content.GetProfileAsync();
        email = profile.Links.Email;

        var atIndex = email.IndexOf('@');

        emailLocalPart = email[..atIndex];
        emailDomain = email[atIndex..];
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            module = await JS.InvokeAsync<IJSObjectReference>("import", "./js/clipboard.js");
        }
    }

    private async Task CopyAsync()
    {
        if (module is null)
        {
            return;
        }

        var copied = await module.InvokeAsync<bool>("copyText", email);
        var attempt = ++copyAttempt;

        copyStatus = copied ? Loc["ContactBlock_Copied"] : Loc["ContactBlock_CopyFailed"];
        StateHasChanged();

        await Task.Delay(StatusDuration);

        if (attempt == copyAttempt)
        {
            copyStatus = null;
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (module is not null)
        {
            await module.DisposeAsync();
        }
    }
}
