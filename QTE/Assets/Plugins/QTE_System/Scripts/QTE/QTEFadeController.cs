using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEFadeController : MonoBehaviour
{
    [HideInInspector] public QTEFade qteFade;
    public float alphaLerpInSpeed = 0.1f;
    public float alphaLerpOutSpeed = 0.08f;
    public float notIntantFadeOut = 0.3f;
    public float startingFade = 0;
    public void AssignVariables()
    {
        if (qteFade != null)
        {
            qteFade.alphaLerpInSpeed = alphaLerpInSpeed;
            qteFade.alphaLerpOutSpeed = alphaLerpOutSpeed;
            qteFade.notInstantFadeOut = notIntantFadeOut;
            qteFade.startingFade = startingFade;
        }
    }
}
