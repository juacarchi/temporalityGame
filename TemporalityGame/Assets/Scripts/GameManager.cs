using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int level; //level = 0 ==> Basico, level = 1 ==> Intermedio, level = 2 ==> Dificil; 
    public static GameManager instance;
    int numberToSucces;
    bool completed;
    bool levelComplete;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        //if(REQUISITOS PARA GANAR && !completed)
        //{
        //    completed = true;
        //    UIManager.instance.Victory();
        //    SoundNumberManager.instance.PlaySFX(SoundNumberManager.instance.victorySound);
        //}
    }
    public void SetCompleted(bool completed)
    {
        this.completed = completed;
    }
    public void SetLevel(int level)
    {
        this.level = level;
    }
    public int GetLevel()
    {
        return level;
    }
    public bool GetLevelComplete()
    {
        return levelComplete;
    }
    public void SetLevelComplete(bool levelComplete)
    {
        this.levelComplete = levelComplete;
    }
    public void SetNumberToSucces(int numberToSucces)
    {
        this.numberToSucces = numberToSucces;
    }
    public void Pause()
    {
        Time.timeScale = 0;
        UIManager.instance.OpenPause();
        //ABRIR PANEL UI
    }
    public void Resume()
    {
        Time.timeScale = 1;
        UIManager.instance.ClosePause();
        //CERRAR PANEL UI
    }
    
      
   
}
