using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpBar : MonoBehaviour
{

    Image hpBarImage;

    float visibleValue = 1;
    float realValue = 1;
    bool isChanging = false;

    void Awake()
    {
        hpBarImage = GetComponent<Image>();
    }

    //public void UpdateValue(float value)
    //{
    //    realValue = value;
    //}


    //void Update()
    //{
    //    hpBarImage.fillAmount = realValue;
    //}

    public void UpdateValue(float value)
    {
        realValue = value;
        changing = true;
    }


    bool changing = false;
    float elapsedTime = 0f;
    void Update()
    {
        if (changing)
            elapsedTime += Time.deltaTime;
        visibleValue = EasingUtil.linear(visibleValue, realValue, elapsedTime);

        hpBarImage.fillAmount = visibleValue;

        if (elapsedTime >= 1f)
        {
            elapsedTime = 0f;
            changing = false;
        }
    }

    public void ShowHurt()
    {
        StartCoroutine(RedColorProcess());
    }

    IEnumerator RedColorProcess()
    {
        for (int i = 0; i < 3; ++i)
        {
            hpBarImage.color = Color.red;

            yield return new WaitForSeconds(0.1f);

            hpBarImage.color = Color.white;

            yield return new WaitForSeconds(0.1f);
        }
    }
}
