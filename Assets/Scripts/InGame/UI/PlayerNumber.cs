using UnityEngine;
using System.Collections;

public class PlayerNumber : MonoBehaviour
{
    SpriteRenderer sprRenderer;

    void Awake()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (this.transform.rotation.eulerAngles.y == 0)
        {
            sprRenderer.flipX = false;
        }
        else
            sprRenderer.flipX = true;
    }
}
