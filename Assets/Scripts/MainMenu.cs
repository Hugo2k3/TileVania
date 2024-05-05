using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    
    public static event Action OnLoadMainMenu;
 
    private void Update()
    {
      
    }
    public void StartFirstLevel()
    {
            SceneManager.LoadScene(1);  
    }
    public void LoadMainMenu()
    {
        GameSession.instance.ResetMenu();
        //FindObjectOfType<GameSession>().ResetMenu();
        OnLoadMainMenu?.Invoke();
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        StartCoroutine(QuitWithDelay());
    }
    IEnumerator QuitWithDelay()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();
        
    }
}
