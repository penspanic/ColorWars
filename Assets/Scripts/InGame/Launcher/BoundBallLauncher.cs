using UnityEngine;
using System.Collections;

public class BoundballLauncher : Launcher
{

    public GameObject boundballPrefab;

    public float[] scale;
    public float[] damage;
    public int[] boundTime;

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

        Boundball newBoundball = Instantiate<GameObject>(boundballPrefab).GetComponent<Boundball>();

        newBoundball.transform.position = player.transform.position;
        newBoundball.Init(player);
        newBoundball.SetBoundTime(boundTime[levelNum - 1]);
        newBoundball.damage = damage[levelNum - 1];
        newBoundball.transform.localScale = Vector3.one * scale[levelNum - 1];
        newBoundball.AddForce(player.GetDirVec() * 100);
        newBoundball.AddForce(Vector2.up * 500);
    }
}
