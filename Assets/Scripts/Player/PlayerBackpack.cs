using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
