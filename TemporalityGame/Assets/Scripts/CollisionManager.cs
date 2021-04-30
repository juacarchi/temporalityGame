using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public static CollisionManager instance;
    string tagCorrect;
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
    public void SetTagCorrect(string tagCorrect)
    {
        this.tagCorrect = tagCorrect;
    }
    public string GetTagCorrect()
    {
        return tagCorrect;
    }

    
}
