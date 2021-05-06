using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Vagon2 : MonoBehaviour
{
    public SpriteRenderer imageVagon;
    public void SetTextActive()
    {
        GameplayTrainManager.instance.SetTextVagon2Active();
    }
    public void SetImage(Sprite spriteImage)
    {
        imageVagon.sprite = spriteImage;
    }
}
