using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] PanelFade fadeIn;
    private AudioManager audio;
    private void Start()
    {
        audio = FindObjectOfType<AudioManager>();
    }
    public void StartGame()
    {
        //SceneManager.LoadScene("Va11HallaQTE_Gameplay");
        fadeIn.fadeIn = true;
    }


    public void RestartGame()
    {
        SceneManager.LoadScene("Va11HallaQTE_Gameplay");
    }    

    public void ToMenu()
    {
        SceneManager.LoadScene("Va11HallaMenu");
    }
    
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }


}
