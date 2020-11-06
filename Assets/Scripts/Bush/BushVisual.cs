using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This component cointains and manages the visual aspect of bushes, managed by <see cref="BushFruits"/>
/// </summary>
public class BushVisual : MonoBehaviour
{
    //Hacked away solution with prefabs, would work better using Scriptable objects for this data
    [SerializeField] Sprite[] sprites;
    [SerializeField] Sprite[] fruitSprites;
    [SerializeField] Sprite[] drySprites;

    [SerializeField] SpriteRenderer[] fruitsRenderers;

    //The type of bush, defined randomly at Start
    BushVariant variant;    
    
    //Delay for the sequential hiding of each fruit on harvest
    public float HideTimePer;
    SpriteRenderer sprite;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        //Defines a variant at random.
        variant = (BushVariant)Random.Range(0, sprites.Length);

        sprite.sprite = sprites[(int)variant];

        //Also randomly flips the sprite
        if(Random.Range(0,2) == 1)
        {
            sprite.flipX = true;
        }

        for (int i = 0; i < fruitsRenderers.Length; i++)
        {
            fruitsRenderers[i].sprite = fruitSprites[(int)variant];
            fruitsRenderers[i].enabled = false;
        }
    }

    /// <summary>
    /// Used by <see cref="BushFruits.HarvestFruit"/> to sequentially hide the fruits visuals
    /// </summary>
    public void HideFruits()
    {
        float add = HideTimePer;
        for (int i = 0; i < fruitsRenderers.Length; i++)
        {
            StartCoroutine(HideFruit(add,i));
            add += HideTimePer;
        }
    }
    IEnumerator HideFruit(float time, int index)
    {
        yield return new WaitForSeconds(time);
        fruitsRenderers[index].enabled = false;
    }

    /// <summary>
    /// Used by the main Update loop of <see cref="BushFruits"/> when the bush has regenerated fruits.
    /// </summary>
    public void ShowFruits()
    {
        for (int i = 0; i < fruitsRenderers.Length; i++)
        {
            fruitsRenderers[i].enabled = true;
        }
    }

    /// <summary>
    /// Used by <see cref="BushFruits"/> to define how often the fruits regenerate based on BushVariant
    /// </summary>
    public BushVariant GetVariant()
    {
        return variant;
    }

    /// <summary>
    /// Used by <see cref="BushFruits.EatBush"/> to update the bush visual to a dry one
    /// </summary>
    public void SetToDry()
    {
        sprite.sprite = drySprites[(int)variant];
    }
}
/// <summary>
/// Indicates the type of bush variant for visual and a couple of logical purposes
/// </summary>
public enum BushVariant { Green, Cyan, Yellow }
