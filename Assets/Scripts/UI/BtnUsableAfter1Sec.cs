using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Helper script that disables a button at Start, and enables it after one second.
/// </summary>
public class BtnUsableAfter1Sec : MonoBehaviour
{
    Button button;
    float timer;

    void Start()
    {
        button = GetComponent<Button>();
        button.interactable = false;
        timer = Time.time + 1;
    }

    void Update()
    {
        if(Time.time > timer)
        {
            button.interactable = true;
        }
    }
}
