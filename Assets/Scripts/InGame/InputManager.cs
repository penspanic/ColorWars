using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{

    Player player1;
    Player player2;

    RoundManager roundMgr;

    void Awake()
    {
        roundMgr = GameObject.FindObjectOfType<RoundManager>();
    }

    public void SetPlayer(Player player1, Player player2)
    {
        this.player1 = player1;
        this.player2 = player2;
    }

    void Update()
    {
        if (!roundMgr.roundProcessing)
            return;

        // Player 1

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            player1.LeftKey();
        }

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            player1.RightKey();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            player1.JumpKeyDown();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            player1.ShotKeyDown();
        }

        // Player 2

        if(Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.L))
        {
            player2.LeftKey();
        }

        if(Input.GetKey(KeyCode.L) && !Input.GetKey(KeyCode.J))
        {
            player2.RightKey();
        }

        if(Input.GetKeyDown(KeyCode.Period))
        {
            player2.JumpKeyDown();
        }

        if(Input.GetKeyDown(KeyCode.Slash))
        {
            player2.ShotKeyDown();
        }
    }
}
