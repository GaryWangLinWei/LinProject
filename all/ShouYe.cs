using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShouYe : MonoBehaviour {
    public Image Word1;
    public GameObject Word2;
    public GameObject LianXiBtn;
    public GameObject KaoHeBtn;
	// Use this for initialization
	void Start () {
        StartCoroutine(delay());
	}

    IEnumerator delay()
    {
        Word1.DOFade(1, 2);
        yield return new WaitForSeconds(2);
        LianXiBtn.SetActive(true);
        KaoHeBtn.SetActive(true);
    }
	public void LianXiMode()
    {
        Word1.gameObject.SetActive(false);
        LianXiBtn.SetActive(false);
        KaoHeBtn.SetActive(false);
        Word2.SetActive(true);
        AllStaticVariable.IsTip = true;
    }
    public void KaoHeMode()
    {
        Word1.gameObject.SetActive(false);
        LianXiBtn.SetActive(false);
        KaoHeBtn.SetActive(false);
        Word2.SetActive(true);
        AllStaticVariable.IsTip = false;
    }

    public void ToCase()
    {
        SceneManager.LoadScene("MainScene");
    }
}
