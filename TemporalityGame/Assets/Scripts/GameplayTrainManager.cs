using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayTrainManager : MonoBehaviour
{
    public static GameplayTrainManager instance;
    public Animator animTrain;
    public List<Text> textList;
    public List<Button> buttonList;
    public List<Transform> posButtons;
    public List<GameObject> vagonList;
    int aciertosToWin = 2;
    bool checkWin;


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
        
    }
    private void Start()
    {
        RandomMonth();
        checkWin = true;
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


}
