using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace DiegoBravo
{
    public class QTEBehaviour : MonoBehaviour
{
    QTESystem qteSystem;
    QTEConditions qteConditions;
    QTESpawn qteSpawn;
    QTETimer qteTimer;
    QTEFade qteFade;

    [SerializeField] bool customTemplate = true;
    [SerializeField] bool usingFade = true;
    [SerializeField] bool usingConditions = true;
    bool fadeController = true;

    [SerializeField] TMP_Text keyText;
    [SerializeField] Slider slider;
    [SerializeField] TMP_Text feedbackText;
    private void Awake()
    {
        QTEBehaviour[] qTEBehaviours = FindObjectsOfType<QTEBehaviour>();
        if (qTEBehaviours.Length > 1)
        {
            Destroy(qTEBehaviours[1].gameObject);
        }

        if (usingFade)
        {
            gameObject.AddComponent<QTEFade>();
            qteFade = GetComponent<QTEFade>();
        }

        if (usingConditions)
        {
            qteConditions = FindObjectOfType<QTEConditions>();
        }

        qteSystem = FindObjectOfType<QTESystem>();
        qteSpawn = FindObjectOfType<QTESpawn>();
        qteTimer  = FindObjectOfType<QTETimer>();

        slider.maxValue = qteTimer.storedTime;
    }
    private void Update()
    {
        if (!customTemplate)
        {
            Example();
        }
        else
        {
            Custom();
        }
    }
    private void Example()
    {
        keyText.text = qteSystem.keyString;
        feedbackText.text = qteSystem.status;
        slider.value = qteTimer.timer;
    }
    private void Custom()
    {
        slider.value = qteTimer.timer;
        keyText.text = qteSystem.keyString;

        if (!usingFade)
        {
            if (qteSystem.customTemplateTrigger)
            {
                if (qteSystem.status == "Correct")
                {
                    // do something
                    if (usingConditions && !FindObjectOfType<QTESpawn>().endlesQTE)
                    {
                        qteConditions.success = true;
                        qteConditions.GetResult();
                    }

                    if (qteSystem.useSpawnScript)
                    {
                        qteSpawn.Succeeded();
                    }

                    Debug.Log(qteSystem.status);
                    qteSystem.customTemplateTrigger = false;
                    Destroy(this.gameObject);
                }
                else
                {
                    // do something
                    if (usingConditions && !FindObjectOfType<QTESpawn>().endlesQTE)
                    {
                        qteConditions.fail = true;
                        qteConditions.GetResult();
                    }

                    if (qteSystem.useSpawnScript)
                    {
                        qteSpawn.Failed();
                    }

                    Debug.Log(qteSystem.status);
                    qteSystem.customTemplateTrigger = false;
                    Destroy(this.gameObject);
                }
            }
        }
        else
        {
            if (qteSystem.customTemplateTrigger)
            {
                if (qteSystem.status == "Correct")
                {
                    // do something
                    if (usingConditions && !FindObjectOfType<QTESpawn>().endlesQTE)
                    {
                        qteConditions.success = true;
                        qteConditions.GetResult();
                    }

                    if (qteSystem.useSpawnScript)
                    {
                        qteSpawn.Succeeded();
                    }

                    fadeController = false;
                    Debug.Log(qteSystem.status);
                    qteSystem.customTemplateTrigger = false;
                }
                else
                {
                    // do something
                    if (usingConditions && !FindObjectOfType<QTESpawn>().endlesQTE)
                    {
                        qteConditions.fail = true;
                        qteConditions.GetResult();
                    }

                    if (qteSystem.useSpawnScript)
                    {
                        qteSpawn.Failed();
                    }

                    fadeController = false;
                    Debug.Log(qteSystem.status);
                    qteSystem.customTemplateTrigger = false;
                }
            }

            if (fadeController)
            {
                qteFade.FadeIn();
            }
            else
            {
                qteFade.FadeOut();
            }
        }
    }
}
}

