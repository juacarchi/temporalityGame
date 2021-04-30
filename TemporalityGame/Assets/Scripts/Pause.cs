using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    
public void PauseGame()
    {
        GameManager.instance.Pause();
    }
    public void ReanudarGame()
    {
        GameManager.instance.Resume();
    }
    public void ResetGame()
    {
        ManagerScene.instance.SetNumberSceneToChange(1);
        TransitionManager.instance.AnimateTransition();
    }
    public void MenuReturn()
    {
        ManagerScene.instance.SetNumberSceneToChange(0);
        TransitionManager.instance.AnimateTransition();
        Debug.Log("Return");

    }
}
