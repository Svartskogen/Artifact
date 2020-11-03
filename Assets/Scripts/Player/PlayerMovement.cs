using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component responsible of the player movement and managing the <see cref="SpriteRenderer.flipX"/> property
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;

    new Rigidbody2D rigidbody;
    Vector2 normVector;
    SpriteRenderer sprite;

    float timer;
    bool harvesting;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Time.time > timer)
        {
            harvesting = false;
        }
        FlipSprite();
    }

    private void FlipSprite()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            sprite.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            sprite.flipX = true;
        }
    }

    void FixedUpdate()
    {
        if (harvesting)
        {
            rigidbody.velocity = Vector2.zero;
        }
        else
        {
            normVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if(normVector.sqrMagnitude > 1)
            {
                normVector = normVector.normalized;
            }
            rigidbody.velocity = new Vector2(normVector.x * movementSpeed,normVector.y * movementSpeed);
        }
    }

    public void HarvestStopMovement(float time)
    {
        harvesting = true;
        timer = Time.time + time;
    }

    public bool IsHarvesting()
    {
        return harvesting;
    }
}
