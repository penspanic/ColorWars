using UnityEngine;
using System.Collections;

public abstract class ProjectileBase : MonoBehaviour
{
    public float moveSpeed;
    public float damage;

    Player shooter;

    protected virtual void Awake()
    {

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
