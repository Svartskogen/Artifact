using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public bool isEater;
    public bool isMoving;
    public bool left;
    public float moveSpeed;
    Artifact artifact;

    BushFruits target;
    public int attackDamage;
    public float attackTime;
    float attackTimer;
    public float eatTime;
    float eatTimer;
    public LayerMask bushesMask;
    bool killingBush;
    bool attacking;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (isEater)
        {
            SearchForTarget();
            killingBush = false;
        }
        else
        {
            attacking = false;
            artifact = GameObject.FindGameObjectWithTag("Artifact").GetComponent<Artifact>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isEater)
        {
            if(target != null && target.enabled == true && target.HasFruits() && !killingBush)
            {
                if (Vector2.Distance(transform.position, target.transform.position) > 0.5f)
                {
                    float step = moveSpeed * Time.deltaTime;
                    transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
                    isMoving = true;
                }
                else
                {
                    isMoving = false;
                    //audioSource.Play();
                    target.HarvestFruit();
                    eatTimer = Time.time + eatTime;
                    killingBush = true;
                }
            }
            else if (killingBush)
            {
                if(Time.time > eatTimer)
                {
                    target.EatBush();
                    killingBush = false;
                    SearchForTarget();
                }
            }
            else
            {
                SearchForTarget();
            }

            if (target.transform.position.x < transform.position.x)
            {
                left = true;
            }
            else
            {
                left = false;
            }
            if(target == null)
            {
                SearchForTarget();
            }
        }
        else
        {
            if(Vector2.Distance(transform.position, artifact.transform.position) > 1.5f)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, artifact.transform.position, step);
                isMoving = true;
            }
            else if(!attacking)
            {
                attacking = true;
                attackTimer = Time.time + attackTime;
                isMoving = false;
            }

            if (attacking)
            {
                if(Time.time > attackTimer)
                {
                    Attack();
                    attackTimer = Time.time + attackTime;
                }
            }
            if (artifact.transform.position.x < transform.position.x)
            {
                left = true;
            }
            else
            {
                left = false;
            }
        }
    }
    void Attack()
    {
        //Debug.Log("Attacking");
        //TODO FX
        //audioSource.Play();
        artifact.Damage(attackDamage);
    }
    void SearchForTarget()
    {
        target = null;
        for (int i = 1; i < 50; i++)
        {
            Collider2D[] hits =
            Physics2D.OverlapCircleAll(transform.position, Mathf.Exp(i), bushesMask);
            foreach(Collider2D hit in hits)
            {
                if (hit != null && (hit.GetComponent<BushFruits>().HasFruits()) && hit.GetComponent<BushFruits>().enabled == true)
                {
                    target = hit.GetComponent<BushFruits>();
                    break;
                }
            }
            if(target != null)
            {
                //Debug.Log("Ciclo completado con " + i + " iteraciones");
                break;
            }
            //Debug.Log("Ciclo completado con " + i + " iteraciones");
        }
    }
}
