using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public int fullHp;
    public float jumpPower;
    public float maxJumpPower;
    public float moveSpeed;
    public float maxSpeed;
    public Sprite red;
    public Sprite blue;
    public Sprite green;
    public Sprite yellow;
    public Sprite purple;
    public Sprite death;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer playerUIrenderer;
    Rigidbody2D rgdBdy;
    TileManager tileMgr;
    RoundManager roundMgr;
    EffectManager effectMgr;
    Transform shotTransform;
    HpBar hpBar;

    int hp;
    int playerNum;
    bool canMove = true;

    void Awake()
    {
        hp = fullHp;
        rgdBdy = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerUIrenderer = transform.FindChild("Player UI").GetComponent<SpriteRenderer>();
        tileMgr = GameObject.FindObjectOfType<TileManager>();
        roundMgr = GameObject.FindObjectOfType<RoundManager>();
        effectMgr = GameObject.FindObjectOfType<EffectManager>();
        shotTransform = transform.FindChild("Shot Position");

        effectMgr.ShowEffect("Prefabs/Effect/Appear Effect", transform.position, Vector3.one);
    }

    public void SetHpBar(HpBar hpBar)
    {
        this.hpBar = hpBar;
        hpBar.UpdateValue(1f);
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

        if (!canMove)
            return;

        if(GetDirVec() == Vector2.right)
        {
            ChangeDirection();
        }

        rgdBdy.AddForce(Vector2.left * Time.deltaTime * moveSpeed);
        if(Mathf.Abs(rgdBdy.velocity.x) <= maxSpeed/2)
        {
            rgdBdy.velocity = new Vector2(-maxSpeed / 2, rgdBdy.velocity.y);
        }
    }

    public void RightKey()
    {

        if (!canMove)
            return;

        if(GetDirVec() == Vector2.left)
        {
            ChangeDirection();
        }

        rgdBdy.AddForce(Vector2.right * Time.deltaTime * moveSpeed);
        if (Mathf.Abs(rgdBdy.velocity.x) <= maxSpeed / 2)
        {
            rgdBdy.velocity = new Vector2(maxSpeed / 2, rgdBdy.velocity.y);
        }
    }

    public void JumpKeyDown()
    {
        if (!canMove)
            return;

        performJump = true;
    }

    public void ShotKeyDown()
    {
        if (!canMove)
            return;

        Shot();
    }

    bool performJump = false;
    void FixedUpdate()
    {
        YRotationChange();
        ChangeColor();
        MaxVelocitySet();

        if (performJump)
        {
            Jump();
        }
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
        if (!roundMgr.roundProcessing)
            return;

        spriteRenderer.sprite = GetSprite(tileMgr.GetColor(transform.position.x));
    }

    int jumpCount = 0;

    void Jump()
    {
        performJump = false;
        if (jumpCount == 3)
            return;
        rgdBdy.velocity = new Vector2(rgdBdy.velocity.x, 0);

        rgdBdy.AddForce(new Vector2(0, jumpPower));
        jumpCount++;

        if (jumpCount == 2)
            effectMgr.ShowEffect("Prefabs/Effect/Double Jump Effect", transform.position,Vector3.one);
        else if (jumpCount == 3)
            effectMgr.ShowEffect("Prefabs/Effect/Triple Jump Effect", transform.position,Vector3.one);


    }

    void Shot()
    {
        tileMgr.Shot(this);
    }

    bool unbeatable = false;
    public void OnDamaged(int damage, ProjectileBase projectile)
    {
        if (unbeatable)
            return;


        hp -= damage;
        hpBar.UpdateValue((float)hp / (float)fullHp);
        hpBar.ShowHurt();
        StartCoroutine(DamagedProcess(projectile));
        StartCoroutine(TwinkleProcess());

        if (hp <= 0)
            OnDeath();
    }

    void Collision(ProjectileBase projectile)
    {
        Vector2 dirVec = transform.position - projectile.transform.position;
        dirVec.Normalize();

        rgdBdy.AddForce(dirVec * 200);
        rgdBdy.AddForce(Vector2.up * 250);
    }

    IEnumerator DamagedProcess(ProjectileBase projectile)
    {
        unbeatable = true;

        canMove = false;
        rgdBdy.velocity = Vector3.zero;

        Collision(projectile);

        yield return new WaitForSeconds(0.5f);

        canMove = true;

        yield return new WaitForSeconds(0.5f);

        unbeatable = false;
    }

    IEnumerator TwinkleProcess()
    {
        for(int i = 0;i<5;++i)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void OnDeath()
    {
        if (!roundMgr.roundProcessing)
            return;
        spriteRenderer.sprite = death;
        GetComponent<Rigidbody2D>().Sleep();
        transform.Rotate(new Vector3(0, 0, 90), Space.World);
        roundMgr.PlayerDeath(this);
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
    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.name == "Left" || other.gameObject.name == "Right")
        {
            if (jumpCount > 0)
                jumpCount--;
        }

        if(other.gameObject.name == "Bottom")
        {
            jumpCount = 0;

            effectMgr.ShowEffect("Prefabs/Effect/Landing Effect", transform.position + new Vector3(0,0.4f,0),Vector3.one);
        }
    }
}