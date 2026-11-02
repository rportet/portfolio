using Microsoft.AspNetCore.Components;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Pages;

public partial class Home
{
    private Profile? profile;
    private IReadOnlyList<EducationStep> education = [];
    private IReadOnlyList<Experience> experiences = [];
    private IReadOnlyList<Project> projects = [];

    [Inject]
    private IContentService Content { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        profile = await Content.GetProfileAsync();
        education = await Content.GetEducationAsync();
        experiences = await Content.GetExperiencesAsync();
        projects = await Content.GetProjectsAsync();
    }
}
