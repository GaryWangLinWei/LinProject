using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceQuestionPanel : MonoBehaviour {
    public GameObject answerGrid;               //  回答的格子
    public GameObject answerGridChildPrefab;    //  回答格子的预设体
    public TextMeshProUGUI questionText;        //  问题文本
    public string question;                     //  文本内容
    public TextMeshProUGUI titleText;           //  问题标题
    public string title;                        //  标题
    public string analysis = null;              //  解析
    public GameObject CannotChoose;             //  无法选择层
    public Button TiJiaoBtn;                    //  提交按钮
    public Image BgPic;                         //  背景图

    public List<string> answers;
    List<TextMeshProUGUI> answerText = new List<TextMeshProUGUI>();
    List<Toggle> toggles = new List<Toggle>();
    private GameObject correctPanel;
    private GameObject errorPanel;
    //正确答案
    public int[] corrects;
    public string correctText;
    //不用查看解析
    public Button.ButtonClickedEvent submitCall;
    //查看解析
    public Button.ButtonClickedEvent analysisCall;
    //查看题目(显示答案用)
    public Button.ButtonClickedEvent showQuestionCall;
    //查看题目(再做一遍用)
    public Button.ButtonClickedEvent showQuestionCall2;
    //直接下一题
    public Button.ButtonClickedEvent NextAnswerCall;
    public int score;


    //评分预制件
    public string mission;
    public string operate;
    public string getScore;
    public string property;

    // Use this for initialization
    void Start()
    {
        Init();
    }

    public void Init()
    {
        correctPanel = Resources.Load<GameObject>("Prefabs/all/Panel_right");
        errorPanel = Resources.Load<GameObject>("Prefabs/all/Panel_wrong");

        RectTransform rectTrans = transform as RectTransform;
        rectTrans.offsetMax = Vector2.zero;
        rectTrans.offsetMin = Vector2.zero;
        questionText.text = question;
        titleText.text = title;
        for (int i = 0; i < answers.Count; i++)
        {
            GameObject go = Instantiate(answerGridChildPrefab);
            go.transform.parent = answerGrid.transform;
            Toggle toggle = go.GetComponent<Toggle>();
            go.transform.localScale = Vector3.one;
            toggles.Add(toggle);
            
            switch(i)
            {
                case 0:
                    go.transform.localPosition = new Vector3(6.9f, -33, 0);
                    break;
                case 1:
                    go.transform.localPosition = new Vector3(554f, -33, 0);
                    break;
                case 2:
                    go.transform.localPosition = new Vector3(6.9f, -343, 0);
                    break;
                case 3:
                    go.transform.localPosition = new Vector3(554, -343, 0);
                    break;
            }
            if (corrects.Length == 1)
                toggle.group = GetComponentInChildren<ToggleGroup>();
            answerText.Add(go.transform.Find("Label").GetComponent<TextMeshProUGUI>());
        }
        print(AllStaticVariable.IsShowAnswer);
        if (AllStaticVariable.IsShowAnswer == true && !AllStaticVariable.isInPingFen)
        {
            CannotChoose.SetActive(true);
            print(corrects.Length);
            for (int i = 0; i < corrects.Length; i++)
            {
                answerGrid.transform.GetChild(corrects[i]).GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.yellow;
                answerGrid.transform.GetChild(corrects[i]).GetComponent<Toggle>().isOn = true;
            }
            TiJiaoBtn.onClick = NextAnswerCall;
            TiJiaoBtn.onClick.AddListener(() =>
            {
                Destroy(this.gameObject);
            });

            //AllStaticVariable.IsShowAnswer = false;
        }
        //answerGrid.GetComponent<GridLayoutGroup>().CalculateLayoutInputVertical();
        for (int i = 0; i < answerText.Count; i++)
        {
            answerText[i].text = answers[i];
        }
    }

    public void submit()
    {
        print("333333");
        if (AllStaticVariable.isInPingFen == true)
        {
            print("在评分中");
            Destroy(gameObject);
            return;
        }

        int index = -1;
        for (int i = 0; i < toggles.Count; i++)
        {
            if (toggles[i].isOn)
            {
                index = i;
                break;
            }
        }
        if (index == -1)
        {
            Debug.Log("您还没有选择答案，请选择！");
            return;
        }
        if (judgeAnswer())
        {
            //重新答对，不计分
            if (!AllStaticVariable.isAgain)
            {
                GameObject pingFen = createPingFenItem();
                pingFen.GetComponent<PingFenItem>().operate.text = "选择题：                   答题正确。";
                pingFen.GetComponent<PingFenItem>().score.text = "0";
                MonoWay.Instance.starUp(1);
                pingFen.GetComponent<PingFenItem>().gou.SetActive(true);
            }
            else
            {
                AllStaticVariable.isAgain = false;
            }
            print("回答正确");
            GameObject go = Instantiate(correctPanel);
            go.transform.parent = GameObject.Find("Canvas").transform;
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            go.transform.localEulerAngles = Vector3.zero;
            Button btn = go.transform.GetChild(1).GetComponent<Button>();
            Button btn2 = go.transform.GetChild(2).GetComponent<Button>();
            if (analysis == "")
            {
                btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "确    定";
                btn.onClick = submitCall;
            }            
            else
            {
                btn2.gameObject.SetActive(true);
                btn2.onClick = submitCall;
                btn.transform.localPosition = new Vector3(123,-107,0);
                btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "课题解析";
                btn.onClick = analysisCall;
            }
            btn.onClick.AddListener(() =>
            {
                Destroy(go);
            });
            btn2.onClick.AddListener(() =>
            {
                Destroy(go);
            });
        }
        else
        {
            if(!AllStaticVariable.isAgain)
            {
                GameObject pingFen = createPingFenItem();
                pingFen.GetComponent<PingFenItem>().operate.text = "选择题：                   答题错误。";
                pingFen.GetComponent<PingFenItem>().score.text = "-1";
                MonoWay.Instance.starDown(1);
                pingFen.GetComponent<PingFenItem>().cross.SetActive(true);
                print("回答错误");
            }
            else
            {
                AllStaticVariable.isAgain = false;
            }           
            GameObject go = Instantiate(errorPanel);
            go.transform.parent = GameObject.Find("Canvas").transform;
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            go.transform.localEulerAngles = Vector3.zero;
            //查看答案按钮
            Button btn = go.transform.Find("Button_LookAnswer").GetComponent<Button>();
            if (analysis == "")
            {
                print("1111111");
                btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "查看答案";
                btn.onClick = showQuestionCall;
                btn.onClick.AddListener(() =>
                {
                    AllStaticVariable.IsShowAnswer = true;
                    Destroy(go);
                });
            }
            else
            {
                btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "课题解析";
                btn.onClick = analysisCall;
                btn.onClick.AddListener(() =>
                {
                    //if (!AllStaticVariable.isInPingFen)
                    //{
                    //    GameObject lookAnswerPingFen = createPingFenItem();
                    //    lookAnswerPingFen.GetComponent<PingFenItem>().operate.text = "查    看：                   答案。";
                    //    lookAnswerPingFen.GetComponent<PingFenItem>().score.text = "-5";
                    //    MonoWay.Instance.starDown(5);
                    //    lookAnswerPingFen.GetComponent<PingFenItem>().cross.SetActive(true);
                    //}
                    Destroy(go);
                });
            }

            //再接再厉按钮
            Button againBtn = go.transform.Find("Button_DoAgain").GetComponent<Button>();
            againBtn.onClick = showQuestionCall2;
            againBtn.onClick.AddListener(() =>
            {
                print(AllStaticVariable.IsShowAnswer);
                AllStaticVariable.isAgain = true;
                Destroy(go);
            });
        }
        Destroy(gameObject);
    }

    //判断答案是否正确
    private bool judgeAnswer()
    {
        for (int i = 0; i < corrects.Length; i++)
        {
            if (!toggles[corrects[i]].isOn)
                return false;
        }
        for (int i = 0; i < toggles.Count; i++)
        {
            if (Array.IndexOf(corrects, i) == -1 && toggles[i].isOn)
                return false;
        }
        return true;
    }
    //创建记录
    private GameObject createPingFenItem()
    {
        GameObject pingFen = PingFenItem.Init();
        pingFen.GetComponent<PingFenItem>().day.text = AllStaticVariable.day;
        pingFen.GetComponent<PingFenItem>().mission.text = mission;
        pingFen.GetComponent<PingFenItem>().property.text = property;
        pingFen.GetComponent<PingFenItem>().qusetionButton.GetComponent<Button>().onClick = showQuestionCall;
        pingFen.GetComponent<PingFenItem>().analysisButton.GetComponent<Button>().onClick = analysisCall;
        return pingFen;
    }
}
