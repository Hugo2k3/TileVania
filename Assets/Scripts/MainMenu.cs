using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    private bool intheSencediffent = false;
    public static event Action OnLoadMainMenu;
 
    private void Update()
    {
        PlayerPrefs.DeleteKey("IsGun");
        PlayerMovement.instance.SetCanGun(false);

        if (intheSencediffent)
        {
            PlayerMovement.instance.SetCanGun(true);
        }

    }
    public void StartFirstLevel()
    {

            intheSencediffent = true;
            SceneManager.LoadScene(1);  
    }
   
    public void LoadMainMenu()
    {

        FindObjectOfType<GameSession>().ResetMenu();
        OnLoadMainMenu?.Invoke();
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
        
    }
}
