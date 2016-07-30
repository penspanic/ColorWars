using UnityEngine;
using System.Collections;

public class Fight : MonoBehaviour
{

    public void OnEnd()
    {
        Destroy(gameObject);
    }
}
