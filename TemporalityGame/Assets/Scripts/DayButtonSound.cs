using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayButtonSound : MonoBehaviour
{
public void PlayDaySound(AudioClip audioclip)
    {
        SoundManager.instance.PlaySFX(audioclip);
    }
}
