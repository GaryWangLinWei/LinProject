using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeTextColor : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.GetComponent<TextMeshProUGUI>().color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.GetComponent<TextMeshProUGUI>().color = new Color(0.33f,0.33f,0.33f);
    }
}
