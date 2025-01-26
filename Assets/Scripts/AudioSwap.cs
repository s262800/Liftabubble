using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwap : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] music;

    [SerializeField]
    private AudioSource audioSource;

    int i = 0;

    bool shouldLerp;

    float target = 1;



    private void Start()
    {
        i = Random.Range(0, music.Length);
        StartCoroutine(PlayNext());
        shouldLerp = true;
        target = 0.1f;
    }

    private void Update()
    {
        if(shouldLerp)
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, target, 1 * Time.deltaTime);

            if (audioSource.volume == target)
            {
                shouldLerp = false;
            }

        }
    }

    public void FadeOut()
    {
        shouldLerp = true;
        target = 0;
    }

    IEnumerator PlayNext()
    {
        audioSource.clip = music[i];
        i++;
        audioSource.Play();
        yield return new WaitForSeconds(music[i - 1].length);
        if (i >= music.Length) i = 0;
        StartCoroutine(PlayNext());
    }


}
