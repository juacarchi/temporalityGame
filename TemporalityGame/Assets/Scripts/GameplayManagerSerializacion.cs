using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManagerSerializacion : MonoBehaviour
{
    public List<Serie> listaSeries;
    public GameObject canvasVictory;
    public Image imageAntes;
    public Image imageAhora;
    public Image imageDespues;
    

    public GameObject go1;
    public GameObject go2;
    public GameObject go3;
    public List<RectTransform> posiciones;

    public List<Image> imagesCompletes;


    int aciertosToComplete = 2; //ANTES, AHORA Y DESPUÉS
    private void Awake()
    {
        canvasVictory.SetActive(false);
    }
    private void Start()
    {
        RandomSerie();
    }
    public void RandomSerie()
    {

        int randomCorrect = Random.Range(0, imagesCompletes.Count);
        int randomNumber = Random.Range(0, listaSeries.Count);
        Serie newSerie = listaSeries[randomNumber];
        Debug.Log(newSerie.name);
        imagesCompletes[randomCorrect].sprite = newSerie.GetSprite(randomCorrect);
        imagesCompletes[randomCorrect].color = Color.white;

        if (randomCorrect == 0)
        {
            imageAntes.enabled = false;
            go1.GetComponent<CircleCollider2D>().enabled = false;
            imageAhora.sprite = newSerie.GetSprite(1);
            imageDespues.sprite = newSerie.GetSprite(2);
            RectTransform rect2 = go2.GetComponent<RectTransform>();
            RectTransform rect3 = go3.GetComponent<RectTransform>();
            int numberPos = Random.Range(0, posiciones.Count);
            if (numberPos == 0)
            {
                rect2.anchoredPosition = posiciones[0].anchoredPosition;
                rect3.anchoredPosition = posiciones[1].anchoredPosition;
            }
            else
            {
                rect2.anchoredPosition = posiciones[1].anchoredPosition;
                rect3.anchoredPosition = posiciones[0].anchoredPosition;
            }


        }
        else if (randomCorrect == 1)
        {
            imageAntes.sprite = newSerie.GetSprite(0);
            imageAhora.enabled = false;
            go2.GetComponent<CircleCollider2D>().enabled = false;
            imageDespues.sprite = newSerie.GetSprite(2);

            RectTransform rect1 = go1.GetComponent<RectTransform>();
            RectTransform rect3 = go3.GetComponent<RectTransform>();
            int numberPos = Random.Range(0, posiciones.Count);
            if (numberPos == 0)
            {
                rect1.anchoredPosition = posiciones[0].anchoredPosition;
                rect3.anchoredPosition = posiciones[1].anchoredPosition;
            }
            else
            {
                rect1.anchoredPosition = posiciones[1].anchoredPosition;
                rect3.anchoredPosition = posiciones[0].anchoredPosition;
            }
        }
        else if (randomCorrect == 2)
        {

            imageAntes.sprite = newSerie.GetSprite(0);
            imageAhora.sprite = newSerie.GetSprite(1);
            imageDespues.enabled = false;
            go3.GetComponent<CircleCollider2D>().enabled = false;
            RectTransform rect1 = go1.GetComponent<RectTransform>();
            RectTransform rect2 = go2.GetComponent<RectTransform>();
            int numberPos = Random.Range(0, posiciones.Count);
            if (numberPos == 0)
            {
                rect1.anchoredPosition = posiciones[0].anchoredPosition;
                rect2.anchoredPosition = posiciones[1].anchoredPosition;
            }
            else
            {
                rect1.anchoredPosition = posiciones[1].anchoredPosition;
                rect2.anchoredPosition = posiciones[0].anchoredPosition;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.GetAciertos() == aciertosToComplete)
        {
            Debug.Log("VICTORIA");
            GameManager.instance.SetAciertos(0);
            Victory();
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
        GameManager.instance.SetAciertos(0);
        ManagerScene.instance.SetNumberSceneToChange(3);
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
}
