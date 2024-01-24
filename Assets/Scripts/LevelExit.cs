using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    AudioPlay audioPlay;
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] float levelExitSlowMo = 0.5f;
    public static event Action Win;
    private void Awake()
    {
        audioPlay = FindObjectOfType<AudioPlay>();
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // tai cap do tiep theo theo 1 thoi gian nhat dinh
        if (collision.tag=="Player")
        {
            StartCoroutine(LoadNextLevel());
            audioPlay.PlayExit();

        }
       


    }
    IEnumerator LoadNextLevel()
    {
        Time.timeScale = levelExitSlowMo;
        yield return new WaitForSecondsRealtime(levelLoadDelay);//su dung de tao thoi gian cho
        Time.timeScale = 1f;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;// lay chi so index hien tai
        int nextSceneIndex = currentSceneIndex + 1;

        // if man scene dat max thi quay ve man dau
        // SceneManager.sceneCountInBuildSettings lay ra so man scene hien co o build setting
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings-1)
        {
            Win?.Invoke();
        }
        FindObjectOfType<ScenePersist>().ResetScenePersist();

        SceneManager.LoadScene(nextSceneIndex);
    }
   



}
