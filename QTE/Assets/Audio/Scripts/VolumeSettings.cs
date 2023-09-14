using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioManager manager;

    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider bgmSlider;


    public const string MIXER_BGM = "volBGM";
    public const string MIXER_SFX = "volSFX";

    private void Awake()
    {
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        

        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        
    }

    void Start()
    {
        bgmSlider.value = PlayerPrefs.GetFloat(AudioManager.BGM_KEY, 1f);
       
        sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY, 1f);
    
      
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.BGM_KEY, bgmSlider.value);
       
        PlayerPrefs.SetFloat(AudioManager.SFX_KEY, sfxSlider.value);
    }

    void SetBGMVolume(float value)
    {
        mixer.SetFloat(MIXER_BGM, Mathf.Log10(value) * 20);
   
            
    }


    void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
      
    }

    public void VolButtonPLUS(bool sfx)
    {
        float changeValue = 0.05f;

        if(!sfx)
        {
        
            manager.video.SetDirectAudioVolume(0, bgmSlider.value + changeValue);

            
        }

        if(sfx)
        {


            mixer.SetFloat(MIXER_SFX, Mathf.Log10(sfxSlider.value) + changeValue);

            
        }
        
        
    }

    public void VolButtonMINUS(bool sfx)
    {
        float changeValue = 0.05f;

        if (!sfx)
        {

            manager.video.SetDirectAudioVolume(0, bgmSlider.value - changeValue);


        }

        if (sfx)
        {


            mixer.SetFloat(MIXER_SFX, Mathf.Log10(sfxSlider.value) - changeValue);


        }
    }





}
