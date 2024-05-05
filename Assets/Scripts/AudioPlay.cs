using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [Header("Background")]
    [SerializeField] AudioClip AudioBackground;
    [Header("Shooting")]
    [SerializeField] AudioClip AudioClipShooting;
    [SerializeField] [Range(0f,1f)] float shootingVolume = 1.0f;

    [Header("Jumping")]
    [SerializeField] AudioClip AudioClipJumping;
    [SerializeField] [Range (0f,1f)] float JumpingVolume = 1.0f;

    [Header("CoinPickup")]
    [SerializeField] AudioClip AudioClipCoin;
    [SerializeField] [Range(0f,1f)] float CoinVolume = 1f;

    [Header("Exit")]
    [SerializeField] AudioClip AudioClipExit;
    [SerializeField] [Range(0f,1f)] float ExitVolume = 1.0f;

    [Header("Die")]
    [SerializeField] AudioClip AudioDie;
    [SerializeField] [Range(0f,1f)] float DieVolume = 1.0f;

    [Header("Bouncing")]
    [SerializeField] AudioClip AudioBouncing;
    [SerializeField] [Range(0f,1f)] float BouncingVolume = 1.0f;

    [Header("Shop_effect")]
    [SerializeField] AudioClip AudioShop_effect;
    [SerializeField][Range(0f, 1f)] float ShopEffectVolume = 1.0f;

    [Header("Shop_effect_nofi1")]
    [SerializeField] AudioClip AudioShop_effect_nofi1;
    [SerializeField][Range(0f, 1f)] float ShopEffectNofi1Volume = 1.0f;

    [Header("Shop_effect_nofi2")]
    [SerializeField] AudioClip AudioShop_effect_nofi2;
    [SerializeField][Range(0f, 1f)] float ShopEffectNofi2Volume = 1.0f;

    [Header("Shop_effect_success")]
    [SerializeField] AudioClip AudioShop_effect_success;
    [SerializeField][Range(0f, 1f)] float ShopEffectsuccessVolume = 1.0f;

    [Header("Win")]
    [SerializeField] AudioClip AudioWin;   
    public static AudioPlay instance;
    private void Awake()
    {
        ManageSingleton();
       
    }
    private void Start()
    {
        LevelExit.Win += PlayWin;
        MainMenu.OnLoadMainMenu += PlayBackground;
        pause_menu.onloadMenu += PlayBackground;
    }

     void OnDestroy()
    {
        LevelExit.Win -= PlayWin;
        MainMenu.OnLoadMainMenu -= PlayBackground;
        pause_menu.onloadMenu -= PlayBackground;
    }
    void ManageSingleton()
    {
        if (instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
 
    public void PlayShootingClip()
    {
       PlayClip(AudioClipShooting, shootingVolume);
    }
    public void PlayJumping()
    {
        PlayClip(AudioClipJumping, JumpingVolume);
    }
    public void PlayShop_effect()
    {
        PlayClip(AudioShop_effect, ShopEffectVolume);
    }

    public void  PlayCoin()
    {
        PlayClip(AudioClipCoin, CoinVolume);
    }
    public void PlayShop_effect_nofi1()
    {
        PlayClip(AudioShop_effect_nofi1, ShopEffectNofi1Volume);
    }
    public void PlayShop_effect_nofi2()
    {
        PlayClip(AudioShop_effect_nofi2, ShopEffectNofi2Volume);
    }
    public void PlayShop_effect_success()
    {
        PlayClip(AudioShop_effect_success, ShopEffectsuccessVolume);
    }
    public void PlayExit()
    {
        PlayClip(AudioClipExit, ExitVolume);
    }
    public void PlayWin()
    {
            audioSource.clip = AudioWin;
            audioSource.Play();
    }
    public void PlayBackground()
    {
        audioSource.clip = AudioBackground;
        audioSource.Play();
    }
 
    public void PlayDie()
    {
        PlayClip(AudioDie, DieVolume);
    }
    public void PlayBouncing()
    {
        PlayClip(AudioBouncing,BouncingVolume);
    }
    void PlayClip(AudioClip clip,float volume)
    {
        Vector3 cameraPos=Camera.main.transform.position;
        if(clip!=null)
        {
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }



}
