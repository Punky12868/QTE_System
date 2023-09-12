using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class SetPlayback : MonoBehaviour
{
    public VideoPlayer video;
    public void Resume()
    {
        video.playbackSpeed = 1;
    }
    public void Stop()
    {
        video.playbackSpeed = 0;
    }
}
