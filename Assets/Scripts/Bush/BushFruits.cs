using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushFruits : MonoBehaviour
{
    bool ready;
    public int[] amountPerType;
    public float[] respawnTime;

    BushVisual bushVisual;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        bushVisual = GetComponent<BushVisual>();
        if(Random.Range(0,2) == 0)
        {
            ready = false;
            timer = Time.time + respawnTime[bushVisual.GetVariant()];
        }
        else
        {
            ready = true;
            bushVisual.ShowFruits();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timer)
        {
            ready = true;
            bushVisual.ShowFruits();
        }
    }

    public bool HasFruits()
    {
        return ready;
    }
    public int HarvestFruit()
    {
        if (ready)
        {
            ready = false;
            bushVisual.HideFruits();
            timer = Time.time + respawnTime[bushVisual.GetVariant()];
            return amountPerType[bushVisual.GetVariant()];
        }
        else
        {
            return 0;
        }
    }
    public void EatBush()
    {
        enabled = false;
        bushVisual.SetToDry();
    }
}
