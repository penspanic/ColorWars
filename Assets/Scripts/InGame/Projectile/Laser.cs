using UnityEngine;
using System.Collections;

public class Laser : ProjectileBase
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void Init(Player player)
    {
        base.Init(player);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name + " Laser");
    }
}
