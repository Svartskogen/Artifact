using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BackpackUI : MonoBehaviour
{
    public LocalizableString localizableString;
    public PlayerBackpack backpack;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = localizableString.GetString(Localization.currentLanguage) + ":\n" + backpack.current + " / " + backpack.max;
    }
}
