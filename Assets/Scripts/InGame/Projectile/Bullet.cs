using UnityEngine;
using System.Collections;

public class Bullet : ProjectileBase
{

    Vector2 dirVec;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void Init(Player player)
    {
        base.Init(player);

    }

    public void SetPos(Vector2 pos)
    {
        transform.position = pos;
    }

    public void SetDirVec(Vector2 dirVec)
    {
        this.dirVec = dirVec;
    }

    protected override void OnLaunched()
    {
        base.OnLaunched();
    }

    protected override void OnDestroyed()
    {
        base.OnDestroyed();
        Destroy(this.gameObject);
    }

    protected override void Update()
    {
        base.Update();

        transform.Translate(dirVec * moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        OnDestroyed();
    }
}
