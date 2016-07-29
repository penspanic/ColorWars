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

    public void UpdateValue(float value)
    {

        if (isChanging)
        {
            realValue = value;
            StopAllCoroutines();
            StartCoroutine(ValueChange(visibleValue, realValue));
        }
        else
        {
            StartCoroutine(ValueChange(realValue, value));
            realValue = value;
        }
    }


    IEnumerator ValueChange(float startValue, float endValue)
    {
        isChanging = true;
        float elaspedTime = 0f;
        float changeTime = 1f;

        while(elaspedTime < changeTime)
        {
            elaspedTime += Time.deltaTime;
            // 0.6 -> 0.3
            visibleValue = 1f - EasingUtil.easeInQuad(1f - startValue, 1f - endValue, elaspedTime / changeTime);

            yield return null;
        }

        isChanging = false;
    }

    void Update()
    {
        hpBarImage.fillAmount = visibleValue;
    }
}
