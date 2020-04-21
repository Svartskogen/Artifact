using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Localization
{
    public static LocalizableString.Language currentLanguage = LocalizableString.Language.Spanish;

    public static void SetLanguageTo(LocalizableString.Language language)
    {
        currentLanguage = language;
    }
}
