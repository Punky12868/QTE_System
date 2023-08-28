using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class QTEFade : MonoBehaviour
{
    [SerializeField] CanvasGroup template;
    [SerializeField] float alphaLerpInSpeed = 0.1f;
    [SerializeField] float alphaLerpOutSpeed = 0.08f;
    [SerializeField] float notIntantFadeOut = 0.3f;
    [HideInInspector] public float startingFade = 0;
    private void Awake()
    {
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
        if (notIntantFadeOut > 0)
        {
            notIntantFadeOut -= Time.deltaTime;
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
            Destroy(this.gameObject);
        }
    }
}
