using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
    public AudioClip musicaClip;
    private AudioSource musicaAudioSource;

    int aux;
    int nivelVol;

    private static SoundController instance;

 
    public TMP_Text vol;
    // Start is called before the first frame update
    
     void Awake() 
     {
        SceneManager.sceneLoaded += OnSceneLoaded;
     }
     private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
         // Silencia el sonido en cada escena cargada
    }
    // void Awake()
    // {
    //     if (instance == null)
    //     {
    //         instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }
    
    void Start()
    {
        
        PlaySound();
        nivelVol = 100;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void muted (){
        if(aux == 0){
           // musicaAudioSource.mute = true;
           //AudioListener.pause = true;
           AudioListener.volume = 0f;
           // vol.text = "0";
            aux++;
        }else{
           // AudioListener.pause = false;
           AudioListener.volume = 1f;
         //   vol.text = nivelVol.ToString();
            aux = 0;
        }
    }

    public void PlaySound()
    {
         //Sound
        musicaAudioSource = gameObject.AddComponent<AudioSource>();
        musicaAudioSource.clip = musicaClip;
        musicaAudioSource.loop = true;
        musicaAudioSource.Play();
        aux = 0;
    }

    public void StopSound()
    {
         musicaAudioSource.Stop();
    }

    public void AumentarVolumen () {
        if(AudioListener.volume < 1f) {
            nivelVol += 10;
            AudioListener.volume += 0.1f;
            vol.text = nivelVol.ToString();
    
            
        }
    }
    public void DisminuirVolumen () {
        if(AudioListener.volume > 0f) {
            nivelVol -= 10;
            AudioListener.volume -= 0.1f;
            vol.text = nivelVol.ToString();
           
        }
    }

    public void cambiarText () {
        vol.text = "VOLUMEN";
        
    }

}
