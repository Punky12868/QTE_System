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
    [SerializeField] float antiDeSync;
    int i;
    bool test;
    private void Awake()
    {
        Application.targetFrameRate = 60;

        setClear = true;
    }
    private void Update()
    {
        if (Application.targetFrameRate != 60)
        {
            Application.targetFrameRate = 60;
        }

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
        if (!Pause.isPausedByQTE_Fail)
        {
            if (!test)
            {
                if (antiDeSync > timeCheck - timeWindow && antiDeSync < timeCheck + timeWindow)
                {
                    FindObjectOfType<Condition>().playable.Play();
                    FindObjectOfType<SetPlayback>().video.Play();
                    test = true;
                }
            }
            timeCheck += Time.fixedDeltaTime;
        }
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
