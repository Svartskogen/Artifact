using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ParticleSystem footStepsParticles;

    public float movementSpeed;

    Rigidbody2D rigidbody;
    Vector2 normVector;
    SpriteRenderer sprite;

    float timer;
    bool harvesting;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(Time.time > timer)
        {
            harvesting = false;
        }
        HandleParticles();
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

    private void HandleParticles()
    {
        if (rigidbody.velocity == Vector2.zero)
        {
            if (footStepsParticles.isPlaying)
            {
                footStepsParticles.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            }
        }
        else
        {
            if (!footStepsParticles.isPlaying)
            {
                footStepsParticles.Play(false);
            }
        }
    }

    // Update is called once per frame
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
