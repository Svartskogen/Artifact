using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Shows the remaining time to the user in the object's <see cref="Text"/>
/// </summary>
public class RemainingTimeUI : MonoBehaviour
{
    public LocalizableString remainingTime;
    public LocalizableString secondsString;
    public Manager manager;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = remainingTime.GetString(Localization.currentLanguage) + ": " + (int)manager.GetTime() 
            + " "+ secondsString.GetString(Localization.currentLanguage);
    }
}
