using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DynamicButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    //里面圆
    public GameObject circle1;
    //六点圆
    public GameObject circle2;
    //外面圆
    public GameObject circle4;
    //里圈速度
    public int speed1 = -10;
    //中圈速度
    public int speed2 = 10;
    //外圈速度
    public int speed4 = 10;
    //是否悬停
    private bool isHover = false;

    public void Update()
    {
        if (isHover == true)
        {
            circle1.GetComponent<RectTransform>().eulerAngles += new Vector3(0, 0, Time.deltaTime * speed1);
            circle4.GetComponent<RectTransform>().eulerAngles += new Vector3(0, 0, Time.deltaTime * speed4);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHover = true;
        StartCoroutine(circle2Anim());
        StartCoroutine(circle2Color());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHover = false;
        StopAllCoroutines();

    }

    IEnumerator circle2Anim()
    {
        while (true)
        {
            circle2.GetComponent<RectTransform>().eulerAngles += new Vector3(0,0,Time.deltaTime*speed2);
            if (circle2.GetComponent<RectTransform>().eulerAngles.z > 350)
            {
                yield return new WaitForSeconds(0.5f);
                speed2 = 50;
            }
            else if (circle2.GetComponent<RectTransform>().eulerAngles.z > 30)
            {
                yield return new WaitForSeconds(0.5f);
                speed2 = -50;
            }
            yield return null;
        }
    }

    IEnumerator circle2Color()
    {
        while (true)
        {
            float time = 0.3f;
            circle2.GetComponent<Image>().DOColor(Color.yellow, time);
            yield return new WaitForSeconds(time);
            circle2.GetComponent<Image>().DOColor(Color.white, time);
            yield return new WaitForSeconds(time);
        }
    }
}
