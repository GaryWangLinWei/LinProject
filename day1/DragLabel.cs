using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragLabel : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, ICanvasRaycastFilter
{
    private RectTransform canvas;          //得到canvas的ugui坐标
    private RectTransform imgRect;        //得到图片的ugui坐标
    Vector2 offset = new Vector3();    //用来得到鼠标和图片的差值
    public GameObject tempParent;       //标签的临时父物体，拖动时
    private bool isRaycastLocationValid = true; //默认射线不能穿透物品  
    public GameObject MCondition;
    public GameObject NCondition;
    public GameObject centerCondition;
    public GameObject partCondition;
    public GameObject labelList;
    public Vector3 prePosition;
    public GameObject[] labels;
    private GameObject pingFen;
    public GameObject ZhongDuPanel;


    void Start()
    {
        imgRect = GetComponent<RectTransform>();
        prePosition = transform.localPosition;
        canvas = GameObject.Find("Canvas_M").GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mouseDrag = eventData.position;   //当鼠标拖动时的屏幕坐标
        Vector2 uguiPos = new Vector2();   //用来接收转换后的拖动坐标
        //和上面类似
        bool isRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, mouseDrag, eventData.enterEventCamera, out uguiPos);
        print(isRect);
        if (isRect)
        {
            //设置图片的ugui坐标与鼠标的ugui坐标保持不变
            imgRect.anchoredPosition = offset + uguiPos;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.SetParent(tempParent.transform);
        Vector2 mouseDown = eventData.position;    //记录鼠标按下时的屏幕坐标
        Vector2 mouseUguiPos = new Vector2();   //定义一个接收返回的ugui坐标
        //RectTransformUtility.ScreenPointToLocalPointInRectangle()：把屏幕坐标转化成ugui坐标
        //canvas：坐标要转换到哪一个物体上，这里img父类是Canvas，我们就用Canvas
        //eventData.enterEventCamera：这个事件是由哪个摄像机执行的
        //out mouseUguiPos：返回转换后的ugui坐标
        //isRect：方法返回一个bool值，判断鼠标按下的点是否在要转换的物体上
        bool isRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, mouseDown, eventData.enterEventCamera, out mouseUguiPos);
        if (isRect)   //如果在
        {
            //计算图片中心和鼠标点的差值
            offset = imgRect.anchoredPosition - mouseUguiPos;
            print(offset);
        }
        isRaycastLocationValid = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameObject go = eventData.pointerCurrentRaycast.gameObject;//获取到鼠标终点位置下 可能的物体 
        if (go != null)
        {
            Debug.Log(go.name);
            if (go.tag == "Condition")
            {
                transform.SetParent(go.transform);
            }
            else if (go.tag == "Label")
            {
                if(go.transform.parent.tag == "Condition")
                    transform.SetParent(go.transform.parent);
                else
                {
                    transform.SetParent(labelList.transform);
                    transform.localPosition = prePosition;
                }
            }
            else
            {
                transform.SetParent(labelList.transform);
                transform.localPosition = prePosition;
            }
        }
        else
        {
            transform.SetParent(labelList.transform);
            transform.localPosition = prePosition;
        }
        offset = Vector2.zero;
        isRaycastLocationValid = true;
    }

    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)//UI事件穿透：如置为false即可以穿透，被图片覆盖的按钮可以被点击到  
    {
        return isRaycastLocationValid;
    }

    public void onQueRenClick()
    {
        if (AllStaticVariable.isInPingFen)
        {
            Destroy(ZhongDuPanel);
            return;
        }
        Destroy(ZhongDuPanel);
        for (int i = 0; i < 9; i++)
        {
            if (labels[i].transform.parent.name != "M_Condition")
            {
                loseScore();
                return;
            }
        }
        for (int i = 9; i < 14; i++)
        {
            if (labels[i].transform.parent.name != "N_Condition")
            {
                loseScore();
                return;
            }
        }
        for (int i = 14; i < 16; i++)
        {
            if (labels[i].transform.parent.name != "centerCondition")
            {
                loseScore();
                return;
            }
        }
        for (int i = 16; i < 18; i++)
        {
            if (labels[i].transform.parent.name != "partCondition")
            {
                loseScore();
                return;
            }
        }

        getScore();
    }

    private void getScore()
    {
        //重新答对，不计分
        if (!AllStaticVariable.isAgain)
        {
            createPingFenItem();
            pingFen.GetComponent<PingFenItem>().operate.text = "选择题：                   答题正确。";
            pingFen.GetComponent<PingFenItem>().score.text = "0";
            MonoWay.Instance.starUp(1);
            pingFen.GetComponent<PingFenItem>().gou.SetActive(true);
        }
        else
        {
            AllStaticVariable.isAgain = false;
        }      
        GameObject correctGo = (GameObject) Instantiate(Resources.Load("Prefabs/all/Panel_right"));
        correctGo.transform.parent = GameObject.Find("Canvas").transform;
        correctGo.transform.localScale = Vector3.one;
        correctGo.transform.localPosition = Vector3.zero;
        correctGo.transform.localEulerAngles = Vector3.zero;
        Button btn = correctGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(correctGo);
            if(AllStaticVariable.isInPingFen == false)
                QuestionBank.scorePoint6();
        });
    }

    private void loseScore()
    {
        if(!AllStaticVariable.isAgain)
        {
            createPingFenItem();
            pingFen.GetComponent<PingFenItem>().operate.text = "选择题：                   答题错误。";
            pingFen.GetComponent<PingFenItem>().score.text = "-1";
            MonoWay.Instance.starDown(1);
            pingFen.GetComponent<PingFenItem>().cross.SetActive(true);
        }
        else
        {
            AllStaticVariable.isAgain = false;
        }
        GameObject wrongGo = (GameObject)Instantiate(Resources.Load("Prefabs/all/Panel_wrong"));
        wrongGo.transform.parent = GameObject.Find("Canvas").transform;
        wrongGo.transform.localScale = Vector3.one;
        wrongGo.transform.localPosition = Vector3.zero;
        wrongGo.transform.localEulerAngles = Vector3.zero;
        //查看答案
        Button btn = wrongGo.transform.Find("Button_LookAnswer").GetComponent<Button>();
        btn.onClick.AddListener(() =>
        {
            //createPingFenItem();
            //pingFen.GetComponent<PingFenItem>().operate.text = "查    看：                   答案。";
            //pingFen.GetComponent<PingFenItem>().score.text = "-5";
            //MonoWay.Instance.starDown(5);
            //pingFen.GetComponent<PingFenItem>().cross.SetActive(true);

            Destroy(wrongGo);
            analysisPanel();
        });
        //再接再厉按钮
        Button againBtn = wrongGo.transform.Find("Button_DoAgain").GetComponent<Button>();
        againBtn.onClick.AddListener(() =>
        {
            AllStaticVariable.isAgain = true;
            MonoWay.Instance.CreateZhongDuPanel();
            Destroy(wrongGo);
        });
    }

    private void analysisPanel()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load("Prefabs/all/Panel_analysis"));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text3").GetComponent<TextMeshProUGUI>().text = "M样症状：恶心、呕吐、腹泻、出汗、瞳孔缩小、心率减慢、括约肌松弛、瞳孔括约肌收缩、血压下降\n" +
                                                                                  "N样症状：肌肉抽动或强直、血压升高、瘫痪、血压升高、心脏兴奋\n" +
                                                                                  "中枢神经系统症状：烦躁或昏迷\n" +
                                                                                  "局部损伤：局部皮肤发红或缺损";
        analysisGo.transform.Find("Button_QueDing").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if (AllStaticVariable.isInPingFen == false)
                QuestionBank.scorePoint6();
        });
    }

    private void createPingFenItem()
    {
        pingFen = PingFenItem.Init();       
        pingFen.GetComponent<PingFenItem>().day.text = AllStaticVariable.day;
        pingFen.GetComponent<PingFenItem>().mission.text = "临床诊断";
        pingFen.GetComponent<PingFenItem>().property.text = "临床诊断";

        pingFen.GetComponent<PingFenItem>().analysisButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            print("22");
            GameObject analysisGo = (GameObject)Instantiate(Resources.Load("Prefabs/all/Panel_analysis"));
            analysisGo.transform.parent = GameObject.Find("Canvas").transform;
            analysisGo.transform.localScale = Vector3.one;
            analysisGo.transform.localPosition = Vector3.zero;
            analysisGo.transform.localEulerAngles = Vector3.zero;
            analysisGo.transform.Find("Text3").GetComponent<TextMeshProUGUI>().text = "M样症状：恶心、呕吐、腹泻、出汗、瞳孔缩小、心率减慢、括约肌松弛、瞳孔括约肌收缩、血压下降\n" +
                                                                                      "N样症状：肌肉抽动或强直、血压升高、瘫痪、血压升高、心脏兴奋\n" +
                                                                                      "中枢神经系统症状：烦躁或昏迷\n" +
                                                                                      "局部损伤：局部皮肤发红或缺损";
            analysisGo.transform.Find("Button_QueDing").GetComponent<Button>().onClick.AddListener(() =>
            {
                Destroy(analysisGo);
            });
        });
        pingFen.GetComponent<PingFenItem>().qusetionButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            MonoWay.Instance.CreateZhongDuPanel();
        });


    }
}
