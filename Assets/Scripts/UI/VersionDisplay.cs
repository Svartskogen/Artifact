using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Keeps the object's <see cref="Text"/> updated with the current game version
/// </summary>
public class VersionDisplay : MonoBehaviour
{
    private Text text;
    
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = Application.version;
    }
}
