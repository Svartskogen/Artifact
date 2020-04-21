using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnUsableAfter1Sec : MonoBehaviour
{
    Button button;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.interactable = false;
        timer = Time.time + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timer)
        {
            button.interactable = true;
        }
    }
}
