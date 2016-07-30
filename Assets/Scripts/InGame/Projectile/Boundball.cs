using UnityEngine;
using System.Collections;

public class Boundball : ProjectileBase
{
    public AudioClip boundingSound;

    Rigidbody2D rgdBdy;
    Animator animator;

    int hittedCount = 0;
    int boundTime;
    protected override void Awake()
    {
        base.Awake();
        rgdBdy = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    protected override void Update()
    {
        base.Update();
    }

    public void SetBoundTime(int boundTime)
    {
        this.boundTime = boundTime;
    }

    public void AddForce(Vector3 force)
    {
        rgdBdy.AddForce(force);
    }

    public void OnAnimationEnd()
    {
        animator.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Edge"))
        {
            hittedCount++;
            animator.enabled = true;

            BoundingSound();
            if (hittedCount == boundTime + 1)
            {
                Destroy(this.gameObject);
                ShowEffect();
                return;
            }
        }
        else if(other.gameObject.GetComponent<Player>()!= null)
        {
            if(other.gameObject.GetComponent<Player>() != shooter)
            {
                other.gameObject.GetComponent<Player>().OnDamaged((int)damage, this);
                Destroy(this.gameObject);
                ShowEffect();
            }
        }
    }

    void BoundingSound()
    {
        GetComponent<AudioSource>().PlayOneShot(boundingSound);
    }

    void ShowEffect()
    {
        effectMgr.ShowEffect("Prefabs/Effect/Pop Effect", transform.position, Vector3.one);
    }
}
