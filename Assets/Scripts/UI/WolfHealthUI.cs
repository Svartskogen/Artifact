using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfHealthUI : MonoBehaviour
{
    EnemyHealth enemyHealth;
    float scale;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponentInParent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        scale = (float)enemyHealth.current / (float)enemyHealth.max;
        transform.localScale = new Vector3(scale, transform.localScale.y, 1);
    }
}
