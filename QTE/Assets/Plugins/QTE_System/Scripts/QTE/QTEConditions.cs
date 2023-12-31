using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DiegoBravo
{ 
public class QTEConditions : MonoBehaviour
{
    [HideInInspector] public bool success;
    [HideInInspector] public bool fail;
    [HideInInspector] public bool oneChance;

    [HideInInspector] public int successesNecessariesForSucceeding;
    [HideInInspector] public int failesNecessariesForFailing;
    [HideInInspector] public int succeses;
    [HideInInspector] public int fails;

    public UnityEvent succeded;
    public UnityEvent failed;
    private void Awake()
    {
        if (!oneChance)
        {
            if (GetComponent<QTESpawn>().useQuantityTilFail)
            {
                successesNecessariesForSucceeding = GetComponent<QTESpawn>().qteQuantity;
                failesNecessariesForFailing = 1;
            }
            else if (!GetComponent<QTESpawn>().failTilSuccesQTE)
            {
                successesNecessariesForSucceeding = GetComponent<QTESpawn>().qteQuantity;
                failesNecessariesForFailing = GetComponent<QTESpawn>().qteQuantity;
            }
            else
            {
                successesNecessariesForSucceeding = GetComponent<QTESpawn>().qteQuantity;
            }
        }
        else
        {
            GetComponent<QTESpawn>().onlyOneQTE = true;
            GetComponent<QTESpawn>().failTilSuccesQTE = false;
            GetComponent<QTESpawn>().endlesQTE = false;
        }
    }
    public void GetResult()
    {
        if (oneChance)
        {
            if (success)
            {
                succeded.Invoke();
                success = false;
            }
            else if (fail)
            {
                failed.Invoke();
                fail = false;
            }
        }
        else
        {
            if (success)
            {
                succeses++;
                success = false;
            }
            else if (fail)
            {
                if (GetComponent<QTESpawn>().resetQTEOnFail)
                {
                    succeses = 0;
                }
                else if (!GetComponent<QTESpawn>().failTilSuccesQTE)
                {
                    fails++;
                }
                fail = false;
            }

            

            if (succeses == successesNecessariesForSucceeding)
            {
                succeded.Invoke();
                succeses = 0;
            }
            else if (fails == failesNecessariesForFailing && !GetComponent<QTESpawn>().failTilSuccesQTE)
            {
                failed.Invoke();
                fails = 0;
            }
        }
    }
}
}
