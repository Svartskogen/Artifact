using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Efecto de golpe simple
/// </summary>
public class HitFx : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] float time;

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
        if (Time.time > timer)
        {
            if (state == sprites.Length)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                spriteRenderer.sprite = sprites[state];
                state++;
                timer = Time.time + time;
            }
        }
    }
}
