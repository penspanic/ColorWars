using UnityEngine;
using System.Collections;

public abstract class ProjectileBase : MonoBehaviour
{
    public float moveSpeed;
    public float damage;

    protected Player shooter;
    protected EffectManager effectMgr;

    protected virtual void Awake()
    {
        effectMgr = GameObject.FindObjectOfType<EffectManager>();
    }

    protected virtual void Update()
    {

    }

    public virtual void Init(Player player)
    {
        shooter = player;
    }

    protected virtual void OnLaunched()
    {

    }

    protected virtual void OnDestroyed()
    {

    }
}
