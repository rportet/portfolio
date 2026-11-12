using Microsoft.AspNetCore.Components;
using Portfolio.Models;

namespace Portfolio.Components;

public partial class ProjectCard
{
    [Parameter, EditorRequired]
    public Project Project { get; set; } = default!;

    private string Href => $"projets/{Project.Slug}";
}
