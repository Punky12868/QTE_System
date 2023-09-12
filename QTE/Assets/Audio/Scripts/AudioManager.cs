using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    
    [SerializeField]private VideoPlayer video;


    private void Start()
    {
        video = FindObjectOfType<VideoPlayer>();
        
    }

    public void NoVideo()
    {
        video = null;
    }


    
}
