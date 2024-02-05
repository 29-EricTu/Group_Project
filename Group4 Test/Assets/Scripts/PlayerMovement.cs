using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float bulletCount = 7;
    public float Magazine = 0;
    public GameObject BulletPrefab;
    public GameObject BulletSpawn;
    public bool FacingRight = false;

    Animator Yes;
    public GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Yes = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            GM.MoveRight();
            this.GetComponent<SpriteRenderer>().flipX = false;
            Yes.SetBool("IsRunBool", true);
            FacingRight = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            GM.MoveLeft();
            this.GetComponent<SpriteRenderer>().flipX = true;
            Yes.SetBool("IsRunBool", true);
            FacingRight = false;
        }
        else
        {
            Yes.SetBool("IsRunBool", false);
        }

        if (bulletCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(BulletPrefab, BulletSpawn.transform.position,Quaternion.identity);
                bulletCount--;
                Yes.SetBool("IsShootBool", true);
                GM.MovementSeed = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            bulletCount = 7;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Yes.SetBool("IsShootBool", false);
            GM.MovementSeed = 2;
        }
    }
}
