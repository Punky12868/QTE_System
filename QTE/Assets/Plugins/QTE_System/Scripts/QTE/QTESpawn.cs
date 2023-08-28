using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTESpawn : MonoBehaviour
{
    QTESystem qteSystem;
    public bool onlyOneQTE;
    public int qteQuantity = 3;
    int storedQTEQuantity;
    [HideInInspector] public float refillQuantityTimer;
    float storedRefillQuantityTimer;
    bool restoreQuantity;

    [SerializeField] bool playOnAwake;
    [SerializeField] float playOnAwakeTime = 5;

    public bool useQuantityTilFail;
    public bool resetQTEOnFail;
    public bool endlesQTE;
    public bool failTilSuccesQTE;
    [SerializeField] bool usingFade;

    
    private void Awake()
    {
        if (qteQuantity > 1)
        {
            useQuantityTilFail = true;
        }
        else
        {
            onlyOneQTE = true;
        }
        if (GetComponent<QTETimer>().timer > refillQuantityTimer)
        {
            refillQuantityTimer = GetComponent<QTETimer>().timer + 2;
        }
        if (onlyOneQTE)
        {
            endlesQTE = false;
            resetQTEOnFail = false;
            failTilSuccesQTE = false;
            useQuantityTilFail = false;
            qteQuantity = 1;
            GetComponent<QTEConditions>().oneChance = true;
        }
        else if (resetQTEOnFail)
        {
            endlesQTE = false;
            failTilSuccesQTE = false;
            useQuantityTilFail = false;
        }
        else if (useQuantityTilFail)
        {
            endlesQTE = false;
            failTilSuccesQTE = false;
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
                int i = 1;
                if (qteQuantity > i)
                {
                    StartEvent();
                    i++;
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
            else if (useQuantityTilFail)
            {
                LooseOnFail();
            }
            else
            {
                int i = 1;
                if (qteQuantity > i)
                {
                    StartEvent();
                    i++;
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
                int i = 1;
                if (qteQuantity > i)
                {
                    StartEvent();
                    i++;
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
            else if (useQuantityTilFail)
            {
                LooseOnFail();
            }
            else
            {
                int i = 1;
                if (qteQuantity > i)
                {
                    StartEvent();
                    i++;
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
        refillQuantityTimer = storedRefillQuantityTimer;
        restoreQuantity = false;
        qteQuantity = storedQTEQuantity;
        qteSystem.qteTrigger = true;
    }
    private void LooseOnFail()
    {
        qteQuantity = 1;
    }
}
