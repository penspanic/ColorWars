using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour
{
    SpriteRenderer sprRenderer;
    void Awake()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(BlinkProcess());
    }

    IEnumerator BlinkProcess()
    {
        while(true)
        {
            sprRenderer.enabled = false;

            yield return new WaitForSeconds(0.75f);

            sprRenderer.enabled = true;

            yield return new WaitForSeconds(0.75f);
        }
    }
}
