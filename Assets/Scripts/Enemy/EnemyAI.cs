using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component responsible of wolf movement, target finding, attack and bush eating
/// </summary>
public class EnemyAI : MonoBehaviour
{
    //True if the enemy is a red wolf and eats bushes instead of attacking the artifact.
    [SerializeField] bool isEater;
    [SerializeField] float moveSpeed;

    [SerializeField] int attackDamage;
    [SerializeField] float attackTime;
    [SerializeField] float eatTime;

    [SerializeField] LayerMask bushesMask;

    [HideInInspector] public bool isMoving;
    [HideInInspector] public bool left;
    
    Artifact artifact;

    BushFruits target;
    float attackTimer; 
    float eatTimer;
    bool killingBush;
    bool attacking;

    void Start()
    {
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

    void Update()
    {
        if (isEater)
        {
            //Main eater wolf logic:
            if(target != null && target.enabled == true && target.HasFruits() && !killingBush)
            {
                //If not close enough to bush, continue walking towards it, else stop and eat the bush.
                if (Vector2.Distance(transform.position, target.transform.position) > 0.5f)
                {
                    float step = moveSpeed * Time.deltaTime;
                    transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
                    isMoving = true;
                }
                else
                {
                    isMoving = false;
                    target.HarvestFruit();
                    eatTimer = Time.time + eatTime;
                    killingBush = true;
                }
            }
            else if (killingBush)
            {
                //Wait for eatTimer, then search next closest bush.
                if(Time.time > eatTimer)
                {
                    target.EatBush();
                    killingBush = false;
                    SearchForTarget();
                }
            }
            else //In some cases, a wolf can target the same bush that other wolf targeted, so when the other wolf eats it, its no longer valid for this wolf to continue targeting it.
            {
                SearchForTarget();
            }
            //target based sprite flipping.
            if (target.transform.position.x < transform.position.x)
            {
                left = true;
            }
            else
            {
                left = false;
            }
            //Error handling
            if(target == null)
            {
                SearchForTarget();
            }
        }
        else
        {
            //Main attacker wolf logic:
            if(Vector2.Distance(transform.position, artifact.transform.position) > 1.5f)
            {
                //if not close enough to artifact, continue moving
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, artifact.transform.position, step);
                isMoving = true;
            }
            else if(!attacking)
            {
                //Start attacking when close enough
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
            //Artifact based sprite flipping
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
        artifact.Damage(attackDamage);
    }
    /// <summary>
    /// This is a interesting one, instead of spamming <see cref="Vector2.Distance(Vector2, Vector2)"/> to search for a close bush,
    /// the wolf will start overlapping circles, each one exponentialy bigger than the previous one in a increasing loop, ending as soon as it hits a bush.
    /// <para>The loop finds a bush at around 2-4 iterations in most cases, more or less a median of 3 <see cref="Physics2D.OverlapCircleAll(Vector2, float)"/> calls per method call.</para>
    /// </summary>
    void SearchForTarget()
    {
        target = null;
        for (int i = 1; i < 50; i++) //iterate with a safe value of 50
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
                break; //end the main for loop once we are sure that target is not null
            }
        }
    }
}
