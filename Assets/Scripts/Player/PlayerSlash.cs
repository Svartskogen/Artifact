using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component responsible of creating and managing the Player's melee attack
/// </summary>
public class PlayerSlash : MonoBehaviour
{
    public GameObject slashPrefab;
    public float cooldown;
    public Transform pivot;
    public int damage = 35;

    float timer;
    new Collider2D collider2D;
    public LayerMask enemyMask;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && Time.time > timer)
        {
            Slash();
            audioSource.Play();
            timer = Time.time + cooldown;
        }
    }
    void Slash()
    {
        Instantiate(slashPrefab, transform.position, transform.rotation);
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, new Vector2(2,1.5f), pivot.rotation.z, enemyMask);
        if(hits.Length != 0)
        {
            foreach(Collider2D hit in hits)
            {
                hit.GetComponent<EnemyHealth>().DamageEnemy(damage);
            }
        }
    }
}
