using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCorrectManager : MonoBehaviour
{
    public static AudioCorrectManager instance;
    AudioSource audioSource;
    float timer;
    bool hasSound;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void PlaySFX(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        timer = 0.5f;
        hasSound = false;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && !hasSound)
        {
            audioSource.Play();
            hasSound = true;
        }
    }
}
