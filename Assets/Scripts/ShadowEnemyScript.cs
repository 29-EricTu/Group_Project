using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.AI;
using UnityEngine.UI;

public class ShadowEnemyScript : MonoBehaviour
{
    // gets the player object
    private GameObject Player;
    private float distanceToPlayer;

    // for pratrolling
    public GameObject pointA;
    public GameObject pointB;
    private Transform CurrentPoint;
    private bool CanMove = true;

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

    // parameters for when the enemy can attack
    private bool canDamage = true;
    public float damageRate;

    //gets the rigidbody
    public Rigidbody2D RB2D;

    public float EnemyHP = 3;

    //public Text ScoreText;//
    //public float Score;//
    // Start is called before the first frame update
    void Start()
    {
        // find the player gameObject
        Player = GameObject.FindGameObjectWithTag("Player");
        // get the rigidbody component
        RB2D = GetComponent<Rigidbody2D>();
        CurrentPoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //ScoreText.text = ("Enemies Purified : ") + Score;//
        // find the distance of the player to the enemy
        distanceToPlayer = Vector2.Distance(Player.transform.position, transform.position);

            // when the player is within the range of the enemy's argo
            if (distanceToPlayer < contactDistance)
            {
                // activate the run animation
                Ania.SetBool("Player_Spotted", true);
                Ania.SetBool("Enemy_Walk", false);
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
                Ania.SetBool("Enemy_Walk", false);
                if (CanMove == true)
                {
                    Ania.SetBool("Enemy_Walk", true);
                    if (CurrentPoint.position.x < transform.position.x)
                    {
                    RB2D.velocity = new Vector2(-MoveSpeed, 0);
                    RSprite.flipX = true;
                    }

                    else
                    {
                    RB2D.velocity = new Vector2(MoveSpeed, 0);
                    RSprite.flipX = false;
                    }
                }
            }
            if (EnemyHP <=0)
        {
            Ania.SetTrigger("Enemy_Die");
            Destroy(gameObject, 1);
            //Score++;//
            MoveSpeed = 0;
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

    private IEnumerator Patrolling(float waitingTime)
    {
        CanMove = false;
        //wait for some time
        yield return new WaitForSeconds(waitingTime);

        CanMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == pointA.gameObject)
        {
            StartCoroutine(Patrolling(1f));
            if (CurrentPoint.position.x == pointA.transform.position.x)
            {
                CurrentPoint = pointB.transform;
            }
        }

        if (collision.gameObject == pointB.gameObject)
        {
            StartCoroutine(Patrolling(1f));
            if (CurrentPoint.position.x == pointB.transform.position.x)
            {
                CurrentPoint = pointA.transform;
            }
        }
        if(collision.gameObject.tag=="Bullets")
        {
            EnemyHP--;
        }
    }
}


