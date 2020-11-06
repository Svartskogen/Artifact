using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Simple script that updates a <see cref="Slider"/> with the <see cref="Artifact"/> health
/// </summary>
public class ArtifactHealthUI : MonoBehaviour
{
    Slider slider;
    [SerializeField] Artifact artifact;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = artifact.maxHealth;
    }

    void Update()
    {
        slider.value = artifact.health;   
    }
}
