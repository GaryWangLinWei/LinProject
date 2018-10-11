using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class YaoPinMuLu : MonoBehaviour
{
    //评分item预制件
    private GameObject pingFenGo;
    //用药次数
    private int medicineTime;
    //选项得分数组
    private int[] choiceScore;
    //选项们
    public Toggle[] choices;

    public Sprite[] spriteYao;

    public void judgeAnswer()
    {
        medicineTime = AllStaticVariable.medicineTime;
        switch (medicineTime)
        {
            //第一天用药
            case 0:
                if(!AllStaticVariable.IsInEICU)
                    choiceScore = new int[14] { 1, 1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
                else
                    choiceScore = new int[14] { -1, 1, 1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
                break;
            //第二天用药
            case 1:
                choiceScore = new int[14] { 1, 1, 1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
                break;
            //第三天用药
            case 2:
                choiceScore = new int[14] { 0, 1, 1, 1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
                break;
            //第七天
            case 3:
                choiceScore = new int[14] { 0, 1, 1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
                break;
            //第八天
            case 4:
                choiceScore = new int[14] { 0, 1, 1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
                break;
            //第八天普通
            case 5:
                choiceScore = new int[14] { 0, 1, 1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
                break;
        }
        checkEachAnswer();
        AllStaticVariable.isAgain = false;
        Destroy(gameObject);
    }
    //创建评分item
    private void createPingFenItem()
    {
        pingFenGo = PingFenItem.Init();
        pingFenGo.GetComponent<PingFenItem>().day.text = AllStaticVariable.day;
        pingFenGo.GetComponent<PingFenItem>().mission.text = "药物治疗";
        pingFenGo.GetComponent<PingFenItem>().property.text ="专业知识";
        pingFenGo.GetComponent<PingFenItem>().qusetionButton.SetActive(false);
        pingFenGo.GetComponent<PingFenItem>().analysisButton.SetActive(false);
    }
    //核对每一个选项
    private void checkEachAnswer()
    {
        int WrongCount = 0;
        string rightAnswerText = null;
        //选择正确数量
        int index = 0;
        //正确答案数量
        int rightIndex = 0;
        for (int i = 0; i < choices.Length; i++)
        {
            //if (choices[i].isOn)
            //{
            //    index++;
            //}

        }
        if (index == 0)
        {
            Debug.Log("您还没有选择答案，请选择！");
        }
        for (int i = 0; i < 14; i++)
        {
            //获取正确答案数量
            if (choiceScore[i] == 1)
            {
                rightIndex++;
            }
            //获取正确答案药名
            if (choiceScore[i] == 1)
            {
                string name = choices[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
                if(rightAnswerText != null)
                    rightAnswerText = rightAnswerText+"、"+name;
                else
                    rightAnswerText = rightAnswerText + name;
            }
            //获取选择正确答案数量
            if (choices[i].isOn && choiceScore[i] == 1)
            {
                index++;
                ////重做答对不加分
                //if (!AllStaticVariable.isAgain)
                //{
                //    createPingFenItem();
                //    pingFenGo.GetComponent<PingFenItem>().operate.text = "选择正确的药物进行治疗。";
                //    pingFenGo.GetComponent<PingFenItem>().gou.SetActive(true);
                //    pingFenGo.GetComponent<PingFenItem>().score.text = "0";
                //    totalScore += 1;
                //}
            }
            //获取选择错误答案数量
            else if (choices[i].isOn && choiceScore[i] == -1)
            {
                print("扣分");
                WrongCount++;
                //createPingFenItem();
                //string name = choices[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
                //pingFenGo.GetComponent<PingFenItem>().operate.text = "当前选择"+name+"药物进行治疗，是错误的。";
                //pingFenGo.GetComponent<PingFenItem>().cross.SetActive(true);
                //pingFenGo.GetComponent<PingFenItem>().score.text = choiceScore[i].ToString();
                //totalScore += choiceScore[i];
            }
        }

        if (WrongCount != 0 || (index != rightIndex && WrongCount == 0))
        {
            if (!AllStaticVariable.isAgain)
            {
                createPingFenItem();
                pingFenGo.GetComponent<PingFenItem>().operate.text = "选择错误的药物进行治疗。";
                pingFenGo.GetComponent<PingFenItem>().cross.SetActive(true);
                pingFenGo.GetComponent<PingFenItem>().score.text = "-1";
                MonoWay.Instance.starDown(1);
            }
            GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_wrong"));
            go.transform.parent = GameObject.Find("Canvas").transform;
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            go.transform.localEulerAngles = Vector3.zero;
            Button btn = go.GetComponentInChildren<Button>();
            //查看答案
            btn.onClick.AddListener(() =>
            {
                ////创建评分Item
                //createPingFenItem();
                //pingFenGo.GetComponent<PingFenItem>().operate.text = "查看药物选项答案";
                //pingFenGo.GetComponent<PingFenItem>().cross.SetActive(true);
                //pingFenGo.GetComponent<PingFenItem>().score.text = "-5";
                //MonoWay.Instance.starDown(5);
                //创造正确答案
                GameObject rightAnswerGo = (GameObject)Instantiate(Resources.Load("Prefabs/all/Panel_RightMedcine"));
                rightAnswerGo.transform.parent = GameObject.Find("Canvas").transform;
                rightAnswerGo.transform.localScale = Vector3.one;
                rightAnswerGo.transform.localPosition = Vector3.zero;
                rightAnswerGo.transform.localEulerAngles = Vector3.zero;
                Button rightBtn = rightAnswerGo.GetComponentInChildren<Button>();
                rightAnswerGo.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = rightAnswerText;
                rightBtn.onClick.AddListener(() =>
                {
                    MonoWay.Instance.DongHua(spriteYao, 2f);
                    if (AllStaticVariable.ZhiLiaoTime == 2)
                    {
                        QuestionBank.scorePoint19();
                    }
                    else if (AllStaticVariable.ZhiLiaoTime == 21 && AllNeedUI.Instance.ZhiLiaoLeftLabel.text == "0")
                    {
                        QuestionBank.scorePoint20();
                    }
                    else if (AllNeedUI.Instance.ZhiLiaoLeftLabel.text == "0" && AllStaticVariable.ZhiLiaoTime == 6)
                    {
                        AllNeedUI.Instance.EmergencyWarning.SetActive(true);
                        //播放快的节奏音效
                        AllNeedUI.Instance.SlowAudio.enabled = false;
                        AllNeedUI.Instance.FastAudio.enabled = true;
                        AllNeedUI.Instance.FastAudio.volume = 0.5f;
                        MonoWay.Instance.OccurFastMusic();
                    }
                    else if (AllNeedUI.Instance.ZhiLiaoLeftLabel.text == "0" && AllStaticVariable.ZhiLiaoTime == 7)
                    {
                        QuestionBank.scorePoint46();
                    }
                    Destroy(rightAnswerGo);
                });
                Destroy(go);
            });
            //再接再厉按钮
            Button againBtn = go.transform.Find("Button_DoAgain").GetComponent<Button>();
            againBtn.onClick.AddListener(() =>
            {
                AllStaticVariable.isAgain = true;
                GameObject YaoPinGo = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_YaoPinMuLu"));
                YaoPinGo.transform.parent = GameObject.Find("Canvas").transform;
                YaoPinGo.transform.localPosition = Vector3.zero;
                Destroy(go);
            });
        }
        else
        {
            if (!AllStaticVariable.isAgain)
            {
                createPingFenItem();
                pingFenGo.GetComponent<PingFenItem>().operate.text = "选择正确的药物进行治疗。";
                pingFenGo.GetComponent<PingFenItem>().gou.SetActive(true);
                pingFenGo.GetComponent<PingFenItem>().score.text = "0";
            }
            GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_right"));
            go.transform.parent = GameObject.Find("Canvas").transform;
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            go.transform.localEulerAngles = Vector3.zero;
            Button btn = go.GetComponentInChildren<Button>();
            btn.onClick.AddListener(() =>
            {
                MonoWay.Instance.DongHua(spriteYao, 2f);
                if (AllStaticVariable.ZhiLiaoTime == 2)
                {
                    QuestionBank.scorePoint19();
                }
                else if (AllStaticVariable.ZhiLiaoTime == 21 && AllNeedUI.Instance.ZhiLiaoLeftLabel.text == "0")
                {
                    QuestionBank.scorePoint20();
                }
                else if(AllNeedUI.Instance.ZhiLiaoLeftLabel.text == "0" && AllStaticVariable.ZhiLiaoTime == 3)
                {
                    MonoWay.Instance.OpenTip("请结束今天工作");
                }
                else if (AllNeedUI.Instance.ZhiLiaoLeftLabel.text == "0" && AllStaticVariable.ZhiLiaoTime == 6)
                {
                    AllNeedUI.Instance.EmergencyWarning.SetActive(true);
                    //播放快的节奏音效
                    AllNeedUI.Instance.SlowAudio.enabled = false;
                    AllNeedUI.Instance.FastAudio.enabled = true;
                    AllNeedUI.Instance.FastAudio.volume = 0.5f;
                    MonoWay.Instance.OccurFastMusic();
                }
                else if (AllNeedUI.Instance.ZhiLiaoLeftLabel.text == "0" && AllStaticVariable.ZhiLiaoTime == 7)
                {
                    QuestionBank.scorePoint46();
                }
                Destroy(go);
            });
        }
        if(AllStaticVariable.medicineTime == 0 && !AllStaticVariable.IsInEICU)
        {
            return;
        }
        AllStaticVariable.medicineTime++;
    }



}
