using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarvest : MonoBehaviour
{
    public float harvestRadius;
    public float harvestTime;
    public LayerMask bushesMask;
    PlayerMovement playerMovement;
    PlayerBackpack backpack;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        backpack = GetComponent<PlayerBackpack>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryHarvestClose();
        }
    }
    void TryHarvestClose()
    {
        Collider2D hit =
        Physics2D.OverlapCircle(transform.position, harvestRadius / 2, bushesMask);

        if (hit != null)
        {
            
            BushFruits bush = hit.GetComponent<BushFruits>();
            if (bush.HasFruits())
            {
                audioSource.Play();
                playerMovement.HarvestStopMovement(harvestTime);
                backpack.AddFruits(bush.HarvestFruit());
            }
        }
        else
        {
            TryHarvestFruit();
        }
    }
    void TryHarvestFruit()
    {
        Collider2D hit =
        Physics2D.OverlapCircle(transform.position, harvestRadius,bushesMask);

        if(hit != null)
        {
            
            BushFruits bush = hit.GetComponent<BushFruits>();
            if (bush.HasFruits())
            {
                audioSource.Play();
                playerMovement.HarvestStopMovement(harvestTime);
                backpack.AddFruits(bush.HarvestFruit());
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, harvestRadius);
    }
}
