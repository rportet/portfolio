using System.Net.Http.Json;
using System.Text.Json.Serialization.Metadata;
using Portfolio.Models;

namespace Portfolio.Services;

public sealed class JsonContentService(HttpClient http) : IContentService
{
    private Task<Profile>? profile;
    private Task<IReadOnlyList<EducationStep>>? education;
    private Task<IReadOnlyList<Experience>>? experiences;
    private Task<IReadOnlyList<Project>>? projects;

    public Task<Profile> GetProfileAsync() =>
        profile ??= LoadAsync("data/profile.json", ContentJsonContext.Default.Profile);

    public Task<IReadOnlyList<EducationStep>> GetEducationAsync() =>
        education ??= LoadAsync("data/education.json", ContentJsonContext.Default.IReadOnlyListEducationStep);

    public Task<IReadOnlyList<Experience>> GetExperiencesAsync() =>
        experiences ??= LoadAsync("data/experiences.json", ContentJsonContext.Default.IReadOnlyListExperience);

    public Task<IReadOnlyList<Project>> GetProjectsAsync() =>
        projects ??= LoadAsync("data/projects.json", ContentJsonContext.Default.IReadOnlyListProject);

    public async Task<Project?> GetProjectAsync(string slug)
    {
        var allProjects = await GetProjectsAsync();

        return allProjects.FirstOrDefault(project => project.Slug == slug);
    }

    private async Task<T> LoadAsync<T>(string path, JsonTypeInfo<T> typeInfo) =>
        await http.GetFromJsonAsync(path, typeInfo)
            ?? throw new InvalidOperationException($"The content file '{path}' is empty.");
}
