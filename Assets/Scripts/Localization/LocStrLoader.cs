using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LocStrLoader : MonoBehaviour
{
    public LocalizableString localizableString;
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
        
    }
}
