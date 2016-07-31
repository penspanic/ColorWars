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

    const float dead = 0.4f;
    void Update()
    {
        if (!roundMgr.roundProcessing)
            return;

        // Player 1

        Debug.Log(Input.GetAxis("Horizontal1"));

        if (Input.GetAxis("Horizontal1") < 0)
            player1.LeftKey();

        if (Input.GetAxis("Horizontal1") > 0)
            player1.RightKey();

        if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Q))
        {
            player1.JumpKeyDown();
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.W))
        {
            player1.ShotKeyDown();
        }

        // Player 2

        if (Input.GetAxis("Horizontal2") < 0)
            player2.LeftKey();

        if (Input.GetAxis("Horizontal2") > 0)
            player2.RightKey();

        if (Input.GetKeyDown(KeyCode.Joystick2Button0) || Input.GetKeyDown(KeyCode.Comma))
        {
            player2.JumpKeyDown();
        }

        if (Input.GetKeyDown(KeyCode.Joystick2Button1) || Input.GetKeyDown(KeyCode.Period))
        {
            player2.ShotKeyDown();
        }
    }
}
