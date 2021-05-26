using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serie : MonoBehaviour
{
    public Sprite spriteAntes;
    public Sprite spriteAhora;
    public Sprite spriteDespues;

    public Serie(Sprite spriteAntes, Sprite spriteAhora, Sprite spriteDespues)
    {
        this.spriteAntes = spriteAntes;
        this.spriteAhora = spriteAhora;
        this.spriteDespues = spriteDespues;
    }
    public Sprite GetSprite(int i)
    {
        if (i == 0)
        {
            return spriteAntes;
        }
        else if (i == 1)
        {
            return spriteAhora;
        }
        else if (i == 2)
        {
            return spriteDespues;
        }
        else return null;
    }
   
}
