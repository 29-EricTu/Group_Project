using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float bulletCount = 7;
    public float Magazine = 0;
    public GameObject BulletPrefab;
    public GameObject BulletSpawn;
    public bool FacingRight = false;
    public bool canShoot = true;

    public Text MagazineText;

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
        MagazineText.text = bulletCount + ("/7");
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
            if (Input.GetKey(KeyCode.Space) && canShoot)
            {
                canShoot = false;
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
            GM.MovementSeed = 4;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Enemies"))
        {
            Yes.SetTrigger("IsDeathTrigger");
            GM.MovementSeed = 0;
        }
        if (collision.gameObject.tag == ("Goal"))
        {
            SceneManager.LoadScene("WinScene");
        }
    }
    public void ChangeScene()
    {
        GM.Loser();
    }
    public void Cooldown()
    {
        canShoot = true;
    }
}
