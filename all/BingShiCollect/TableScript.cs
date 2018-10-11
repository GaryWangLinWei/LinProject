using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TableScript : MonoBehaviour
{
    //所有问题面板
    public GameObject[] scrollViewGos;
    //所有tag
    public GameObject[] toggleGos;
    //剩余问题数
    public TextMeshProUGUI LeftNum;
    //问题list数组
    public GameObject[] QuestionsArray;

    //现病史
    public void ButtonNow()
    {
        if (toggleGos[0].GetComponent<Toggle>().isOn)
        {
            closeAllPanel();
            scrollViewGos[AllStaticVariable.wenZhenTime-1].SetActive(true);
            //switch (AllStaticVariable.wenZhenTime)
            //{
            //    case 1:
            //        scrollViewGos[0].SetActive(true);
            //        break;
            //    case 2:
            //        scrollViewGos[1].SetActive(true);
            //        break;
            //    case 3:
            //        scrollViewGos[2].SetActive(true);
            //        break;
            //    case 4:
            //        scrollViewGos[3].SetActive(true);
            //        break;
            //    case 5:
            //        scrollViewGos[4].SetActive(true);
            //        break;
            //    case 6:
            //        scrollViewGos[5].SetActive(true);
            //        break;
            //    case 7:
            //        scrollViewGos[6].SetActive(true);
            //        break;
            //    case 8:
            //        scrollViewGos[7].SetActive(true);
            //        break;
            //    case 9:
            //        scrollViewGos[8].SetActive(true);
            //        break;
            //}
        }
    }
    //既往史
    public void ButtonJW()
    {
        if (toggleGos[1].GetComponent<Toggle>().isOn)
        {
            closeAllPanel();
            scrollViewGos[10].SetActive(true);
        }
    }
    //个人史
    public void ButtonGR()
    {
        if (toggleGos[2].GetComponent<Toggle>().isOn)
        {
            closeAllPanel();
            scrollViewGos[11].SetActive(true);
        }
    }
    //家族史
    public void ButtonJZ()
    {
        if (toggleGos[3].GetComponent<Toggle>().isOn)
        {
            closeAllPanel();
            scrollViewGos[12].SetActive(true);
        }
    }


    void Update()
    {
        changeButton();
        //LeftNum.text = CountLeftNum().ToString();
    }

    //关闭所有问题面板
    private void closeAllPanel()
    {
        for (int i = 0; i < scrollViewGos.Length; i++)
        {
            scrollViewGos[i].SetActive(false);
        }
    }

    //button高亮
    private void gaoliangButton(GameObject toggle)
    {
        Image img = toggle.transform.GetComponent<Image>();
        Sprite sprite = Resources.Load("smallPic/bingShiCollect/2", typeof(Sprite)) as Sprite;
        img.overrideSprite = sprite;
        //toggle.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0.21f, 0.25f, 0.32f, 1);
    }
    //button一般
    private void yiBanButton(GameObject toggle)
    {
        Image img = toggle.transform.GetComponent<Image>();
        Sprite sprite = Resources.Load("smallPic/bingShiCollect/1", typeof(Sprite)) as Sprite;
        img.overrideSprite = sprite;
        //toggle.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0.21f, 0.25f, 0.32f, 1);
    }

    private void changeButton()
    {
        for (int i = 0; i < toggleGos.Length; i++)
        {
            if (toggleGos[i].transform.GetComponent<Toggle>().isOn)
                gaoliangButton(toggleGos[i]);
            else
            {
                yiBanButton(toggleGos[i]);
            }
        }
    }

    //计算剩余问题
    private int CountLeftNum()
    {
        int res = 0;
        for (int i = 0; i < QuestionsArray[AllStaticVariable.wenZhenTime - 1].transform.childCount; i++)
        {
            if (QuestionsArray[AllStaticVariable.wenZhenTime - 1].transform.GetChild(i).GetComponent<IsRightQuestion>()
                .IsRight)
                res++;
        }
        return res;
    }
}
