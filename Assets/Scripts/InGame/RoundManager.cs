using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoundManager : MonoBehaviour
{
    List<Launcher> launcherList = new List<Launcher>();

    public bool roundProcessing
    {
        get;
        private set;
    }

    Player player1;
    Player player2;

    void Awake()
    {
        CreatePlayer();
        roundProcessing = true;
    }



    void CreatePlayer()
    {
        player1 = Instantiate(Resources.Load<GameObject>("Prefabs/Player1")).GetComponent<Player>();
        player2 = Instantiate(Resources.Load<GameObject>("Prefabs/Player2")).GetComponent<Player>();

        player1.SetNumber(1);
        player2.SetNumber(2);

    }

    public Player GetPlayer(int number)
    {
        if (number == 1)
            return player1;
        else
            return player2;
    }

    void Update()
    {

    }
}
