
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Image healthImage;
    private Vector3 respawnPosition;
    [SerializeField] float delay =0.5f;
    PlayerMovement playerMovement;
    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

     void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text =score.ToString();
    }

    public void ProcessPlayerDeath()
    {
       
        StartCoroutine(PlayDie());
    }
    public void  AddtoScore(int pointsToAdd )
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }
  
   IEnumerator PlayDie()
    {

        yield return new WaitForSeconds(delay);
        if (playerLives>1)
        {
            TakeLife();
        }
        else 
        {
            resetgamesession();
        }
    }
    void TakeLife()
    {
        playerLives--;
        livesText.text = playerLives.ToString();
        if (playerLives == 1)
        {
            healthImage.color = Color.red;
            livesText.color = Color.red;
        }
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void resetgamesession()
    {

        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    public void ResetMenu()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        Destroy(gameObject);

    }

        
}
