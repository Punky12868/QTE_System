using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE_ChangeCameraColor : MonoBehaviour
{
    public void Success()
    {
        FindObjectOfType<Camera>().backgroundColor = new Color32(0, 255, 0, 255);
    }
    public void Failed()
    {
        FindObjectOfType<Camera>().backgroundColor = new Color32(255, 0, 0, 255);
    }
}
