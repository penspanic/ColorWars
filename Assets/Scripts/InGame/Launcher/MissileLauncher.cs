using UnityEngine;
using System.Collections;

public class MissileLauncher : Launcher
{

    public float[] duration;
    public int[] damage;
    public float[] speed;
    public Vector3[] size;


    public GameObject missilePrefab;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Shot(Player player, int levelNum)
    {
        base.Shot(player, levelNum);

        if (!CanShot(player))
            return;

        StartCoroutine(ShotProcess(player));


        Missile newMissile = Instantiate<GameObject>(missilePrefab).GetComponent<Missile>();

        newMissile.SetTarget(roundMgr.GetOppositePlayer(player));
        newMissile.SetData(duration[levelNum - 1], damage[levelNum - 1], speed[levelNum - 1]);
        newMissile.transform.localScale = size[levelNum - 1];
        newMissile.SetPos(player.transform.position);

        newMissile.Follow();
    }
}
