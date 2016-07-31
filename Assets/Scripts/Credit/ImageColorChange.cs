using UnityEngine;
using System.Collections;

public class ImageColorChange : MonoBehaviour
{

    SpriteRenderer sprRenderer;
    void Awake()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeProcess());
    }

    IEnumerator ChangeProcess()
    {
        while(true)
        {

            float changeTime = Random.Range(1f, 2f);
            float elapsedTime = 0f;

            Color startColor = sprRenderer.color;
            Color newColor = Random.ColorHSV();
            newColor *= 1.5f;

            while(elapsedTime <= changeTime)
            {
                elapsedTime += Time.deltaTime;

                sprRenderer.color = Color.Lerp(startColor, newColor, elapsedTime / changeTime);

                yield return null;
            }
        }
    }
}
