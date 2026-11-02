using System.Globalization;

namespace Portfolio.Models;

public sealed record LocalizedText(string Fr, string En)
{
    public string Value =>
        CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en" ? En : Fr;
}
