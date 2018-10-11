using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PatientZhiLiao : MonoBehaviour
{
    public GameObject JiZhen;
    public GameObject XueTou;
    public GameObject FangShe;
    public GameObject QiGuan;
    public GameObject XiWei;
    public GameObject XinLi;
    public GameObject ShouShu;
    public GameObject YaoWu;
    public GameObject YingYang;
    public GameObject BiDaoGuan;
    public GameObject HuXiQiNang;
    public GameObject XueTouJi;
    //public GameObject HuXiJi;
    public Sprite[] SpritesHDP;

    public static bool IsJiZhen = false;
    public static bool IsXueTou = false;
    public static bool IsFangShe = false;
    public static bool IsQiGuan = false;
    public static bool IsXiWei = false;
    public static bool IsXinLi = false;
    public static bool IsShouShu = false;
    public static bool IsYaoWu = false;
    public static bool IsYingYang = false;
    public static bool IsBiDaoGuan = false;
    public static bool IsHuXiQiNang = false;
    public static bool IsXueTouJi = false;
    public static bool IsHuXiJi = false;

    public void JiZhenClick()
    {
        if (AllStaticVariable.ZhiLiaoTime == 0)
        {
            QuestionBank.scorePoint3();
            OperateRecordItem.Init("急诊分诊");
            CreateFenZhenRecord(true);
            CloseZhiLiao();
            RefreshZhiLiao();
            ReduceLeftNum();
        }
    }
    public void XueTouClick()
    {
        switch (AllStaticVariable.ZhiLiaoTime)
        {
            case 1:
                ZhiLiaoTip10();
                break;
            case 2:
                if (!IsXueTou)
                {
                    if (IsYaoWu)
                    {
                        OperateRecordItem.Init("血透置管");
                        CreateRightRecord();
                        XueTouAnim();
                        ReduceLeftNum();
                        IsXueTou = true;
                        Transform[] item1 = { AllNeedUI.Instance.ZhiLiaoItems[7] };
                        MonoWay.Instance.PreferItem(item1);
                        AllNeedUI.Instance.ZhiLiaoPanel.SetActive(false);

                        AllStaticVariable.JianChaTime = -1;
                        AllNeedUI.Instance.ChaTiLeftLabel.text = "1";
                        Transform[] item2 =
                        {
                            AllNeedUI.Instance.ChaTiItems[7]
                        };
                        MonoWay.Instance.PreferItem(item2);
                        MonoWay.Instance.OpenTip("请进行CT检查");
                    }
                    else
                    {
                        OperateRecordItem.Init("血透置管");
                        CreateJiZhenRecord(false);
                        ZhiLiaoTip9();
                    }
                }
                else
                {
                    ZhiLiaoTip1();
                }
                break;
            default:
                OperateRecordItem.Init("血透置管");
                ZhiLiaoTip1();
                CreateWrongRecord("血透置管");
                break;
        }
    }
    public void FangSheClick()
    {
        switch (AllStaticVariable.ZhiLiaoTime)
        {
            case 1:
                OperateRecordItem.Init("放射治疗");
                CreateJiZhenRecord(false);
                string text = "未按正确诊断治疗导致病患病情加重最终导致病患死亡。";
                FailPanel.Init(text);
                break;
            case 2:
                OperateRecordItem.Init("放射治疗");
                CreateJiZhenRecord(false);
                ZhiLiaoTip9();
                break;
            default:
                OperateRecordItem.Init("放射治疗");
                ZhiLiaoTip3();
                CreateWrongRecord("放射治疗");
                break;
        }
    }
    public void QiGuanClick()
    {
        switch (AllStaticVariable.ZhiLiaoTime)
        {
            case 1:
                OperateRecordItem.Init("气管插管");
                CreateJiZhenRecord(false);
                string text = "未按正确诊断治疗导致病患病情加重最终导致病患死亡。";
                FailPanel.Init(text);
                break;
            case 2:
                if(!IsQiGuan)
                {
                    //进入室内，噪音减小
                    IsQiGuan = true;
                    AllNeedUI.Instance.XiWeiBg.SetActive(false);
                    AllNeedUI.Instance.BgNoise.volume = 0.12f;
                    OperateRecordItem.Init("气管插管");
                    MonoWay.Instance.CloseTip();
                    CreateJiZhenRecord(true);
                    QiGuanAnim();
                    AllNeedUI.Instance.JiZhenBingRen.SetActive(true);
                    CamMove.Instance.MoveCamto(5);
                    AllNeedUI.Instance.ZouLangWenZhen.SetActive(false);
                    QuestionBank.scorePoint15();
                    CloseZhiLiao();
                    ReduceLeftNum();
                }
                else
                {
                    ZhiLiaoTip1();
                }
                break;
            default:
                OperateRecordItem.Init("气管插管");
                ZhiLiaoTip1();
                CreateWrongRecord("气管插管");
                break;
        }
    }
    public void XiWeiClick()
    {
        switch (AllStaticVariable.ZhiLiaoTime)
        {
            case 1:
                OperateRecordItem.Init("洗胃");
                CreateJiZhenRecord(true);
                XiWeiAnim();
                AllNeedUI.Instance.ZhiLiaoPanel.SetActive(false);
                //AllNeedUI.Instance.KnowledgePanel.SetActive(true);
                ReduceLeftNum();
                MonoWay.Instance.OpenTip("请进行气管插管治疗");
                break;
            case 2:
                OperateRecordItem.Init("洗胃");
                CreateJiZhenRecord(false);
                ZhiLiaoTip9();
                break;
            default:
                OperateRecordItem.Init("洗胃");
                ZhiLiaoTip1();
                CreateWrongRecord("洗胃");
                break;
        }
    }
    public void XinLiClick()
    {
        switch (AllStaticVariable.ZhiLiaoTime)
        {
            case 1:
                OperateRecordItem.Init("心理干预");
                CreateJiZhenRecord(false);
                string text = "未按正确诊断治疗导致病患病情加重最终导致病患死亡。";
                FailPanel.Init(text);
                break;
            case 2:
                OperateRecordItem.Init("心理干预");
                CreateJiZhenRecord(false);
                ZhiLiaoTip9();
                break;
            case 3:
            case 4:
            case 5:
            case 21:
                ZhiLiaoTip2();
                CreateWrongRecord("心理干预");
                break;
            default:
                if (IsXinLi == false)
                {
                    OperateRecordItem.Init("心理干预");
                    CreateRightRecord();
                    XinLiAnim();
                    ReduceLeftNum();
                    EndTodayJob();
                    IsXinLi = true;
                    if (AllStaticVariable.ZhiLiaoTime == 6)
                        OccurEmergency();
                    if (AllStaticVariable.ZhiLiaoTime == 7)
                    {
                        OccurScore46();
                    }
                }
                else
                {
                    ZhiLiaoTip1();
                }

                break;
        }
    }
    public void ShouShuClick()
    {
        switch (AllStaticVariable.ZhiLiaoTime)
        {
            case 1:
                OperateRecordItem.Init("外科手术");
                CreateJiZhenRecord(false);
                string text = "未按正确诊断治疗导致病患病情加重最终导致病患死亡。";
                FailPanel.Init(text);
                break;
            case 2:
                OperateRecordItem.Init("外科手术");
                CreateJiZhenRecord(false);
                ZhiLiaoTip9();
                break;
            default:
                OperateRecordItem.Init("外科手术");
                ZhiLiaoTip3();
                CreateWrongRecord("外科手术");
                break;
        }
    }
    public void YaoWulick()
    {
        switch (AllStaticVariable.ZhiLiaoTime)
        {
            case 1:
                OperateRecordItem.Init("营养支持");
                CreateJiZhenRecord(false);
                string text = "未按正确诊断治疗导致病患病情加重最终导致病患死亡。";
                FailPanel.Init(text);
                break;
            case 2:
                if (!IsYaoWu)
                {
                    if (IsQiGuan)
                    {
                        OperateRecordItem.Init("药物治疗");
                        ReduceLeftNum();
                        CreateYaoPin();
                        IsYaoWu = true;
                        CreateRightRecord();
                        Transform[] item7 = { AllNeedUI.Instance.ZhiLiaoItems[4] };
                        MonoWay.Instance.PreferItem(item7);
                        AllNeedUI.Instance.ZhiLiaoPanel.SetActive(false);
                        MonoWay.Instance.CloseTip();
                        //MonoWay.Instance.OpenTip("请进行患者洗胃");
                    }
                    else
                    {
                        ZhiLiaoTip10();
                    }
                }
                else
                {
                    ZhiLiaoTip1();
                }
                break;
            case 3:
                if (IsYaoWu == false)
                {
                    OperateRecordItem.Init("药物治疗");
                    CreateYaoPin();
                    IsYaoWu = true;
                    ReduceLeftNum();
                    CreateRightRecord();
                }
                else
                {
                    ZhiLiaoTip1();
                }
                break;
            case 21:
                if (IsYaoWu == false)
                {
                    OperateRecordItem.Init("药物治疗");
                    CreateYaoPin();
                    IsYaoWu = true;
                    ReduceLeftNum();
                    CreateRightRecord();
                }
                else
                {
                    ZhiLiaoTip1();
                }
                break;
            default:
                if (IsYaoWu == false)
                {
                    OperateRecordItem.Init("药物治疗");
                    CreateYaoPin();
                    IsYaoWu = true;
                    ReduceLeftNum();
                    EndTodayJob();
                    CreateRightRecord();
                }
                else
                    ZhiLiaoTip1();
                break;
        }
    }
    public void YingYangClick()
    {
        switch (AllStaticVariable.ZhiLiaoTime)
        {
            case 1:
                OperateRecordItem.Init("营养支持");
                CreateJiZhenRecord(false);
                string text = "未按正确诊断治疗导致病患病情加重最终导致病患死亡。";
                FailPanel.Init(text);
                break;
            case 2:
                OperateRecordItem.Init("营养支持");
                CreateJiZhenRecord(false);
                ZhiLiaoTip9();
                break;
            case 6:
                if (IsYingYang == false)
                {
                    OperateRecordItem.Init("营养支持");
                    YingYangAnim();
                    IsYingYang = true;
                }
                else
                {
                    ZhiLiaoTip1();
                }
                break;
            case 21:
                ZhiLiaoTip10();
                break;
            default:
                if (IsYingYang == false)
                {
                    ReduceLeftNum();
                    EndTodayJob();
                    YingYangAnim();
                    if (AllStaticVariable.ZhiLiaoTime == 7)
                    {
                        OccurScore46();
                    }
                    OperateRecordItem.Init("营养支持");
                    IsYingYang = true;
                    CreateRightRecord();

                }
                else
                {
                    ZhiLiaoTip1();
                }
                break;
        }
    }
    public void BiDaoGuanClick()
    {
        switch (AllStaticVariable.ZhiLiaoTime)
        {
            case 1:
                OperateRecordItem.Init("鼻导管给氧");
                CreateJiZhenRecord(false);
                string text = "未按正确诊断治疗导致病患病情加重最终导致病患死亡。";
                FailPanel.Init(text);
                break;
            case 2:
                OperateRecordItem.Init("鼻导管给氧");
                CreateJiZhenRecord(false);
                ZhiLiaoTip9();
                break;
            case 6:
                OperateRecordItem.Init("鼻导管给氧");
                ZhiLiaoTip1();
                break;
            default:
                OperateRecordItem.Init("鼻导管给氧");
                CreateWrongRecord("鼻导管给氧");
                ZhiLiaoTip4();
                break;
        }
    }
    public void HuXiQiuNangClick()
    {
        switch (AllStaticVariable.ZhiLiaoTime)
        {
            case 1:
                OperateRecordItem.Init("连接呼吸球囊");
                CreateJiZhenRecord(false);
                string text = "未按正确诊断治疗导致病患病情加重最终导致病患死亡。";
                FailPanel.Init(text);
                break;
            case 2:
                OperateRecordItem.Init("连接呼吸球囊");
                CreateJiZhenRecord(false);
                ZhiLiaoTip9();
                break;
            case 21:
                if (!IsHuXiQiNang)
                {
                    print("出现球囊");
                    AllNeedUI.Instance.HuXiQiuNang.SetActive(true);
                    ReduceLeftNum();
                    if (AllNeedUI.Instance.ZhiLiaoLeftLabel.text == "0")
                    {
                        AllNeedUI.Instance.XueJianWarning.SetActive(true);
                        AllNeedUI.Instance.CTScanWarning.SetActive(true);
                    }
                    IsHuXiQiNang = true;
                }
                else
                {
                    ZhiLiaoTip1();
                }
                break;
            default:
                ZhiLiaoTip10();
                break;
        }
    }
    public void HuXiJiClick()
    {
        switch (AllStaticVariable.ZhiLiaoTime)
        {
            case 1:
                OperateRecordItem.Init("连接呼吸机");
                CreateJiZhenRecord(false);
                string text = "未按正确诊断治疗导致病患病情加重最终导致病患死亡。";
                FailPanel.Init(text);
                break;
            case 2:
                OperateRecordItem.Init("连接呼吸机");
                CreateJiZhenRecord(false);
                ZhiLiaoTip9();
                break;
            case 3:
                if (!IsHuXiJi)
                {
                    print("出现呼吸机");
                    AllNeedUI.Instance.QiGuan.SetActive(true);
                    AllNeedUI.Instance.HuXiQiuNangICU.SetActive(false);
                    AllNeedUI.Instance.NoUseHuXiJi.SetActive(false);
                    ReduceLeftNum();
                    EndTodayJob();
                    IsHuXiJi = true;
                }
                else
                {
                    ZhiLiaoTip1();
                }
                break;
            default:
                ZhiLiaoTip10();
                break;
        }
    }
    public void XueTouJiClick()
    {
        switch (AllStaticVariable.ZhiLiaoTime)
        {
            case 1:
                OperateRecordItem.Init("连接血透机");
                CreateJiZhenRecord(false);
                string text = "未按正确诊断治疗导致病患病情加重最终导致病患死亡。";
                FailPanel.Init(text);
                break;
            case 2:
                OperateRecordItem.Init("连接血透机");
                CreateJiZhenRecord(false);
                ZhiLiaoTip9();
                break;
            case 3:
                if (!IsXueTouJi)
                {
                    print("出现血透机");
                    AllNeedUI.Instance.XueTouJiLine.SetActive(true);
                    ReduceLeftNum();
                    EndTodayJob();
                    IsXueTouJi = true;
                }
                else
                {
                    ZhiLiaoTip1();
                }
                break;
            default:
                ZhiLiaoTip10();
                break;
        }
    }

    #region 动画

    private void XiWeiAnim()
    {
        //Sprite[] list = { SpritesHDP[10], SpritesHDP[11], SpritesHDP[12], SpritesHDP[13] };
        //MonoWay.Instance.DongHua(list, 3f);
        //AllNeedUI.Instance.XiWeiBg.SetActive(true);
        AllNeedUI.Instance.XiWeiBg.SetActive(true);
        AllNeedUI.Instance.XiWeiBg.GetComponent<Image>().overrideSprite = SpritesHDP[10];
        StartCoroutine(OccurQuestion10());
    }
    IEnumerator OccurQuestion10()
    {
        yield return new WaitForSeconds(3);
        QuestionBank.scorePoint10();
    }

    private void QiGuanAnim()
    {
        Sprite[] list = { SpritesHDP[6], SpritesHDP[7], SpritesHDP[8], SpritesHDP[9] };
        MonoWay.Instance.DongHua(list, 3f);
    }

    private void XueTouAnim()
    {
        Sprite[] list = { SpritesHDP[14], SpritesHDP[15], SpritesHDP[16], SpritesHDP[17] };
        MonoWay.Instance.DongHua(list, 3f);
    }

    private void XinLiAnim()
    {
        Sprite[] list = { SpritesHDP[3] };
        MonoWay.Instance.DongHua(list, 2f);
    }


    private void YingYangAnim()
    {
        Sprite[] list = { SpritesHDP[4] };
        MonoWay.Instance.DongHua(list, 2f);
    }


    #endregion
    //创建药品目录
    private void CreateYaoPin()
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_YaoPinMuLu"));
        go.transform.parent = GameObject.Find("Canvas").transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.localScale = Vector3.one;

    }

    #region

    /// <summary>
    /// 提示：患者已做过此类治疗，不适合重复治疗
    /// </summary>
    private void ZhiLiaoTip1()
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_normalTip"));
        go.transform.parent = GameObject.Find("Canvas").transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "患者已做过此类治疗，不适合重复治疗。";
        go.transform.Find("Button_QueDing").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(go);
        });
    }
    /// <summary>
    /// 心理干预提示：患者意识还不够清醒不适合做此类治疗
    /// </summary>
    private void ZhiLiaoTip2()
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_normalTip"));
        go.transform.parent = GameObject.Find("Canvas").transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "患者意识还不够清醒,不适合做此类治疗。";
        go.transform.Find("Button_QueDing").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(go);
        });
    }
    /// <summary>
    /// 提示：患者是中毒症状，不适合做此类治疗
    /// </summary>
    private void ZhiLiaoTip3()
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_normalTip"));
        go.transform.parent = GameObject.Find("Canvas").transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "患者是中毒症状，不适合做此类治疗。";
        go.transform.Find("Button_QueDing").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(go);
        });
    }
    /// <summary>
    /// 提示：患者已气管插管给氧，不适合做此类治疗。
    /// </summary>
    private void ZhiLiaoTip4()
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_normalTip"));
        go.transform.parent = GameObject.Find("Canvas").transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "患者已气管插管给氧，不适合做此类治疗。";
        go.transform.Find("Button_QueDing").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(go);
        });
    }
    /// <summary>
    /// 提示：未给患者提供营养支持，患者不易早日康复。
    /// </summary>
    private void ZhiLiaoTip5()
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_normalTip"));
        go.transform.parent = GameObject.Find("Canvas").transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "未给患者提供营养支持，患者不易早日康复。";
        go.transform.Find("Button_QueDing").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(go);
        });
    }
    /// <summary>
    /// 提示：已连接呼吸机，不必再做此项。
    /// </summary>
    private void ZhiLiaoTip6()
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_normalTip"));
        go.transform.parent = GameObject.Find("Canvas").transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "已连接呼吸机，不必再做此项。";
        go.transform.Find("Button_QueDing").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(go);
        });
    }
    /// <summary>
    /// 提示：患者已在EICU病房，无需再一次分诊。
    /// </summary>
    private void ZhiLiaoTip7()
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_normalTip"));
        go.transform.parent = GameObject.Find("Canvas").transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "患者已在EICU病房，无需再一次分诊。";
        go.transform.Find("Button_QueDing").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(go);
        });
    }
    /// <summary>
    /// 提示：进入分诊
    /// </summary>
    public void ZhiLiaoTip8()
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_normalTip"));
        go.transform.parent = GameObject.Find("Canvas").transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "此刻应立即进入急诊分诊阶段";
        go.transform.Find("Button_QueDing").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(go);
        });
    }
    /// <summary>
    /// 提示：施救不当
    /// </summary>
    public void ZhiLiaoTip9()
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_normalTip"));
        go.transform.parent = GameObject.Find("Canvas").transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "因施救不当，导致患者呼吸困难，病情加重。";
        go.transform.Find("Button_QueDing").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(go);
        });
    }
    /// <summary>
    /// 患者无需此类治疗
    /// </summary>
    private void ZhiLiaoTip10()
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_normalTip"));
        go.transform.parent = GameObject.Find("Canvas").transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "患者无需此类治疗";
        go.transform.Find("Button_QueDing").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(go);
        });
    }
    /// <summary>
    /// 请先进行血透置管
    /// </summary>
    private void ZhiLiaoTip11()
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/Panel_normalTip"));
        go.transform.parent = GameObject.Find("Canvas").transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "请先进行血透置管";
        go.transform.Find("Button_QueDing").GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(go);
        });
    }
    #endregion 提示
    //剩余治疗项-1
    private void ReduceLeftNum()
    {
        int oldNum = int.Parse(AllNeedUI.Instance.ZhiLiaoLeftLabel.text);
        int newNum = oldNum - 1;
        AllNeedUI.Instance.ZhiLiaoLeftLabel.text = newNum.ToString();
    }
    //关闭治疗
    private void CloseZhiLiao()
    {
        AllNeedUI.Instance.ZhiLiaoPanel.SetActive(false);
        AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().isOn = false;
    }
    //关闭分诊，开启其他治疗
    private void RefreshZhiLiao()
    {
        JiZhen.SetActive(false);
        XueTou.SetActive(true);
        FangShe.SetActive(true);
        QiGuan.SetActive(true);
        XiWei.SetActive(true);
        XinLi.SetActive(true);
        ShouShu.SetActive(true);
        YaoWu.SetActive(true);
        YingYang.SetActive(true);
        BiDaoGuan.SetActive(true);
        //HuXiJi.SetActive(true);
        XueTouJi.SetActive(true);
    }
    //出现突发事件
    public void OccurEmergency()
    {
        print(AllNeedUI.Instance.ZhiLiaoLeftLabel.text);
        if (AllNeedUI.Instance.ZhiLiaoLeftLabel.text == "0")
        {
            //播放快的节奏音效
            AllNeedUI.Instance.SlowAudio.enabled = false;
            AllNeedUI.Instance.FastAudio.enabled = true;
            AllNeedUI.Instance.FastAudio.volume = 0.5f;
            StartCoroutine(EmergencyDelay());
            //AllNeedUI.Instance.EmergencyWarning.SetActive(true);
        }
    }
    IEnumerator EmergencyDelay()
    {
        yield return new WaitForSeconds(0.5f);
        AllNeedUI.Instance.FastAudio.volume = 0.4f;
        yield return new WaitForSeconds(0.5f);
        AllNeedUI.Instance.FastAudio.volume = 0.3f;
        AllNeedUI.Instance.EmergencyWarning.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        AllNeedUI.Instance.FastAudio.volume = 0.2f;
        yield return new WaitForSeconds(0.5f);
        AllNeedUI.Instance.FastAudio.volume = 0.15f;

    }
    //题46出现
    public void OccurScore46()
    {
        if (AllNeedUI.Instance.ZhiLiaoLeftLabel.text == "0")
        {
            QuestionBank.scorePoint46();
        }
    }

    //生成分诊错误与正确的评分记录
    private void CreateFenZhenRecord(bool TOrF)
    {
        GameObject pingFen = PingFenItem.Init();
        pingFen.GetComponent<PingFenItem>().day.text = AllStaticVariable.day;
        pingFen.GetComponent<PingFenItem>().mission.text = "急诊分诊";
        pingFen.GetComponent<PingFenItem>().property.text = "临床诊断";
        pingFen.GetComponent<PingFenItem>().qusetionButton.SetActive(false);
        if (TOrF == true)
        {
            pingFen.GetComponent<PingFenItem>().gou.SetActive(true);
            pingFen.GetComponent<PingFenItem>().score.text = "0";
            MonoWay.Instance.starUp(1);
            pingFen.GetComponent<PingFenItem>().operate.text = "根据预检台提供的病患报告，能正确处理急诊分诊。";
        }
        else
        {
            pingFen.GetComponent<PingFenItem>().cross.SetActive(true);
            pingFen.GetComponent<PingFenItem>().analysisButton.SetActive(false);
            pingFen.GetComponent<PingFenItem>().score.text = "-2";
            MonoWay.Instance.starDown(2);
            pingFen.GetComponent<PingFenItem>().operate.text = "根据预检台提供的病患报告，未能第一时间做出正确判断。";
        }
    }
    //生成洗胃和插管评分记录
    private void CreateJiZhenRecord(bool TOrF)
    {
        GameObject pingFen = PingFenItem.Init();
        pingFen.GetComponent<PingFenItem>().day.text = AllStaticVariable.day;
        pingFen.GetComponent<PingFenItem>().mission.text = "急诊抢救";
        pingFen.GetComponent<PingFenItem>().property.text = "临床诊断";
        pingFen.GetComponent<PingFenItem>().qusetionButton.SetActive(false);
        if (TOrF == true)
        {
            pingFen.GetComponent<PingFenItem>().gou.SetActive(true);
            pingFen.GetComponent<PingFenItem>().score.text = "0";
            MonoWay.Instance.starUp(1);
            pingFen.GetComponent<PingFenItem>().operate.text = "根据急诊患者情况，能立刻正确处理。";
        }
        else
        {
            pingFen.GetComponent<PingFenItem>().cross.SetActive(true);
            pingFen.GetComponent<PingFenItem>().analysisButton.SetActive(false);
            pingFen.GetComponent<PingFenItem>().score.text = "-5";
            MonoWay.Instance.starDown(5);
            pingFen.GetComponent<PingFenItem>().operate.text = "根据急诊患者情况，未能立刻正确处理，导致严重后果。";
        }
    }
    //生成错误记录
    private void CreateWrongRecord(string name)
    {
        GameObject pingFen = PingFenItem.Init();
        pingFen.GetComponent<PingFenItem>().day.text = AllStaticVariable.day;
        if (AllStaticVariable.ZhiLiaoTime == 8)
            pingFen.GetComponent<PingFenItem>().mission.text = "普通病房治疗";
        else
            pingFen.GetComponent<PingFenItem>().mission.text = "EICU治疗";
        pingFen.GetComponent<PingFenItem>().property.text = "临床诊断";
        pingFen.GetComponent<PingFenItem>().score.text = "-2";
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
        if (AllStaticVariable.ZhiLiaoTime == 8)
            pingFen.GetComponent<PingFenItem>().mission.text = "普通病房治疗";
        else
            pingFen.GetComponent<PingFenItem>().mission.text = "EICU治疗";
        pingFen.GetComponent<PingFenItem>().property.text = "临床诊断";
        pingFen.GetComponent<PingFenItem>().score.text = "0";
        MonoWay.Instance.starUp(1);
        pingFen.GetComponent<PingFenItem>().gou.SetActive(true);
        pingFen.GetComponent<PingFenItem>().qusetionButton.SetActive(false);
        pingFen.GetComponent<PingFenItem>().operate.text = "选择正确的治疗项目。";
    }
    //生成遗漏记录
    private static void CreateMissRecord(string name)
    {
        GameObject pingFen = PingFenItem.Init();
        pingFen.GetComponent<PingFenItem>().day.text = AllStaticVariable.day;
        if (AllStaticVariable.ZhiLiaoTime == 8)
            pingFen.GetComponent<PingFenItem>().mission.text = "普通病房治疗";
        else
            pingFen.GetComponent<PingFenItem>().mission.text = "EICU治疗";
        pingFen.GetComponent<PingFenItem>().property.text = "临床诊断";
        string score = null;
        if (name == "血透置管" || name == "药物治疗")
        {
            score = "-10";
            MonoWay.Instance.starDown(10);
        }
        if (name == "营养支持" || name == "心理干预")
        {
            score = "-5";
            MonoWay.Instance.starDown(5);
        }
        pingFen.GetComponent<PingFenItem>().score.text = score;
        pingFen.GetComponent<PingFenItem>().cross.SetActive(true);
        pingFen.GetComponent<PingFenItem>().qusetionButton.SetActive(false);
        pingFen.GetComponent<PingFenItem>().analysisButton.SetActive(false);
        pingFen.GetComponent<PingFenItem>().operate.text = name + "，未完成就结束当天工作了。";
    }

    public static void ResetZhiLiao()
    {
        IsJiZhen = false;
        IsBiDaoGuan = false;
        IsFangShe = false;
        IsQiGuan = false;
        IsShouShu = false;
        IsXiWei = false;
        IsXinLi = false;
        IsXueTou = false;
        IsYaoWu = false;
        IsYingYang = false;
        IsHuXiQiNang = false;
        IsXueTouJi = false;
        IsHuXiJi = false;
    }

    //遗漏治疗
    public static void CheckHasMiss()
    {
        if (!IsYaoWu)
            CreateMissRecord("药物治疗");
        switch (AllStaticVariable.ZhiLiaoTime)
        {
            case 3:
                if (!IsYingYang)
                    CreateMissRecord("营养支持");
                break;
            case 4:
                if (!IsYingYang)
                    CreateMissRecord("营养支持");
                break;
            case 5:
                if (!IsYingYang)
                    CreateMissRecord("营养支持");
                break;
            case 6:
                if (!IsXinLi)
                    CreateMissRecord("心理干预");
                break;
            case 7:
                if (!IsYingYang)
                    CreateMissRecord("营养支持");
                if (!IsXinLi)
                    CreateMissRecord("心理干预");
                break;
            case 8:
                if (!IsYingYang)
                    CreateMissRecord("营养支持");
                if (!IsXinLi)
                    CreateMissRecord("心理干预");
                break;
        }
    }
    //提示结束今天工作
    private void EndTodayJob()
    {
        if (AllNeedUI.Instance.ZhiLiaoLeftLabel.text == "0")
        {
            switch (AllStaticVariable.day)
            {
                case "第一天":
                case "第二天":
                case "第三天":
                    MonoWay.Instance.OpenTip("请结束今天工作");
                    break;
                case "第八天":
                    if (AllStaticVariable.IsInPt)
                    {
                        MonoWay.Instance.OpenTip("请结束今天工作");
                    }
                    break;
            }
        }
    }
}
