using UnityEngine;
using System.Collections;

public class RoundEndSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSource2;

    void Awake()
    {
        StartCoroutine(SoundProcess());
    }

    IEnumerator SoundProcess()
    {
        yield return new WaitForSeconds(0.3f);

        audioSource.Play();

        yield return new WaitForSeconds(0.3f);


        audioSource2.Play();
    }
}
