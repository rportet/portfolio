using Portfolio.Models;

namespace Portfolio.Services;

public interface IContentService
{
    Task<Profile> GetProfileAsync();

    Task<IReadOnlyList<EducationStep>> GetEducationAsync();

    Task<IReadOnlyList<Experience>> GetExperiencesAsync();

    Task<IReadOnlyList<Project>> GetProjectsAsync();

    Task<Project?> GetProjectAsync(string slug);
}
