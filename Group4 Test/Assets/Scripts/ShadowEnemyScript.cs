using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.AI;

public class ShadowEnemyScript : MonoBehaviour
{
    // gets the player object
    private GameObject Player;

    // for pratrolling
    public GameObject pointA;
    public GameObject pointB;

    // get the sprite renderer
    public SpriteRenderer RSprite;

    // get the animator
    public Animator Ania;

    // get the attack and contact distance
    public float contactDistance;
    public float Attackdistance;

    // movement speed
    public float MoveSpeed;

    // enemy damage
    public int damage;

    // enemy's Health
    public int Health;

    // parameters for when the enemy can attack
    private bool canDamage = true;
    public float damageRate;

    //gets the rigidbody
    public Rigidbody2D RB2D;

    // Start is called before the first frame update
    void Start()
    {
        // find the player gameObject
        Player = GameObject.FindGameObjectWithTag("Player");
        // get the rigidbody component
        RB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // find the distance of the player to the enemy
        float distanceToPlayer = Vector2.Distance(Player.transform.position, transform.position);
        if (Health > 0)
        {
            // when the player is within the range of the enemy's argo
            if (distanceToPlayer < contactDistance)
            {
                // flips and move to the left
                if (Player.transform.position.x < transform.position.x)
                {
                    RB2D.velocity = new Vector2(-MoveSpeed, 0);
                    RSprite.flipX = true;
                }
                // flips and move to the right
                else if (Player.transform.position.x > transform.position.x)
                {
                    RB2D.velocity = new Vector2(MoveSpeed, 0);
                    RSprite.flipX = false;
                }

                // activate the run animation
                Ania.SetBool("Player_Spotted", true);

                // when the player is in attack range
                if (distanceToPlayer < Attackdistance)
                {
                    RB2D.velocity = new Vector2(0f, 0f);
                    Ania.SetBool("Player_Spotted", false);
                    // see if the enemy can attack
                    if (canDamage == true)
                    {
                        StartCoroutine(Attack());
                    }

                }
            }
            // when the player is out of range
            else if (distanceToPlayer > contactDistance)
            {
                RB2D.velocity = new Vector2(0, 0);
                Ania.SetBool("Player_Spotted", false);
            }
        }

        // when the health = 0
        if (Health <= 0)
        {
            RB2D.velocity = new Vector2(0f, 0f);
            StartCoroutine(Dead(0.3f));
        }
    }

    // when the player can attack
    private IEnumerator Attack()
    {
        Ania.SetTrigger("Enemy_Attacking");
        canDamage = false;
        //wait for some time
        yield return new WaitForSeconds(damageRate);
        canDamage = true;
    }

    // when the dies
    private IEnumerator Dead(float despawn)
    {
        Ania.SetBool("Enemy_Die", true);
        //wait for some time
        yield return new WaitForSeconds(despawn);

        Destroy(gameObject);
    }
}


