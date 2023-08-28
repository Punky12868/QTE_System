using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTESpawn : MonoBehaviour
{
    QTESystem qteSystem;
    public bool onlyOneQTE;
    public int qteQuantity = 3;
    int storedQTEQuantity;
    [SerializeField] float refillQuantityTimer = 5;
    float storedRefillQuantityTimer;
    bool restoreQuantity;

    [SerializeField] bool playOnAwake;
    [SerializeField] float playOnAwakeTime = 5;

    public bool resetQTEOnFail;
    public bool endlesQTE;
    public bool failTilSuccesQTE;
    [SerializeField] bool usingFade;

    
    private void Awake()
    {
        if (endlesQTE || resetQTEOnFail)
        {
            failTilSuccesQTE = false;
            onlyOneQTE = false;
        }

        if (onlyOneQTE)
        {
            qteQuantity = 1;
            GetComponent<QTEConditions>().oneChance = true;
        }

        storedQTEQuantity = qteQuantity;
        storedRefillQuantityTimer = refillQuantityTimer;
        qteSystem = GetComponent<QTESystem>();
    }
    private void Update()
    {
        if (playOnAwake)
        {
            if (playOnAwakeTime > 0)
            {
                playOnAwakeTime -= Time.unscaledDeltaTime;
            }
            else
            {
                FailToSuccessEvent();
                playOnAwake = false;
            }
        }

        if (restoreQuantity)
        {
            if (refillQuantityTimer > 0)
            {
                refillQuantityTimer -= Time.unscaledDeltaTime;
            }
            else
            {
                qteQuantity = storedQTEQuantity;
                refillQuantityTimer = storedRefillQuantityTimer;
                restoreQuantity = false;
            }
        }
    }
    public void Succeeded()
    {
        if (!usingFade)
        {
            if (endlesQTE)
            {
                StartEvent();
            }
            else
            {
                for (int i = 1; i < qteQuantity; i++)
                {
                    StartEvent();
                }
            }
        }
    }
    public void Failed()
    {
        if (!usingFade)
        {
            if (failTilSuccesQTE)
            {
                FailToSuccessEvent();
            }
            else if (resetQTEOnFail)
            {
                ResetOnFail();
            }
            else
            {
                for (int i = 1; i < qteQuantity; i++)
                {
                    StartEvent();
                }
            }
        }
    }
    public void Fade()
    {
        if (qteSystem.status == "Correct")
        {
            if (endlesQTE)
            {
                StartEvent();
            }
            else
            {
                for (int i = 1; i < qteQuantity; i++)
                {
                    StartEvent();
                }
            }
        }
        else
        {
            if (failTilSuccesQTE)
            {
                FailToSuccessEvent();
            }
            else if (resetQTEOnFail)
            {
                ResetOnFail();
            }
            else
            {
                for (int i = 1; i < qteQuantity; i++)
                {
                    StartEvent();
                }
            }
        }
    }
    public void StartEvent()
    {
        if (qteSystem.useSpawnScript)
        {
            if (endlesQTE)
            {
                qteSystem.qteTrigger = true;
            }
            else
            {
                qteQuantity--;
                qteSystem.qteTrigger = true;
                if (qteQuantity == 1)
                {
                    restoreQuantity = true;
                }
            }
        }
        else
        {
            qteSystem.qteTrigger = true;
        }

    }
    private void FailToSuccessEvent()
    {
        qteSystem.qteTrigger = true;
    }
    private void ResetOnFail()
    {
        qteQuantity = storedQTEQuantity;
        qteSystem.qteTrigger = true;
    }
}
