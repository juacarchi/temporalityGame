using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayTrainManager : MonoBehaviour
{
    public List<Text> textList;
    public List<Button> buttonList;
    public List<Transform> posButtons;

    public List<Meses> mesesList;
    private void Start()
    {
        RandomMonth();
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

        Text textButton1 = buttonList[0].GetComponentInChildren<Text>();
        Text textButton2 = buttonList[1].GetComponentInChildren<Text>();

        textButton1.text = mesPreview.monthName;
        textButton2.text = mesForward.monthName;

        //List<Transform> posButtonsProvisional = new List<Transform>(posButtons);
        for (int i = 0; i < buttonList.Count; i++)
        {
            int numberPos = Random.Range(0, posButtons.Count);
            buttonList[i].transform.position = posButtons[numberPos].transform.position;
            posButtons.RemoveAt(numberPos);
        }
    }
}
