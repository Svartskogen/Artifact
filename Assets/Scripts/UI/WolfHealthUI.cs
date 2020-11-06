using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scales the current object based on the <see cref="EnemyHealth.current"/> value
/// </summary>
public class WolfHealthUI : MonoBehaviour
{
    EnemyHealth enemyHealth;
    float scale;

    void Start()
    {
        enemyHealth = GetComponentInParent<EnemyHealth>();
    }

    void Update()
    {
        scale = (float)enemyHealth.current / (float)enemyHealth.max;
        transform.localScale = new Vector3(scale, transform.localScale.y, 1);
    }
}
