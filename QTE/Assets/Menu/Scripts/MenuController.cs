using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private AudioManager audio;
    private void Start()
    {
        audio = FindObjectOfType<AudioManager>();
    }
    public void StartGame()
    {
        audio.NoVideo();
        SceneManager.LoadScene("Va11HallaQTE_Gameplay");
    }

    

    public void Settings()
    {
        //get active panel
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }


}
