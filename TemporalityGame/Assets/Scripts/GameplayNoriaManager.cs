using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayNoriaManager : MonoBehaviour
{
    public Button[] buttonList;
    public GameObject[] dayList;
    public Transform[] spaceToInstantiate;
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
        int numberToComplete = Random.Range(2, 5);
        Debug.Log(numberToComplete);
        GameManager.instance.SetNumberToSucces(numberToComplete);
        for (int i = 0; i < numberToComplete; i++)
        {
            Button[] listButtonProvisional = buttonList;
            int ocultarText = Random.Range(0, listButtonProvisional.Length);
            Cabina newCabina = listButtonProvisional[ocultarText].GetComponent<Cabina>();
            newCabina.textCabina.enabled = false;
            GameObject newGO = Instantiate(dayList[ocultarText], spaceToInstantiate[i].transform.position, Quaternion.identity);
            newGO.transform.SetParent(spaceToInstantiate[i].transform);
            //HACER LISTA EN VEZ DE ARRAY
        }
        //CAMBIAR ESCALA, EVITAR QUE SE REPITA NÚMERO(HACER LISTA PROVISIONAL)
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
