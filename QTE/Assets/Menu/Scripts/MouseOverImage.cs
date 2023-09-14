using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseOverImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image sprite;
    public Color32 color1;
    public Color32 color2;

    public void OnPointerEnter(PointerEventData eventData)
    {
        sprite.color = color1;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        sprite.color = color2;
    }
}
