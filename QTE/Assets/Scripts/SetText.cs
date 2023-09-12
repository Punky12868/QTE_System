using System.Collections;
using System.Collections.Generic;
using Febucci.UI.Core;
using UnityEngine;
using TMPro;

public class SetText : MonoBehaviour
{
    public bool setDialogue;
    public bool setClear;
    [SerializeField] TypewriterCore typewriter;
    [SerializeField] TMP_Text text;
    public string copao;
    public string jill;
    [TextArea] public string[] dialogue;
    public float timeCheck, timeWindow;
    [SerializeField] float[] timeMarks;
    int i;
    private void Start()
    {
        setClear = true;
    }
    private void Update()
    {
        if (i < dialogue.Length)
        {
            if (timeMarks[i] > timeCheck - timeWindow && timeMarks[i] < timeCheck + timeWindow)
            {
                setDialogue = true;
            }
        }

        if (setDialogue)
        {
            Set();
            setDialogue = false;
        }

        if (setClear)
        {
            Clear();
            setClear = false;
        }
    }
    private void FixedUpdate()
    {
        timeCheck += Time.deltaTime;
    }
    public void Set()
    {
        string output = "";
        if (dialogue[i].Contains("Copao"))
        {
            output = dialogue[i].Replace("Copao:", copao);
        }
        else if (dialogue[i].Contains("Jill"))
        {
            output = dialogue[i].Replace("Jill:", jill);
        }

        typewriter.ShowText(output);
        typewriter.StartShowingText(true);
        i++;
    }
    public void Clear()
    {
        typewriter.ShowText("");
        typewriter.StartShowingText(true);
    }
}
