using UnityEngine;
using System.Collections;

public class DelayDestroy : MonoBehaviour
{
    public float time;
    void Awake()
    {
        Invoke("DestroyObject", time);
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
