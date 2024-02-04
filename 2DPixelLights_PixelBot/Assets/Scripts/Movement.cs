using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody2D rb;
    ParticleSystem gun;
    Animator anim;
    public float speed = 3;
    public string Direction;
    public SpriteRenderer AHHHH;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gun = GetComponentInChildren<ParticleSystem>();
        anim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Blend", x);

        transform.position += new Vector3(x * speed * Time.deltaTime, 0,0);
        
        if(Input.GetKeyDown(KeyCode.A)||(Input.GetKey(KeyCode.LeftArrow)))
        {
            AHHHH.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            AHHHH.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gun.Play();
            anim.SetBool("IsShootBool", true);
            speed = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            gun.Stop();
            anim.SetBool("IsShootBool", false);
            speed = 3;
        }
    }
}
