using UnityEngine;
using System.Collections;

public class BoomerangLauncher : Launcher
{
    public GameObject boomerangPrefab;

    public float[] size;
    public float[] damage;

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

        Boomerang newBoomerang = Instantiate<GameObject>(boomerangPrefab).GetComponent<Boomerang>();

        newBoomerang.transform.localScale = new Vector3(size[levelNum - 1], size[levelNum - 1], size[levelNum - 1]);
        newBoomerang.damage = damage[levelNum - 1];

        newBoomerang.Init(player);
        newBoomerang.Shot();
    }

    IEnumerator FlyProcess(GameObject boomerang, Player player, int levelNum, Vector3 shootPos)
    {
        float endX;
        bool moveRight = player.GetDirVec() == Vector2.right;
        if (moveRight)
        {
            endX = 5f;
        }
        else
        {
            endX = -5f;
        }


        float elaspedTime = 0f;
        float length = Mathf.Abs(endX - shootPos.x);
        Debug.Log(endX);
        float speed = 10f;
        float moveTime = length / speed * 2;
        Vector3 startPos = boomerang.transform.position;
        float h = 1f;
        bool upshot = false;

        while (elaspedTime < moveTime)
        {
            elaspedTime += Time.deltaTime;

            float x = (speed * elaspedTime) - (speed / (2 * moveTime)) * Mathf.Pow(elaspedTime, 2);
            float y = h * Mathf.Sqrt((1 - Mathf.Pow((x - length / 2), 2) / Mathf.Pow((length / 2), 2)));


            if (upshot == true)
            {
                if (moveRight)
                {
                    boomerang.transform.position = new Vector3(x, y, 0) + shootPos;
                }
                else
                    boomerang.transform.position = new Vector3(-x, y, 0) + shootPos;

            }
            else
            {
                if (moveRight)
                {
                    boomerang.transform.position = new Vector3(x, -y, 0) + shootPos;
                }
                else
                    boomerang.transform.position = new Vector3(-x, -y, 0) + shootPos;

            }

            yield return null;
        }

        elaspedTime = 0f;
        while(elaspedTime <= moveTime)
        {
            elaspedTime += Time.deltaTime;

            boomerang.transform.position = EasingUtil.EaseVector3(EasingUtil.linear,
                boomerang.transform.position, player.transform.position, (elaspedTime / moveTime / 3));

            yield return null;
        }
    }
    bool ReturnToShooter(Boomerang boomerang,Player shooter)
    {
        if ((boomerang.transform.position - shooter.transform.position).magnitude < 0.3f)
            return true;
        return false;
    }


}