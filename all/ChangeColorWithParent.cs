using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI ;

public class ChangeColorWithParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        var temp = transform.parent.GetComponent<Image>().color;
        //transform.GetComponent<TextMeshProUGUI>().color = temp;
        transform.GetComponent<TextMeshProUGUI>().fontMaterial.SetColor("_FaceColor", temp);
        transform.GetComponent<TextMeshProUGUI>().fontMaterial.SetColor("_UnderlayColor", temp);
    }
}
