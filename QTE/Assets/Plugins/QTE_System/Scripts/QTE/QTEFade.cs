using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiegoBravo
{
[RequireComponent(typeof(CanvasGroup))]
public class QTEFade : MonoBehaviour
{
    [HideInInspector] public CanvasGroup template;
    [HideInInspector] public float alphaLerpInSpeed = 0.1f;
    [HideInInspector] public float alphaLerpOutSpeed = 0.08f;
    [HideInInspector] public float notInstantFadeOut = 0.3f;
    [HideInInspector] public float startingFade = 0;
    private void Awake()
    {
        FindObjectOfType<QTEFadeController>().qteFade = this;
        FindObjectOfType<QTEFadeController>().AssignVariables();
        template = GetComponent<CanvasGroup>();
        template.alpha = startingFade;
    }
    public void FadeIn()
    {
        template.alpha = Mathf.Lerp(template.alpha, 1, alphaLerpInSpeed);

        if (template.alpha >= 0.999)
        {
            template.alpha = 1;
        }
    }
    public void FadeOut()
    {
        if (notInstantFadeOut > 0)
        {
            notInstantFadeOut -= Time.unscaledDeltaTime;
        }
        else
        {
            template.alpha = Mathf.Lerp(template.alpha, 0, alphaLerpOutSpeed);
        }

        if (template.alpha <= 0.001)
        {
            template.alpha = 0;
            if (FindObjectOfType<QTESystem>().useSpawnScript)
            {
                FindObjectOfType<QTESpawn>().Fade();
            }
            FindObjectOfType<QTEFadeController>().qteFade = null;
            Destroy(this.gameObject);
        }
    }
}
}

