using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cabina : MonoBehaviour
{
    public string nameCabina;
    public Text textCabina;
    public AudioClip audioCabina;

    public Cabina(string nameCabina, Text textCabina, AudioClip audioCabina)
    {
        this.nameCabina = nameCabina;
        this.textCabina = textCabina;
        this.audioCabina = audioCabina;
    }
}
