using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickQuestion : MonoBehaviour
{
    public bool IsChoose = false;

    public Transform QuestionParent;

    public GameObject ZheDangPanel;
    //剩余问题数
    public TextMeshProUGUI LeftNum;
    //选择问题
    private List<Transform> Answers = new List<Transform>();
    //扣除星星数
    private int ReduceStarNum = 0;

    // Use this for initialization
    void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onQuestionClick()
    {
        if (!IsChoose)
        {
            IsChoose = true;
            transform.GetComponent<Image>().overrideSprite =
                Resources.Load("smallPic/bingShiCollect/choose", typeof(Sprite)) as Sprite;
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0.33f, 0.33f, 0.33f);
            transform.GetChild(0).GetComponent<ChangeTextColor>().enabled = false;
        }
        else
        {
            IsChoose = false;
            transform.GetComponent<Image>().overrideSprite =
                Resources.Load("smallPic/MissionList/blank", typeof(Sprite)) as Sprite;
            transform.GetChild(0).GetComponent<ChangeTextColor>().enabled = true;
        }
    }

    private void startTalk(List<Transform> answer)
    {
        print("in");
        print(answer.Count);
        //创建对话
        GameObject talkGo = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_talk"));
        talkGo.transform.parent = GameObject.Find("Canvas").transform;
        talkGo.transform.localScale = Vector3.one;
        talkGo.transform.localPosition = new Vector3(0, -20, 0);
        talkGo.transform.localEulerAngles = Vector3.zero;
        //赋值对话
        Talk talk = talkGo.GetComponent<Talk>();
        talk.doctorAudio.Clear();
        talk.patientAudio.Clear();
        for (int i = 0; i < answer.Count; i++)
        {
            AudioClip temp1 = Resources.Load("ask/" + answer[i].name) as AudioClip;
            string string1 = AllStaticVariable.QuestionStrings[int.Parse(answer[i].name)];
            talk.doctorAudio.Add(temp1);
            talk.doctorTexts.Add(string1);
            AudioClip temp2 = Resources.Load("answer/" + answer[i].name) as AudioClip;
            string string2 = AllStaticVariable.AnswerStrings[int.Parse(answer[i].name)];
            talk.patientAudio.Add(temp2);
            talk.patientTexts.Add(string2);
        }

    }

    //创建评分item
    private void createPingFen(Transform questionItem)
    {
        GameObject pingFenItem = PingFenItem.Init();
        pingFenItem.GetComponent<PingFenItem>().day.text = AllStaticVariable.day;
        switch (AllStaticVariable.wenZhenTime)
        {
            case 1:
                pingFenItem.GetComponent<PingFenItem>().mission.text = "急诊问诊";
                break;
            case 2:
                pingFenItem.GetComponent<PingFenItem>().mission.text = "EICU问诊";
                break;
            case 3:
                pingFenItem.GetComponent<PingFenItem>().mission.text = "EICU问诊";
                break;
            case 4:
                pingFenItem.GetComponent<PingFenItem>().mission.text = "EICU问诊";
                break;
            case 5:
                pingFenItem.GetComponent<PingFenItem>().mission.text = "EICU问诊";
                break;
            case 6:
                pingFenItem.GetComponent<PingFenItem>().mission.text = "EICU问诊";
                break;
            case 7:
                pingFenItem.GetComponent<PingFenItem>().mission.text = "EICU问诊";
                break;
            case 8:
                pingFenItem.GetComponent<PingFenItem>().mission.text = "普通病房问诊";
                break;
            case 9:
                pingFenItem.GetComponent<PingFenItem>().mission.text = "门诊问诊";
                break;
        }
        pingFenItem.GetComponent<PingFenItem>().property.text = "医患沟通";
        //pingFenItem.GetComponent<PingFenItem>().qusetionButton.GetComponent<Button>().onClick = showQuestionCall;
        pingFenItem.GetComponent<PingFenItem>().qusetionButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>()
            .text = "某个问题";
        pingFenItem.GetComponent<PingFenItem>().qusetionButton.GetComponent<RectTransform>().localPosition = new Vector3(-242.2f, -1.5f,0);
        pingFenItem.GetComponent<PingFenItem>().qusetionButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_BingShiQuestion"));
            go.transform.parent = GameObject.Find("Canvas").transform;
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            go.transform.localEulerAngles = Vector3.zero;
            string questionText = questionItem.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            go.transform.Find("Text").GetComponent<TextMeshProUGUI>().text =
                getTextWithoutNum(questionText);
        });
        pingFenItem.GetComponent<PingFenItem>().analysisButton.SetActive(false);
        if (AllStaticVariable.QuestionScore[int.Parse(questionItem.name)] == 1)
        {
            pingFenItem.GetComponent<PingFenItem>().gou.SetActive(true);
            pingFenItem.GetComponent<PingFenItem>().operate.text = "向病患询问：                   很合理。";
            pingFenItem.GetComponent<PingFenItem>().score.text = "0";
        }
        else if (AllStaticVariable.QuestionScore[int.Parse(questionItem.name)] == 0)
        {
            pingFenItem.GetComponent<PingFenItem>().cross.SetActive(true);
            pingFenItem.GetComponent<PingFenItem>().operate.text = "向病患询问：                   并非迫切问题。";
            pingFenItem.GetComponent<PingFenItem>().score.text = "0";
        }
        else if (AllStaticVariable.QuestionScore[int.Parse(questionItem.name)] == -1)
        {
            ReduceStarNum += 2;
            pingFenItem.GetComponent<PingFenItem>().cross.SetActive(true);
            pingFenItem.GetComponent<PingFenItem>().operate.text = "向病患询问：                   紧急时刻不应提出此类问题。";
            pingFenItem.GetComponent<PingFenItem>().score.text = "-2";
        }
    }

    public void CreateLoseChoice()
    {
        string tempText = null;
        GameObject bingShiPanel = null;
        switch(AllStaticVariable.wenZhenTime)
        {
            case 1:
                tempText = "急诊问诊";
                bingShiPanel = AllNeedUI.Instance.BingShiQuestionList[AllStaticVariable.wenZhenTime - 1];
                break;
            case 2:
                tempText = "EICU问诊";
                bingShiPanel = AllNeedUI.Instance.BingShiQuestionList[AllStaticVariable.wenZhenTime - 1];
                break;
            case 3:
                tempText = "EICU问诊";
                bingShiPanel = AllNeedUI.Instance.BingShiQuestionList[AllStaticVariable.wenZhenTime - 1];
                break;
            case 4:
                tempText = "EICU问诊";
                bingShiPanel = AllNeedUI.Instance.BingShiQuestionList[AllStaticVariable.wenZhenTime - 1];
                break;
            case 5:
                tempText = "EICU问诊";
                bingShiPanel = AllNeedUI.Instance.BingShiQuestionList[AllStaticVariable.wenZhenTime - 1];
                break;
            case 6:
                tempText = "EICU问诊";
                bingShiPanel = AllNeedUI.Instance.BingShiQuestionList[AllStaticVariable.wenZhenTime - 1];
                break;
            case 7:
                tempText = "EICU问诊";
                bingShiPanel = AllNeedUI.Instance.BingShiQuestionList[AllStaticVariable.wenZhenTime - 1];
                break;
            case 8:
                tempText = "普通病房问诊";
                bingShiPanel = AllNeedUI.Instance.BingShiQuestionList[AllStaticVariable.wenZhenTime - 1];
                break;
            case 9:
                return;
            case 10:
                tempText = "门诊问诊";
                bingShiPanel = AllNeedUI.Instance.BingShiQuestionList[AllStaticVariable.wenZhenTime - 1];
                break;
        }
        for (int i = 0; i < bingShiPanel.transform.childCount; i++)
        {
            //每个问题
            Transform eachQuestion = bingShiPanel.transform.GetChild(i);
            //判断每个问题是否为正确且未被选择
            if (AllStaticVariable.QuestionScore[int.Parse(eachQuestion.name)] == 1 && 
                eachQuestion.GetComponent<IsRightQuestion>().IsRight)
            {
                GameObject pingFenItem = PingFenItem.Init();
                pingFenItem.GetComponent<PingFenItem>().day.text = AllStaticVariable.day;
                pingFenItem.GetComponent<PingFenItem>().mission.text = tempText;
                pingFenItem.GetComponent<PingFenItem>().property.text = "医患沟通";
                pingFenItem.GetComponent<PingFenItem>().score.text = "-5";
                ReduceStarNum += 5;
                pingFenItem.GetComponent<PingFenItem>().operate.text = "病史询问有遗漏问题：";
                pingFenItem.GetComponent<PingFenItem>().analysisButton.SetActive(false);
                pingFenItem.GetComponent<PingFenItem>().cross.SetActive(true);
                pingFenItem.GetComponent<PingFenItem>().qusetionButton.GetComponent<RectTransform>().localPosition =
                    new Vector3(-160,0,0);
                pingFenItem.GetComponent<PingFenItem>().qusetionButton.GetComponent<Button>().onClick.AddListener(() =>
                {
                    GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_BingShiQuestion"));
                    go.transform.parent = GameObject.Find("Canvas").transform;
                    go.transform.localScale = Vector3.one;
                    go.transform.localPosition = Vector3.zero;
                    go.transform.localEulerAngles = Vector3.zero;
                    string questionText = eachQuestion.GetChild(0).GetComponent<TextMeshProUGUI>().text;
                    go.transform.Find("Text").GetComponent<TextMeshProUGUI>().text =
                        getTextWithoutNum(questionText);
                });
            }
        }
    }

    //获取问题text无题号部分
    private static string getTextWithoutNum(string text)
    {
        string[] array = text.Split(' ');
        return array[array.Length - 1];
    }

    public void AskQuestion()
    {
        AllStaticVariable.IsFinishTodayAsk = true;
        if (AllStaticVariable.wenZhenTime == 1 && !AllStaticVariable.IsCreateRecord1)
        {
            CreateBodyResult.Day1Item4();
            AllStaticVariable.IsCreateRecord1 = true;
        }
        if (AllStaticVariable.day == "两周后")
        {
            AllStaticVariable.IsMenZhenAsk = true;
        }
        if(AllStaticVariable.day == "第七天" && AllStaticVariable.IsRemoveBDG)
        {
            MonoWay.Instance.OpenTip("请结束今天工作");
        }
        ZheDangPanel.SetActive(true);
        for (int i = 0; i < QuestionParent.childCount; i++)
        {
            if (QuestionParent.GetChild(i).GetComponent<ClickQuestion>().IsChoose)
            {
                QuestionParent.GetChild(i).GetComponent<IsRightQuestion>().IsRight = false;
                Answers.Add(QuestionParent.GetChild(i));
            }
        }
        LeftNum.text = CountLeftNum().ToString();
        //创建选择项评分item
        for (int i = 0; i < Answers.Count; i++)
        {
            createPingFen(Answers[i]);
        }
        //创建未选项评分item
        CreateLoseChoice();
        //结算星星
        print(ReduceStarNum);
        MonoWay.Instance.starDown(ReduceStarNum);
        if (AllNeedUI.Instance.ChaTiLeftLabel.text == "0" && AllStaticVariable.IsFinishTodayAsk)
        {
            if(AllStaticVariable.wenZhenTime == 1)
            {
                MonoWay.Instance.OpenTip("请点击患者治疗，进行三区四级分诊");
            }
            else if(AllStaticVariable.wenZhenTime == 5 )
            {
                MonoWay.Instance.OpenTip("请点击患者治疗");
            }
            else if (AllStaticVariable.wenZhenTime == 6)
            {
            }
            else
            {
                MonoWay.Instance.OpenTip("请点击患者治疗");
            }
            
            AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().enabled = true;
        }
        startTalk(Answers);
    }

    //计算剩余问题
    private int CountLeftNum()
    {
        int res = 0;
        for (int i = 0; i < QuestionParent.childCount; i++)
        {
            if (QuestionParent.GetChild(i).GetComponent<IsRightQuestion>().IsRight)
            {
                res++;
            }

        }
        return res;
    }
    //出现问诊tip
    public void OpenWenZhenTip()
    {
        
    }
}
