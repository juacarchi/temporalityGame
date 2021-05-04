using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayNoriaManager : MonoBehaviour
{
    public Animator noriaAnimator;
    public List<Button> buttonList;
    public GameObject[] dayList;
    public Transform[] spaceToInstantiate;
    int aciertosToWin;
    bool checkWin;
    void Start()
    {
        RandomCabinas();
        
    }
    void Update()
    {
        if (checkWin)
        {
            if (GameManager.instance.GetAciertos() == aciertosToWin)
            {
                Debug.Log("Victoria");
                checkWin = false;
                noriaAnimator.SetTrigger("Win");
            }
        }
        

    }

    public void RandomCabinas()
    {
        int numberToComplete = Random.Range(2, 5);
        Debug.Log(numberToComplete);
        aciertosToWin = numberToComplete;
        GameManager.instance.SetNumberToSucces(numberToComplete);
        List<Button> listButtonProvisional = new List<Button>(buttonList);
        List<GameObject> dayListProvisional = new List<GameObject>(dayList);
        for (int i = 0; i < numberToComplete; i++)
        {
            Debug.Log("Antes" + listButtonProvisional.Count);
            int ocultarText = Random.Range(0, listButtonProvisional.Count);
            Cabina newCabina = listButtonProvisional[ocultarText].GetComponent<Cabina>();
            newCabina.textCabina.enabled = false;
            GameObject newGO = Instantiate(dayListProvisional[ocultarText], spaceToInstantiate[i].transform.position, Quaternion.identity);
            newGO.transform.SetParent(spaceToInstantiate[i].transform);
            newGO.transform.localScale = new Vector3(1, 1, 1);
            listButtonProvisional.RemoveAt(ocultarText);
            dayListProvisional.RemoveAt(ocultarText);
            Debug.Log("Despues" + listButtonProvisional.Count);

            //HACER LISTA EN VEZ DE ARRAY
        }
        //CAMBIAR ESCALA, EVITAR QUE SE REPITA NÚMERO(HACER LISTA PROVISIONAL)
        checkWin = true;
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
