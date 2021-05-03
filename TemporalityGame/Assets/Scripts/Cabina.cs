using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cabina : MonoBehaviour
{
    public string nameCabina;
    public Text textCabina;

    public Cabina(string nameCabina, Text textCabina)
    {
        this.nameCabina = nameCabina;
        this.textCabina = textCabina;
    }
}
