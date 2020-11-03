using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Loads a <see cref="LocalizableString"/> into a <see cref="Text"/> based in the <see cref="Localization.currentLanguage"/>
/// </summary>
public class LocStrLoader : MonoBehaviour
{
    public LocalizableString localizableString;
    Text text;
    
    void Start()
    {
        text = GetComponent<Text>();
        text.text = localizableString.GetString(Localization.currentLanguage);
    }
}
