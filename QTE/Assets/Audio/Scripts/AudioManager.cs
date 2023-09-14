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
        if(!video)
        {
            video = FindObjectOfType<VideoPlayer>();

        }
        
    }

    public void NoVideo()
    {
        video = null;
    }


    private void Update()
    {
        if (!video)
        {
            video = FindObjectOfType<VideoPlayer>();
        }
    }
}
