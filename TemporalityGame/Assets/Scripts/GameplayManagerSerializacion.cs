﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManagerSerializacion : MonoBehaviour
{
    public Canvas canvasVictory;
    int aciertosToComplete = 3; //ANTES, AHORA Y DESPUÉS
    private void Awake()
    {
        canvasVictory.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.GetAciertos() == aciertosToComplete)
        {
            Debug.Log("VICTORIA");
            GameManager.instance.SetAciertos(0);
            Victory();
        }
    }

    public void MuteMusic()
    {
        MusicManager.instance.MuteMusic();
    }
    public void PlayButton()
    {
        SoundManager.instance.PlaySFX(SoundManager.instance.buttonSound);
    }
    public void ResetGame()
    {
        GameManager.instance.Resume();
        ManagerScene.instance.SetNumberSceneToChange(3);
        TransitionManager.instance.AnimateTransition();
    }
    public void ReturnMenu()
    {
        GameManager.instance.Resume();
        ManagerScene.instance.SetNumberSceneToChange(0);
        TransitionManager.instance.AnimateTransition();
    }
    public void Victory()
    {
        canvasVictory.enabled = true;
    }
}
