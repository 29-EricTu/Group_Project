﻿using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Rigidbody2D rb;
    public float MovementSeed;

    public AudioClip[] PP;
    public AudioSource Urmom;

    // Start is called before the first frame update
    void Start()
    {
        Urmom=GetComponent<AudioSource>();
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
    public void Loser()
    {
        SceneManager.LoadScene("GameLose");
    }
    public void Ow()
    {
        Urmom.PlayOneShot(PP[1]);
    }
    public void Pew()
    {
        Urmom.PlayOneShot(PP[0]);
    }
}
