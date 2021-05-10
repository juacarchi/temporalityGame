using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayTrainManager : MonoBehaviour
{
    public static GameplayTrainManager instance;
    public GameObject canvasVictory;
    public Animator animTrain;
    public List<Text> textList;
    public List<Button> buttonList;
    public List<Transform> posButtons;
    public List<GameObject> vagonList;
    int aciertosToWin = 2;
    bool checkWin;
    public AudioClip audioVagon1;
    AudioClip audioVagon2;
    public AudioClip audioVagon3;

    public List<Meses> mesesList;
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
        canvasVictory.SetActive(false);
    }
    private void Start()
    {
        RandomMonth();
        checkWin = true;
        animTrain.SetTrigger("Start");
    }
    private void Update()
    {
        if (checkWin)
        {
            if (GameManager.instance.GetAciertos() == aciertosToWin)
            {
                Debug.Log("Victoria");
                animTrain.SetTrigger("Win");
                checkWin = false;
                SoundManager.instance.PlaySFX(SoundManager.instance.trainSound);
            }
        }
    }

    public void RandomMonth()
    {
        int numberMonth = Random.Range(1, mesesList.Count - 1);
        Meses mesPreview = mesesList[numberMonth - 1];
        Meses mesChosen = mesesList[numberMonth];
        Meses mesForward = mesesList[numberMonth + 1];

        textList[0].text = mesPreview.monthName;
        textList[0].enabled = false;
        textList[1].text = mesChosen.monthName;
        textList[2].text = mesForward.monthName;
        textList[2].enabled = false;

        vagonList[0].tag = mesPreview.tagName;
        vagonList[1].tag = mesForward.tagName;

        Text textButton1 = buttonList[0].GetComponentInChildren<Text>();
        Text textButton2 = buttonList[1].GetComponentInChildren<Text>();

        textButton1.text = mesPreview.monthName;
        textButton2.text = mesForward.monthName;

        Button button1 = buttonList[0].GetComponent<Button>();
        Button button2 = buttonList[1].GetComponent<Button>();

        button1.tag = mesPreview.tagName;
        button2.tag = mesForward.tagName;

        audioVagon1 = mesPreview.audioMonth;
        audioVagon2 = mesChosen.audioMonth;
        audioVagon3 = mesForward.audioMonth;

        //List<Transform> posButtonsProvisional = new List<Transform>(posButtons);
        for (int i = 0; i < buttonList.Count; i++)
        {
            int numberPos = Random.Range(0, posButtons.Count);
            buttonList[i].transform.position = posButtons[numberPos].transform.position;
            posButtons.RemoveAt(numberPos);
        }
    }
    public void SetTextVagon1Active()
    {
        textList[0].enabled = true;
    }
    public void SetTextVagon2Active()
    {
        textList[2].enabled = true;
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
        GameManager.instance.SetAciertos(0);
        GameManager.instance.Resume();
        ManagerScene.instance.SetNumberSceneToChange(2);
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
    public void PlayVagon2Sound()
    {
        SoundManager.instance.PlaySFX(audioVagon2);
    }
    public void PlayVagon1Sound()
    {
        SoundManager.instance.PlaySFX(audioVagon1);
    }
    public void PlayVagon3Sound()
    {
        SoundManager.instance.PlaySFX(audioVagon3);
    }

}
