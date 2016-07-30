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

            transform.Translate(moveVec * moveSpeed * Time.deltaTime,Space.World);

            Vector3 dir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


            yield return null;
        }

        Explode();
    }

    void Explode()
    {
        if (HitPlayer())
            target.OnDamaged((int)damage,this);


        StartCoroutine(EffectProcess());
    }

    IEnumerator EffectProcess()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        Vector3 pos = transform.position;
        pos.x = Random.Range(pos.x - 0.2f, pos.x + 0.2f);
        pos.y = Random.Range(pos.y - 0.2f, pos.y + 0.2f);

        for(int i= 0;i<2;++i)
        {
            pos.x = Random.Range(pos.x - 0.2f, pos.x + 0.2f);
            pos.y = Random.Range(pos.y - 0.2f, pos.y + 0.2f);
            yield return new WaitForSeconds(0.1f);
            effectMgr.ShowEffect("Prefabs/Effect/Boom Effect", pos, Vector3.one);
        }

        Destroy(this.gameObject);
    }

    bool HitPlayer()
    {
        if (target == null)
            return true;
        return (target.transform.position- transform.position).magnitude < 0.6f;
    }
}
