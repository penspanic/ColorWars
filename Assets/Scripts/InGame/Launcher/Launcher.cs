using UnityEngine;
using System.Collections;

public abstract class Launcher : MonoBehaviour
{
    public float coolTime;

    Player player1;
    Player player2;


    bool canPlayer1Shot = true;
    bool canPlayer2Shot = true;

    RoundManager roundMgr;

    protected virtual void Awake()
    {
        roundMgr = GameObject.FindObjectOfType<RoundManager>();
    }

    void Start()
    {
        player1 = roundMgr.GetPlayer(1);
        player2 = roundMgr.GetPlayer(2);
    }

    protected virtual void Update()
    {

    }


    public virtual void Shot(Player player,int levelNum)
    {
        if(player1 == player)
        {
            canPlayer1Shot = false;
        }
        else // Player2
        {
            canPlayer2Shot = false;
        }

        StartCoroutine(ShotProcess(player));
    }
    IEnumerator ShotProcess(Player player)
    {


        yield return new WaitForSeconds(coolTime);

        if (player.GetNumber() == 1)
            canPlayer1Shot = true;
        else
            canPlayer2Shot = true;
    }
}