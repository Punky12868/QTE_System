using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class SetPlayback : MonoBehaviour
{
    public VideoPlayer video;
    public bool setPlay, setPause;

    private void Update()
    {
        if (setPlay)
        {
            video.playbackSpeed = 1;
            setPlay = false;
        }
        if (setPause)
        {
            video.playbackSpeed = 0;
            setPause = false;
        }
    }
}
