using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarvestUI : MonoBehaviour
{
    public LocalizableString localizableString;
    public PlayerMovement player;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = localizableString.GetString(Localization.currentLanguage);
    }

    // Update is called once per frame
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
