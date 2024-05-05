using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    
    [SerializeField] int pointsForCoinPickup = 100;
    
    bool wasCollected = false;
    private void Awake()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player" && !wasCollected )
        {
            wasCollected = true;
            //FindObjectOfType<GameSession>().AddtoScore(pointsForCoinPickup);
            GameSession.instance.AddtoScore(pointsForCoinPickup);
            //audioClip.PlayCoin();
            AudioPlay.instance.PlayCoin();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
