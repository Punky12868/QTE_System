using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class MouseOverTexture : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] private TMP_Text text;
    public Color32 color1;
    public Color32 color2;
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = color1;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = color2;
    }
}
