using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiegoBravo
{
[RequireComponent(typeof(QTETimer))]
[RequireComponent(typeof(QTESpawn))]
[RequireComponent(typeof(QTEConditions))]
[RequireComponent(typeof(QTEFadeController))]
public class QTESystem : MonoBehaviour
{
        [HideInInspector] public bool isPaused;
    QTETimer timer;
    [SerializeField] KeyCode[] keys;
    [HideInInspector] public int keyIndex;
    [HideInInspector] public string keyString;
    [HideInInspector] public string status;

    [HideInInspector] public bool qteTrigger;
    [HideInInspector] public bool canPress;
    [HideInInspector] public bool customTemplateTrigger;

    public bool spawnTemplate;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject template;

    public bool forceStart;
    public bool useSpawnScript;
    [SerializeField] KeyCode forceStartKey;
    private void Awake()
    {
        timer = GetComponent<QTETimer>();
        if (!spawnTemplate || !useSpawnScript)
        {
            GetComponent<QTESpawn>().enabled = false;
        }
    }
    private void Update()
    {
        if (forceStart)
        {
            ForceStart();
        }

        if (qteTrigger)
        {
            StartQTE();
        }

        GetInput();
    }
    private void StartQTE()
    {
        if (spawnTemplate)
        {
            Instantiate(template, canvas.transform);
        }

        keyIndex = Random.Range(0, keys.Length);
        keyString = keys[keyIndex].ToString();
        status = "";
        qteTrigger = false;

        timer.timer = timer.storedTime;
        timer.timerIsRunning = true;
    }
        private void GetInput()
        {
            if (canPress && Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Mouse0))
                {
                    //do nothing
                }
                else
                {
                    customTemplateTrigger = true;
                    if (Input.GetKeyDown(keys[keyIndex]))
                    {
                        status = "Correct";
                        canPress = false;

                        timer.timerIsRunning = false;
                        timer.timer = 0;
                    }
                    else
                    {
                        status = "Incorrect";
                        canPress = false;

                        timer.timerIsRunning = false;
                        timer.timer = 0;
                    }
                }
            }

            if (!isPaused)
            {
                if (timer.timerIsRunning)
                {
                    timer.StartCountDown();
                }
            }
        }
        private void ForceStart()
        {
            if (Input.GetKeyUp(forceStartKey) && !qteTrigger && !canPress)
            {
                qteTrigger = true;
            }
        }
    }
}

