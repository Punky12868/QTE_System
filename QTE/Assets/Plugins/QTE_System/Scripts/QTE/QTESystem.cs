using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(QTETimer))]
[RequireComponent(typeof(QTESpawn))]
[RequireComponent(typeof(QTEConditions))]
public class QTESystem : MonoBehaviour
{
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

        if (timer.timerIsRunning)
        {
            timer.StartCountDown();
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
