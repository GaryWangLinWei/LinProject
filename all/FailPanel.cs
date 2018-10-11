using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FailPanel : MonoBehaviour
{
    public TextMeshProUGUI Text;


    public static GameObject Init(string text)
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_fail"));
        go.transform.parent = GameObject.Find("Canvas").transform;
        go.transform.localScale = Vector3.one;
        go.transform.localPosition = Vector3.zero;
        go.transform.localEulerAngles = Vector3.zero;
        go.GetComponent<FailPanel>().Text.text = text;
        return go;
    }

}
