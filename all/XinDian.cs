using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class XinDian : MonoBehaviour
{
    public Image XinDian1;
    public Image XinDian2;

    public TextMeshProUGUI xueYa1;
    public TextMeshProUGUI xueYa2;

    public TextMeshProUGUI tiWen;

    public TextMeshProUGUI huXi;

    public TextMeshProUGUI xueYang;

    public TextMeshProUGUI xinLv;

    public GameObject RedJumpWord;
	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(WaveGo());
	    StartCoroutine(ChangeHuXi());
	    StartCoroutine(ChangeXueYa1());
	    StartCoroutine(ChangeXueYang());
	    StartCoroutine(ChangeTiWen());
	    StartCoroutine(ChangeXinLv());
	}
	
	// Update is called once per frame
	void Update ()
	{

        if (AllStaticVariable.IsBeRed)
	    {
	        RedJumpWord.SetActive(true);
            xinLv.gameObject.SetActive(false);
            xueYang.gameObject.SetActive(false);
	    }
	    else
	    {
	        RedJumpWord.SetActive(false);
	        xinLv.gameObject.SetActive(true);
	        xueYang.gameObject.SetActive(true);
        }
	}

    IEnumerator WaveGo()
    {
        while (true)
        {
            XinDian1.fillOrigin = 0;
            XinDian2.fillOrigin = 1;
            XinDian1.DOFillAmount(0.97f, 4);
            XinDian2.DOFillAmount(0, 4);
            yield return new WaitForSeconds(4);
            XinDian1.fillOrigin = 1;
            XinDian2.fillOrigin = 0;
            XinDian1.DOFillAmount(0, 4);
            XinDian2.DOFillAmount(0.97f, 4);
            yield return new WaitForSeconds(4);
        }

    }


    IEnumerator ChangeXueYa1()
    {
        while (true)
        {
            int num1 = Random.Range(AllStaticVariable.TodayXueYa1-2, AllStaticVariable.TodayXueYa1+3);
            int num2 = Random.Range(AllStaticVariable.TodayXueYa2 - 2, AllStaticVariable.TodayXueYa2 + 2);
            xueYa1.text = num1.ToString();
            xueYa2.text = num2.ToString();
            yield return new WaitForSeconds(60f);
        }
    }

    IEnumerator ChangeTiWen()
    {
        while (true)
        {
            float num = Random.Range(AllStaticVariable.TodayTiWen - 0.2f, AllStaticVariable.TodayTiWen + 0.3f);
            Double num2 = Math.Round(num, 1);
            tiWen.text = num2.ToString();
            yield return new WaitForSeconds(3f);
        }
    }

    IEnumerator ChangeHuXi()
    {
        while (true)
        {
            int num = Random.Range(AllStaticVariable.TodayHuXi - 2, AllStaticVariable.TodayHuXi + 3);
            huXi.text = num.ToString();
            yield return new WaitForSeconds(20);
        }
    }

    IEnumerator ChangeXueYang()
    {
        while (true)
        {
            int num = Random.Range(98, 101);
            xueYang.text = num.ToString();
            yield return new WaitForSeconds(5f);
        }
    }
    IEnumerator ChangeXinLv()
    {
        while (true)
        {
            int num = Random.Range(AllStaticVariable.TodayXinLv - 2, AllStaticVariable.TodayXinLv + 3);
            xinLv.text = num.ToString();
            yield return new WaitForSeconds(7f);
        }
    }

}
