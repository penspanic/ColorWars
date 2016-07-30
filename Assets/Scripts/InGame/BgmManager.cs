using UnityEngine;
using System.Collections;

public class BgmManager : MonoBehaviour
{
    public AudioSource bgmSource;

    public void Pause()
    {
        bgmSource.Pause();
    }

    public void UnPause()
    {
        bgmSource.UnPause();
    }
}