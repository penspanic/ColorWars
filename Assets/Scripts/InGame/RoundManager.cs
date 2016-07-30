﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoundManager : MonoBehaviour
{

    public HpBar player1HpBar;
    public HpBar player2HpBar;

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

        player1.SetHpBar(player1HpBar);
        player2.SetHpBar(player2HpBar);
    }

    public Player GetPlayer(int number)
    {
        if (number == 1)
            return player1;
        else
            return player2;
    }

    public Player GetOppositePlayer(Player player)
    {
        if (player == player1)
            return player2;
        return player1;
    }

    void Update()
    {

    }
}
