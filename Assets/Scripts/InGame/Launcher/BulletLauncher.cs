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

    }

    void Level3Shot(Player player)
    {

    }
}