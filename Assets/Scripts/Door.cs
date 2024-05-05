using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    public static Door instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
       
    }
    
    [SerializeField] ParticleSystem Effect;
    [SerializeField] Transform tranform_effect;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameSession.instance.ShowShop();
            // FindObjectOfType<GameSession>().ShowShop()
        }
    }
    public void PlayEffect()
    {

        if (Effect != null)
        {
            ParticleSystem instance1 = Instantiate(Effect, tranform_effect.transform.position, Quaternion.identity);
            Destroy(gameObject,0.5f);
            Destroy(instance1.gameObject,1f);
            //audioClip.PlayShop_effect();
            AudioPlay.instance.PlayShop_effect();
        }
    }
  
}
