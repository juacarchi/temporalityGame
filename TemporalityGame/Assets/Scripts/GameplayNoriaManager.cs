using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayNoriaManager : MonoBehaviour
{
    public Button[] buttonList;

    void Start()
    {
        RandomCabinas();  
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void RandomCabinas()
    {
        int numberOfPistas = Random.Range(2, 5);
        Debug.Log(numberOfPistas);
        for (int i = 0; i < numberOfPistas; i++)
        {
            int showText = Random.Range(0, buttonList.Length);
            Cabina newCabina = buttonList[showText].GetComponent<Cabina>();
            newCabina.textCabina.enabled = true;
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
