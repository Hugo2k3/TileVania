using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
   public static ScenePersist instance;
    void Awake()
    {
        //int NumScenePersists = FindObjectsOfType<ScenePersist>().Length;
        //if (NumScenePersists > 1)
        //{
        //    Destroy(gameObject);
        //}
        //else
        //{
        //    DontDestroyOnLoad(gameObject);
        //}
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void  ResetScenePersist()
    {
        
        Destroy(gameObject);
       
    }
 

}
