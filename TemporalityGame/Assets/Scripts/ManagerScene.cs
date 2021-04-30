using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerScene : MonoBehaviour
{
    public static ManagerScene instance;
    int sceneNumber;
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
    public void SetNumberSceneToChange(int sceneNumber)
    {
        this.sceneNumber = sceneNumber;
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
