using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField]
    private AudioSource a_source;

    [SerializeField]
    private AudioClip[] a_clips;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlaySounds()
    {
        a_source.clip = a_clips[Random.Range(0, a_clips.Length)];

        a_source.Play();

    }

    public void StopSound()
    {
        a_source.Stop();
    }

}
