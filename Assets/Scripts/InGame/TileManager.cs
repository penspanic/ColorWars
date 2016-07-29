using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TileManager : MonoBehaviour
{
    public GameObject[] tiles;

    List<GameObject> tileList = new List<GameObject>();
    void Awake()
    {
        ShuffleTile();
    }

    void ShuffleTile()
    {
        tileList.AddRange(tiles);
        System.Random rnd = new System.Random();

        int n = tileList.Count;
        while (n > 1)
        {
            n--;
            int k = rnd.Next(n + 1);
            GameObject value = tileList[k];
            tileList[k] = tileList[n];
            tileList[n] = value;
        }

        float startPosX = -5.12f;
        float xInterval = 2.56f;

        for (int i = 0; i < tileList.Count; ++i)
        {
            tileList[i].transform.position = new Vector3(startPosX + xInterval * i, 0, 0);
        }
    }

    public void Shot(Player player)
    {
        int levelNum = 0;

        float playerY = player.transform.position.y;

        if (playerY < -1.2f && playerY >= -3.6f)
        {
            levelNum = 1;

        }
        if (playerY < 1.2f && playerY >= -1.2f)
        {
            levelNum = 2;

        }
        if (playerY < 3.6f && playerY >= 1.2f)
        {
            levelNum = 3;
        }

        Launcher launcher = GetTile(player.transform.position.x).GetComponent<Launcher>();

        launcher.Shot(player,levelNum);
    }


    GameObject GetTile(float x)
    {
        if (x < -3.84 && x >= -6.4)
        {
            return tileList[0];
        }
        if (x < -1.28 && x >= -3.84)
        {
            return tileList[1];
        }
        if (x < 1.28 && x >= -1.28)
        {
            return tileList[2];
        }
        if (x < 3.84 && x >= 1.28)
        {
            return tileList[3];
        }
        if (x < 6.4 && x >= 3.84)
        {
            return tileList[4];
        }

        throw new UnityException();
    }

    public string GetColor(float x)
    {
        if (x < -3.84 && x >= -6.4)
        {
            return tileList[0].name;
        }
        if (x < -1.28 && x >= -3.84)
        {
            return tileList[1].name;
        }
        if (x < 1.28 && x >= -1.28)
        {
            return tileList[2].name;
        }
        if (x < 3.84 && x >= 1.28)
        {
            return tileList[3].name;
        }
        if (x < 6.4 && x >= 3.84)
        {
            return tileList[4].name;
        }

        throw new UnityException();
    }
}