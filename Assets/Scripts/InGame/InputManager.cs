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

    void Update()
    {
        if (!roundMgr.roundProcessing)
            return;

        // Player 1

        if (Input.GetKey(KeyCode.W))
        {

        }

        if (Input.GetKey(KeyCode.D))
        {

        }

        if (Input.GetKeyDown(KeyCode.C))
        {

        }

        if (Input.GetKeyDown(KeyCode.V))
        {

        }

        // Player 2

        if(Input.GetKey(KeyCode.J))
        {

        }

        if(Input.GetKey(KeyCode.L))
        {

        }

        if(Input.GetKeyDown(KeyCode.Period))
        {

        }

        if(Input.GetKeyDown(KeyCode.Slash))
        {

        }
    }
}
