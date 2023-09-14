using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine;

public class Condition : MonoBehaviour
{
    public PlayableDirector playable;
    public RawImage image;
    public Texture[][] frameArrays = new Texture[4][];
    public Texture[] frames_qte1;
    public Texture[] frames_qte2;
    public Texture[] frames_qte3;
    public Texture[] frames_qte4;

    public float[] timeMarks;
    public float timeWindow;
    int qte_i;
    int i;
    bool startTimer;
    bool changeFrame;
    [SerializeField] float timerTime;
    public void Good()
    {
        FindObjectOfType<StartQTEAnimatic>().qte_OnScreen = false;
        FindObjectOfType<Pause>().ResumeGameWithoutQTE();
        qte_i++;
        Debug.Log("Continua el animatic");
        AudioManager manager = FindObjectOfType<AudioManager>();
        manager.Correct();
    }
    public void Bad()
    {
        FindObjectOfType<StartQTEAnimatic>().qte_OnScreen = false;
        FindObjectOfType<Pause>().BadCondition();
        playable.Stop();
        startTimer = true;
        Debug.Log("Pierdes y se reinicia el juego");
        AudioManager manager = FindObjectOfType<AudioManager>();
        manager.Wrong();

    }
    private void Start()
    {
        frameArrays[0] = frames_qte1;
        frameArrays[1] = frames_qte2;
        frameArrays[2] = frames_qte3;
        frameArrays[3] = frames_qte4;
    }
    private void FixedUpdate()
    {
        if (startTimer)
        {
            timerTime += Time.fixedDeltaTime;

            if (i < frameArrays[qte_i].Length)
            {
                if (timeMarks[i] > timerTime - timeWindow && timeMarks[i] < timerTime + timeWindow)
                {
                    changeFrame = true;
                }
            }
            else
            {
                if (timeMarks[i] > timerTime - timeWindow && timeMarks[i] < timerTime + timeWindow)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }

        if (changeFrame)
        {
            Change();
            changeFrame = false;
        }
    }
    private void Change()
    {
        Debug.Log("AAA");
        image.texture = frameArrays[qte_i][i];
        i++;
    }
}
