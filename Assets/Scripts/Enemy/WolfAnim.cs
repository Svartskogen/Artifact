using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnim : MonoBehaviour
{
    public Sprite[] sprites;
    public float time;
    EnemyAI enemyAI;
    SpriteRenderer spriteRenderer;
    int state = 0;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
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
