using UnityEngine;
using System.Collections;

public class Laser : ProjectileBase
{

    public BoxCollider2D boxCollider;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void Init(Player player)
    {
        base.Init(player);

        transform.SetParent(player.transform);
    }

    public void OnLaserStart()
    {
        boxCollider.enabled = true;
    }

    public void OnLaserEnd()
    {
        boxCollider.enabled = false;
    }

    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Player>() != null)
        {
            if(other.GetComponent<Player>() != shooter)
            {
                other.GetComponent<Player>().OnDamaged((int)damage,this);
                effectMgr.ShowEffect("Prefabs/Effect/Laser Hit Effect", other.transform.position, Vector3.one);
            }
        }
    }
}