using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float jumpPower;
    public float moveSpeed;
    public float maxSpeed;
    public int colornum;
    public int levelnum;
    // public GameObject[] colorshiftline;
    Rigidbody2D rgdBdy;

    void Awake()
    {
        rgdBdy = GetComponent<Rigidbody2D>();
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

        }

        if (transform.position.x < -3.84 && transform.position.x >= -6.4)
        {
            colornum = 1;
        
        }
        if (transform.position.x < -1.28 && transform.position.x >= -3.84)
        {
            colornum = 2;

        }
        if (transform.position.x < 1.28 && transform.position.x >= -1.28)
        {
            colornum = 3;

        }
        if (transform.position.x < 3.84 && transform.position.x >= 1.28)
        {
            colornum = 4;

        }
        if (transform.position.x < 6.4 && transform.position.x >= 3.84)
        {
            colornum = 5;

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
}
