using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float jumpPower;
    public float moveSpeed;
    public float maxSpeed;
    public int colornum;
    public int levelnum;
    public float shotcooltime =0f;
    public GameObject bulletweapon;
    public GameObject boundballweapon;
    public GameObject missileweapon;
    public GameObject boomerangweapon;
    public GameObject laserweapon;
    public Sprite red;
    public Sprite blue;
    public Sprite green;
    public Sprite yellow;
    public Sprite purple;
    private SpriteRenderer spriteRenderer;
    // public GameObject[] colorshiftline;
    Rigidbody2D rgdBdy;

    void Awake()
    {
        rgdBdy = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            rgdBdy.AddForce(Vector2.left * Time.deltaTime * moveSpeed);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            //transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            rgdBdy.AddForce(Vector2.right * Time.deltaTime * moveSpeed);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            shot();
        }

        if (transform.position.x < -3.84 && transform.position.x >= -6.4)
        {
            colornum = 1;
            spriteRenderer.sprite = red;
        }
        if (transform.position.x < -1.28 && transform.position.x >= -3.84)
        {
            colornum = 2;
            spriteRenderer.sprite = green;
        }
        if (transform.position.x < 1.28 && transform.position.x >= -1.28)
        {
            colornum = 3;
            spriteRenderer.sprite = blue;
        }
        if (transform.position.x < 3.84 && transform.position.x >= 1.28)
        {
            colornum = 4;
            spriteRenderer.sprite = yellow;
        }
        if (transform.position.x < 6.4 && transform.position.x >= 3.84)
        {
            colornum = 5;
            spriteRenderer.sprite = purple;
        }
        if (transform.position.y < -1.2 && transform.position.y >= -3.6)
        {
            levelnum = 1;

        }
        if (transform.position.y < 1.2 && transform.position.y >= -1.2)
        {
            levelnum = 2;

        }
        if (transform.position.y < 3.6 && transform.position.y >= 1.2)
        {
            levelnum = 3;

        }
        shotcooltime += Time.deltaTime;
    }

    int jumpCount = 0;

    void Jump()
    {
        if (jumpCount == 3)
            return;

        rgdBdy.AddForce(Vector2.up * jumpPower);
        jumpCount++;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Bottom")
        {
            jumpCount = 0;
        }
    }

    void shot()
    {
        if (shotcooltime >= 0.5f)
        {
            shotcooltime = 0.0f;

            if (colornum == 1) //bullet
            {
                bulletweapon.SendMessage("bulletshot");
                
            }
            if (colornum == 2) //boundball
            {
               
            }
            if (colornum == 3) // missile
            {
                
            }
            if (colornum == 4) // boomerang
            {
               
            }
            if (colornum == 5) // laser
            {
                
            }
        }
    }
}
