using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RemainingTimeUI : MonoBehaviour
{
    public LocalizableString remainingTime;
    public LocalizableString secondsString;
    public Manager manager;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = remainingTime.GetString(Localization.currentLanguage) + ": " + (int)manager.GetTime() 
            + " "+ secondsString.GetString(Localization.currentLanguage);
    }
}
