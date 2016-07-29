using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{

    bool isChanging = false;

    void Awake()
    {

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
