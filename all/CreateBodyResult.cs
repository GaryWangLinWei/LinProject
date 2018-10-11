using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateBodyResult : MonoBehaviour {
    public static void Day0Item1()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "体温：T36.8℃";
        AllNeedUI.Instance.BodyPlanes[1].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day0Item2()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血压：BP156/90mmHg";
        AllNeedUI.Instance.BodyPlanes[1].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day0Item3()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血氧饱和度：98%";
        AllNeedUI.Instance.BodyPlanes[1].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day0Item4()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "视诊：神志朦胧，两瞳孔对称，1mm，光反射迟钝。皮肤出汗明显、湿冷，肢体可见阵发性震颤。";
        AllNeedUI.Instance.BodyPlanes[1].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day0Item5()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "触诊：腹软，上腹部轻压痛。";
        AllNeedUI.Instance.BodyPlanes[1].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day0Item6()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "听诊：两肺呼吸音粗，可闻及少许湿罗音，心律齐，肠鸣音5-6次/min。";
        AllNeedUI.Instance.BodyPlanes[1].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day0Item7()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "呼吸：20次/分。";
        AllNeedUI.Instance.BodyPlanes[1].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day0Item8()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "心率：70次/分。";
        AllNeedUI.Instance.BodyPlanes[1].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }

    public void Day1Item1()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "预检台查体报告";
        go.GetComponent<RecordItem>().YellowLine.SetActive(true);
        go.GetComponent<Button>().onClick.AddListener(() =>
        {
            AllNeedUI.Instance.yuJianBaoGao.SetActive(true);
        });
        AllNeedUI.Instance.BodyPlanes[0].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }

    public void Day1Item2()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "急诊血液检查回报";
        go.GetComponent<RecordItem>().YellowLine.SetActive(true);
        go.GetComponent<Button>().onClick.AddListener(() =>
        {
            AllNeedUI.Instance.xueJianReport1.SetActive(true);
        });
        AllNeedUI.Instance.BodyPlanes[1].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public void Day1Item3()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "CT胸部扫描图";
        go.GetComponent<RecordItem>().YellowLine.SetActive(true);
        go.GetComponent<Button>().onClick.AddListener(() =>
        {
            AllNeedUI.Instance.CTScanReport.SetActive(true);
        });
        AllNeedUI.Instance.BodyPlanes[1].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day1Item4()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "追问病史详情";
        go.GetComponent<RecordItem>().YellowLine.SetActive(true);
        go.GetComponent<Button>().onClick.AddListener(() =>
        {
            AllNeedUI.Instance.BingShiDetial.SetActive(true);
        });
        AllNeedUI.Instance.BodyPlanes[1].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day1Item5()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "体温：T37.8℃";
        AllNeedUI.Instance.BodyPlanes[2].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day1Item6()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血压：BP134/86mmHg";
        AllNeedUI.Instance.BodyPlanes[2].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day1Item7()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血氧饱和度：98%";
        AllNeedUI.Instance.BodyPlanes[2].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day1Item8()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "心率：102次/min";
        AllNeedUI.Instance.BodyPlanes[2].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day1Item9()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "呼吸：RR 24次/min";
        AllNeedUI.Instance.BodyPlanes[2].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day1Item10()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "瞳孔检查：两瞳孔直径4mm，光反射迟钝。";
        AllNeedUI.Instance.BodyPlanes[2].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day1Item11()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "听诊：两肺呼吸音粗，右下肺可闻及湿性罗音  心音有力，心率102次/min，律齐，未闻及杂音。";
        AllNeedUI.Instance.BodyPlanes[2].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day1Item12()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "触诊：腹软，肠鸣音1-2次/min。";
        AllNeedUI.Instance.BodyPlanes[2].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day1Item13()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "视诊：神志不清，GCS评分3+1（T）+5。全身皮肤干燥。未见肌束震颤。双侧病理征（-）。";
        AllNeedUI.Instance.BodyPlanes[2].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }

    public static void Day2Item1()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "体温：T37.2℃";
        AllNeedUI.Instance.BodyPlanes[3].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day2Item2()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血压：BP130/72mmHg";
        AllNeedUI.Instance.BodyPlanes[3].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day2Item3()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血氧饱和度：100%";
        AllNeedUI.Instance.BodyPlanes[3].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day2Item4()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "心率：110次/min";
        AllNeedUI.Instance.BodyPlanes[3].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day2Item5()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "呼吸：RR 20次/min";
        AllNeedUI.Instance.BodyPlanes[3].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day2Item6()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "患者经血液灌流治疗后，神志转清，经口气管插管呼吸辅助通气";
        AllNeedUI.Instance.BodyPlanes[3].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day2Item7()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "视诊：遵嘱活动明显减弱。上肢肢肌力3级，对称。血清下肢肌力3+级，对称，两侧病理征（-）。";
        AllNeedUI.Instance.BodyPlanes[3].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day2Item8()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血液检查报告";
        go.GetComponent<RecordItem>().YellowLine.SetActive(true);
        go.GetComponent<Button>().onClick.AddListener(() =>
        {
            AllNeedUI.Instance.xueJianReport2.SetActive(true);
        });
        AllNeedUI.Instance.BodyPlanes[3].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }

    public static void Day3Item1()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "体温：T38.8℃";
        AllNeedUI.Instance.BodyPlanes[4].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day3Item2()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血压：BP180/100mmHg";
        AllNeedUI.Instance.BodyPlanes[4].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day3Item3()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血氧饱和度：98%";
        AllNeedUI.Instance.BodyPlanes[4].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day3Item4()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "心率：145次/min";
        AllNeedUI.Instance.BodyPlanes[4].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day3Item5()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "呼吸：RR 32次/min";
        AllNeedUI.Instance.BodyPlanes[4].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day3Item6()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "突发出现烦躁不安，意欲拔除气管插管，医护人员心理护理不能收效。";
        AllNeedUI.Instance.BodyPlanes[4].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day3Item7()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "瞳孔检查：两瞳孔5mm，对光迟钝";
        AllNeedUI.Instance.BodyPlanes[4].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day3Item8()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "听诊：肠鸣音消失";
        AllNeedUI.Instance.BodyPlanes[4].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day3Item9()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血液检查报告";
        go.GetComponent<RecordItem>().YellowLine.SetActive(true);
        go.GetComponent<Button>().onClick.AddListener(() =>
        {
            AllNeedUI.Instance.xueJianReport3.SetActive(true);
        });
        AllNeedUI.Instance.BodyPlanes[4].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day4To6()
    {
        AllStaticVariable.day = "第四天";
        Day4Item1();
        Day4Item2();
        Day4Item3();
        Day4Item4();
        Day4Item5();
        AllStaticVariable.day = "第五天";
        Day5Item1();
        Day5Item2();
        Day5Item3();
        Day5Item4();
        Day5Item5();
        AllStaticVariable.day = "第六天";
        Day6Item1();
        Day6Item2();
        Day6Item3();
        Day6Item4();
        Day6Item5();
    }
    #region 第四五六天

    private static void Day4Item1()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "体温：T37.2℃";
        AllNeedUI.Instance.BodyPlanes[5].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    private static void Day4Item2()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血压：180/100mmHg";
        AllNeedUI.Instance.BodyPlanes[5].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    private static void Day4Item3()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "心率：145次/min";
        AllNeedUI.Instance.BodyPlanes[5].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    private static void Day4Item4()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "呼吸：32次/min";
        AllNeedUI.Instance.BodyPlanes[5].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    private static void Day4Item5()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血氧饱和度：99%";
        AllNeedUI.Instance.BodyPlanes[5].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }

    private static void Day5Item1()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "体温：T36.9℃";
        AllNeedUI.Instance.BodyPlanes[6].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    private static void Day5Item2()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "心率：140次/min";
        AllNeedUI.Instance.BodyPlanes[6].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    private static void Day5Item3()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血压：180/100mmHg";
        AllNeedUI.Instance.BodyPlanes[6].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    private static void Day5Item4()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "呼吸：30次/min";
        AllNeedUI.Instance.BodyPlanes[6].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    private static void Day5Item5()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血氧饱和度：100%";
        AllNeedUI.Instance.BodyPlanes[6].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }

    private static void Day6Item1()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "心率：141次/min";
        AllNeedUI.Instance.BodyPlanes[7].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    private static void Day6Item2()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "体温：T37.3℃";
        AllNeedUI.Instance.BodyPlanes[7].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    private static void Day6Item3()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血压：179/98mmHg";
        AllNeedUI.Instance.BodyPlanes[7].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    private static void Day6Item4()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "呼吸：32次/min";
        AllNeedUI.Instance.BodyPlanes[7].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    private static void Day6Item5()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血氧饱和度：100%";
        AllNeedUI.Instance.BodyPlanes[7].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }

    #endregion

    public static void Day7Item1()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "体温：36.8℃";
        AllNeedUI.Instance.BodyPlanes[8].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day7Item2()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "心率：72次/min";
        AllNeedUI.Instance.BodyPlanes[8].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day7Item3()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血氧饱和度：100%";
        AllNeedUI.Instance.BodyPlanes[8].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day7Item4()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "呼吸：18次/min";
        AllNeedUI.Instance.BodyPlanes[8].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day7Item5()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血压：126/76mmHg";
        AllNeedUI.Instance.BodyPlanes[8].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day7Item6()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "视诊 气道无明显分泌物，神志清楚，配合。四肢肌力5级。";
        AllNeedUI.Instance.BodyPlanes[8].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day7Item7()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血液检查报告";
        go.GetComponent<RecordItem>().YellowLine.SetActive(true);
        go.GetComponent<Button>().onClick.AddListener(() =>
        {
            AllNeedUI.Instance.xueJianReport4.SetActive(true);
        });
        AllNeedUI.Instance.BodyPlanes[8].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day7Item8()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "CT胸部扫描图";
        go.GetComponent<RecordItem>().YellowLine.SetActive(true);
        go.GetComponent<Button>().onClick.AddListener(() =>
        {
            AllNeedUI.Instance.CtReport2.SetActive(true);
        });
        AllNeedUI.Instance.BodyPlanes[8].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }

    public static void Day8Item1()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "体温：37.0℃";
        AllNeedUI.Instance.BodyPlanes[9].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day8Item2()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "心率：73次/min";
        AllNeedUI.Instance.BodyPlanes[9].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day8Item3()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血氧饱和度：100%";
        AllNeedUI.Instance.BodyPlanes[9].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day8Item4()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血压：125/81mmHg";
        AllNeedUI.Instance.BodyPlanes[9].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day8Item5()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "呼吸：18次/min";
        AllNeedUI.Instance.BodyPlanes[9].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day8Item6()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "视诊：神志清楚，呼吸逐渐平稳，配合。";
        AllNeedUI.Instance.BodyPlanes[9].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day8Item7()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "体温：37.0℃";
        AllNeedUI.Instance.BodyPlanes[10].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day8Item8()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "心率：73次/min";
        AllNeedUI.Instance.BodyPlanes[10].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day8Item9()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血氧饱和度：100%";
        AllNeedUI.Instance.BodyPlanes[10].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day8Item10()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血压：125/81mmHg";
        AllNeedUI.Instance.BodyPlanes[10].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day8Item11()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "呼吸：18次/min";
        AllNeedUI.Instance.BodyPlanes[10].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day8Item12()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "护士反馈：患者阵发性头晕、视物模糊、双影等现象，伴有胸部不适感。";
        AllNeedUI.Instance.BodyPlanes[10].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void Day8Item13()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "视诊：神志清楚，呼吸逐渐平稳，配合。";
        AllNeedUI.Instance.BodyPlanes[10].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }

    public static void LongAfterItem1()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "视诊：患者出现双手下垂，持物无力，并伴有麻木感。";
        AllNeedUI.Instance.BodyPlanes[11].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void LongAfterItem2()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "听诊：心率73次/min";
        AllNeedUI.Instance.BodyPlanes[11].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void LongAfterItem3()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "体温检查：37.0℃";
        AllNeedUI.Instance.BodyPlanes[11].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void LongAfterItem4()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血压检查：血压125/81mmHg";
        AllNeedUI.Instance.BodyPlanes[11].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void LongAfterItem5()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "血液检查报告";
        go.GetComponent<RecordItem>().YellowLine.SetActive(true);
        go.GetComponent<Button>().onClick.AddListener(() =>
        {
            AllNeedUI.Instance.xueJianReport5.SetActive(true);
        });
        AllNeedUI.Instance.BodyPlanes[11].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
    public static void LongAfterItem6()
    {
        GameObject go = RecordItem.Init();
        go.GetComponent<RecordItem>().Text.text = "肌电图检查：双上肢运动神经和感觉神经传导速度有不同程度传导减慢和延长";
        AllNeedUI.Instance.BodyPlanes[11].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
    }
}
