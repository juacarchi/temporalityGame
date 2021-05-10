using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManagerSerializacion : MonoBehaviour
{
    public GameObject canvasVictory;
    int aciertosToComplete = 3; //ANTES, AHORA Y DESPUÉS
    private void Awake()
    {
        canvasVictory.SetActive(false);
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
        GameManager.instance.SetAciertos(0);
        ManagerScene.instance.SetNumberSceneToChange(3);
        TransitionManager.instance.AnimateTransition();
        canvasVictory.SetActive(false);
    }
    public void ReturnMenu()
    {
        
        GameManager.instance.Resume();
        GameManager.instance.SetAciertos(0);
        ManagerScene.instance.SetNumberSceneToChange(0);
        TransitionManager.instance.AnimateTransition();
        canvasVictory.SetActive(false);
    }
    public void Victory()
    {
        canvasVictory.SetActive(true);
        SoundManager.instance.PlaySFX(SoundManager.instance.childVictory);
    }
}
