using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition : MonoBehaviour
{
    public void Good()
    {
        FindObjectOfType<StartQTEAnimatic>().qte_OnScreen = false;
        FindObjectOfType<Pause>().ResumeGameWithoutQTE();
        Debug.Log("Continua el animatic");
    }
    public void Bad()
    {
        FindObjectOfType<StartQTEAnimatic>().qte_OnScreen = false;
        FindObjectOfType<Pause>().ResumeGameWithoutQTE();
        Debug.Log("Pierdes y se reinicia el juego");
    }
}
