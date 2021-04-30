using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
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
    public void PlayButton()
    {
        SoundManager.instance.PlaySFX(SoundManager.instance.buttonSound);
    }
}
