using UnityEngine;
using System.Collections;

public class RoundManager : MonoBehaviour
{

    public bool roundProcessing
    {
        get;
        private set;
    }

    void Awake()
    {

    }

    void CreatePlayer()
    {
        Player player1 = Instantiate(Resources.Load<GameObject>("Prefabs/Player")).GetComponent<Player>();
        Player player2 = Instantiate(Resources.Load<GameObject>("Prefabs/Player")).GetComponent<Player>();

        //player1.SetNumber(1);
        //Player2.SetNumber(2);

        //
    }

    void Update()
    {

    }
}
