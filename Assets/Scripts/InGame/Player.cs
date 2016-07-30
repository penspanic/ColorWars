using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public int fullHp;
    public float jumpPower;
    public float moveSpeed;
    public float maxSpeed;
    public Sprite red;
    public Sprite blue;
    public Sprite green;
    public Sprite yellow;
    public Sprite purple;
    private SpriteRenderer spriteRenderer;
    Rigidbody2D rgdBdy;
    ProjectileManager projectileMgr;
    TileManager tileMgr;
    Transform shotTransform;
    HpBar hpBar;

    int hp;
    int playerNum;

    void Awake()
    {
        rgdBdy = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        projectileMgr = GameObject.FindObjectOfType<ProjectileManager>();
        tileMgr = GameObject.FindObjectOfType<TileManager>();
        shotTransform = transform.FindChild("Shot Position");
    }

    public void SetHpBar(HpBar hpBar)
    {
        this.hpBar = hpBar;
    }

    public void SetNumber(int num)
    {
        playerNum = num;
    }

    public int GetNumber()
    {
        return playerNum;
    }

    public Transform GetShotTransform()
    {
        return shotTransform;
    }

    public void LeftKey()
    {
        if(GetDirVec() == Vector2.right)
        {
            ChangeDirection();
        }

        rgdBdy.AddForce(Vector2.left * Time.deltaTime * moveSpeed);
    }

    public void RightKey()
    {

        if(GetDirVec() == Vector2.left)
        {
            ChangeDirection();
        }

        rgdBdy.AddForce(Vector2.right * Time.deltaTime * moveSpeed);
    }

    public void JumpKeyDown()
    {
        Jump();
    }

    public void ShotKeyDown()
    {
        Shot();
    }

    void FixedUpdate()
    {
        YRotationChange();
        ChangeColor();
        MaxVelocitySet();
    }

    void MaxVelocitySet()
    {
        if (rgdBdy.velocity.x >= maxSpeed)
        {
            Vector3 newVel = rgdBdy.velocity;
            newVel.x = maxSpeed;
            rgdBdy.velocity = newVel;
        }
    }

    void ChangeDirection()
    {
        Vector3 vel = rgdBdy.velocity;

        vel.x = -vel.x;

        rgdBdy.velocity = vel;
    }

    void YRotationChange()
    {
        if (Mathf.Abs(rgdBdy.velocity.x) < 0.1f)
            return;

        if (rgdBdy.velocity.x >= 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }

    void ChangeColor()
    {
        spriteRenderer.sprite = GetSprite(tileMgr.GetColor(transform.position.x));
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

    void Shot()
    {
        tileMgr.Shot(this);
    }

    public void OnDamaged(int damage)
    {
        hp -= damage;
        hpBar.UpdateValue(hp / fullHp);

        if (hp <= 0)
            OnDeath();
    }

    void OnDeath()
    {
        Debug.Log("Player Dead!");
    }

    Sprite GetSprite(string colorName)
    {
        switch(colorName)
        {
            case "Red":
                return red;
            case "Blue":
                return blue;
            case "Purple":
                return purple;
            case "Yellow":
                return yellow;
            case "Green":
                return green;
        }
        throw new UnityException();
    }

    public Vector2 GetDirVec()
    {
        if (transform.rotation.eulerAngles.y == 0)
            return Vector2.right;
        return Vector2.left;
    }
}
