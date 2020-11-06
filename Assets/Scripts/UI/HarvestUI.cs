using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Enables the <see cref="Text"/> component when harvesting
/// </summary>
public class HarvestUI : MonoBehaviour
{
    public LocalizableString localizableString;
    public PlayerMovement player;
    Text text;
    
    void Start()
    {
        text = GetComponent<Text>();
        text.text = localizableString.GetString(Localization.currentLanguage);
    }

    void Update()
    {
        if (player.IsHarvesting())
        {
            text.enabled = true;
        }
        else
        {
            text.enabled = false;
        }
    }
}
