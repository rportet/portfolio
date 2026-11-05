using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Portfolio.Models;
using Portfolio.Resources;
using Portfolio.Services;

namespace Portfolio.Components;

public partial class ContactBlock
{
    private Profile? profile;
    private string email = string.Empty;
    private string emailLocalPart = string.Empty;
    private string emailDomain = string.Empty;

    [Inject]
    private IContentService Content { get; set; } = default!;

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
}
