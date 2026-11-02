using System.Text.Json;
using System.Text.Json.Serialization;
using Portfolio.Models;

namespace Portfolio.Services;

[JsonSourceGenerationOptions(JsonSerializerDefaults.Web, UseStringEnumConverter = true)]
[JsonSerializable(typeof(Profile))]
[JsonSerializable(typeof(IReadOnlyList<EducationStep>))]
[JsonSerializable(typeof(IReadOnlyList<Experience>))]
[JsonSerializable(typeof(IReadOnlyList<Project>))]
internal partial class ContentJsonContext : JsonSerializerContext;
