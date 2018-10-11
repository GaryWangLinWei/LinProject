using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PatientChaTi : MonoBehaviour
{
    //视诊按钮
    public GameObject ShiZhen;
    //尿液检查
    public GameObject NiaoJian;
    //血氧饱和度
    public GameObject XueYangBaoHe;
    //量体温
    public GameObject TiWen;
    //量血压
    public GameObject XueYa;
    //瞳孔检查
    public GameObject TongKongCheck;
    //触诊
    public GameObject ChuZhen;
    //CT检查
    public GameObject CTCheck;
    //MRI检查
    public GameObject MRICheck;
    //X光检查
    public GameObject XCheck;
    //血液检查
    public GameObject BloodCheck;
    //病情记录操作记录页面
    public GameObject OperateNote;
    public GameObject TiWenNote;
    public GameObject ChaTiNote;
    //操作记录toggle
    public Toggle OperateToggle;
    public Toggle TiWenToggle;
    public Toggle ChaTiToggle;
    //幻灯片精灵
    public Sprite[] SpritesHDP;


    //是否检查过该项
    public static bool IsShiZhen = false;
    public static bool IsNiaoJian = false;
    public static bool IsXueYangBaoHe = false;
    public static bool IsTiWen = false;
    public static bool IsXueYa = false;
    public static bool IsTongKongCheck = false;
    public static bool IsChuZhen = false;
    public static bool IsCTCheck = false;
    public static bool IsMRICheck = false;
    public static bool IsXCheck = false;
    public static bool IsBloodCheck = false;
    public static bool IsTingZhen = false;
    public static bool IsJiDianTu = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            print(IsCTCheck);
        }
    }
    public void ShiZhenClick()
    {
        if (AllStaticVariable.JianChaTime == -1)
        {
            OperateRecordItem.Init("视诊");
            TiChaTip5();
            return;
        }
        if (IsShiZhen == false)
        {
            switch (AllStaticVariable.JianChaTime)
            {
                case -2:
                    ReduceLeftNum();
                    OpenZhiLiao();
                    CreateBodyResult.Day0Item4();
                    break;
                case 0:
                    ReduceLeftNum();
                    OpenZhiLiao();
                    CreateBodyResult.Day1Item13();
                    break;
                case 1:
                    ReduceLeftNum();
                    OpenZhiLiao();
                    CreateBodyResult.Day2Item6();
                    CreateBodyResult.Day2Item7();
                    LoadCheckTalk();
                    break;
                case 2:
                    CreateBodyResult.Day3Item6();
                    //StartCoroutine(JumpQuestion());
                    LoadCheckTalk();
                    break;
                case 3:
                    ReduceLeftNum();
                    OpenZhiLiao();
                    CreateBodyResult.Day7Item6();
                    LoadCheckTalk();
                    break;
                case 4:
                    ReduceLeftNum();
                    OpenZhiLiao();
                    CreateBodyResult.Day8Item6();
                    break;
                case 5:
                    ReduceLeftNum();
                    OpenZhiLiao();
                    CreateBodyResult.Day8Item13();
                    break;
                case 6:
                    ReduceLeftNum();
                    OpenZhiLiao();
                    CreateBodyResult.LongAfterItem1();
                    break;
            }
            OperateRecordItem.Init("视诊");
            IsShiZhen = true;
            ShiZhenAnim();
        }
        else
        {
            TiChaTip2();
        }
    }
    public void NiaoJianClick()
    {
        if (AllStaticVariable.JianChaTime == -2 || AllStaticVariable.JianChaTime == -1)
        {
            OperateRecordItem.Init("尿液检查");
            TiChaTip5();
            return;
        }
        if (AllStaticVariable.JianChaTime == 6)
        {
            TiChaTip1();
            return;
        }
        else
        {
            if (IsNiaoJian == true)
            {
                TiChaTip1();
                return;
            }
            OperateRecordItem.Init("尿液检查");
            IsNiaoJian = true;
            TiChaTip1();
            CreateWrongRecord("尿液检查");
        }
    }
    public void XueYangBaoHeClick()
    {
        if (AllStaticVariable.JianChaTime == -1)
        {
            OperateRecordItem.Init("血氧饱和度");
            TiChaTip5();
            return;
        }
        if (AllStaticVariable.JianChaTime == 6)
        {
            TiChaTip1();
            return;
        }
        if (IsXueYangBaoHe == false)
        {
            switch (AllStaticVariable.JianChaTime)
            {
                case -2:
                    ReduceLeftNum();
                    OpenZhiLiao();
                    CreateBodyResult.Day0Item3();
                    break;
                case 0:
                    CreateBodyResult.Day1Item7();
                    break;
                case 1:
                    CreateBodyResult.Day2Item3();
                    break;
                case 2:
                    CreateBodyResult.Day3Item3();
                    break;
                case 3:
                    CreateBodyResult.Day7Item3();
                    break;
                case 4:
                    CreateBodyResult.Day8Item3();
                    break;
                case 5:
                    CreateBodyResult.Day8Item9();
                    break;
            }
            OperateRecordItem.Init("血氧饱和度");
            XueYangAnim();
            MonoWay.Instance.OpenBingQingResult();
            IsXueYangBaoHe = true;
        }
        else
        {
            TiChaTip2();
        }

    }
    public void TiWenClick()
    {
        if (AllStaticVariable.JianChaTime == -1)
        {
            OperateRecordItem.Init("量体温");
            TiChaTip5();
            return;
        }
        if (IsTiWen == false)
        {
            switch (AllStaticVariable.JianChaTime)
            {
                case -2:
                    ReduceLeftNum();
                    OpenZhiLiao();
                    CreateBodyResult.Day0Item1();
                    break;
                case 0:
                    CreateBodyResult.Day1Item5();
                    break;
                case 1:
                    CreateBodyResult.Day2Item1();
                    break;
                case 2:
                    CreateBodyResult.Day3Item1();
                    break;
                case 3:
                    CreateBodyResult.Day7Item1();
                    break;
                case 4:
                    CreateBodyResult.Day8Item1();
                    break;
                case 5:
                    CreateBodyResult.Day8Item7();
                    break;
                case 6:
                    CreateBodyResult.LongAfterItem3();
                    ReduceLeftNum();
                    break;

            }
            CloseChaTi();
            OperateRecordItem.Init("量体温");
            TiWenAnim();
            IsTiWen = true;
        }
        else
        {
            TiChaTip2();
        }
    }
    public void XueYaClick()
    {
        if (AllStaticVariable.JianChaTime == -1)
        {
            OperateRecordItem.Init("量血压");
            TiChaTip5();
            return;
        }
        if (IsXueYa == false)
        {
            switch (AllStaticVariable.JianChaTime)
            {
                case -2:
                    ReduceLeftNum();
                    OpenZhiLiao();
                    OperateRecordItem.Init("量血压");
                    MonoWay.Instance.OpenBingQingResult();
                    IsXueYa = true;
                    CreateBodyResult.Day0Item2();
                    return;
                case 0:
                    CreateBodyResult.Day1Item6();
                    break;
                case 1:
                    CreateBodyResult.Day2Item2();
                    break;
                case 2:
                    CreateBodyResult.Day3Item2();
                    break;
                case 3:
                    CreateBodyResult.Day7Item5();
                    break;
                case 4:
                    CreateBodyResult.Day8Item4();
                    break;
                case 5:
                    CreateBodyResult.Day8Item10();
                    break;
                case 6:
                    CreateBodyResult.LongAfterItem4();
                    OperateRecordItem.Init("量血压");
                    MonoWay.Instance.OpenBingQingResult();
                    IsXueYa = true;
                    ReduceLeftNum();
                    return;
            }
            OperateRecordItem.Init("量血压");
            XueYaAnim();
            MonoWay.Instance.OpenBingQingResult();
            IsXueYa = true;
        }
        else
        {
            TiChaTip2();
        }
    }
    public void TongKongCheckClick()
    {
        if (AllStaticVariable.JianChaTime == -1)
        {
            OperateRecordItem.Init("瞳孔检查");
            TiChaTip5();
            return;
        }
        if (AllStaticVariable.JianChaTime == 6)
        {
            TiChaTip1();
            return;
        }
        if (IsTongKongCheck == false)
        {
            if (AllStaticVariable.JianChaTime == 0)
            {
                print("得分");
                ReduceLeftNum();
                OpenZhiLiao();
                CreateBodyResult.Day1Item10();
            }
            if (AllStaticVariable.JianChaTime == 2)
            {
                ReduceLeftNum();
                OpenZhiLiao();
                OccurScore33();
                CreateBodyResult.Day3Item7();
            }
            OperateRecordItem.Init("瞳孔检查");
            if (AllStaticVariable.JianChaTime == -2)
            {
                TongKongAnim3();
            }
            else if (AllStaticVariable.JianChaTime == 0 || AllStaticVariable.JianChaTime == 1 || AllStaticVariable.JianChaTime == 2)
            {
                TongKongAnim2();
            }
            else
                TongKongAnim1();
            MonoWay.Instance.OpenBingQingResult();
            IsTongKongCheck = true;
        }
        else
        {
            TiChaTip2();
        }
    }
    public void ChuZhenClick()
    {
        if (AllStaticVariable.JianChaTime == -1)
        {
            OperateRecordItem.Init("触诊");
            TiChaTip5();
            return;
        }
        if (AllStaticVariable.JianChaTime == 6)
        {
            TiChaTip1();
            return;
        }
        if (IsChuZhen == false)
        {
            if (AllStaticVariable.JianChaTime == 0)
            {
                ReduceLeftNum();
                OpenZhiLiao();
                CreateBodyResult.Day1Item12();
            }
            else if (AllStaticVariable.JianChaTime == -2)
            {
                ReduceLeftNum();
                OpenZhiLiao();
                CreateBodyResult.Day0Item5();
            }
            //CloseChaTi();
            OperateRecordItem.Init("触诊");
            IsChuZhen = true;
            ChuZhenAnim();
            MonoWay.Instance.OpenBingQingResult();
        }
        else
        {
            TiChaTip2();
        }
    }
    public void CTCheckClick()
    {
        print(AllStaticVariable.JianChaTime);
        if (AllStaticVariable.JianChaTime == -2)
        {
            TiChaTip1();
            return;
        }
        if (AllStaticVariable.JianChaTime == -1)
        {
            if (IsCTCheck == true)
            {
                TiChaTip2();
                return;
            }
            IsCTCheck = true;
            CTAnim();
            MonoWay.Instance.CloseTip();
            OperateRecordItem.Init("CT检查");
            ReduceLeftNum();
            AllNeedUI.Instance.ChaTiPanel.SetActive(false);
            AllNeedUI.Instance.XueJianWarning.SetActive(true);
            AllNeedUI.Instance.CTScanWarning.SetActive(true);
            return;
        }
        else if (AllStaticVariable.JianChaTime == 6)
        {
            TiChaTip1();
        }
        else if (AllStaticVariable.JianChaTime == 3)
        {
            if (IsCTCheck)
            {
                TiChaTip2();
            }
            else
            {
                IsCTCheck = true;
                CTAnim();
                AllNeedUI.Instance.CtReport2.SetActive(true);
                OperateRecordItem.Init("CT检查");
                CreateBodyResult.Day7Item8();
                ReduceLeftNum();
                OpenZhiLiao();
                AllNeedUI.Instance.CtReport2.SetActive(true);
            }
        }
        else if (AllStaticVariable.JianChaTime >= 0 && AllStaticVariable.JianChaTime < 6)
        {
            if (!IsCTCheck)
            {
                TiChaTip1();
                return;
            }
            IsCTCheck = true;
            TiChaTip1();
            OperateRecordItem.Init("CT检查");
            CreateWrongRecord("CT检查");
        }

    }
    public void MRICheckClick()
    {
        if (AllStaticVariable.JianChaTime == -2 || AllStaticVariable.JianChaTime == -1)
        {
            OperateRecordItem.Init("MRI检查");
            TiChaTip5();
            return;
        }
        if (AllStaticVariable.JianChaTime == 6)
        {
            TiChaTip1();
            return;
        }
        if (IsMRICheck == false)
        {
            OperateRecordItem.Init("MRI检查");
            IsMRICheck = true;
            CreateWrongRecord("MRI检查");
            TiChaTip1();
        }
        else
        {
            TiChaTip1();
        }
    }
    public void XCheckClick()
    {
        if (AllStaticVariable.JianChaTime == -2 || AllStaticVariable.JianChaTime == -1)
        {
            OperateRecordItem.Init("X光检查");
            TiChaTip5();
            return;
        }
        if (AllStaticVariable.JianChaTime == 6)
        {
            TiChaTip1();
            return;
        }
        if (IsXCheck == false)
        {
            OperateRecordItem.Init("X光检查");
            IsXCheck = true;
            CreateWrongRecord("X光检查");
            TiChaTip1();
        }
        else
        {
            TiChaTip1();
        }
    }
    public void BloodCheckClick()
    {
        if (AllStaticVariable.JianChaTime == -2)
        {
            if (IsBloodCheck == true)
            {
                TiChaTip2();
                return;
            }
            IsBloodCheck = true;
            ReduceLeftNum();
            OpenZhiLiao();
            OperateRecordItem.Init("血液检查");
            BloodAnim();

            return;
        }
        if (AllStaticVariable.JianChaTime == -1)
        {
            TiChaTip1();
            return;
        }
        if (IsBloodCheck == true)
        {
            TiChaTip2();
        }
        else
        {
            switch (AllStaticVariable.JianChaTime)
            {
                case 1:
                    CreateBodyResult.Day2Item8();
                    ReduceLeftNum();
                    OpenZhiLiao();
                    AllNeedUI.Instance.xueJianReport2.SetActive(true);
                    if (AllNeedUI.Instance.ChaTiLeftLabel.text == "0")
                        AllNeedUI.Instance.XueYeJingHuaWarning.SetActive(true);
                    break;
                case 2:
                    CreateBodyResult.Day3Item9();
                    ReduceLeftNum();
                    OpenZhiLiao();
                    OccurScore33();
                    AllNeedUI.Instance.xueJianReport3.SetActive(true);
                    break;
                case 3:
                    CreateBodyResult.Day7Item7();
                    ReduceLeftNum();
                    OpenZhiLiao();
                    AllNeedUI.Instance.xueJianReport4.SetActive(true);
                    break;
                case 4:
                    ReduceLeftNum();
                    OpenZhiLiao();
                    break;
                case 5:
                    TiChaTip2();
                    return;
                case 6:
                    ReduceLeftNum();
                    OpenZhiLiao();
                    CreateBodyResult.LongAfterItem5();
                    AllNeedUI.Instance.xueJianReport5.SetActive(true);
                    break;
            }
            OperateRecordItem.Init("血液检查");
            BloodAnim();
            MonoWay.Instance.OpenBingQingResult();

            IsBloodCheck = true;
        }
    }

    public void TingZhenClick()
    {
        if (AllStaticVariable.JianChaTime == -1)
        {
            OperateRecordItem.Init("听诊");
            TiChaTip5();
            return;
        }
        if (IsTingZhen == false)
        {
            switch (AllStaticVariable.JianChaTime)
            {
                case -2:
                    ReduceLeftNum();
                    OpenZhiLiao();
                    CreateBodyResult.Day0Item7();
                    CreateBodyResult.Day0Item8();
                    CreateBodyResult.Day0Item6();
                    break;

                case 0:
                    CreateBodyResult.Day1Item11();
                    CreateBodyResult.Day1Item8();
                    CreateBodyResult.Day1Item9();
                    ReduceLeftNum();
                    OpenZhiLiao();
                    break;
                case 1:
                    CreateBodyResult.Day2Item4();
                    CreateBodyResult.Day2Item5();
                    break;
                case 2:
                    CreateBodyResult.Day3Item8();
                    CreateBodyResult.Day3Item4();
                    CreateBodyResult.Day3Item5();
                    ReduceLeftNum();
                    OpenZhiLiao();
                    //StartCoroutine(JumpQuestionAfterTing());
                    break;
                case 3:
                    CreateBodyResult.Day7Item2();
                    CreateBodyResult.Day7Item4();
                    break;
                case 4:
                    CreateBodyResult.Day8Item2();
                    CreateBodyResult.Day8Item5();
                    break;
                case 5:
                    CreateBodyResult.Day8Item8();
                    CreateBodyResult.Day8Item11();
                    break;
                case 6:
                    CreateBodyResult.LongAfterItem2();
                    ReduceLeftNum();
                    OpenZhiLiao();
                    break;
            }
            CloseChaTi();
            OperateRecordItem.Init("听诊");
            TingZhenAnim();
            IsTingZhen = true;
        }
        else
        {
            TiChaTip2();
        }
    }
    //肌电图
    public void JiDianTUClick()
    {
        if (!IsJiDianTu)
        {
            CreateBodyResult.LongAfterItem6();
            ReduceLeftNum();
            OpenZhiLiao();
            CloseChaTi();
            MonoWay.Instance.OpenBingQingResult();
            IsJiDianTu = true;
        }
        else
        {
            TiChaTip2();
        }
    }


    //题33出现
    public void OccurScore33()
    {
        print(AllNeedUI.Instance.ChaTiLeftLabel.text);
        if (AllNeedUI.Instance.ChaTiLeftLabel.text == "0")
            QuestionBank.scorePoint33();
    }

    #region 提示
    /// <summary>
    /// 提示：患者无需此项检查
    /// </summary>
    private void TiChaTip1()
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_normalTip"));
        go.transform.parent = GameObject.Find("Canvas").transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "病患无需此项检查。";
        go.transform.Find("Button_QueDing").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(go);
        });
    }
    /// <summary>
    /// 提示：患者已做过此类检查，不用重复检查。
    /// </summary>
    private void TiChaTip2()
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_normalTip"));
        go.transform.parent = GameObject.Find("Canvas").transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "患者已做过此类检查，不用重复检查。";
        go.transform.Find("Button_QueDing").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(go);
        });
    }
    /// <summary>
    /// 提示：患者经治疗及心理干预后，完全康复出院。
    /// </summary>
    private void TiChaTip3()
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_normalTip"));
        go.transform.parent = GameObject.Find("Canvas").transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "患者经治疗及心理干预后，完全康复出院。";
        go.transform.Find("Button_QueDing").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(go);
        });
    }

    /// <summary>
    /// 提示：预检台已查体
    /// </summary>
    public void TiChaTip5()
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_normalTip"));
        go.transform.parent = GameObject.Find("Canvas").transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "预检台已经查体，请查看预检台查体结果。";
        go.transform.Find("Button_QueDing").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(go);
        });
    }
    #endregion
    //生成错误记录
    private void CreateWrongRecord(string name)
    {
        GameObject pingFen = PingFenItem.Init();
        pingFen.GetComponent<PingFenItem>().day.text = AllStaticVariable.day;
        if (AllStaticVariable.JianChaTime == 5)
            pingFen.GetComponent<PingFenItem>().mission.text = "普通病房查体";
        else if (AllStaticVariable.JianChaTime == 6)
            pingFen.GetComponent<PingFenItem>().mission.text = "门诊查体";
        else
            pingFen.GetComponent<PingFenItem>().mission.text = "EICU查体";
        pingFen.GetComponent<PingFenItem>().property.text = "专业知识";
        pingFen.GetComponent<PingFenItem>().score.text = "-2";
        MonoWay.Instance.starDown(2);
        pingFen.GetComponent<PingFenItem>().cross.SetActive(true);
        pingFen.GetComponent<PingFenItem>().qusetionButton.SetActive(false);
        pingFen.GetComponent<PingFenItem>().analysisButton.SetActive(false);
        pingFen.GetComponent<PingFenItem>().operate.text = name + "，不适合当前操作";
    }
    //生成正确记录
    private void CreateRightRecord()
    {
        GameObject pingFen = PingFenItem.Init();
        pingFen.GetComponent<PingFenItem>().day.text = AllStaticVariable.day;
        if (AllStaticVariable.JianChaTime == 5)
            pingFen.GetComponent<PingFenItem>().mission.text = "普通病房查体";
        else if (AllStaticVariable.JianChaTime == 6)
            pingFen.GetComponent<PingFenItem>().mission.text = "门诊查体";
        else
            pingFen.GetComponent<PingFenItem>().mission.text = "EICU查体";
        pingFen.GetComponent<PingFenItem>().property.text = "专业知识";
        pingFen.GetComponent<PingFenItem>().score.text = "0";
        MonoWay.Instance.starUp(1);
        pingFen.GetComponent<PingFenItem>().gou.SetActive(true);
        pingFen.GetComponent<PingFenItem>().qusetionButton.SetActive(false);
        pingFen.GetComponent<PingFenItem>().operate.text = "选择正确的查体项目。";
    }

    private static void CreateMissRecord(string name)
    {
        GameObject pingFen = PingFenItem.Init();
        pingFen.GetComponent<PingFenItem>().day.text = AllStaticVariable.day;
        if (AllStaticVariable.JianChaTime == 5)
            pingFen.GetComponent<PingFenItem>().mission.text = "普通病房查体";
        else if (AllStaticVariable.JianChaTime == 6)
            pingFen.GetComponent<PingFenItem>().mission.text = "门诊查体";
        else
            pingFen.GetComponent<PingFenItem>().mission.text = "EICU查体";
        pingFen.GetComponent<PingFenItem>().property.text = "专业知识";
        pingFen.GetComponent<PingFenItem>().score.text = "-3";
        MonoWay.Instance.starDown(3);
        pingFen.GetComponent<PingFenItem>().cross.SetActive(true);
        pingFen.GetComponent<PingFenItem>().qusetionButton.SetActive(false);
        pingFen.GetComponent<PingFenItem>().analysisButton.SetActive(false);
        pingFen.GetComponent<PingFenItem>().operate.text = name + "，未完成就结束当天工作了。";
    }

    //剩余查体数量-1
    private void ReduceLeftNum()
    {
        CreateRightRecord();
        int oldNum = int.Parse(AllNeedUI.Instance.ChaTiLeftLabel.text);
        int newNum = oldNum - 1;
        AllNeedUI.Instance.ChaTiLeftLabel.text = newNum.ToString();
    }

    public static void ResetChaTi()
    {
        IsBloodCheck = false;
        IsCTCheck = false;
        IsChuZhen = false;
        IsMRICheck = false;
        IsNiaoJian = false;
        IsShiZhen = false;
        IsTiWen = false;
        IsTongKongCheck = false;
        IsXCheck = false;
        IsXueYa = false;
        IsXueYangBaoHe = false;
        IsTingZhen = false;
        IsJiDianTu = false;
    }

    #region 对应动画

    private void ShiZhenAnim()
    {
        if (AllStaticVariable.JianChaTime == -2)
        {
            AllNeedUI.Instance.DaTangCamera.SetActive(true);
        }
        if (AllStaticVariable.JianChaTime == 1 || AllStaticVariable.JianChaTime == 2 || AllStaticVariable.JianChaTime == 3)
        {
            AllNeedUI.Instance.ChaTiPanel.SetActive(false);
            return;
        }
        AllNeedUI.Instance.ChaTiPanel.SetActive(false);
        if (AllStaticVariable.IsInEICU)
        {
            AllNeedUI.Instance.EICUCamera.SetActive(true);
        }
        else if (AllStaticVariable.IsInPt)
        {
            AllNeedUI.Instance.PTCamera.SetActive(true);
        }
        else if (AllStaticVariable.IsInMenZhen)
        {
            AllNeedUI.Instance.MenZhenObject.SetActive(true);
            AllNeedUI.Instance.MenZhenCamera.SetActive(true);
        }
    }

    private void TiWenAnim()
    {
        if (AllStaticVariable.JianChaTime == -2)
        {
            AllNeedUI.Instance.DaTangChaTi.SetActive(true);
            GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/Go/TiWenJi_DaTang"));
            go.transform.parent = GameObject.Find("Tool").transform;

        }
        else if (AllStaticVariable.IsInEICU)
        {
            CamMove.Instance.MoveCamto(3);
            AllNeedUI.Instance.EICUBeiZi.SetActive(false);
            GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/Go/TiWenJi_EICU"));
            go.transform.parent = GameObject.Find("Tool").transform;
        }
        else if (AllStaticVariable.IsInPt)
        {
            CamMove.Instance.MoveCamto(8);
            AllNeedUI.Instance.PTBeiZi.SetActive(false);
            GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/Go/TiWenJi_PT"));
            go.transform.parent = GameObject.Find("Tool").transform;
        }
        else if (AllStaticVariable.IsInMenZhen)
        {
            CamMove.Instance.MoveCamto(10);
            GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/Go/TiWenJi_MenZhen"));
            go.transform.parent = GameObject.Find("Tool").transform;
        }

    }

    private void XueYangAnim()
    {
        Sprite[] list = { SpritesHDP[10] };
        MonoWay.Instance.DongHua(list, 2f);
    }

    private void XueYaAnim()
    {
        Sprite[] list = { SpritesHDP[7], SpritesHDP[8] };
        MonoWay.Instance.DongHua(list, 1f);
    }
    //前三天
    private void TongKongAnim2()
    {
        Sprite[] list = { SpritesHDP[0], SpritesHDP[1], SpritesHDP[2], SpritesHDP[3], SpritesHDP[4], SpritesHDP[5] };
        MonoWay.Instance.DongHua(list, 1f);
    }

    //后几天
    private void TongKongAnim1()
    {
        Sprite[] list = { SpritesHDP[11], SpritesHDP[12], SpritesHDP[13], SpritesHDP[14], SpritesHDP[15], SpritesHDP[16] };
        MonoWay.Instance.DongHua(list, 1f);
        //if (AllStaticVariable.JianChaTime == 0 && !AllStaticVariable.IsJumpChaTiTip)
        //{
        //    AllNeedUI.Instance.ChaTiPanel.SetActive(false);
        //    AllStaticVariable.IsJumpChaTiTip = true;
        //    StartCoroutine(OpenChaTiTip(6));
        //}
    }
    //第一天
    private void TongKongAnim3()
    {
        Sprite[] list = { SpritesHDP[19], SpritesHDP[20], SpritesHDP[21], SpritesHDP[22], SpritesHDP[23], SpritesHDP[24] };
        MonoWay.Instance.DongHua(list, 1f);
    }
    IEnumerator OpenChaTiTip(int num)
    {
        yield return new WaitForSeconds(num);
        MonoWay.Instance.OpenBingQingResult();
        yield return new WaitForSeconds(1);
        AllNeedUI.Instance.ChaTiTip.SetActive(true);
    }
    private void ChuZhenAnim()
    {
        print("2");
        Sprite[] list = { SpritesHDP[17], SpritesHDP[18] };
        MonoWay.Instance.DongHua(list, 1f);
        //if (AllStaticVariable.JianChaTime == 0 && !AllStaticVariable.IsJumpChaTiTip)
        //{
        //    AllNeedUI.Instance.ChaTiPanel.SetActive(false);
        //    AllStaticVariable.IsJumpChaTiTip = true;
        //    StartCoroutine(OpenChaTiTip(2));
        //}
        //if (AllStaticVariable.IsInEICU)
        //{
        //    CamMove.Instance.MoveCamto(3);
        //    AllNeedUI.Instance.EICUBeiZi.SetActive(false);
        //    GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/Go/Shou_EICU"));
        //    go.transform.parent = GameObject.Find("Tool").transform;
        //}
        //else if (AllStaticVariable.IsInPt)
        //{
        //    CamMove.Instance.MoveCamto(8);
        //    AllNeedUI.Instance.PTBeiZi.SetActive(false);
        //    GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/Go/Shou_PT"));
        //    go.transform.parent = GameObject.Find("Tool").transform;
        //}
    }

    private void CTAnim()
    {
        Sprite[] list = { SpritesHDP[9] };
        MonoWay.Instance.DongHua(list, 2f);
    }

    private void BloodAnim()
    {
        Sprite[] list = { SpritesHDP[6] };
        MonoWay.Instance.DongHua(list, 1f);
    }

    private void TingZhenAnim()
    {
        if (AllStaticVariable.JianChaTime == -2)
        {
            AllNeedUI.Instance.DaTangChaTi.SetActive(true);
            GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/Go/TingZhenQi_DaTang"));
            go.transform.parent = GameObject.Find("Tool").transform;
            AllNeedUI.Instance.DaTangCloth.SetActive(false);
        }
        if (AllStaticVariable.IsInEICU)
        {
            CamMove.Instance.MoveCamto(3);
            AllNeedUI.Instance.ICUBeiXin.SetActive(true);
            AllNeedUI.Instance.ICUShangYi.SetActive(false);
            AllNeedUI.Instance.EICUBeiZi.SetActive(false);
            AllNeedUI.Instance.DianJiDaoXian.SetActive(false);
            GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/Go/TingZhenQi_EICU"));
            go.transform.parent = GameObject.Find("Tool").transform;
        }
        else if (AllStaticVariable.IsInPt)
        {
            CamMove.Instance.MoveCamto(8);
            AllNeedUI.Instance.PTBeiZi.SetActive(false);
            AllNeedUI.Instance.PtBeiXin.SetActive(true);
            AllNeedUI.Instance.PtShangYi.SetActive(false);
            GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/Go/TingZhenQi_PT"));
            go.transform.parent = GameObject.Find("Tool").transform;
        }
        else if (AllStaticVariable.IsInMenZhen)
        {
            CamMove.Instance.MoveCamto(12);
            GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/Go/TingZhenQi_MenZhen"));
            go.transform.parent = GameObject.Find("Tool").transform;
        }
    }


    //视诊结束后跳出问题
    IEnumerator JumpQuestion()
    {
        yield return new WaitForSeconds(4);
        OccurScore33();
    }
    IEnumerator JumpQuestionAfterTing()
    {
        yield return new WaitForSeconds(4f);
        OccurScore33();
    }

    #endregion

    //关闭查体
    private void CloseChaTi()
    {
        AllNeedUI.Instance.ChaTiPanel.SetActive(false);
        AllNeedUI.Instance.mainMenuToggles[3].GetComponent<Toggle>().isOn = false;
    }

    //遗漏查体
    public static void CheckHasMiss()
    {
        switch (AllStaticVariable.JianChaTime)
        {
            case 0:
                if (!IsShiZhen)
                    CreateMissRecord("视诊");
                if (!IsTongKongCheck)
                    CreateMissRecord("瞳孔检查");
                if (!IsChuZhen)
                    CreateMissRecord("触诊");
                if (!IsTingZhen)
                    CreateMissRecord("听诊");
                break;
            case 1:
                if (!IsShiZhen)
                    CreateMissRecord("视诊");
                if (!IsBloodCheck)
                    CreateMissRecord("血液检查");
                break;
            case 2:
                if (!IsTongKongCheck)
                    CreateMissRecord("瞳孔检查");
                if (!IsBloodCheck)
                    CreateMissRecord("血液检查");
                if (!IsTingZhen)
                    CreateMissRecord("听诊");
                break;
            case 3:
                if (!IsShiZhen)
                    CreateMissRecord("视诊");
                if (!IsBloodCheck)
                    CreateMissRecord("血液检查");
                break;
            case 4:
                if (!IsShiZhen)
                    CreateMissRecord("视诊");
                if (!IsBloodCheck)
                    CreateMissRecord("血液检查");
                break;
            case 6:
                if (!IsShiZhen)
                    CreateMissRecord("视诊");
                if (!IsTingZhen)
                    CreateMissRecord("听诊");
                break;
        }
    }

    //弹出病史记录操作记录
    private void OpenBingQingRecord()
    {
        AllNeedUI.Instance.BingQingRecord.SetActive(true);
        AllNeedUI.Instance.ChaTiPanel.SetActive(false);
        OperateNote.SetActive(true);
        TiWenNote.SetActive(false);
        ChaTiNote.SetActive(false);
        OperateToggle.isOn = true;
        TiWenToggle.isOn = false;
        ChaTiToggle.isOn = false;
        OperateToggle.transform.GetChild(0).GetComponent<Image>().overrideSprite =
            Resources.Load("smallPic/BingQingRecord/operateNote1", typeof(Sprite)) as Sprite;
        TiWenToggle.transform.GetChild(0).GetComponent<Image>().overrideSprite =
            Resources.Load("smallPic/BingQingRecord/TiWenNote1", typeof(Sprite)) as Sprite;
        ChaTiToggle.transform.GetChild(0).GetComponent<Image>().overrideSprite =
            Resources.Load("smallPic/BingQingRecord/ChaTiNote1", typeof(Sprite)) as Sprite;
    }
    //满足条件时打开治疗开关
    private void OpenZhiLiao()
    {
        if (AllNeedUI.Instance.ChaTiLeftLabel.text == "0" &&
            (AllStaticVariable.IsFinishTodayAsk || AllNeedUI.Instance.WenZhenLeftLabel.text == "0"))
        {
            MonoWay.Instance.OpenTip("请点击患者治疗");
            AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().enabled = true;
        }
    }
    //延时关闭病史
    IEnumerator delayCloseBingQing()
    {
        yield return new WaitForSeconds(2);
        AllNeedUI.Instance.BingQingRecord.SetActive(false);
    }
    //加载视诊前对话
    private void LoadCheckTalk()
    {
        print(":");
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_CheckTalk"));
        go.transform.SetParent(AllNeedUI.Instance.Canvas.transform);
        go.transform.localPosition = Vector3.zero;
        go.transform.localScale = Vector3.one;
    }
}
