using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    //Declarar variable estática singleton
    public static MusicManager instance;
    public AudioSource audioSource;
    AudioSource audioSource2;
    //Aqui podemos meter una serie de AudioClip para poder llamarlos desde otros elementos.
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
    private void Start()
    {
        audioSource2 = SoundManager.instance.audioSource;
    }

    //Método para modificar volumen
    public void MuteMusic()
    {
        if (audioSource.mute == false)
        {
            audioSource.mute = true;
        }
        else
        {
            audioSource.mute = false;
        }
        //MUTEAR AUDIOSOURCE2
        if (audioSource2.mute == false)
        {
            audioSource2.mute = true;
        }
        else
        {
            audioSource2.mute = false;
        }
    }
}
