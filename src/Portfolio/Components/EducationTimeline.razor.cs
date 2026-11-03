using System.Globalization;
using Microsoft.AspNetCore.Components;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Components;

public partial class EducationTimeline
{
    private IReadOnlyList<EducationStep> steps = [];
    private EducationStep? mostRecent;

    [Inject]
    private IContentService Content { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        steps = await Content.GetEducationAsync();
        mostRecent = steps.MaxBy(step => step.End);
    }

    private string DotClass(EducationStep step)
    {
        if (step.Compact)
        {
            return "rp-dot-hollow";
        }

        return step == mostRecent ? "rp-dot-current" : "rp-dot-past";
    }

    private static string MachineDate(DateOnly date) => date.ToString("yyyy-MM", CultureInfo.InvariantCulture);
}
