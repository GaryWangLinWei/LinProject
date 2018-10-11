using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorJump : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(Change());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Change()
    {
        while (true)
        {
            transform.GetComponent<Image>().DOFade(0.6f, 0.3f);
            yield return new WaitForSeconds(0.3f);
            transform.GetComponent<Image>().DOFade(1f, 0.3f);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
