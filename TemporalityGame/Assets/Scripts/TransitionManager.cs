using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager instance;
    Animator animTransition;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            animTransition = GetComponent<Animator>();
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
    public void AnimateTransition()
    {
        animTransition.SetTrigger("Change");
    }
    public void ChangeScene()
    {
        ManagerScene.instance.ChangeScene();
    }
}
