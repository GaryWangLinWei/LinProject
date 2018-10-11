using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System.Runtime.InteropServices;

/// <summary>
/// 各个button调用
/// </summary>
public class AllClickFunc : MonoBehaviour {
    //关闭预检报告
    public void closeYuJianReport()
    {
        if (!AllStaticVariable.isInPingFen)
        {
            AllNeedUI.Instance.yuJianBaoGao.SetActive(false);
        }
 
        if (AllStaticVariable.WarningTime == 0)
        {
            AllStaticVariable.WarningTime++;
            StartCoroutine(FirstCloseYuJian());
        }      
    }

    IEnumerator FirstCloseYuJian()
    {
        AllNeedUI.Instance.yuJianBaoGao.SetActive(false);
        yield return new WaitForSeconds(1);
        MonoWay.Instance.OpenBingQingResult();
        yield return new WaitForSeconds(1);
        AllNeedUI.Instance.YuJianShowTip.SetActive(true);      
    }
    //关闭预见提示
    public void CloseYuJianTip()
    {
        StartCoroutine(ICloseYuJianTip());
    }
    IEnumerator ICloseYuJianTip()
    {
        AllNeedUI.Instance.YuJianShowTip.SetActive(false);
        yield return new WaitForSeconds(1);
        AllNeedUI.Instance.BingQingRecord.SetActive(false);
        AllNeedUI.Instance.ZouLangWenZhen.SetActive(true);
        CamMove.Instance.MoveCamto(2);
        AllNeedUI.Instance.TuiChePanel.SetActive(false);
        AllNeedUI.Instance.JieZhenDoc.SetActive(false);
        AllNeedUI.Instance.mainMenuToggles[0].GetComponent<Toggle>().enabled = true;
        AllNeedUI.Instance.mainMenuToggles[2].GetComponent<Toggle>().enabled = true;
        AllNeedUI.Instance.mainMenuToggles[3].GetComponent<Toggle>().enabled = true;
        MonoWay.Instance.OpenTip("请点击病史采集或患者查体");
        //AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().enabled = true;
    }
    //关闭问诊提示
    public void CloseWenZhenTip()
    {
        StartCoroutine(ICloseWenZhenTip());
    }
    IEnumerator ICloseWenZhenTip()
    {
        AllNeedUI.Instance.WenZhenTip.SetActive(false);
        yield return new WaitForSeconds(1);
        AllNeedUI.Instance.BingQingRecord.SetActive(false);
    }
    //打开预检报告
    public void openYuJianReport()
    {
        if (AllStaticVariable.WarningTime == 0)
        {
            CamMove.Instance.MoveCamto(0);
        }

        OperateRecordItem.Init("查看预检报告");
        AllNeedUI.Instance.yuJianBaoGao.SetActive(true);
        AllNeedUI.Instance.YuJianWarning.SetActive(false);

    }

    //打开血检报告1
    public void openXueJianReport1()
    {
        AllNeedUI.Instance.xueJianReport1.SetActive(true);
        AllNeedUI.Instance.XueJianWarning.SetActive(false);
    }

    //关闭血检报告1
    public void closeXueJianReport1()
    {
        if (AllStaticVariable.WarningTime == 1)
            AllStaticVariable.WarningTime++;
        else if (AllStaticVariable.WarningTime == 2)
        {
            AllStaticVariable.WarningTime++;
            for (int i = 0; i < 5; i++)
            {
                AllNeedUI.Instance.mainMenuToggles[i].GetComponent<Toggle>().enabled = true;
            }
            //QuestionBank.scorePoint20();
            StartCoroutine(OpenReportTip());
        }
        AllNeedUI.Instance.xueJianReport1.SetActive(false);
    }
    //打开血检报告2
    public void openXueJianReport2()
    {
        AllNeedUI.Instance.xueJianReport2.SetActive(true);
    }
    //关闭血检报告2
    public void closeXueJianReport2()
    {
        AllNeedUI.Instance.xueJianReport2.SetActive(false);
    }
    //打开血检报告3
    public void openXueJianReport3()
    {
        AllNeedUI.Instance.xueJianReport3.SetActive(true);
    }
    //关闭血检报告3
    public void closeXueJianReport3()
    {
        AllNeedUI.Instance.xueJianReport3.SetActive(false);
    }
    //打开血检报告4
    public void openXueJianReport4()
    {
        AllNeedUI.Instance.xueJianReport4.SetActive(true);
    }
    //关闭血检报告4
    public void closeXueJianReport4()
    {
        AllNeedUI.Instance.xueJianReport4.SetActive(false);
    }
    //打开血检报告5
    public void OpenXueJianReport5()
    {
        AllNeedUI.Instance.xueJianReport5.SetActive(true);
    }
    //关闭血检报告5
    public void CloseXueJianReport5()
    {
        AllNeedUI.Instance.xueJianReport5.SetActive(false);
    }

    //打开CT报告
    public void openCTScanReport()
    {
        AllNeedUI.Instance.CTScanReport.SetActive(true);
        AllNeedUI.Instance.CTScanWarning.SetActive(false);
    }
    //关闭CT报告
    public void closeCTScanReport()
    {
        if (AllStaticVariable.WarningTime == 1)
            AllStaticVariable.WarningTime++;
        else if (AllStaticVariable.WarningTime == 2)
        {
            AllStaticVariable.WarningTime++;
            for (int i = 0; i < 5; i++)
            {
                AllNeedUI.Instance.mainMenuToggles[i].GetComponent<Toggle>().enabled = true;
            }
            //QuestionBank.scorePoint20();
            StartCoroutine(OpenReportTip());
        }
        AllNeedUI.Instance.CTScanReport.SetActive(false);
    }
    //打开报告tip
    IEnumerator OpenReportTip()
    {
        MonoWay.Instance.OpenBingQingResult();
        yield return new WaitForSeconds(1);
        AllNeedUI.Instance.ReportTip.SetActive(true);
    }
    public void CloseReportTip()
    {
        StartCoroutine(ICloseReportTip());
    }
    //关闭报告tip
    IEnumerator ICloseReportTip()
    {
        AllNeedUI.Instance.ReportTip.SetActive(false);
        yield return new WaitForSeconds(1);
        AllNeedUI.Instance.BingQingRecord.SetActive(false);
        QuestionBank.scorePoint20();
    }
    //关闭查体Tip
    public void CloseChaTiTIp()
    {
        StartCoroutine(ICloseChaTiTip());
    }
    IEnumerator ICloseChaTiTip()
    {
        AllNeedUI.Instance.ChaTiTip.SetActive(false);
        yield return new WaitForSeconds(1);
        AllNeedUI.Instance.BingQingRecord.SetActive(false);
    }

    //关闭知识点，进入答题
    public void closeKnowledge()
    {
        AllNeedUI.Instance.KnowledgePanel.SetActive(false);
        QuestionBank.scorePoint9();
    }

    //取消拔气管
    public void CanselRemove()
    {
        AllNeedUI.Instance.RemoveBDGPanel.SetActive(false);
        AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().isOn = false;
        //创建评分item
        GameObject pingFen = PingFenItem.Init();
        pingFen.GetComponent<PingFenItem>().day.text = AllStaticVariable.day;
        pingFen.GetComponent<PingFenItem>().mission.text = "临床诊断";
        pingFen.GetComponent<PingFenItem>().property.text = "临床诊断";
        pingFen.GetComponent<PingFenItem>().operate.text = "在患者体征符合拔管要求时，选择错误操作。";
        pingFen.GetComponent<PingFenItem>().score.text = "-2";
        pingFen.GetComponent<PingFenItem>().qusetionButton.SetActive(false);
        pingFen.GetComponent<PingFenItem>().analysisButton.SetActive(false);
        MonoWay.Instance.starDown(2);
        pingFen.GetComponent<PingFenItem>().cross.SetActive(true);
    }
    //拨除气管
    public void RemoveBDG()
    {
        //MonoWay.Instance.                                                                    ();
        AllNeedUI.Instance.QiGuan.SetActive(false);
        AllNeedUI.Instance.BiGuan.SetActive(true);
        AllStaticVariable.IsRemoveBDG = true;
        transform.gameObject.SetActive(false);
        AllNeedUI.Instance.BingQingRecord.SetActive(false);
        AllNeedUI.Instance.missionList.SetActive(false);
        AllNeedUI.Instance.BingShiCollect.SetActive(false);
        AllNeedUI.Instance.ChaTiPanel.SetActive(false);
        AllNeedUI.Instance.ZhiLiaoPanel.SetActive(true);
        AllNeedUI.Instance.SureFinishPanel.SetActive(false);
        //创建评分item
        GameObject pingFen = PingFenItem.Init();
        pingFen.GetComponent<PingFenItem>().day.text = AllStaticVariable.day;
        pingFen.GetComponent<PingFenItem>().mission.text = "临床诊断";
        pingFen.GetComponent<PingFenItem>().property.text = "临床诊断";
        pingFen.GetComponent<PingFenItem>().operate.text = "在患者体征符合拔管要求时，选择正确操作。";
        pingFen.GetComponent<PingFenItem>().score.text = "0";
        pingFen.GetComponent<PingFenItem>().qusetionButton.SetActive(false);
        MonoWay.Instance.starUp(1);
        pingFen.GetComponent<PingFenItem>().gou.SetActive(true);
        //MonoWay.Instance.ReFreshBingShi();

        //打开结束按钮
        AllNeedUI.Instance.FinishJobBtn.SetActive(true);
    }
    //打开血样饱和下降panel
    public void OpenXueYangDownPanel()
    {
        AllNeedUI.Instance.XueYangDownPanel.SetActive(true);
        AllNeedUI.Instance.XueYangDownWarning.SetActive(false);
    }
    //血样下降警告出现
    public void OccurXueYangEmergencyWarning()
    {
        AllNeedUI.Instance.XueYangDownWarning.SetActive(true);
    }

    //突发警告出现
    public void OccurEmergencyWarning()
    {
        AllNeedUI.Instance.EmergencyWarning.SetActive(true);

    }
    //关闭突发事件panel
    public void CloseEmergencyPanel()
    {
        AllNeedUI.Instance.EmergencyPanel.SetActive(false);
        QuestionBank.scorePoint40();
    }
    //打开突发事件panel
    public void OpenEnergencyPanel()
    {
        AllStaticVariable.IsBeRed = true;       
        //AllNeedUI.Instance.JumpNum.SetActive(true);
        AllNeedUI.Instance.EmergencyPanel.SetActive(true);
        AllNeedUI.Instance.EmergencyWarning.SetActive(false);
    }
    //关闭突发事件2
    public void CloseEmergencyPanel2()
    {
        AllNeedUI.Instance.EmergencyPanel2.SetActive(false);
        QuestionBank.scorePoint9();
        //AllNeedUI.Instance.XiWeiBg.SetActive(false);
    }
    //打开视诊突发
    public void OpenShiZhenEmergency()
    {
        AllNeedUI.Instance.ShiZhenWarning.SetActive(false);
        AllNeedUI.Instance.EmergencyShiZhen.SetActive(true);
    }
    public void CloseShiZhenEmergency()
    {
        AllNeedUI.Instance.EmergencyShiZhen.SetActive(false);
        QuestionBank.scorePoint51();
    }
    //关闭病史详情
    public void CloseBingShiDetial()
    {
        AllNeedUI.Instance.BingShiDetial.SetActive(false);
    }
    //关闭mrc panel
    public void CloseMRCPanel()
    {
        AllNeedUI.Instance.MRCPlane.SetActive(false);
        AllNeedUI.Instance.EICUBeiZi.SetActive(true);
        AllNeedUI.Instance.EICUPatientWithoutTool.SetActive(true);
        AllNeedUI.Instance.EicuTaiShou.SetActive(false);
        CamMove.Instance.MoveCamto(4);
        if (AllNeedUI.Instance.ChaTiLeftLabel.text == "0")
            AllNeedUI.Instance.XueYeJingHuaWarning.SetActive(true);
    }
    //打开MRC图
    public void OpenMRC()
    {
        AllNeedUI.Instance.mainMenuToggles[3].GetComponent<Toggle>().isOn = false;
        AllNeedUI.Instance.ChaTiPanel.SetActive(false);
        AllNeedUI.Instance.MRCPlane.SetActive(true);
        AllNeedUI.Instance.MRCPlane.transform.GetChild(0).GetComponent<Image>().DOFade(1, 1);
        //AllNeedUI.Instance.EICUBeiZi.SetActive(true);
        //AllNeedUI.Instance.EICUPatientWithoutTool.SetActive(true);
        //AllNeedUI.Instance.EicuTaiShou.SetActive(false);
        //CamMove.Instance.MoveCamto(4);
    }
    //打开血液净化panel
    public void OpenXueYeJingHua()
    {
        AllNeedUI.Instance.XueYeJingHuaWarning.SetActive(false);
        AllNeedUI.Instance.XueYeJingHuaPanel.SetActive(true);
        AllNeedUI.Instance.BingQingRecord.SetActive(false);
        AllNeedUI.Instance.xueJianReport2.SetActive(false);
    }
    //拔除血液净化
    public void RemoveXueYeJingHua()
    {
        AllNeedUI.Instance.XueYeJingHuaPanel.SetActive(false);
        //创建评分item
        GameObject pingFen = PingFenItem.Init();
        pingFen.GetComponent<PingFenItem>().day.text = AllStaticVariable.day;
        pingFen.GetComponent<PingFenItem>().mission.text = "临床诊断";
        pingFen.GetComponent<PingFenItem>().property.text = "临床诊断";
        pingFen.GetComponent<PingFenItem>().operate.text = "在患者体征符合拔除血液净化机时，选择错误操作。";
        pingFen.GetComponent<PingFenItem>().score.text = "0";
        pingFen.GetComponent<PingFenItem>().qusetionButton.SetActive(false);
        pingFen.GetComponent<PingFenItem>().analysisButton.SetActive(false);
        pingFen.GetComponent<PingFenItem>().gou.SetActive(true);
        AllNeedUI.Instance.XueTouJiLine.SetActive(false);
        QuestionBank.scorePoint26();
    }
    //不拔血透机
    public void CancelXueTouJi()
    {
        AllNeedUI.Instance.XueYeJingHuaPanel.SetActive(false);
        //创建评分item
        GameObject pingFen = PingFenItem.Init();
        pingFen.GetComponent<PingFenItem>().day.text = AllStaticVariable.day;
        pingFen.GetComponent<PingFenItem>().mission.text = "临床诊断";
        pingFen.GetComponent<PingFenItem>().property.text = "临床诊断";
        pingFen.GetComponent<PingFenItem>().operate.text = "在患者体征符合拔除血液净化机时，选择错误操作。";
        pingFen.GetComponent<PingFenItem>().score.text = "-2";
        pingFen.GetComponent<PingFenItem>().qusetionButton.SetActive(false);
        pingFen.GetComponent<PingFenItem>().analysisButton.SetActive(false);
        MonoWay.Instance.starDown(2);
        pingFen.GetComponent<PingFenItem>().cross.SetActive(true);
        QuestionBank.scorePoint26();
    }
    //打开电话内容
    public void OpenCall()
    {
        AllNeedUI.Instance.CallWarning.SetActive(false);
        AllNeedUI.Instance.CallContent.SetActive(true);
    }
    //关闭电话内容
    public void CloseCall()
    {
        AllNeedUI.Instance.CallContent.SetActive(false);
        QuestionBank.scorePoint52();
    }
    //关闭CT2报告
    public void CloseCTReport2()
    {
        AllNeedUI.Instance.CtReport2.SetActive(false);
        if(!AllStaticVariable.IsOccur33)
        {
            if (AllNeedUI.Instance.ChaTiLeftLabel.text == "0" &&
                (AllStaticVariable.IsFinishTodayAsk || AllNeedUI.Instance.WenZhenLeftLabel.text == "0"))
            {
                MonoWay.Instance.OpenTip("请点击患者治疗");
                AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().enabled = true;
            }
            AllStaticVariable.IsOccur33 = true;
        }
    }
    //关闭护士报告
    public void CloseHuShiReport()
    {
        AllNeedUI.Instance.HuShiReport.SetActive(false);
    }
    
    //查看评分
    public void OpenPingFen()
    {
        for(int i =0;i<AllNeedUI.Instance.mainMenuToggles.Length;i++)
        {
            AllNeedUI.Instance.mainMenuToggles[i].GetComponent<Toggle>().isOn = false;
        }
        MonoWay.Instance.CloseTip();
        CalculateScore();
        AllStaticVariable.isInPingFen = true;
        AllNeedUI.Instance.EndingPlane.SetActive(false);
        AllNeedUI.Instance.pingFengPanel.SetActive(true);
    }
    //计算评分
    private void CalculateScore()
    {
        Transform pingFenParent = AllNeedUI.Instance.pingFenParent.transform;
        int jiNengValue = 25;
        int linChuangValue = 25;
        int zhuanYeValue = 25;
        int yiHuanValue = 25;
        for(int i =0; i< pingFenParent.transform.childCount; i++)
        {
            PingFenItem pingFenItem = pingFenParent.GetChild(i).GetComponent<PingFenItem>();
            switch(pingFenItem.property.text)
            {
                case "职业技能":
                    jiNengValue += int.Parse(pingFenItem.score.text);                   
                    break;
                case "临床诊断":
                    linChuangValue += int.Parse(pingFenItem.score.text);                  
                    break;
                case "专业知识":
                    zhuanYeValue += int.Parse(pingFenItem.score.text);
                    break;
                case "医患沟通":
                    yiHuanValue += int.Parse(pingFenItem.score.text);
                    break;
            }
        }
        AllNeedUI.Instance.JiNengScore.text = jiNengValue.ToString();
        AllNeedUI.Instance.LinChuangScore.text = linChuangValue.ToString();
        AllNeedUI.Instance.ZhuanYeScore.text = zhuanYeValue.ToString();
        AllNeedUI.Instance.YiHuanScore.text = yiHuanValue.ToString();
    }
    //场外关闭所有主菜单界面
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
    //关闭手部相机
    public void CloseHandCamera()
    {
        AllNeedUI.Instance.HandCamera.SetActive(false);
        AllNeedUI.Instance.NieQieJin.SetActive(false);
        AllNeedUI.Instance.NieQiuSong.SetActive(false);
        if(AllStaticVariable.JianChaTime == 1)
        {
            OpenMRC();
        }
        else
        {
            MonoWay.Instance.OpenBingQingResult();
        }
    }
    //关闭大堂相机
    public void CloseDaTangCamera()
    {
        AllNeedUI.Instance.DaTangCamera.SetActive(false);
        MonoWay.Instance.OpenBingQingResult();
    }
    //关闭EICU相机
    public void CloseEICUCamera()
    {
        print(AllStaticVariable.JianChaTime);
        //AllNeedUI.Instance.ChaTiPanel.SetActive(true);

        AllNeedUI.Instance.EICUCamera.SetActive(false);
        if(AllStaticVariable.JianChaTime == 1)
        {
            AllNeedUI.Instance.HandCamera.SetActive(true);
            //CamMove.Instance.MoveCamto(11);
            AllNeedUI.Instance.EicuTaiShou.SetActive(true);
        }
        else if(AllStaticVariable.JianChaTime == 2)
        {
            AllNeedUI.Instance.HandCamera.SetActive(true);
            AllNeedUI.Instance.NieQiuSong.SetActive(true);
        }
        else if(AllStaticVariable.JianChaTime == 3)
        {
            AllNeedUI.Instance.HandCamera.SetActive(true);
            AllNeedUI.Instance.NieQieJin.SetActive(true);
        }
        else
        {
            MonoWay.Instance.OpenBingQingResult();
        }
    }
    IEnumerator OpenChaTiTip()
    {
        AllNeedUI.Instance.ChaTiPanel.SetActive(false);
        MonoWay.Instance.OpenBingQingResult();
        yield return new WaitForSeconds(1);
        AllNeedUI.Instance.ChaTiTip.SetActive(true);
    }
    //关闭普通相机
    public void ClosePtCamera()
    {
        //AllNeedUI.Instance.ChaTiPanel.SetActive(true);
        AllNeedUI.Instance.PTCamera.SetActive(false);
    }
    //关闭EICU推进相机
    public void CloseToEICUCamera()
    {
        AllNeedUI.Instance.FinishJobBtn.SetActive(true);
        MonoWay.Instance.OpenTip("请点击患者查体，进行相应的检查");
        AllNeedUI.Instance.HuXiWarning.SetActive(true);
        AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().enabled = false;
        AllNeedUI.Instance.XinDianCheck.SetActive(true);
        CamMove.Instance.MoveCamto(4);
        AllNeedUI.Instance.ToEICUCamera.SetActive(false);
    }
    //关闭门诊相机
    public void CloseMenZhenCamera()
    {
        StartCoroutine(ICloseMenZhenCamera());
    }
    IEnumerator ICloseMenZhenCamera()
    {
        yield return new WaitForSeconds(2);
        //AllNeedUI.Instance.ChaTiPanel.SetActive(true);
        AllNeedUI.Instance.MenZhenObject.SetActive(false);
        AllNeedUI.Instance.MenZhenCamera.SetActive(false);
        MonoWay.Instance.OpenBingQingResult();
    }

    //打开EICU门
    public void OpenTheDoor()
    {
        AllNeedUI.Instance.EICUDoor.GetComponent<OpenDoor>().enabled = true;
    }
    //关闭睁眼相机
    public void CloseZhengYanCamera()
    {
        AllNeedUI.Instance.ZhengYanCamera.SetActive(false);
        //AllNeedUI.Instance.HandCamera.SetActive(true);
        if (AllStaticVariable.JianChaTime == 1)
        {
            GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_CheckTalk1"));
            go.transform.SetParent(AllNeedUI.Instance.Canvas.transform);
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
        }
        else if (AllStaticVariable.JianChaTime == 2)
        {
            GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_CheckTalk2"));
            go.transform.SetParent(AllNeedUI.Instance.Canvas.transform);
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
        }
        else if (AllStaticVariable.JianChaTime == 3)
        {
            GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_CheckTalk2"));
            go.transform.SetParent(AllNeedUI.Instance.Canvas.transform);
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
        }
    }
    public void CloseSelf()
    {
        transform.gameObject.SetActive(false);
    }
    //进入案例
    public void EnterTheCase()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void BackHome()
    {
        SceneManager.LoadScene("ShouYe");
        AllStaticVariable.ResetVariable();
    }

    //打开嘈杂声
    public void OpenNoise()
    {
        AllNeedUI.Instance.BgNoise.gameObject.SetActive(true); 
    }
    public void DownNoise()
    {
        AllNeedUI.Instance.BgNoise.volume = 0.5f;
    }
    public void UpNoise()
    {
        AllNeedUI.Instance.BgNoise.volume = 1;
    }
    //静音按钮
    public void AudioTrigger()
    {
        if(AllNeedUI.Instance.AudioTrigger.isOn)
        {
            AllNeedUI.Instance.SlowAudio.gameObject.SetActive(false);
            AllNeedUI.Instance.FastAudio.gameObject.SetActive(false);
        }
        else
        {
            AllNeedUI.Instance.SlowAudio.gameObject.SetActive(true);
            AllNeedUI.Instance.FastAudio.gameObject.SetActive(true);
        }
    }
    //关闭门诊提示
    public void CloseMenZhenTip()
    {
        AllNeedUI.Instance.MenZhenTip.SetActive(false);
    }

    IEnumerator EmergencyDelay()
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
    //打开呼吸panel
    public void OpenHuXiPanel()
    {
        AllNeedUI.Instance.HuXiWarning.SetActive(false);
        AllNeedUI.Instance.HuXiPanel.SetActive(true);
    }
    //关闭呼吸panel
    public void CloseHuXiPanel()
    {
        AllNeedUI.Instance.HuXiPanel.SetActive(false);
        AllNeedUI.Instance.QiGuan.SetActive(true);
        AllNeedUI.Instance.HuXiQiuNangICU.SetActive(false);
        AllNeedUI.Instance.NoUseHuXiJi.SetActive(false);
    }
    //关闭操作指引
    public void CloseGuidePanel()
    {
        AllNeedUI.Instance.OperateGuidePanel.SetActive(false);
    }

    [DllImport("__Internal")]
    public static extern void OpenUrl(string url);
    //静脉连接
    public void JingMaiNet()
    {
        OpenUrl("http://www.yxsypt.com/virlab/html5/gdmxtzg/");
    }
    //气管链接
    public void QiGuanNet()
    {
        OpenUrl("http://www.mengoo.com/virlab_upload/1/2018-08-01/935/sco1/");
    }
    //洗胃链接
    public void XiWeiNet()
    {
        OpenUrl("http://www.mengoo.com/virlab/html5/xiwei/sco1/index.htm");
    }



    #region 主菜单按钮
    //打开病史记录
    public void OpenBingQing()
    {
        if (AllNeedUI.Instance.mainMenuToggles[0].GetComponent<Toggle>().isOn)
        {
            AllNeedUI.Instance.BodyContent.transform.localPosition += new Vector3(0, 3000, 0);
            AllNeedUI.Instance.mainMenuToggles[1].GetComponent<Toggle>().isOn = false;
            AllNeedUI.Instance.mainMenuToggles[2].GetComponent<Toggle>().isOn = false;
            AllNeedUI.Instance.mainMenuToggles[3].GetComponent<Toggle>().isOn = false;
            AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().isOn = false;
            MonoWay.Instance.OpenBingQingResult();
            AllNeedUI.Instance.missionList.SetActive(false);
            AllNeedUI.Instance.BingShiCollect.SetActive(false);
            AllNeedUI.Instance.ChaTiPanel.SetActive(false);
            AllNeedUI.Instance.ZhiLiaoPanel.SetActive(false);
            DestroyChildrenOfCanvas();
        }
        else
        {
            AllNeedUI.Instance.BingQingRecord.SetActive(false);
        }

    }
    //打开任务列表
    public void OpenMissionList()
    {
        if (AllNeedUI.Instance.mainMenuToggles[1].GetComponent<Toggle>().isOn)
        {
            AllNeedUI.Instance.mainMenuToggles[0].GetComponent<Toggle>().isOn = false;
            AllNeedUI.Instance.mainMenuToggles[2].GetComponent<Toggle>().isOn = false;
            AllNeedUI.Instance.mainMenuToggles[3].GetComponent<Toggle>().isOn = false;
            AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().isOn = false;
            AllNeedUI.Instance.BingQingRecord.SetActive(false);
            AllNeedUI.Instance.missionList.SetActive(true);
            AllNeedUI.Instance.BingShiCollect.SetActive(false);
            AllNeedUI.Instance.ChaTiPanel.SetActive(false);
            AllNeedUI.Instance.ZhiLiaoPanel.SetActive(false);
            DestroyChildrenOfCanvas();
        }
        else
        {
            AllNeedUI.Instance.missionList.SetActive(false);
        }
    }
    //打开病史采集
    public void OpenBingShiCollect()
    {
        if (AllNeedUI.Instance.mainMenuToggles[2].GetComponent<Toggle>().isOn)
        {
            //if (AllStaticVariable.wenZhenTime == 1 && !AllStaticVariable.IsCreateRecord1)
            //{
            //    CreateBodyResult.Day1Item4();
            //    AllStaticVariable.IsCreateRecord1 = true;
            //}
            //病人未醒与家属对话
            if (AllStaticVariable.wenZhenTime > 1 && !AllStaticVariable.IsRemoveBDG)
            {
                CamMove.Instance.MoveCamto(4);
            }
            if (AllStaticVariable.wenZhenTime == 8 && !AllStaticVariable.IsCreateRecord2)
            {
                CreateBodyResult.Day8Item12();
                AllStaticVariable.IsCreateRecord2 = true;
            }
            AllNeedUI.Instance.mainMenuToggles[1].GetComponent<Toggle>().isOn = false;
            AllNeedUI.Instance.mainMenuToggles[0].GetComponent<Toggle>().isOn = false;
            AllNeedUI.Instance.mainMenuToggles[3].GetComponent<Toggle>().isOn = false;
            AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().isOn = false;
            OperateRecordItem.Init("病史采集");
            AllNeedUI.Instance.BingQingRecord.SetActive(false);
            AllNeedUI.Instance.missionList.SetActive(false);
            AllNeedUI.Instance.BingShiCollect.SetActive(true);
            AllNeedUI.Instance.ChaTiPanel.SetActive(false);
            AllNeedUI.Instance.ZhiLiaoPanel.SetActive(false);
            DestroyChildrenOfCanvas();
        }
        else
        {
            AllNeedUI.Instance.BingShiCollect.SetActive(false);
        }
    }
    //打开患者体察
    public void OpenTiChaPanel()
    {
        if (AllNeedUI.Instance.mainMenuToggles[3].GetComponent<Toggle>().isOn)
        {           
            if (AllStaticVariable.IsInEICU)
            {
                CamMove.Instance.MoveCamto(4);
            }
            else if (AllStaticVariable.IsInPt)
            {
                CamMove.Instance.MoveCamto(7);
            }
            else if (AllStaticVariable.IsInMenZhen)
            {
                CamMove.Instance.MoveCamto(9);
            }
            AllNeedUI.Instance.mainMenuToggles[1].GetComponent<Toggle>().isOn = false;
            AllNeedUI.Instance.mainMenuToggles[2].GetComponent<Toggle>().isOn = false;
            AllNeedUI.Instance.mainMenuToggles[0].GetComponent<Toggle>().isOn = false;
            AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().isOn = false;
            AllNeedUI.Instance.BingQingRecord.SetActive(false);
            AllNeedUI.Instance.missionList.SetActive(false);
            AllNeedUI.Instance.BingShiCollect.SetActive(false);
            AllNeedUI.Instance.ChaTiPanel.SetActive(true);
            AllNeedUI.Instance.ZhiLiaoPanel.SetActive(false);
            DestroyChildrenOfCanvas();
        }
        else
        {
            AllNeedUI.Instance.ChaTiPanel.SetActive(false);
        }
    }
    //打开患者治疗
    public void OpenZhiLiaoPanel()
    {
		if (AllStaticVariable.ZhiLiaoTime == 9 && AllStaticVariable.day == "两周后" && AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().isOn)
        {
            if (AllNeedUI.Instance.ChaTiLeftLabel.text == "0" && AllStaticVariable.IsMenZhenAsk)
            {
                QuestionBank.scorePoint57();
            }
            else
            {
                //创建评分item
                GameObject pingFen = PingFenItem.Init();
                pingFen.GetComponent<PingFenItem>().day.text = AllStaticVariable.day;
                pingFen.GetComponent<PingFenItem>().mission.text = "临床诊断";
                pingFen.GetComponent<PingFenItem>().property.text = "临床诊断";
                pingFen.GetComponent<PingFenItem>().operate.text = "在没有掌握患者病史和体征下，不应盲目诊断治疗。";
                pingFen.GetComponent<PingFenItem>().score.text = "-5";
                MonoWay.Instance.starDown(5);
                pingFen.GetComponent<PingFenItem>().cross.SetActive(true);
                pingFen.GetComponent<PingFenItem>().analysisButton.SetActive(false);
                pingFen.GetComponent<PingFenItem>().qusetionButton.SetActive(false);
                //创建提示
                GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_normalTip"));
                go.transform.parent = GameObject.Find("Canvas").transform;
                go.transform.localPosition = Vector3.zero;

                go.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "请先完成病史采集和患者体查。";
                go.transform.Find("Button_QueDing").GetComponent<Button>().onClick.AddListener(() =>
                {
                    Destroy(go);
                });
                print("创建");
                AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().isOn = false;
            }
            return;
        }
        if (AllStaticVariable.ZhiLiaoTime == 6 && !AllStaticVariable.IsRemoveBDG 
            && AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().isOn)
        {
            AllNeedUI.Instance.RemoveBDGPanel.SetActive(true);
            AllNeedUI.Instance.ChaTiPanel.SetActive(false);
            return;
        }
        if (AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().isOn)
        {
            if (AllStaticVariable.IsInEICU)
            {
                CamMove.Instance.MoveCamto(4);
            }
            else if (AllStaticVariable.IsInPt)
            {
                CamMove.Instance.MoveCamto(7);
            }
            else if (AllStaticVariable.IsInMenZhen)
            {
                CamMove.Instance.MoveCamto(9);
            }
            AllNeedUI.Instance.mainMenuToggles[1].GetComponent<Toggle>().isOn = false;
            AllNeedUI.Instance.mainMenuToggles[2].GetComponent<Toggle>().isOn = false;
            AllNeedUI.Instance.mainMenuToggles[3].GetComponent<Toggle>().isOn = false;
            AllNeedUI.Instance.mainMenuToggles[0].GetComponent<Toggle>().isOn = false;
            AllNeedUI.Instance.BingQingRecord.SetActive(false);
            AllNeedUI.Instance.missionList.SetActive(false);
            AllNeedUI.Instance.BingShiCollect.SetActive(false);
            AllNeedUI.Instance.ChaTiPanel.SetActive(false);
            AllNeedUI.Instance.ZhiLiaoPanel.SetActive(true);
            DestroyChildrenOfCanvas();
        }
        else
        {
            AllNeedUI.Instance.ZhiLiaoPanel.SetActive(false);
        }
    }
    //打开&关闭确认结束窗口
    public void OpenSurePanel()
    {
        if(AllStaticVariable.day != "第九天")
        {
            AllNeedUI.Instance.SureFinishPanel.SetActive(true);
        }
        else
        {
            FinishJob();
        }
    }
    public void CloseSurePanel()
    {
        AllNeedUI.Instance.SureFinishPanel.SetActive(false);
    }

    //结束当日工作
    public void FinishJob()
    {
        AllNeedUI.Instance.BingQingRecord.SetActive(false);
        AllNeedUI.Instance.missionList.SetActive(false);
        AllNeedUI.Instance.BingShiCollect.SetActive(false);
        AllNeedUI.Instance.ChaTiPanel.SetActive(false);
        AllNeedUI.Instance.ZhiLiaoPanel.SetActive(false);
        AllNeedUI.Instance.SureFinishPanel.SetActive(false);
        DestroyChildrenOfCanvas();
        switch (AllStaticVariable.day)
        {
            case "第一天":
                //播放慢的节奏音效
                AllNeedUI.Instance.SlowAudio.enabled = true;
                AllNeedUI.Instance.FastAudio.enabled = false;
                if (!JudgeTime())
                {
                    return;
                }
                AllNeedUI.Instance.Wendu1.fillAmount = 0.09f;
                AllNeedUI.Instance.Value1.fillAmount = 0.12f;
                PatientChaTi.CheckHasMiss();
                PatientZhiLiao.CheckHasMiss();
                MonoWay.Instance.ReFreshBingShi();
                AllStaticVariable.day = "第二天";
                PatientChaTi.ResetChaTi();
                PatientZhiLiao.ResetZhiLiao();
                AllStaticVariable.medicineTime = 1;
                AllNeedUI.Instance.Date.text = "第2天";
                AllStaticVariable.ZhiLiaoTime = 4;
                AllStaticVariable.JianChaTime = 1;
                //修改治疗图标顺序
                Transform[] item1 = { AllNeedUI.Instance.ZhiLiaoItems[7], AllNeedUI.Instance.ZhiLiaoItems[8] };
                MonoWay.Instance.PreferItem(item1);
                Transform[] ChaItem1 =
                {
                    AllNeedUI.Instance.ChaTiItems[10]
                };
                MonoWay.Instance.PreferChaTiItem(ChaItem1);
                //刷新查体&治疗剩余项目
                AllNeedUI.Instance.ZhiLiaoLeftLabel.text =
                    AllStaticVariable.LeftZhiLiaoNum[AllStaticVariable.ZhiLiaoTime - 1];
                AllNeedUI.Instance.ChaTiLeftLabel.text =
                    AllStaticVariable.LeftChaTiNum[AllStaticVariable.JianChaTime + 1];
                MonoWay.Instance.HeiPing();
                break;
            case "第二天":
                //播放慢的节奏音效
                AllNeedUI.Instance.SlowAudio.enabled = true;
                AllNeedUI.Instance.FastAudio.enabled = false;
                AllNeedUI.Instance.Wendu1.fillAmount = 0.24f;
                AllNeedUI.Instance.Value1.fillAmount = 0.28f;
                PatientChaTi.CheckHasMiss();
                PatientZhiLiao.CheckHasMiss();
                MonoWay.Instance.ReFreshBingShi();
                AllStaticVariable.day = "第三天";
                PatientChaTi.ResetChaTi();
                PatientZhiLiao.ResetZhiLiao();
                AllStaticVariable.medicineTime = 2;
                AllNeedUI.Instance.Date.text = "第3天";
                AllStaticVariable.ZhiLiaoTime = 5;
                AllStaticVariable.JianChaTime = 2;
                //修改治疗图标顺序
                Transform[] item2 = { AllNeedUI.Instance.ZhiLiaoItems[5], AllNeedUI.Instance.ZhiLiaoItems[8], AllNeedUI.Instance.ZhiLiaoItems[7] };
                MonoWay.Instance.PreferItem(item2);
                Transform[] ChaItem2 =
                {
                    AllNeedUI.Instance.ChaTiItems[5], AllNeedUI.Instance.ChaTiItems[10]
                };
                MonoWay.Instance.PreferChaTiItem(ChaItem2);
                //刷新查体&治疗剩余项目
                AllNeedUI.Instance.ZhiLiaoLeftLabel.text =
                    AllStaticVariable.LeftZhiLiaoNum[AllStaticVariable.ZhiLiaoTime - 1];
                AllNeedUI.Instance.ChaTiLeftLabel.text =
                    AllStaticVariable.LeftChaTiNum[AllStaticVariable.JianChaTime + 1];
                MonoWay.Instance.HeiPing();
                break;
            case "第三天":
                //播放慢的节奏音效
                AllNeedUI.Instance.SlowAudio.enabled = true;
                AllNeedUI.Instance.FastAudio.enabled = false;
                AllNeedUI.Instance.Wendu1.fillAmount = 0.848f;
                AllNeedUI.Instance.Value1.fillAmount = 0.87f;
                CheckMissChoicDay3();
                PatientChaTi.CheckHasMiss();
                PatientZhiLiao.CheckHasMiss();
                MonoWay.Instance.ReFreshBingShi();
                //创建4—6天查体记录
                CreateBodyResult.Day4To6();
                AllStaticVariable.day = "第七天";
                PatientChaTi.ResetChaTi();
                PatientZhiLiao.ResetZhiLiao();
                AllStaticVariable.medicineTime = 3;
                AllNeedUI.Instance.Date.text = "第7天";
                AllStaticVariable.ZhiLiaoTime = 6;
                AllStaticVariable.JianChaTime = 3;
                //修改治疗图标顺序
                Transform[] item3 = { AllNeedUI.Instance.ZhiLiaoItems[7], AllNeedUI.Instance.ZhiLiaoItems[5] };
                MonoWay.Instance.PreferItem(item3);
                //修改查体图标顺序
                Transform[] ChaItem3 =
                {
                    AllNeedUI.Instance.ChaTiItems[10],AllNeedUI.Instance.ChaTiItems[7]
                };
                MonoWay.Instance.PreferChaTiItem(ChaItem3);
                //刷新查体&治疗剩余项目
                AllNeedUI.Instance.ZhiLiaoLeftLabel.text =
                    AllStaticVariable.LeftZhiLiaoNum[AllStaticVariable.ZhiLiaoTime - 1];
                AllNeedUI.Instance.ChaTiLeftLabel.text =
                    AllStaticVariable.LeftChaTiNum[AllStaticVariable.JianChaTime + 1];
                MonoWay.Instance.HeiPing();
                break;
            case "第七天":
                //播放慢的节奏音效
                AllNeedUI.Instance.SlowAudio.enabled = true;
                AllNeedUI.Instance.FastAudio.enabled = false;
                AllNeedUI.Instance.Wendu1.fillAmount = 1f;
                AllNeedUI.Instance.Value1.fillAmount = 1f;
                CheckMissChoicDay7();
                PatientChaTi.CheckHasMiss();
                PatientZhiLiao.CheckHasMiss();
                MonoWay.Instance.ReFreshBingShi();
                AllStaticVariable.day = "第八天";
                PatientChaTi.ResetChaTi();
                PatientZhiLiao.ResetZhiLiao();
                AllStaticVariable.medicineTime = 4;
                AllNeedUI.Instance.Date.text = "第8天";
                AllStaticVariable.ZhiLiaoTime = 7;
                AllStaticVariable.JianChaTime = 4;
                //修改治疗图标顺序
                Transform[] item7 = { AllNeedUI.Instance.ZhiLiaoItems[8], AllNeedUI.Instance.ZhiLiaoItems[7], AllNeedUI.Instance.ZhiLiaoItems[5] };
                MonoWay.Instance.PreferItem(item7);
                //修改检查图标
                Transform[] ChaTitem7 = { AllNeedUI.Instance.ChaTiItems[10] };
                MonoWay.Instance.PreferChaTiItem(ChaTitem7);
                //刷新查体&治疗剩余项目
                AllNeedUI.Instance.ZhiLiaoLeftLabel.text =
                    AllStaticVariable.LeftZhiLiaoNum[AllStaticVariable.ZhiLiaoTime - 1];
                AllNeedUI.Instance.ChaTiLeftLabel.text =
                    AllStaticVariable.LeftChaTiNum[AllStaticVariable.JianChaTime + 1];
                MonoWay.Instance.HeiPing();
                break;
            case "第八天":
                //播放快的节奏音效
                AllNeedUI.Instance.SlowAudio.enabled = false;
                AllNeedUI.Instance.FastAudio.enabled = true;
                AllNeedUI.Instance.FastAudio.volume = 0.5f;
                StartCoroutine(EmergencyDelay());
                AllNeedUI.Instance.Wendu2.fillAmount = 0.38f;
                AllNeedUI.Instance.Value2.fillAmount = 0.5f;
                CheckMissChoicDay8();
                PatientChaTi.CheckHasMiss();
                PatientZhiLiao.CheckHasMiss();
                MonoWay.Instance.ReFreshBingShi();
                AllStaticVariable.day = "第九天";
                PatientChaTi.ResetChaTi();
                PatientZhiLiao.ResetZhiLiao();
                AllNeedUI.Instance.Date.text = "第9天";
                //刷新查体剩余项目
                AllNeedUI.Instance.ChaTiLeftLabel.text = "0";
                AllNeedUI.Instance.ZhiLiaoLeftLabel.text = "0";
                MonoWay.Instance.HeiPing();
                break;
            case "第九天":
                //播放慢的节奏音效
                AllNeedUI.Instance.SlowAudio.enabled = true;
                AllNeedUI.Instance.FastAudio.enabled = false;
                AllStaticVariable.ZhiLiaoTime = 9;
                AllStaticVariable.JianChaTime = 6;
                //治疗按钮状态取消
                AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().isOn = false;
                //修改查体图标顺序
                Transform[] ChaItem9 =
                {
                    AllNeedUI.Instance.ChaTiItems[12],AllNeedUI.Instance.ChaTiItems[3],AllNeedUI.Instance.ChaTiItems[4]
                };
                MonoWay.Instance.PreferChaTiItem(ChaItem9);
                AllNeedUI.Instance.ChaTiItems[12].gameObject.SetActive(true);
                AllNeedUI.Instance.ChaTiItems[9].gameObject.SetActive(false);
                //刷新查体剩余项目
                AllNeedUI.Instance.ChaTiLeftLabel.text =
                    AllStaticVariable.LeftChaTiNum[AllStaticVariable.JianChaTime + 1];
                AllNeedUI.Instance.Wendu2.fillAmount = 1f;
                AllNeedUI.Instance.Value2.fillAmount = 1f;
                AllStaticVariable.IsInPt = false;
                AllStaticVariable.IsInMenZhen = true;
                MonoWay.Instance.ReFreshBingShi();
                AllStaticVariable.day = "两周后";
                PatientChaTi.ResetChaTi();
                PatientZhiLiao.ResetZhiLiao();
                AllNeedUI.Instance.Date.text = "2周后";
                MonoWay.Instance.HeiPing();
                MonoWay.Instance.OpenTip("请点击病史采集或患者查体");
                break;
        }
    }

    //计算第一天用时
    private bool JudgeTime()
    {
        
        //计算用时
        float useTime = Time.time - AllStaticVariable.CostTime;
        print(Time.time);
        print(AllStaticVariable.CostTime);

        //创建评分item
        GameObject pingFen = PingFenItem.Init();
        pingFen.GetComponent<PingFenItem>().day.text = AllStaticVariable.day;
        pingFen.GetComponent<PingFenItem>().mission.text = "急诊抢救";
        pingFen.GetComponent<PingFenItem>().property.text = "临床诊断";
        pingFen.GetComponent<PingFenItem>().qusetionButton.SetActive(false);
        if (useTime <= 120)
        {
            pingFen.GetComponent<PingFenItem>().operate.text = "非常棒，在很短时间内完成了对病患的抢救工作。";
            pingFen.GetComponent<PingFenItem>().score.text = "0";
            MonoWay.Instance.starUp(10);
            pingFen.GetComponent<PingFenItem>().gou.SetActive(true);
            return true;
        }
        else if(useTime > 120 && useTime <= 600)
        {
            pingFen.GetComponent<PingFenItem>().operate.text = "在有限的时间内完成了对病患的抢救工作，合格。";
            pingFen.GetComponent<PingFenItem>().score.text = "0";
            MonoWay.Instance.starUp(5);
            pingFen.GetComponent<PingFenItem>().gou.SetActive(true);
            return true;
        }
        else
        {
            pingFen.GetComponent<PingFenItem>().operate.text = "因抢救时间太拖沓，导致病患未能得救并死亡。";
            pingFen.GetComponent<PingFenItem>().score.text = "0";
            pingFen.GetComponent<PingFenItem>().cross.SetActive(true);
            pingFen.GetComponent<PingFenItem>().analysisButton.SetActive(false);
            GameObject go = FailPanel.Init("因抢救时间太拖沓，导致病患未能得救并死亡。");
            return false;
        }

    }
    
    //第三天检查漏做选择题
    private void CheckMissChoicDay3()
    {
        if(!AllStaticVariable.IsDone33)
        {
            GameObject pingFen1 = createMissChoicePingFen();
            pingFen1.GetComponent<PingFenItem>().qusetionButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                QuestionBank.scorePoint33();
            });
            pingFen1.GetComponent<PingFenItem>().analysisButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                QuestionBank.scorePoint33Analysis();
            });

            GameObject pingFen2 = createMissChoicePingFen();
            pingFen2.GetComponent<PingFenItem>().qusetionButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                QuestionBank.scorePoint34();
            });
            pingFen2.GetComponent<PingFenItem>().analysisButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                QuestionBank.scorePoint34Analysis();
            });
        }
    }
    private void CheckMissChoicDay7()
    {       
        if (!AllStaticVariable.IsDone40)
        {
            GameObject pingFen1 = createMissChoicePingFen();
            pingFen1.GetComponent<PingFenItem>().qusetionButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                QuestionBank.scorePoint40();
            });
            pingFen1.GetComponent<PingFenItem>().analysisButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                QuestionBank.scorePoint40Analysis();
            });

            GameObject pingFen2 = createMissChoicePingFen();
            pingFen2.GetComponent<PingFenItem>().qusetionButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                QuestionBank.scorePoint41();
            });
            pingFen2.GetComponent<PingFenItem>().analysisButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                QuestionBank.scorePoint41Analysis();
            });
        }
    }
    private void CheckMissChoicDay8()
    {     
        if (!AllStaticVariable.IsDone46)
        {
            GameObject pingFen1 = createMissChoicePingFen();
            pingFen1.GetComponent<PingFenItem>().qusetionButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                QuestionBank.scorePoint46();
            });
            pingFen1.GetComponent<PingFenItem>().analysisButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                QuestionBank.scorePoint46Analysis();
            });
        }
        else if (!AllStaticVariable.IsDone51)
        {
            GameObject pingFen1 = createMissChoicePingFen();
            pingFen1.GetComponent<PingFenItem>().qusetionButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                QuestionBank.scorePoint51();
            });
            pingFen1.GetComponent<PingFenItem>().analysisButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                QuestionBank.scorePoint51Analysis();
            });         
        }
    }
    //创建漏做选择题评分item
    private GameObject createMissChoicePingFen()
    {
        //创建评分item
        GameObject pingFen = PingFenItem.Init();
        pingFen.GetComponent<PingFenItem>().day.text = AllStaticVariable.day;
        pingFen.GetComponent<PingFenItem>().mission.text = "临床诊断";
        pingFen.GetComponent<PingFenItem>().property.text = "临床诊断";
        pingFen.GetComponent<PingFenItem>().operate.text = "选择题：                   未完成，结束了当天工作。";
        pingFen.GetComponent<PingFenItem>().score.text = "-5";
        MonoWay.Instance.starDown(5);
        pingFen.GetComponent<PingFenItem>().cross.SetActive(true);
        pingFen.GetComponent<PingFenItem>().analysisButton.SetActive(true);
        pingFen.GetComponent<PingFenItem>().qusetionButton.SetActive(true);
        return pingFen;
    }
    //删除动态生成于canvas下的子物体
    private void DestroyChildrenOfCanvas()
    {
        GameObject canvas = AllNeedUI.Instance.Canvas;
        for (int i = canvas.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(canvas.transform.GetChild(i).gameObject);
        }
    }

    #endregion

    
}
