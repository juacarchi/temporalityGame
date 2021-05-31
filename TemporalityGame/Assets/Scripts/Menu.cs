using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    string url = "https://iquick.es";
    public void Play(int sceneIndex)
    {
        ManagerScene.instance.SetNumberSceneToChange(sceneIndex);
        TransitionManager.instance.AnimateTransition();
    }
    public void Levels(int sceneIndex)
    {
        ManagerScene.instance.SetNumberSceneToChange(sceneIndex);
        TransitionManager.instance.AnimateTransition();
    }
    public void PlayButton(Button buttonPressed)
    {
        SoundManager.instance.PlaySFX(SoundManager.instance.buttonSound);
        buttonPressed.interactable = false;
    }
    public void Exit()
    {
        //WebGL
        //Application.OpenURL(url);

        //ANDROID
        Application.Quit();
    }
}
