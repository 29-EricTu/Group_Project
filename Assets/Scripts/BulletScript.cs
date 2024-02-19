using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float BulletSpeed=10f;
    public Rigidbody2D RB;
    public PlayerMovement PlayerMove;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
        PlayerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();
        if (PlayerMove.FacingRight)
        {
            RB.velocity = transform.right * BulletSpeed;
        }
        else if (!PlayerMove.FacingRight)
        {
            RB.velocity = -transform.right * BulletSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            Destroy(gameObject);
        }
    }
}
