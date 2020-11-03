using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static class holding the current language value and language changing methods.
/// </summary>
public static class Localization
{
    public static LocalizableString.Language currentLanguage = LocalizableString.Language.Spanish; //Spanish by default
    /// <summary>
    /// Changes the current language to the given value
    /// </summary>
    public static void SetLanguageTo(LocalizableString.Language language)
    {
        currentLanguage = language;
    }
}
