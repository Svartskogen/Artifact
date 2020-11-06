using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Updates the UI with the current amount of fruits in the <see cref="PlayerBackpack"/>
/// </summary>
public class BackpackUI : MonoBehaviour
{
    [SerializeField] LocalizableString localizableString;
    [SerializeField] PlayerBackpack backpack;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = localizableString.GetString(Localization.currentLanguage) + ":\n" + backpack.current + " / " + backpack.max;
    }
}
