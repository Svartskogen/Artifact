using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple script-based animation for wolves
/// </summary>
public class WolfAnim : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] float time;

    EnemyAI enemyAI;
    SpriteRenderer spriteRenderer;
    int state = 0;
    float timer;
    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (enemyAI.isMoving)
        {
            if (Time.time > timer)
            {
                spriteRenderer.sprite = sprites[state % sprites.Length];
                state++;
                timer = Time.time + time;
            }
        }
        else
        {
            spriteRenderer.sprite = sprites[0];
        }

        spriteRenderer.flipX = enemyAI.left;
    }
}
