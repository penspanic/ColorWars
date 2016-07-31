using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{

    bool isChanging = true;

    SeletableButtons selectableButtons;

    void Awake()
    {
        Time.timeScale = 1f;
        selectableButtons = GameObject.FindObjectOfType<SeletableButtons>();

        StartCoroutine(SceneFader.Instance.FadeIn(1f));
        Invoke("FadeInEnd", 1f);
    }

    void Start()
    {
        selectableButtons.AddEvent(0, OnStartButtonDown);
        selectableButtons.AddEvent(1, OnCreditButtonDown);
        selectableButtons.AddEvent(2, OnExitButtonDown);
    }

    void FadeInEnd()
    {
        isChanging = false;
    }

    public void OnStartButtonDown()
    {
        if (isChanging)
            return;
        isChanging = true;

        StartCoroutine(SceneFader.Instance.FadeOut(1f, "InGame"));
        StartCoroutine(SceneFader.Instance.SoundFadeOut(1f, GameObject.FindObjectsOfType<AudioSource>()));
    }

    public void OnCreditButtonDown()
    {
        if (isChanging)
            return;
        isChanging = true;

        StartCoroutine(SceneFader.Instance.FadeOut(1f, "Credit"));
        StartCoroutine(SceneFader.Instance.SoundFadeOut(1f, GameObject.FindObjectsOfType<AudioSource>()));
    }

    public void OnExitButtonDown()
    {
        Application.Quit();
    }
}