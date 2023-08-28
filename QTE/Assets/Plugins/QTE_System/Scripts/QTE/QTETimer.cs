using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTETimer : MonoBehaviour
{
    QTESystem qteSystem;
    [HideInInspector] public float storedTime;
    [HideInInspector] public bool timerIsRunning;
    public float timer = 3;
    private void Awake()
    {
        qteSystem = GetComponent<QTESystem>();
        storedTime = timer;
    }
    public void StartCountDown()
    {
        if (timerIsRunning)
        {
            if (timer > -0.01)
            {
                timer -= Time.unscaledDeltaTime;
                qteSystem.canPress = true;
            }
            else
            {
                if (qteSystem.spawnTemplate)
                {
                    qteSystem.customTemplateTrigger = true;
                }

                qteSystem.status = "Time Out";
                qteSystem.canPress = false;
                timerIsRunning = false;
                timer = 0;
            }
        }
    }
}
