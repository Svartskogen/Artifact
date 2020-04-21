using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public int bleed;
    AudioSource audioSource;
    float timer;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        health = maxHealth;
        timer = Time.time + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timer)
        {
            health -= bleed;
            timer = Time.time + 1;
        }

        if(health <= 0)
        {
            health = 0;
            CallDeath();
        }
    }
    void CallDeath()
    {

    }
    public void Damage(int amount)
    {
        health -= amount;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerBackpack>() != null)
        {
            if(collision.GetComponent<PlayerBackpack>().current != 0)
            {
                audioSource.Play();
            }
            health += collision.GetComponent<PlayerBackpack>().TakeFruits();
            if(health > maxHealth)
            {
                health = maxHealth;
            }
        }
    }
}
