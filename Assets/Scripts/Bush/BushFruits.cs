using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This component is responsible for the main behaviour of bushes and communicates directly with <see cref="BushVisual"/>
/// </summary>
public class BushFruits : MonoBehaviour
{
    //Hacked away solution with prefabs, would work better using Scriptable objects for this data
    [SerializeField] int[] amountPerType;
    [SerializeField] float[] respawnTime;

    BushVisual bushVisual;
    bool ready;
    float timer;
    
    void Start()
    {
        bushVisual = GetComponent<BushVisual>();

        //Randomly initializes some bushes with fruits
        if(Random.Range(0,2) == 0)
        {
            ready = false;
            timer = Time.time + respawnTime[(int)bushVisual.GetVariant()];
        }
        else
        {
            ready = true;
            bushVisual.ShowFruits();
        }
    }

    void Update()
    {
        if(Time.time > timer)
        {
            ready = true;
            bushVisual.ShowFruits();
        }
    }

    /// <summary>
    /// Returns true if the bush has fruits, used by <see cref="PlayerHarvest"/> and <see cref="EnemyAI"/>
    /// </summary>
    public bool HasFruits()
    {
        return ready;
    }

    /// <summary>
    /// Harvests the bush and returns the amount of fruits harvested
    /// </summary>
    public int HarvestFruit()
    {
        if (ready)
        {
            ready = false;
            bushVisual.HideFruits();
            timer = Time.time + respawnTime[(int)bushVisual.GetVariant()];
            return amountPerType[(int)bushVisual.GetVariant()];
        }
        else
        {
            return 0;
        }
    }

    /// <summary>
    /// Used by <see cref="EnemyAI"/> to eat bushes
    /// </summary>
    public void EatBush()
    {
        enabled = false;
        bushVisual.SetToDry();
    }
}
