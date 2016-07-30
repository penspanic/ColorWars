using UnityEngine;
using System.Collections;

public class Boomerang : ProjectileBase
{
    public float rotateSpeed = 500f;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void Init(Player player)
    {
        base.Init(player);
    }

    protected override void OnLaunched()
    {
        base.OnLaunched();
    }

    protected override void Update()
    {
        base.Update();

        transform.Rotate(new Vector3(0, 0, 720) * Time.deltaTime);
    }

    public void Shot()
    {
        StartCoroutine(FlyProcess());
    }

    bool returning = false;
    IEnumerator FlyProcess()
    {
        Vector3 shootPos = shooter.transform.position;
        float endX;
        bool moveRight = shooter.GetDirVec() == Vector2.right;
        if (moveRight)
        {
            endX = 5f;
        }
        else
        {
            endX = -5f;
        }


        float elaspedTime = 0f;
        float length = Mathf.Abs(endX - shootPos.x);
        Debug.Log(endX);
        float speed = 10f;
        float moveTime = length / speed * 2;
        Vector3 startPos = transform.position;
        float h = 1f;
        bool upshot = shootPos.y < 0f;

        while (elaspedTime < moveTime)
        {
            elaspedTime += Time.deltaTime;

            float x = (speed * elaspedTime) - (speed / (2 * moveTime)) * Mathf.Pow(elaspedTime, 2);
            float y = h * Mathf.Sqrt((1 - Mathf.Pow((x - length / 2), 2) / Mathf.Pow((length / 2), 2)));


            if (upshot == true)
            {
                if (moveRight)
                {
                    transform.position = new Vector3(x, y, 0) + shootPos;
                }
                else
                    transform.position = new Vector3(-x, y, 0) + shootPos;

            }
            else
            {
                if (moveRight)
                {
                    transform.position = new Vector3(x, -y, 0) + shootPos;
                }
                else
                    transform.position = new Vector3(-x, -y, 0) + shootPos;

            }

            yield return null;
        }

        returning = true;

        elaspedTime = 0f;
        while (elaspedTime <= moveTime)
        {
            elaspedTime += Time.deltaTime;

            transform.position = EasingUtil.EaseVector3(EasingUtil.linear,
                transform.position, shooter.transform.position, (elaspedTime / moveTime / 3));

            yield return null;
        }

        Destroy(this.gameObject);
    }

    bool ReturnedForShooter()
    {
        return (transform.position - shooter.transform.position).magnitude < 0.3f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Player>() != null)
        {
            if(other.GetComponent<Player>() != shooter)
            {
                other.GetComponent<Player>().OnDamaged((int)damage,this);
                effectMgr.ShowEffect("Prefabs/Effect/Slash Effect", other.transform.position, new Vector3(1.3f, 1.3f, 1.3f));
                Destroy(this.gameObject);
            }
            else
            {
                if (returning)
                    Destroy(this.gameObject);
            }
        }
    }
}