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

        bgmSlider.value = PlayerPrefs.GetFloat(AudioManager.BGM_KEY, 1f);

        sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY, 1f);
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
        manager.video.SetDirectAudioVolume(0, value);
        mixer.SetFloat(MIXER_BGM, Mathf.Log10(value)* 20);
        bgmSlider.value = value;

        if (value <= 0)
        {
            bgmSlider.value = bgmSlider.minValue; //should always be 0.0001 or sth of the sort
        }
    }


    void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
        sfxSlider.value = value;

        if(value <= 0)
        {
            sfxSlider.value = sfxSlider.minValue; //should always be 0.0001 or sth of the sort
        }
      
    }

    public void VolButtonPLUS(bool sfx)
    {
        float changeValue = 0.05f;

        if(!sfx)
        {
        
            manager.video.SetDirectAudioVolume(0, bgmSlider.value + changeValue);
            mixer.SetFloat(MIXER_BGM, Mathf.Log10(bgmSlider.value)* 20 + changeValue);
            SetBGMVolume(bgmSlider.value + changeValue);



        }
        else
        {


            mixer.SetFloat(MIXER_SFX, Mathf.Log10(sfxSlider.value)* 20 + changeValue);
            SetSFXVolume(sfxSlider.value + changeValue);


        }


    }

    public void VolButtonMINUS(bool sfx)
    {
        float changeValue = 0.05f;

        if (!sfx)
        {
            Debug.Log("minus bgm");
            manager.video.SetDirectAudioVolume(0, bgmSlider.value - changeValue);
            mixer.SetFloat(MIXER_BGM, Mathf.Log10(bgmSlider.value) * 20 - changeValue);
            SetBGMVolume(bgmSlider.value - changeValue);

        }
        else
        {
            Debug.Log("minus sfx");

            mixer.SetFloat(MIXER_SFX, Mathf.Log10(sfxSlider.value) - changeValue);
            SetSFXVolume(sfxSlider.value - changeValue);


        }
    }





}
