using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RoundManager : MonoBehaviour
{
    public GameObject readyPrefab;
    public GameObject fightPrefab;

    public HpBar player1HpBar;
    public HpBar player2HpBar;

    public Score player1ScoreUI;
    public Score player2ScoreUI;

    public Image roundImage;
    public Sprite[] roundSprites;

    List<Launcher> launcherList = new List<Launcher>();

    TileManager tileMgr;
    InputManager inputMgr;

    public bool roundProcessing
    {
        get;
        private set;
    }

    Player player1;
    Player player2;

    int player1Score = 0;
    int player2Score = 0;

    void Awake()
    {
        tileMgr = GameObject.FindObjectOfType<TileManager>();
        inputMgr = GameObject.FindObjectOfType<InputManager>();

        CreatePlayer();
        StartCoroutine(RoundStartProcess());
    }

    IEnumerator RoundStartProcess()
    {
        yield return StartCoroutine(SceneFader.Instance.FadeIn(1f));

        Instantiate(readyPrefab);


        yield return new WaitForSeconds(1f);

        Instantiate(fightPrefab);

        roundProcessing = true;
    }


    void CreatePlayer()
    {
        player1 = Instantiate(Resources.Load<GameObject>("Prefabs/Player1")).GetComponent<Player>();
        player2 = Instantiate(Resources.Load<GameObject>("Prefabs/Player2")).GetComponent<Player>();

        inputMgr.SetPlayer(player1, player2);

        player1.SetNumber(1);
        player2.SetNumber(2);

        player1.SetHpBar(player1HpBar);
        player2.SetHpBar(player2HpBar);
    }

    public void PlayerDeath(Player deadPlayer)
    {
        if(deadPlayer == player1)
        {
            PlayerWin(2);        
        }
        else
        {
            PlayerWin(1);
        }
    }

    void PlayerWin(int playerNum)
    {
        roundProcessing = false;
        if (playerNum == 1)
        {
            player1Score++;
            player1ScoreUI.SetScore(player1Score);
            if(player1Score ==2)
            {
                StartCoroutine(GameEndProcess(1));
                return;
            }
        }
        else
        {
            player2Score++;
            player2ScoreUI.SetScore(player2Score);
            if(player2Score == 2)
            {
                StartCoroutine(GameEndProcess(2));
                return;
            }
        }

        Destroy(player1.gameObject);
        Destroy(player2.gameObject);
        StartCoroutine(RoundEndProcess(playerNum));
    }

    IEnumerator RoundEndProcess(int winPlayerNum)
    {
        
        Debug.Log("Player " + winPlayerNum + " Win!");

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(SceneFader.Instance.FadeOut(1f));
        tileMgr.ShuffleTile();
        CreatePlayer();
        roundImage.sprite = roundSprites[player1Score + player2Score];

        Debug.Log("Round" + (player1Score + player2Score) + " Fight!");

        StartCoroutine(RoundStartProcess());
    }

    IEnumerator GameEndProcess(int winPlayerNum)
    {
        roundProcessing = false;

        yield return new WaitForSeconds(1f);

        StartCoroutine(SceneFader.Instance.FadeOut(1f, "Main"));
    }

    void GameEnd(int winPlayerNum)
    {
        roundProcessing = false;
        Debug.Break();
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
}