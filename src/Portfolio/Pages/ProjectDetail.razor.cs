using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Portfolio.Models;
using Portfolio.Resources;
using Portfolio.Services;

namespace Portfolio.Pages;

public partial class ProjectDetail
{
    private const int ImageWidth = 1600;
    private const int ImageHeight = 900;

    private Project? project;

    [Inject]
    private IContentService Content { get; set; } = default!;

    [Inject]
    private NavigationManager Navigation { get; set; } = default!;

    [Inject]
    private IStringLocalizer<SharedResource> Loc { get; set; } = default!;

    [Parameter]
    public string Slug { get; set; } = string.Empty;

    private string PageTitleText => Loc["ProjectDetail_PageTitle", project?.Title.Value ?? string.Empty];

    protected override async Task OnParametersSetAsync()
    {
        project = await Content.GetProjectAsync(Slug);

        if (project is null)
        {
            Navigation.NotFound();
        }
    }
}
