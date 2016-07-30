using UnityEngine;
using System.Collections;

public class EffectManager : MonoBehaviour
{

    void Awake()
    {

    }

    public void ShowEffect(string fileName, Vector3 pos, Vector3 scale, Transform parent = null)
    {
        GameObject newEffect = Instantiate<GameObject>(Resources.Load<GameObject>(fileName));
        newEffect.transform.position = pos;
        newEffect.transform.localScale = scale;

        if (parent != null)
            newEffect.transform.SetParent(parent);
    }
}
