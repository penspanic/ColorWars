using UnityEngine;
using System.Collections;

public class LaserLauncher : Launcher
{
    public GameObject laserPrefab;

    public float[] damage;
    public Vector3[] size;
    public Vector3[] additinalPos;

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

        Laser newLaser = Instantiate<GameObject>(laserPrefab).GetComponent<Laser>();

        newLaser.transform.position = player.transform.position;
        newLaser.transform.rotation = player.transform.rotation;
        newLaser.transform.localScale = size[levelNum - 1];
        newLaser.damage = damage[levelNum - 1];

        if(player.GetDirVec() == Vector2.right)
        {
            newLaser.transform.position += additinalPos[levelNum - 1];
        }
        else
        {
            newLaser.transform.position -= additinalPos[levelNum - 1];
            newLaser.transform.rotation = Quaternion.Euler(0, 180, 0);
        }


        newLaser.Init(player);

    }
}