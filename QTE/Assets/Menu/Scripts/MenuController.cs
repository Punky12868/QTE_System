using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Va11HallaQTE_Gameplay");
    }

    public void CreditScene()
    {
        SceneManager.LoadScene("Credits");
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
