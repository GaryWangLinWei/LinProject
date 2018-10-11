using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PingFenItem : MonoBehaviour
{
    //背景颜色
    public GameObject BackGround;
    //日期
    public TextMeshProUGUI day;
    //任务
    public TextMeshProUGUI mission;
    //操作
    public TextMeshProUGUI operate;
    //打叉
    public GameObject cross;
    //打勾
    public GameObject gou;
    //得分
    public TextMeshProUGUI score;
    //属性
    public TextMeshProUGUI property;
    //问题
    public GameObject qusetionButton;
    //解析
    public GameObject analysisButton;


    void Start()
    {
        //Init();
    }

    public static GameObject Init()
    {
        GameObject pingFen = Instantiate(Resources.Load<GameObject>("Prefabs/all/Image_PingFenItem"));
        AllNeedUI.Instance.pingFenParent.GetComponent<RectTransform>().sizeDelta += new Vector2(0,44);
        pingFen.transform.parent = AllNeedUI.Instance.pingFenParent.transform;
        if (AllNeedUI.Instance.pingFenParent.transform.childCount % 2 == 0)
        {
            pingFen.GetComponent<PingFenItem>().BackGround.GetComponent<Image>().overrideSprite =
                Resources.Load("scorePic/scoreBar2", typeof(Sprite)) as Sprite;
        }
        else
        {
            pingFen.GetComponent<PingFenItem>().BackGround.GetComponent<Image>().overrideSprite =
                Resources.Load("scorePic/scoreBar1", typeof(Sprite)) as Sprite;
        }
        pingFen.transform.localScale = Vector3.one;
        pingFen.transform.localPosition = Vector3.zero;
        pingFen.transform.localEulerAngles = Vector3.zero;

        return pingFen;
    }


}
