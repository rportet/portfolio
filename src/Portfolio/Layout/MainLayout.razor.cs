using Microsoft.AspNetCore.Components;

namespace Portfolio.Layout;

public partial class MainLayout
{
    private ElementReference mainElement;

    private async Task FocusMainAsync() => await mainElement.FocusAsync();
}
