using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVid : MonoBehaviour
{
    [SerializeField] private VideoPlayer vid;
    private void Update()
    {
        if(!vid.isPlaying)
        {
            vid.Play();
        }
    }
}
