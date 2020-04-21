using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushVisual : MonoBehaviour
{
    public Sprite[] sprites;
    public Sprite[] fruitSprites;
    public Sprite[] drySprites;

    public SpriteRenderer[] fruitsRenderers;
    SpriteRenderer sprite;
    int variant;

    public float HideTimePer;
    // Start is called before the first frame update
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        variant = Random.Range(0, sprites.Length);
        sprite.sprite = sprites[variant];
        if(Random.Range(0,2) == 1)
        {
            sprite.flipX = true;
        }
        for (int i = 0; i < fruitsRenderers.Length; i++)
        {
            fruitsRenderers[i].sprite = fruitSprites[variant];
            fruitsRenderers[i].enabled = false;
        }
    }

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
    public void ShowFruits()
    {
        for (int i = 0; i < fruitsRenderers.Length; i++)
        {
            fruitsRenderers[i].enabled = true;
        }
    }
    public int GetVariant()
    {
        return variant;
    }
    public void SetToDry()
    {
        sprite.sprite = drySprites[variant];
    }
}
