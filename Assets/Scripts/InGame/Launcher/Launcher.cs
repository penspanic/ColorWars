using UnityEngine;
using System.Collections;

public abstract class Launcher : MonoBehaviour
{
    public float coolTime;

    protected Player player1;
    protected Player player2;


    bool canPlayer1Shot = true;
    bool canPlayer2Shot = true;

    protected RoundManager roundMgr;

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

    protected bool CanShot(Player player)
    {
        if (player.GetNumber() == 1)
            return canPlayer1Shot;
        else
            return canPlayer2Shot;
    }

    public virtual void Shot(Player player,int levelNum)
    {

    }

    protected IEnumerator ShotProcess(Player player)
    {
        if (player.GetNumber() == 1)
            canPlayer1Shot = false;
        else
            canPlayer2Shot = false;

        yield return new WaitForSeconds(coolTime);

        if (player.GetNumber() == 1)
            canPlayer1Shot = true;
        else
            canPlayer2Shot = true;
    }
}