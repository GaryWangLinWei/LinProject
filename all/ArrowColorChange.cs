using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ArrowColorChange : MonoBehaviour {
    public float delayTime = 0;
	// Use this for initialization
	void Start () {
        StartCoroutine(ColorChange());
	}
    IEnumerator ColorChange()
    {
        yield return new WaitForSeconds(delayTime);
        while(true)
        {
            transform.GetComponent<Image>().DOFade(1, 1f);
            yield return new WaitForSeconds(1f);
            transform.GetComponent<Image>().DOFade(0, 1f);
            yield return new WaitForSeconds(2f);
        }
    }
}
