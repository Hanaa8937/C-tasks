using System;
using System.Collections.Generic;

public class LocalizedText
{
    public Dictionary<string, string> Translations = new Dictionary<string, string>();

    public string GetText(string languageCode)
    {
        if (Translations.ContainsKey(languageCode))
        {
            return Translations[languageCode];
        }

        if (Translations.ContainsKey("en"))
        {
            return Translations["en"];
        }

        return "Translation not found";
    }
}