using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple script based animation for the Player
/// </summary>
public class PlayerSpriteAnim : MonoBehaviour
{
    public Sprite[] sprites;
    public float time;

    float timer;
    int state = 0;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

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
