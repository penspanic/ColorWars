using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float jumpPower;
    public float moveSpeed;
    public float maxSpeed;

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

        Debug.Log(rgdBdy.velocity.x);
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
