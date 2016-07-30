using UnityEngine;
using System.Collections;

public class BackgroundColor : MonoBehaviour
{
    SpriteRenderer sprRenderer;

    void Awake()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ColorChangeProcess());
    }

    IEnumerator ColorChangeProcess()
    {
        while(true)
        {
            float endColor = Random.Range(0.3f, 1);

            float time = Random.Range(0.5f, 1.3f);

            Color startColor = sprRenderer.color;
            float elapsedTime = 0f;
            while(elapsedTime <= time)
            {
                elapsedTime += Time.deltaTime;

                float currValue = EasingUtil.easeInQuint(startColor.r, endColor, elapsedTime / time);
                sprRenderer.color = new Color(currValue, currValue, currValue);

                yield return null;
            }
        }
    }
}
