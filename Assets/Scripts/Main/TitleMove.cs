using UnityEngine;
using System.Collections;

public class TitleMove : MonoBehaviour
{
    Vector3 startPos;
    void Awake()
    {
        startPos = transform.position;
        StartCoroutine(MoveProcess());
    }

    IEnumerator MoveProcess()
    {
        float elapsedTime = 0f;
        while (true)
        {
            elapsedTime += Time.deltaTime;

            transform.position = new Vector3(startPos.x,
                Mathf.Sin(elapsedTime  * 3)/5 + startPos.y, 0);
            yield return null;
        }
    }
}
