
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int maxPlayerLives = 5;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Image healthImage;

    [SerializeField] float delay = 0.5f;
    public static GameSession instance;
    void Awake()
    {
        //int numGameSessions = FindObjectsOfType<GameSession>().Length;
        //if (numGameSessions > 1)
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

    void Start()
    {
        Update_Live();
        Update_Score();
    }
    void Update_Score()
    {
        scoreText.text = score.ToString();

    }
    void Update_Live()
    {
        livesText.text = playerLives.ToString();

    }

    private void Update()
    {
        if (playerLives > 1)
        {
            healthImage.color = new Color(0.5169663f, 0.8490566f, 0.492613f);
            livesText.color = new Color(0.1977264f, 0.7830189f, 0.1514329f);
        }

    }

    public void ProcessPlayerDeath()
    {

        StartCoroutine(PlayDie());
    }
    public void AddtoScore(int pointsToAdd)
    {
        score += pointsToAdd;
        Update_Score();
    }

    IEnumerator PlayDie()
    {

        yield return new WaitForSeconds(delay);
        if (playerLives > 1)
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
        Update_Live();
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
        ScenePersist.instance.ResetScenePersist();
        //FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    public void ResetMenu()
    {
        ScenePersist.instance.ResetScenePersist();
        //FindObjectOfType<ScenePersist>().ResetScenePersist();
        Destroy(gameObject);
    }
    [Space, Header("Shop")]
    public GameObject Shop;
    public Text Text_Nofication;


    int price_playerLives = 500;

    public void Buy()
    {
        if (playerLives < maxPlayerLives)
        {
            if (score >= price_playerLives)
            {
                score -= price_playerLives;
                Update_Score();
                Text_Nofication.text = string.Format($"Successfully Purchase");
                playerLives += 1;
                Update_Live();
                AudioPlay.instance.PlayShop_effect_success();
            }
            else
            {
                Text_Nofication.text = string.Format($"The Amount Is Not Enough To Buy");
                AudioPlay.instance.PlayShop_effect_nofi1();
            }
        }
        else
        {
            Text_Nofication.text = string.Format($"Maximum Number Of Lives is :{maxPlayerLives}");
            AudioPlay.instance.PlayShop_effect_nofi2();
        }
    }
    public void Skip()
    {
        Shop.SetActive(false);
        Time.timeScale = 1;
        Door.instance.PlayEffect();

    }
    public void ShowShop()
    {
        Update_Live();
        Update_Score();
        Time.timeScale = 0;
        Shop.SetActive(true);
        Text_Nofication.text = null;
    }


}
