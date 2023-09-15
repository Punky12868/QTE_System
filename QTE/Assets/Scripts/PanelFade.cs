using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PanelFade : MonoBehaviour
{
    CanvasGroup panel;

    public bool fadeIn;
    [SerializeField] bool fadeOut;
    [SerializeField] bool nextScene;

    [SerializeField] float lerpSpeed;

    private void Awake()
    {
        panel = GetComponent<CanvasGroup>();

        if (fadeIn)
        {
            panel.alpha = 0;
        }
        else if (fadeOut)
        {
            panel.alpha = 1;
        }
    }
    private void Update()
    {
        if (fadeIn)
        {
            if (panel.alpha == 1)
            {
                if (!nextScene)
                {
                    Debug.Log("idk");
                    SceneManager.LoadScene(0);
                    fadeIn = false;
                }
                else
                {
                    Debug.Log("idk");
                    SceneManager.LoadScene(1);
                    fadeIn = false;
                }
            }
            else if (panel.alpha > 0.99)
            {
                panel.alpha = 1;
            }
            else
            {
                panel.alpha = Mathf.Lerp(panel.alpha, 1, lerpSpeed * Time.deltaTime);
            }
        }
        else if (fadeOut)
        {
            if (panel.alpha == 0)
            {
                Destroy(gameObject);
                fadeOut = false;
            }
            else if (panel.alpha < 0.03)
            {
                panel.alpha = 0;
            }
            else
            {
                panel.alpha = Mathf.Lerp(panel.alpha, 0, lerpSpeed * Time.deltaTime);
            }
        }
    }
}
