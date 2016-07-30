using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{
    Image score1Image;
    Image score2Image;


    static Sprite noScoreSprite;
    static Sprite scoredSprite;

    void Awake()
    {

        if(noScoreSprite == null)
        {
            noScoreSprite = Resources.Load<Sprite>("UI/No Score");
            scoredSprite = Resources.Load<Sprite>("UI/Scored");
        }

        score1Image = transform.FindChild("Score1").GetComponent<Image>();
        score2Image = transform.FindChild("Score2").GetComponent<Image>();
    }

    public void SetScore(int score)
    {
        score1Image.sprite = noScoreSprite;
        score2Image.sprite = noScoreSprite;

        if (score >= 1)
            score1Image.sprite = scoredSprite;
        if (score == 2)
            score2Image.sprite = scoredSprite;

        score1Image.SetNativeSize();
        score2Image.SetNativeSize();
    }
}
