using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meses : MonoBehaviour
{
    public string monthName;
    public string tagName;
    public AudioClip audioMonth;

    public Meses(string monthName, string tagName, AudioClip audioMonth)
    {
        this.monthName = monthName;
        this.tagName = tagName;
        this.audioMonth = audioMonth;
    }
}
