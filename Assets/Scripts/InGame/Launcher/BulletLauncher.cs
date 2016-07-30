using UnityEngine;
using System.Collections;

public class BulletLauncher : Launcher
{

    public GameObject bulletPrefab;

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

        switch(levelNum)
        {
            case 1:
                Level1Shot(player);
                break;
            case 2:
                Level2Shot(player);
                break;
            case 3:
                Level3Shot(player);
                break;
        }
    }

    void Level1Shot(Player player)
    {
        Bullet newBullet = Instantiate<GameObject>(bulletPrefab).GetComponent<Bullet>();
        newBullet.Init(player);

        newBullet.SetPos(player.GetShotTransform().transform.position);

        newBullet.SetDirVec(player.GetDirVec());

    }

    void Level2Shot(Player player)
    {
        Bullet newBullet1 = Instantiate<GameObject>(bulletPrefab).GetComponent<Bullet>();
        newBullet1.Init(player);

        newBullet1.SetPos(player.GetShotTransform().transform.position);

        newBullet1.SetDirVec(player.GetDirVec());

        Bullet newBullet2 = Instantiate<GameObject>(bulletPrefab).GetComponent<Bullet>();
        newBullet2.Init(player);

        newBullet2.SetPos(player.GetShotTransform().transform.position);

        newBullet2.SetDirVec(player.GetDirVec() + Vector2.up);

        Bullet newBullet3 = Instantiate<GameObject>(bulletPrefab).GetComponent<Bullet>();
        newBullet3.Init(player);

        newBullet3.SetPos(player.GetShotTransform().transform.position);

        newBullet3.SetDirVec(player.GetDirVec() + Vector2.down);
    }

    void Level3Shot(Player player)
    {
        Bullet newBullet1 = Instantiate<GameObject>(bulletPrefab).GetComponent<Bullet>();
        newBullet1.Init(player);

        newBullet1.SetPos(player.GetShotTransform().transform.position);

        newBullet1.SetDirVec(player.GetDirVec() + new Vector2(0, 0.5f));

        Bullet newBullet2 = Instantiate<GameObject>(bulletPrefab).GetComponent<Bullet>();
        newBullet2.Init(player);

        newBullet2.SetPos(player.GetShotTransform().transform.position);

        newBullet2.SetDirVec(player.GetDirVec());

        Bullet newBullet3 = Instantiate<GameObject>(bulletPrefab).GetComponent<Bullet>();
        newBullet3.Init(player);

        newBullet3.SetPos(player.GetShotTransform().transform.position);

        newBullet3.SetDirVec(player.GetDirVec() + new Vector2(0, -0.5f));

        Bullet newBullet4 = Instantiate<GameObject>(bulletPrefab).GetComponent<Bullet>();
        newBullet4.Init(player);

        newBullet4.SetPos(player.GetShotTransform().transform.position);

        newBullet4.SetDirVec(player.GetDirVec() + Vector2.down);

        Bullet newBullet5 = Instantiate<GameObject>(bulletPrefab).GetComponent<Bullet>();
        newBullet5.Init(player);

        newBullet5.SetPos(player.GetShotTransform().transform.position);

        newBullet5.SetDirVec(player.GetDirVec() + new Vector2(0,-1.5f));
    }
}