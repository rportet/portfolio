using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Portfolio.Models;
using Portfolio.Resources;

namespace Portfolio.Components;

public partial class ExperienceCard
{
    [Inject]
    private IStringLocalizer<SharedResource> Loc { get; set; } = default!;

    [Parameter, EditorRequired]
    public Experience Experience { get; set; } = default!;

    private string BadgeClass => Experience.Type switch
    {
        ExperienceType.Apprenticeship => "rp-badge-apprenticeship",
        ExperienceType.Internship => "rp-badge-internship",
        _ => throw new InvalidOperationException($"Unknown experience type '{Experience.Type}'.")
    };

    private string ShortBadge => Experience.Type switch
    {
        ExperienceType.Apprenticeship => Loc["ExperienceCard_BadgeApprenticeship"],
        ExperienceType.Internship => Loc["ExperienceCard_BadgeInternship"],
        _ => throw new InvalidOperationException($"Unknown experience type '{Experience.Type}'.")
    };

    private static string MachineDate(DateOnly date) => date.ToString("yyyy-MM", CultureInfo.InvariantCulture);

    private static string DisplayDate(DateOnly date) => date.ToString("MMM yyyy", CultureInfo.CurrentCulture);
}
