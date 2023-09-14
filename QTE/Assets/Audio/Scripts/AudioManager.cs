using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    


    public VideoPlayer video;

    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource bgmSource;

    [SerializeField] List<AudioClip> clickClips = new List<AudioClip>();
    public AudioMixer mixer;


    public const string BGM_KEY = "bgmVol";
    public const string SFX_KEY = "sfxVol";

    void Awake()
    {


        LoadVolume();


    }

    public void ClickSound(int audioNumber)
    {
        AudioClip clip = clickClips[audioNumber];
        sfxSource.PlayOneShot(clip);

    }

    public void AudioStartTimer()
    {
        AudioClip clip = clickClips[6];
        sfxSource.PlayOneShot(clip);
    }

    public void Correct()
    {
        AudioClip clip = clickClips[7];
        sfxSource.PlayOneShot(clip);
    }

    public void Wrong()
    {
        AudioClip clip = clickClips[5];
        sfxSource.PlayOneShot(clip);
    }
    

    void LoadVolume()  //Volumen guardado en VolumeSettings.cs
    {

        float bgmVol = PlayerPrefs.GetFloat(BGM_KEY, 1f);
       
        float sfxVol = PlayerPrefs.GetFloat(SFX_KEY, 1f);


        mixer.SetFloat(VolumeSettings.MIXER_BGM, Mathf.Log10(bgmVol) * 20);

        mixer.SetFloat(VolumeSettings.MIXER_SFX, Mathf.Log10(sfxVol) * 20);

    }
}

