using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{

    bool isChanging = true;

    void Awake()
    {
        StartCoroutine(SceneFader.Instance.FadeIn(1f));
        Invoke("FadeInEnd", 1f);
    }

    void FadeInEnd()
    {
        isChanging = false;
    }

    public void OnStartButtonDown()
    {
        if (isChanging)
            return;
        Debug.Log("Button Down");
        isChanging = true;

        StartCoroutine(SceneFader.Instance.FadeOut(1f, "InGame"));
    }
}