using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button pauseButton;
    public Text textPuntuacion;
    public Canvas canvasPause;
    public Canvas canvasVictory;
    Animator animVictory;
    public static UIManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(this.gameObject);
        }
        canvasPause.enabled = false;
        canvasVictory.enabled = false;
        animVictory=canvasVictory.GetComponent<Animator>();
    }
    public void OpenPause()
    {
        canvasPause.enabled = true;
    }
    public void ClosePause()
    {
        canvasPause.enabled = false;
        canvasVictory.enabled = false;
    }
    public void Victory()
    {
        canvasVictory.enabled = true;
        animVictory.SetTrigger("StartAnim");
        pauseButton.interactable = false;
        GameManager.instance.SetLevelComplete(true);
    }
    

}
