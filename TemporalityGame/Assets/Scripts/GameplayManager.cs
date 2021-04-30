using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public Text numberText;
    public SpriteRenderer posSpriteForma;
    int level;
    private void Awake()
    {
        GameManager.instance.SetCompleted(false);
        level = GameManager.instance.GetLevel();
        
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
        ManagerScene.instance.SetNumberSceneToChange(1);
        TransitionManager.instance.AnimateTransition();
    }
    public void ReturnMenu()
    {
        GameManager.instance.Resume();
        ManagerScene.instance.SetNumberSceneToChange(0);
        TransitionManager.instance.AnimateTransition();
    }
}
