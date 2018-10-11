using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowSubSquare : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public GameObject Square;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Square.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Square.SetActive(false);
    }

}
