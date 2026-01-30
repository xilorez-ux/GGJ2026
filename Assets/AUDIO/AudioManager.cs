using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource kawaiiMusic;
    public AudioSource goreMusic;
    bool isKawaii = true;

    public float volumeChange = 0.02f;
    public float timeChange = 0.02f;
    private void Awake()
    {
        if(instance == null) {  instance = this; }
        else { Destroy(this); }
    }

    private void Start()
    {
        GameManager.Instance.OnChangingLayer += ChangeMusic;
    }
     void OnDestroy()
    {
        GameManager.Instance.OnChangingLayer -= ChangeMusic;
    }

    private void ChangeMusic()
    {
        StartCoroutine(ChangeMusicCoroutine());
    }

    private IEnumerator ChangeMusicCoroutine()
    {
        if (isKawaii)
        {
            do
            {
                kawaiiMusic.volume -= volumeChange;
                goreMusic.volume += volumeChange;
                yield return new WaitForSeconds(timeChange);
            } while (kawaiiMusic.volume > 0.02f);
            isKawaii = false;
        }
        else
        {
            do
            {
                kawaiiMusic.volume += volumeChange;
                goreMusic.volume -= volumeChange;
                yield return new WaitForSeconds(timeChange);
            } while (kawaiiMusic.volume > 0.02f);
            isKawaii = true;
        }

    }
}
