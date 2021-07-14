using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource audioSource, bgsource;
    public AudioClip click, bg, fail, screenPress, reward;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
        //audioSource=GetComponent<AudioSource>();
    }
    public void Click()
    {
        audioSource.clip = click;
        audioSource.Play();
    }
    public void Bg()
    {
        DontDestroyOnLoad(gameObject);
        bgsource.Play();
    }
    public void Failed()
    {
        audioSource.clip = fail;
        audioSource.Play();
    }
    public void Press()
    {
        audioSource.clip = screenPress;
        audioSource.Play();
    }
    public void Reward()
    {
        audioSource.clip = reward;
        audioSource.Play();
    }
}

