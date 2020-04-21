using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int max;
    public int current;

    private void Awake()
    {
        current = max;
    }
    
    public void DamageEnemy(int amount)
    {
        current -= amount;
        if(current <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        Destroy(gameObject);
    }
}
