using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    
    [SerializeField] int pointsForCoinPickup = 100;
    AudioPlay audioClip;
    bool wasCollected = false;
    private void Awake()
    {
        audioClip = FindObjectOfType<AudioPlay>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player" && !wasCollected )
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddtoScore(pointsForCoinPickup);
           
            audioClip.PlayCoin();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
