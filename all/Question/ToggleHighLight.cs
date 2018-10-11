using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleHighLight : MonoBehaviour {

    void Update()
    {
        if (transform.GetComponent<Toggle>().isOn)
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.yellow;
        }
        else
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }
}
