using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundNumberManager : MonoBehaviour
{
    public AudioClip victorySound;
    public AudioClip[] soundsNumbers;
    AudioSource audioSource;
    public static SoundNumberManager instance;
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
        audioSource.Play();
    }
}
