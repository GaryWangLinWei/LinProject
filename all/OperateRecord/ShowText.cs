using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour {
    void Update()
    {
        if (transform.GetComponent<RectTransform>().sizeDelta.y > 40)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
