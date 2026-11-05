using Microsoft.AspNetCore.Components;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Components;

public partial class ExperienceList
{
    private IReadOnlyList<Experience> experiences = [];

    [Inject]
    private IContentService Content { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        experiences = await Content.GetExperiencesAsync();
    }
}
