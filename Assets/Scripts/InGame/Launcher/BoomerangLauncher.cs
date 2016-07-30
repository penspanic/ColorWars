using UnityEngine;
using System.Collections;

public class BoomerangLauncher : Launcher
{
    public GameObject boomerangPrefab;

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

        Boomerang newBoomerang = Instantiate<GameObject>(boomerangPrefab).GetComponent<Boomerang>();
        newBoomerang.Init(player);

        StartCoroutine(FlyProcess(newBoomerang.gameObject, player, levelNum));
    }

    IEnumerator FlyProcess(GameObject boomerang, Player player, int levelNum)
    {

        bool moveRight = player.GetDirVec() == Vector2.right;
        float endX;
        if (moveRight)
        {
            endX = 6f;
        }
        else
            endX = -6f;


        float elaspedTime = 0f;
        float moveTime = 2f;
        float speed = 5;
        Vector3 startPos = boomerang.transform.position;
        float h = 1f;


        while(elaspedTime <moveTime)
        {
            elaspedTime += Time.deltaTime;

            float x = (5*elaspedTime)- (5/(2 *moveTime)) * Mathf.Pow(elaspedTime, 2);
            float l = (speed * moveTime) - (speed * Mathf.Pow(moveTime, 2) / 2);
            float y = h * Mathf.Sqrt(1 - Mathf.Pow((x - l / 2), 2) / (l / 2));

            boomerang.transform.position = new Vector3(x, y, 0);

            yield return null;
        }




        //while(elaspedTime < moveTime)
        //{
        //    elaspedTime += Time.deltaTime;

        //    Vector3 newPos = startPos;
        //    newPos.x = Mathf.Lerp(startPos.x, endX, elaspedTime / moveTime);
        //    boomerang.transform.position = newPos;

        //    yield return null;
        //}

        //elaspedTime = 0;

        //startPos = boomerang.transform.position;
        //while(elaspedTime < moveTime)
        //{
        //    elaspedTime += Time.deltaTime;

        //    Vector3 newPos = boomerang.transform.position;
        //    newPos.x = Mathf.Lerp(startPos.x, player.transform.position.x, elaspedTime / moveTime);
        //    boomerang.transform.position = newPos;

        //    yield return null;
        //}
    }
}