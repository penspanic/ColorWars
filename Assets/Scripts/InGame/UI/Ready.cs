using UnityEngine;
using System.Collections;

public class Ready : MonoBehaviour
{

    public void OnEnd()
    {
        Destroy(gameObject);
    }
}
