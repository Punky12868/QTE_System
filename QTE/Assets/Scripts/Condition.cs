using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition : MonoBehaviour
{
    public void Good()
    {
        FindObjectOfType<SetPlayback>().Resume();
        FindObjectOfType<Pause>().ResumeGame();
    }
    public void Bad()
    {
        FindObjectOfType<SetPlayback>().Resume();
        FindObjectOfType<Pause>().ResumeGame();
    }
}
