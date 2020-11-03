using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Helper class to enable language changing through UI events.
/// </summary>
public class LocalizationUI : MonoBehaviour
{
    public void SetLanguage(int language)
    {
        Localization.SetLanguageTo((LocalizableString.Language)language);
    }
}
