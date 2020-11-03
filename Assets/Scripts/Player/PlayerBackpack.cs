using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to store the fruits harvested with <see cref="PlayerHarvest"/> from <see cref="BushFruits"/>
/// </summary>
public class PlayerBackpack : MonoBehaviour
{
    public int max;
    public int current;

    public void AddFruits(int amount)
    {
        current += amount;
        if (current > max)
        {
            current = max;
        }
    }
    public int TakeFruits()
    {
        int ret = current;
        current = 0;
        return ret;
    }
}
