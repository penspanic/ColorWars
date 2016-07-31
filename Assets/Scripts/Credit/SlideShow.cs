using UnityEngine;
using System.Collections;

public class SlideShow : MonoBehaviour
{

    public Sprite[] sprites;

    SpriteRenderer sprRenderer;

    void Awake()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ShowProcess());
    }

    IEnumerator ShowProcess()
    {
        int currIndex = 0;
        while(true)
        {
            float elapsedTime = 0f;
            float moveTime = 2f;

            sprRenderer.sprite = sprites[currIndex];

            Vector2 startPos = new Vector2(8f, -2f);
            Vector2 endPos = new Vector2(0f, -2f);

            while(elapsedTime <= moveTime)
            {
                elapsedTime += Time.deltaTime;
                transform.position = EasingUtil.EaseVector2(EasingUtil.easeOutBack, startPos, endPos, elapsedTime / moveTime);

                yield return null;      
            }

            yield return new WaitForSeconds(2f);

            elapsedTime = 0f;

            startPos = endPos;
            endPos = new Vector2(-8f, -2f);

            while (elapsedTime <= moveTime)
            {
                elapsedTime += Time.deltaTime;
                transform.position = EasingUtil.EaseVector2(EasingUtil.easeInBack, startPos, endPos, elapsedTime / moveTime);

                yield return null;
            }

            currIndex++;
            if (currIndex == sprites.Length)
                currIndex = 0;
        }
    }
}
