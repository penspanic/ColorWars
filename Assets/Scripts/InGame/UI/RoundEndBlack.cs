using UnityEngine;
using System.Collections;

public class RoundEndBlack : MonoBehaviour
{

    SpriteRenderer sprRenderer;

    void Awake()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
    }

    public void FadeOut(float alpha,float t)
    {
        StartCoroutine(FadeOutProcess(alpha, t));
    }

    IEnumerator FadeOutProcess(float alpha, float t)
    {
        float elapsedTime = 0f;
        while(elapsedTime <= t)
        {
            elapsedTime += Time.deltaTime;

            sprRenderer.color = new Color(0, 0, 0, EasingUtil.linear(0, alpha, elapsedTime / t));

            yield return null;
        }
    }

    public void FadeIn(float t)
    {
        StartCoroutine(FadeInProcess(t));
    }

    IEnumerator FadeInProcess(float t)
    {
        float elapsedTime = 0f;
        float startAlpha = sprRenderer.color.a;

        while (elapsedTime <= t)
        {
            elapsedTime += Time.deltaTime;

            sprRenderer.color = new Color(0, 0, 0, EasingUtil.linear(startAlpha, 0, elapsedTime / t));

            yield return null;
        }
    }

    public void SetAlpha(float alpha)
    {
        sprRenderer.color = new Color(0, 0, 0, alpha);
    }
}
