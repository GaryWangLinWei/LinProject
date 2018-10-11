using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowSquare : MonoBehaviour
{
    public GameObject Square;
    public GameObject Panel;

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    print("y");
    //    Square.SetActive(true);
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    print("n");
    //    Square.SetActive(false);
    //}

    // Use this for initialization
    void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		if(transform.GetComponent<Toggle>().isOn)
        {
            Square.SetActive(true);
        }
        else
        {
            Square.SetActive(false);
        }
        if(Panel.activeSelf)
        {
            transform.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            transform.GetComponent<Toggle>().isOn = false;
        }
	}

}
