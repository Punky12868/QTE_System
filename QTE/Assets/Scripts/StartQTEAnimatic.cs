using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiegoBravo;

public class StartQTEAnimatic : MonoBehaviour
{
    SetText setText;
    [SerializeField] float[] qte_timeMarks;
    public bool qte_OnScreen;
    bool canSpawn;
    int i;
    private void Start()
    {
        setText = GetComponent<SetText>();
        canSpawn = false;
    }
    private void Update()
    {
        if (i < qte_timeMarks.Length)
        {
            if (qte_timeMarks[i] > setText.timeCheck - setText.timeWindow && qte_timeMarks[i] < setText.timeCheck + setText.timeWindow)
            {
                canSpawn = true;
            }
        }
        
        if (canSpawn)
        {
            Spawn();
            canSpawn = false;
        }
    }
    void Spawn()
    {
        FindObjectOfType<QTESystem>().qteTrigger = true;
        FindObjectOfType<Pause>().PauseByQTE();
        qte_OnScreen = true;
        i++;
    }
}
