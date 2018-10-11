using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonoWay : Monosingleton<MonoWay>
{
    //增加星星
    public void starUp(int num)
    {
        return;
    }
    //减少星星
    public void starDown(int num)
    {
        if (num == 0)
        {
            return;
        }
        AllStaticVariable.star -= num;
        AllNeedUI.Instance.starText.text = AllStaticVariable.star.ToString();

        //加载上浮星星
        GameObject downStar = (GameObject)GameObject.Instantiate(Resources.
            Load("Prefabs/DownStar"));
        downStar.transform.SetParent(AllNeedUI.Instance.StarParent.transform, false);
        downStar.transform.localPosition = Vector3.zero;
    }


    //刷新病史     
    public void ReFreshBingShi()
    {
        if(!AllStaticVariable.IsFinishTodayAsk)
        {
            CreateLoseChoice();
        }
        //第一个toggle为on
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                AllNeedUI.Instance.BingShiToggles[i].GetComponent<Toggle>().isOn = true;
                continue;
            }
            AllNeedUI.Instance.BingShiToggles[i].GetComponent<Toggle>().isOn = false;
        }  
        //关闭所有问题panel
        for (int i = 0; i < 12; i++)
        {
            AllNeedUI.Instance.BingShiQuestionPanels[i].SetActive(false);
        }
        Transform QuestionParent = AllNeedUI.Instance.BingShiQuestionList[AllStaticVariable.wenZhenTime].transform;
        AllNeedUI.Instance.BingShiQuestionPanels[AllStaticVariable.wenZhenTime].SetActive(true);
        int res = 0;
        for (int i = 0; i < QuestionParent.childCount; i++)
        {
            if (QuestionParent.GetChild(i).GetComponent<IsRightQuestion>().IsRight)
            {
                res++;
            }
        }
        AllNeedUI.Instance.WenZhenLeftLabel.text = res.ToString();
        AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().enabled = false;
        AllStaticVariable.IsFinishTodayAsk = false;

        AllStaticVariable.wenZhenTime++;
    }
    //刷新病史前，检查遗漏
    private void CreateLoseChoice()
    {
        string tempText = null;
        GameObject bingShiPanel = null;
        int ReduceStarNum = 0;
        switch (AllStaticVariable.wenZhenTime)
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
                    new Vector3(-160, 0, 0);
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
        MonoWay.Instance.starDown(ReduceStarNum);
    }
    //获取问题text无题号部分
    private string getTextWithoutNum(string text)
    {
        string[] array = text.Split(' ');
        return array[array.Length - 1];
    }

    //切换黑屏
    public void HeiPing()
    {
        AllNeedUI.Instance.StarProgress.GetComponent<RectTransform>().sizeDelta += new Vector2(128 / 7, 0);
        AllNeedUI.Instance.HeiPing.SetActive(true);
        AllNeedUI.Instance.HeiPing.GetComponent<Image>().DOFade(1,1);
        StartCoroutine(DelayHeiPing());
    }
    IEnumerator DelayHeiPing()
    {
        yield return new WaitForSeconds(1);
        MonoWay.Instance.OpenTip("新的一天，请点击病史采集或患者查体");
        switch (AllStaticVariable.day)
        {
            case "第二天":
                ResetXindian(132,72,37.2f,20,110);
                //AllNeedUI.Instance.ZhengYanCamera.SetActive(true);
                CamMove.Instance.MoveCamto(4);
                break;
            case "第三天":
                CamMove.Instance.MoveCamto(4);
                ResetXindian(182, 98, 38.8f, 32, 145);
                Sprite[] list = {AllNeedUI.Instance.spriteList[0], AllNeedUI.Instance.spriteList[1], AllNeedUI.Instance.spriteList[2] , AllNeedUI.Instance.spriteList[3]};
                MonoWay.Instance.DongHua(list, 1f);
                //CreateBodyResult.Day3Item6();
                //MonoWay.Instance.OpenBingQingResult();
                AllNeedUI.Instance.HuShiReport.SetActive(true);
                break;
            case "第七天":
                ResetXindian(126, 76, 36.8f, 18, 72);
                CamMove.Instance.MoveCamto(4);
                AllNeedUI.Instance.FinishJobBtn.SetActive(false);
                break;
            case "第八天":
                ResetXindian(125, 81, 37.0f, 18, 73);
                CamMove.Instance.MoveCamto(4);
                AllNeedUI.Instance.FinishJobBtn.SetActive(false);
                AllNeedUI.Instance.PTWithPerson.SetActive(true);
                AllNeedUI.Instance.PTWithoutPerson.SetActive(false);
                break;
            case "第九天":
                CamMove.Instance.MoveCamto(7);
                MonoWay.Instance.CloseTip();              
                AllNeedUI.Instance.FinishJobBtn.SetActive(false);
                AllNeedUI.Instance.CallWarning.SetActive(true);
                AllNeedUI.Instance.PTWithPerson.SetActive(false);
                AllNeedUI.Instance.PTWithoutPerson.SetActive(true);
                AllNeedUI.Instance.EICUPatient.SetActive(false);
                StartCoroutine(DelayCloseTip());
                break;
            case "两周后":
                MonoWay.Instance.OpenTip("请点击病史采集或患者查体");
                AllNeedUI.Instance.FinishJobBtn.SetActive(false);
                CamMove.Instance.MoveCamto(9);
                AllNeedUI.Instance.MenZhenTip.SetActive(true);
                AllNeedUI.Instance.MenZhenYiHuan.SetActive(true);
                AllNeedUI.Instance.ChuYuanPanel.SetActive(false);
                break;
        }
        AllNeedUI.Instance.HeiPing.GetComponent<Image>().DOFade(0, 1);
        AllNeedUI.Instance.HeiPing.SetActive(false);
    }
    //第八天黑屏专用
    public void HeiPingS()
    {
        AllNeedUI.Instance.BgNoise.gameObject.SetActive(false);
        AllNeedUI.Instance.StarProgress.GetComponent<RectTransform>().sizeDelta += new Vector2(128 / 7, 0);
        AllNeedUI.Instance.HeiPing.SetActive(true);
        AllNeedUI.Instance.HeiPing.GetComponent<Image>().DOFade(1, 1);
        StartCoroutine(DelayHeiPingS());
    }
    IEnumerator DelayHeiPingS()
    {
        yield return new WaitForSeconds(1);
        AllNeedUI.Instance.HeiPing.GetComponent<Image>().DOFade(0, 1);
        yield return new WaitForSeconds(1);
        AllNeedUI.Instance.ShiZhenWarning.SetActive(true);
        CreateBodyResult.Day8Item12();
        AllNeedUI.Instance.HeiPing.SetActive(false);
    }
    //进入EICU
    public void Go2EICU()
    {
        AllNeedUI.Instance.EICUPatient.SetActive(true);
        //AllNeedUI.Instance.FinishJobBtn.SetActive(true);
        AllNeedUI.Instance.JiZhenBingRen.SetActive(false);
        AllNeedUI.Instance.ToEICUCamera.SetActive(true);
    }
    //创建中毒表现
    public void CreateZhongDuPanel()
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_zhongDuBiaoXian"));
        go.transform.parent = GameObject.Find("Canvas").transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.localScale = Vector3.one;
    }

    /// <summary>
    /// 重新游戏
    /// </summary>
    public void ReStart()
    {
        PatientZhiLiao.ResetZhiLiao();
        PatientChaTi.ResetChaTi();
        AllStaticVariable.ResetVariable();
    }
    /// <summary>
    /// 播放幻灯片
    /// </summary>
    /// <param name="spriteList"></param>
    public void DongHua(Sprite[] spriteList,float time)
    {
        AllNeedUI.Instance.HDPMask.SetActive(true);
        StartCoroutine(HuanDengPianDelay(spriteList,time));
    }

    IEnumerator HuanDengPianDelay(Sprite[] spriteList,float time)
    {
        for (int i = 0; i < spriteList.Length; i++)
        {
            AllNeedUI.Instance.HuanDengPian.sprite = spriteList[i];
            yield return new WaitForSeconds(time);
            if (i == spriteList.Length - 1)
            {
                AllNeedUI.Instance.HDPMask.SetActive(false);
            }
        }       
    }

    public void PreferItem(Transform[] items)
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetAsFirstSibling();
        }
    }
    //提前查体
    public void PreferChaTiItem(Transform[] items)
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetSiblingIndex(3);
        }
    }

    //重置心电监护数据
    public void ResetXindian(int word1,int word2,float word3,int word4,int word5)
    {
        AllStaticVariable.TodayXueYa1 = word1;
        AllStaticVariable.TodayXueYa2 = word2;
        AllStaticVariable.TodayTiWen = word3;
        AllStaticVariable.TodayHuXi = word4;
        AllStaticVariable.TodayXinLv = word5;
    }
    //打开提示框
    public void OpenTip(string tip)
    {
        if(!AllStaticVariable.IsTip)
        {
            return;
        }
        AllNeedUI.Instance.BottomTip.SetActive(true);
        AllNeedUI.Instance.BottomTip.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = tip;
    }
    //关闭提示框
    public void CloseTip()
    {
        AllNeedUI.Instance.BottomTip.SetActive(false);
    }

    //关闭所有以及菜单
    public void CloseAllMainPanel()
    {
        AllNeedUI.Instance.mainMenuToggles[0].GetComponent<Toggle>().isOn = false;
        AllNeedUI.Instance.mainMenuToggles[1].GetComponent<Toggle>().isOn = false;
        AllNeedUI.Instance.mainMenuToggles[2].GetComponent<Toggle>().isOn = false;
        AllNeedUI.Instance.mainMenuToggles[3].GetComponent<Toggle>().isOn = false;
        AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().isOn = false;
        AllNeedUI.Instance.BingQingRecord.SetActive(false);
        AllNeedUI.Instance.missionList.SetActive(false);
        AllNeedUI.Instance.BingShiCollect.SetActive(false);
        AllNeedUI.Instance.ChaTiPanel.SetActive(false);
        AllNeedUI.Instance.ZhiLiaoPanel.SetActive(false);
    }
    //延时关闭门诊提示
    IEnumerator DelayCloseTip()
    {
        yield return new WaitForSeconds(3);
        AllNeedUI.Instance.MenZhenTip.SetActive(false);
    }
    //弹出病史记录操作记录
    public void OpenBingQingRecord()
    {
        AllNeedUI.Instance.BingQingRecord.SetActive(true);
        AllNeedUI.Instance.ChaTiPanel.SetActive(false);
        AllNeedUI.Instance.BingShiCollect.SetActive(false);
        AllNeedUI.Instance.ZhiLiaoPanel.SetActive(false);

        AllNeedUI.Instance.OperateNote.SetActive(true);
        AllNeedUI.Instance.TiWenNote.SetActive(false);
        AllNeedUI.Instance.ChaTiNote.SetActive(false);
        AllNeedUI.Instance.OperateToggle.isOn = true;
        AllNeedUI.Instance.TiWenToggle.isOn = false;
        AllNeedUI.Instance.ChaTiToggle.isOn = false;
        AllNeedUI.Instance.OperateToggle.transform.GetChild(0).GetComponent<Image>().overrideSprite =
            Resources.Load("smallPic/BingQingRecord/operateNote1", typeof(Sprite)) as Sprite;
        AllNeedUI.Instance.TiWenToggle.transform.GetChild(0).GetComponent<Image>().overrideSprite =
            Resources.Load("smallPic/BingQingRecord/TiWenNote1", typeof(Sprite)) as Sprite;
        AllNeedUI.Instance.ChaTiToggle.transform.GetChild(0).GetComponent<Image>().overrideSprite =
            Resources.Load("smallPic/BingQingRecord/ChaTiNote1", typeof(Sprite)) as Sprite;
    }
    //弹出病史记录查体结果
    public void OpenBingQingResult()
    {
        AllNeedUI.Instance.BingQingRecord.SetActive(true);
        AllNeedUI.Instance.ChaTiPanel.SetActive(false);
        AllNeedUI.Instance.BingShiCollect.SetActive(false);
        AllNeedUI.Instance.ZhiLiaoPanel.SetActive(false);

        AllNeedUI.Instance.OperateNote.SetActive(false);
        AllNeedUI.Instance.TiWenNote.SetActive(false);
        AllNeedUI.Instance.ChaTiNote.SetActive(true);
        AllNeedUI.Instance.OperateToggle.isOn = false;
        AllNeedUI.Instance.TiWenToggle.isOn = false;
        AllNeedUI.Instance.ChaTiToggle.isOn = true;
        AllNeedUI.Instance.OperateToggle.transform.GetChild(0).GetComponent<Image>().overrideSprite =
            Resources.Load("smallPic/BingQingRecord/operateNote2", typeof(Sprite)) as Sprite;
        AllNeedUI.Instance.TiWenToggle.transform.GetChild(0).GetComponent<Image>().overrideSprite =
            Resources.Load("smallPic/BingQingRecord/TiWenNote1", typeof(Sprite)) as Sprite;
        AllNeedUI.Instance.ChaTiToggle.transform.GetChild(0).GetComponent<Image>().overrideSprite =
            Resources.Load("smallPic/BingQingRecord/ChaTiNote2", typeof(Sprite)) as Sprite;
    }
    //延时
    #region
    public void DelayOpenWenZhenTip()
    {
        StartCoroutine(IDelayOpenWenZhenTip());
    }
    IEnumerator IDelayOpenWenZhenTip()
    {
        OpenBingQingResult();
        //yield return new WaitForSeconds(0.5f);
        AllNeedUI.Instance.BingShiDetial.SetActive(true);
        yield return new WaitForSeconds(1);
        //AllNeedUI.Instance.BingShiDetial.SetActive(true);
        //AllNeedUI.Instance.WenZhenTip.SetActive(true);
    }

    public void OccurFastMusic()
    {
        StartCoroutine(IOccurFastMusic());
    }
    IEnumerator IOccurFastMusic()
    {
        yield return new WaitForSeconds(0.5f);
        AllNeedUI.Instance.FastAudio.volume = 0.4f;
        yield return new WaitForSeconds(0.5f);
        AllNeedUI.Instance.FastAudio.volume = 0.3f;
        yield return new WaitForSeconds(0.5f);
        AllNeedUI.Instance.FastAudio.volume = 0.2f;
        yield return new WaitForSeconds(0.5f);
        AllNeedUI.Instance.FastAudio.volume = 0.15f;
    }


    public void DelayS4()
    {
        StartCoroutine(IDelayS4());      
    }
    IEnumerator IDelayS4()
    {
        yield return new WaitForSeconds(0.5f);
        QuestionBank.scorePoint4();
    }
    public void DelayS7()
    {
        StartCoroutine(IDelayS7());
    }
    IEnumerator IDelayS7()
    {
        yield return new WaitForSeconds(0.5f);
        QuestionBank.scorePoint7();
    }
    public void DelayS13()
    {
        StartCoroutine(IDelayS13());
    }
    IEnumerator IDelayS13()
    {
        yield return new WaitForSeconds(0.5f);
        QuestionBank.scorePoint13();
    }
    public void DelayS10()
    {
        StartCoroutine(IDelayS10());
    }
    IEnumerator IDelayS10()
    {
        yield return new WaitForSeconds(0.5f);
        QuestionBank.scorePoint10();
    }
    public void DelayS11()
    {
        StartCoroutine(IDelayS11());
    }
    IEnumerator IDelayS11()
    {
        yield return new WaitForSeconds(6f);
        QuestionBank.scorePoint11();
    }
    public void DelayS12()
    {
        StartCoroutine(IDelayS12());
    }
    IEnumerator IDelayS12()
    {
        yield return new WaitForSeconds(3f);
        QuestionBank.scorePoint12();
    }

    public void DelayS16()
    {
        StartCoroutine(IDelayS16());
    }
    IEnumerator IDelayS16()
    {
        yield return new WaitForSeconds(0.5f);
        QuestionBank.scorePoint16();
    }

    public void DelayS17()
    {
        StartCoroutine(IDelayS17());
    }
    IEnumerator IDelayS17()
    {
        yield return new WaitForSeconds(0.5f);
        QuestionBank.scorePoint17();
    }

    public void DelayS18()
    {
        StartCoroutine(IDelayS18());
    }
    IEnumerator IDelayS18()
    {
        yield return new WaitForSeconds(0.5f);
        QuestionBank.scorePoint18();
    }

    public void DelayS19()
    {
        StartCoroutine(IDelayS19());
    }
    IEnumerator IDelayS19()
    {
        yield return new WaitForSeconds(0.5f);
        QuestionBank.scorePoint19();
    }

    public void DelayS34()
    {
        StartCoroutine(IDelayS34());
    }
    IEnumerator IDelayS34()
    {
        yield return new WaitForSeconds(0.5f);
        QuestionBank.scorePoint34();
    }


    public void DelayS41()
    {
        StartCoroutine(IDelayS41());
    }
    IEnumerator IDelayS41()
    {
        yield return new WaitForSeconds(0.5f);
        QuestionBank.scorePoint41();
    }

    public void DelayS53()
    {
        StartCoroutine(IDelayS53());
    }
    IEnumerator IDelayS53()
    {
        yield return new WaitForSeconds(0.5f);
        QuestionBank.scorePoint53();
    }

    public void DelayS58()
    {
        StartCoroutine(IDelayS58());
    }
    IEnumerator IDelayS58()
    {
        yield return new WaitForSeconds(0.5f);
        QuestionBank.scorePoint58();
    }

    public void DelayS59()
    {
        StartCoroutine(IDelayS59());
    }
    IEnumerator IDelayS59()
    {
        yield return new WaitForSeconds(0.5f);
        QuestionBank.scorePoint59();
    }
    public void DelayS60()
    {
        StartCoroutine(IDelayS60());
    }
    IEnumerator IDelayS60()
    {
        yield return new WaitForSeconds(0.5f);
        QuestionBank.scorePoint60();
    }
    #endregion


}
