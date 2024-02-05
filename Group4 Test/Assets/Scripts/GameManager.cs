using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Rigidbody2D rb;
    public float MovementSeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveRight()
    {
        rb.velocity = new Vector2(MovementSeed, rb.velocity.y);
    }
    public void MoveLeft()
    {
        rb.velocity = new Vector2(-MovementSeed, rb.velocity.y);
    }
}
