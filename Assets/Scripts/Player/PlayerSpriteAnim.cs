using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteAnim : MonoBehaviour
{
    public Sprite[] sprites;
    public float time;

    float timer;
    int state = 0;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timer)
        {
            spriteRenderer.sprite = sprites[state % sprites.Length];
            state++;
            timer = Time.time + time;
        }
    }
}
