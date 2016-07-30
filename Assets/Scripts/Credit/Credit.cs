using UnityEngine;
using System.Collections;

public class Credit : MonoBehaviour
{
    bool isChanging = false;

    void Awake()
    {
        isChanging = true;
        StartCoroutine(SceneFader.Instance.FadeIn(1f));
        Invoke("FadeInEnd", 1f);
    }

    void FadeInEnd()
    {
        isChanging = false;
    }

    public void BackToMain()
    {
        if (isChanging)
            return;
        isChanging = true;

        StartCoroutine(SceneFader.Instance.FadeOut(1f, "Main"));
    }
}
