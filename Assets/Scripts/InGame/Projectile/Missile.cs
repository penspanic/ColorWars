using UnityEngine;
using System.Collections;

public class Missile : ProjectileBase
{

    float duration;
    Player target;
    protected override void Awake()
    {
        base.Awake();
    }


    public void SetPos(Vector2 pos)
    {
        transform.position = pos;
    }

    public void SetTarget(Player target)
    {
        this.target = target;
    }

    public void SetData(float duration, int damage, float speed)
    {
        moveSpeed = speed;
        this.damage = damage;
        this.duration = duration;
    }

    public void Follow()
    {
        StartCoroutine(FollowProcess());
    }

    IEnumerator FollowProcess()
    {
        float elaspedTime = 0f;

        while(elaspedTime < duration)
        {
            if(HitPlayer())
            {
                Explode();
                yield break;
            }

            elaspedTime += Time.deltaTime;

            Vector2 moveVec = target.transform.position - transform.position;
            moveVec.Normalize();

            transform.Translate(moveVec * moveSpeed * Time.deltaTime);

            yield return null;
        }

        Explode();
    }

    void Explode()
    {
        if (HitPlayer())
            target.OnDamaged((int)damage);
        Debug.Log("Explode");
    }

    bool HitPlayer()
    {
        return (target.transform.position- transform.position).magnitude < 1.1f;
    }
}
