using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;

    public SpriteRenderer[] renderers;
    public Sprite[] normalSprites;
    public Sprite[] selectedSprites;

    int currIndex = 0;
    RoundManager roundMgr;

    bool isChanging = false;
    void Awake()
    {
        roundMgr = GameObject.FindObjectOfType<RoundManager>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.JoystickButton7) || Input.GetKeyDown(KeyCode.Escape)) && roundMgr.roundProcessing)
        {
            currIndex = 0;
            if (menu.activeSelf)
                HideMenu();
            else
                ShowMenu();
            return;
        }

        if (menu.activeSelf)
        {
            if (Input.GetAxis("Horizontal") < 0 && menu.activeSelf)
                currIndex = 0;
            if (Input.GetAxis("Horizontal") > 0 && menu.activeSelf)
                currIndex = 1;

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                currIndex = 0;
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                currIndex = 1;

        }

        if ((Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Return)) && menu.activeSelf)
        {
            if (currIndex == 0)
                OnYesButtonDown();
            else
                OnNoButtonDown();
        }

        renderers[currIndex == 0 ? 1 : 0].sprite = normalSprites[currIndex == 0 ? 1 : 0];
        renderers[currIndex].sprite = selectedSprites[currIndex];

    }

    void ShowMenu()
    {
        Time.timeScale = 0f;
        menu.SetActive(true);
    }

    void HideMenu()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
    }

    public void OnYesButtonDown()
    {
        if (isChanging)
            return;

        isChanging = true;

        StartCoroutine(SceneFader.Instance.FadeOut(1f, "Main"));
        StartCoroutine(SceneFader.Instance.SoundFadeOut(1f, GameObject.FindObjectsOfType<AudioSource>()));
    }

    public void OnNoButtonDown()
    {
        HideMenu();
    }
}
