using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtifactHealthUI : MonoBehaviour
{
    Slider slider;
    public Artifact artifact;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = artifact.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = artifact.health;   
    }
}
