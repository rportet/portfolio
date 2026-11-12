using Microsoft.AspNetCore.Components;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Components;

public partial class ProjectList
{
    private IReadOnlyList<Project> projects = [];

    [Inject]
    private IContentService Content { get; set; } = default!;

    private string RowClass => projects.Count > 1 ? "row-cols-1 row-cols-md-2" : "row-cols-1";

    protected override async Task OnInitializedAsync()
    {
        projects = await Content.GetProjectsAsync();
    }
}
