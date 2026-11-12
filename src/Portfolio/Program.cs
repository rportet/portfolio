using System.Globalization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using Portfolio;
using Portfolio.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IContentService, JsonContentService>();
builder.Services.AddLocalization();

var host = builder.Build();

const string defaultCulture = "fr";

var js = host.Services.GetRequiredService<IJSRuntime>();

await using (var cultureModule = await js.InvokeAsync<IJSObjectReference>("import", "./js/culture.js"))
{
    var storedCulture = await cultureModule.InvokeAsync<string?>("getCulture");
    var culture = CultureInfo.GetCultureInfo(storedCulture is "fr" or "en" ? storedCulture : defaultCulture);

    CultureInfo.DefaultThreadCurrentCulture = culture;
    CultureInfo.DefaultThreadCurrentUICulture = culture;
}

var content = host.Services.GetRequiredService<IContentService>();

await Task.WhenAll(content.GetProfileAsync(), content.GetEducationAsync(), content.GetExperiencesAsync(), content.GetProjectsAsync());

await host.RunAsync();
