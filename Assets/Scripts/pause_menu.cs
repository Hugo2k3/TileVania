using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_menu : MonoBehaviour
{
    public static event Action onloadMenu;

    [SerializeField] GameObject pauseMenu;
    public bool IsPaused = false;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Home()
    {
        GameSession.instance.ResetMenu();
        //FindObjectOfType<GameSession>().ResetMenu();
        SceneManager.LoadScene(0);
        onloadMenu?.Invoke();
        Time.timeScale = 1f;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused=false;
    }
    public void Quit()
    {
        Application.Quit();
    }
    

}
