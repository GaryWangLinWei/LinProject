using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionBank : MonoBehaviour
{
    private static string QuestionPath = "Prefabs/all/Panel_ChoiceQuestion";
    private static string AnalysisPath = "Prefabs/all/Panel_analysis";

    public static void scorePoint3()
    {
        MonoWay.Instance.CloseAllMainPanel();
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>("Prefabs/all/Panel_SanJiSiQu")) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();

        CQP.question = "1、 作为接诊医师，你认为病人应放何处处置比较合适。";
        CQP.title = "单 选 题";
        CQP.analysis = "1";
        CQP.answers.Clear();

        CQP.answers.Add("A . 急门诊");
        CQP.answers.Add("B . 普通门诊");
        CQP.answers.Add("C . 抢救室或复苏室");
        CQP.answers.Add("D . 就地处置");
        CQP.corrects = new int[] { 2 };


        CQP.analysisCall.AddListener(scorePoint3Analysis);
        CQP.submitCall.AddListener(()=> {
            MonoWay.Instance.DelayS4();
        });

        //评分item输入
        CQP.mission = "急诊分诊";
        CQP.property = "临床诊断";
        CQP.showQuestionCall.AddListener(scorePoint3);
        CQP.showQuestionCall2.AddListener(scorePoint3);
    }
    private static void scorePoint3Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "C";
        analysisGo.transform.Find("Text3").GetComponent<TextMeshProUGUI>().text = "      主要考察对病情初步评估能力。了解急诊三区四分急诊分诊流程。本例患者意识障碍，但血压、呼吸、指氧尚稳定，属于危重病人，应分诊至抢救室处置。";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if(AllStaticVariable.isInPingFen == false)
            {
                MonoWay.Instance.DelayS4();
                //scorePoint4();
            }
        });
    }
    public static void scorePoint4()
    {

        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(100, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "2、你认为对此患者诊断最有帮助的病史是什么？";
        CQP.title = "单 选 题";
        CQP.analysis =
            "1";
        CQP.answers.Clear();

        CQP.answers.Add("A . 既往慢病病史");
        CQP.answers.Add("B . 发病的情况");
        CQP.answers.Add("C . 最近是否有情绪波动事件或精神病史");
        CQP.answers.Add("D . 毒物暴露的线索（身旁的空药瓶、身上污染的药渍、呕吐物的味道等）");
        CQP.answers.Add("E . 最近有头痛史");
        CQP.corrects = new int[] { 3 };
        CQP.analysisCall.AddListener(scorePoint4Analysis);
        CQP.submitCall.AddListener(()=> {
            MonoWay.Instance.CreateZhongDuPanel();
        });

        CQP.mission = "临床诊断";
        CQP.property = "临床诊断";
        CQP.showQuestionCall.AddListener(scorePoint4);
        CQP.showQuestionCall2.AddListener(scorePoint4);
    }

    private static void scorePoint4Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "D";
        analysisGo.transform.Find("Text3").GetComponent<TextMeshProUGUI>().text = 
            "      本题考察有机磷农药中毒的典型临床表现及紧急获取病史的能力。本例患者具有M样症状、N样症状、中枢神经系统表现、伴有特殊的蒜臭味，均提示患者有可能是急性有机磷农药中毒。因此，诊断急性中毒的最重要病史是毒物暴露史。";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if (AllStaticVariable.isInPingFen == false)
            {
                //AllNeedUI.Instance.zhongDuBiaoXian.SetActive(true);
                MonoWay.Instance.CreateZhongDuPanel();
            }
        });
    }
    public static void scorePoint6()
    {
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "3、本例患者最可能的诊断是什么？";
        CQP.title = "单 选 题";
        CQP.analysis = "1";
        CQP.answers.Clear();

        CQP.answers.Add("A . 脑血管意外");
        CQP.answers.Add("B . 低血糖反应");
        CQP.answers.Add("C . 有机磷农药中毒");
        CQP.answers.Add("D . 吗啡中毒");
        CQP.answers.Add("E . 颅内感染");
        CQP.corrects = new int[] { 2 };
        CQP.analysisCall.AddListener(scorePoint6Analysis);
        CQP.submitCall.AddListener(()=> {
            MonoWay.Instance.DelayS7();
        });

        CQP.mission = "临床诊断";
        CQP.property = "临床诊断";
        CQP.showQuestionCall.AddListener(scorePoint6);
        CQP.showQuestionCall2.AddListener(scorePoint6);
    }
    private static void scorePoint6Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "C";
        analysisGo.transform.Find("Text3").GetComponent<TextMeshProUGUI>().text = "      本题考察有机磷农药中毒的诊断以及昏迷的鉴别诊断。";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if (AllStaticVariable.isInPingFen == false)
            {
                MonoWay.Instance.DelayS7();
            }
                //scorePoint7();
        });
    }
    public static void scorePoint7()
    {
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "4、为明确诊断，最需要做检查是";
        CQP.title = "单 选 题";
        CQP.analysis = "1";
        CQP.answers.Clear();

        CQP.answers.Add("A . 头颅CT");
        CQP.answers.Add("B . 快速血糖");
        CQP.answers.Add("C . 血胆碱酯酶活力");
        CQP.answers.Add("D . 氟马西尼诊断试验");
        CQP.answers.Add("E . 脑脊液检测");
        CQP.corrects = new int[] { 2 };
        CQP.analysisCall.AddListener(scorePoint7Analysis);
        CQP.submitCall.AddListener(()=> {
            MonoWay.Instance.OpenTip("请点击患者治疗，进行洗胃治疗");
            AllStaticVariable.ZhiLiaoTime = 1;
            AllNeedUI.Instance.ZhiLiaoLeftLabel.text =
                AllStaticVariable.LeftZhiLiaoNum[AllStaticVariable.ZhiLiaoTime - 1];
        });

        CQP.mission = "临床诊断";
        CQP.property = "临床诊断";
        CQP.showQuestionCall.AddListener(scorePoint7);
        CQP.showQuestionCall2.AddListener(scorePoint7);

    }
    private static void scorePoint7Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "C";
        analysisGo.transform.Find("Text3").GetComponent<TextMeshProUGUI>().text = "      本题考察有机磷农药中毒的诊断的关键标志物。";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if (AllStaticVariable.isInPingFen == false)
            {
                MonoWay.Instance.OpenTip("请点击患者治疗，进行洗胃治疗");
                AllStaticVariable.ZhiLiaoTime = 1;
                AllNeedUI.Instance.ZhiLiaoLeftLabel.text =
                    AllStaticVariable.LeftZhiLiaoNum[AllStaticVariable.ZhiLiaoTime - 1];
            }
        });
    }
    public static void scorePoint9()
    {
        MonoWay.Instance.CloseAllMainPanel();
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "4、洗胃过程中，患者出现呕吐，指端血氧饱和度下降至88%。该如何处置？";
        CQP.title = "单 选 题";
        CQP.analysis = "1";
        CQP.answers.Clear();

        CQP.answers.Add("A . 立即停止洗胃，拔除胃管，经口气管插管，继续洗胃");
        CQP.answers.Add("B . 立即停止洗胃，加大给氧浓度，观察血氧饱和度");
        CQP.answers.Add("C . 停止洗胃，加大给氧，调整进液量，继续洗胃");
        CQP.answers.Add("D . 密切监护，继续洗胃");
        CQP.answers.Add("E . 加大洗胃量，尽快结束洗胃");
        CQP.corrects = new int[] { 0 };
        CQP.analysisCall.AddListener(scorePoint9Analysis);
        CQP.submitCall.AddListener(() => {
            MonoWay.Instance.DelayS13();
        });

        CQP.mission = "洗胃治疗";
        CQP.property = "职业技能";
        CQP.showQuestionCall.AddListener(scorePoint9);
        CQP.showQuestionCall2.AddListener(scorePoint9);
    }

    private static void scorePoint9Analysis()
    {
        GameObject analysisGo = (GameObject) Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "A";
        analysisGo.transform.Find("Text3").GetComponent<TextMeshProUGUI>().text = "      考察洗胃常见并发症及处理。本例患者意识不清，洗胃过程容易发生误吸，患者呕吐后出现饱和度下降，考虑误吸性肺炎。应立即停止洗胃，拔除胃管，行气管插管保护气道，待氧合改善后再行洗胃。";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if (AllStaticVariable.isInPingFen == false)
            {
                MonoWay.Instance.DelayS13();
            }
                //scorePoint10();
        });
    }
    public static void scorePoint10()
    {
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "1、洗胃前应评估患者哪些情况？";
        CQP.title = "多 选 题";
        CQP.BgPic.overrideSprite = Resources.Load("DuoXuan", typeof(Sprite)) as Sprite;
        CQP.answers.Clear();

        CQP.answers.Add("A . 气道是否通畅");
        CQP.answers.Add("B . 血压是否稳定");
        CQP.answers.Add("C . 有无洗胃禁忌");
        CQP.answers.Add("D . 有无误吸风险");
        CQP.corrects = new int[] { 0,1,2,3 };
        CQP.analysisCall.AddListener(scorePoint10Analysis);
        CQP.submitCall.AddListener(() => {
            Sprite[] list = { AllNeedUI.Instance.spriteList[5], AllNeedUI.Instance.spriteList[6] };
            MonoWay.Instance.DongHua(list, 3);
            AllNeedUI.Instance.XiWeiBg.GetComponent<Image>().overrideSprite = AllNeedUI.Instance.spriteList[6];
            MonoWay.Instance.DelayS11();
        });
        CQP.NextAnswerCall.AddListener(() =>
        {
            AllStaticVariable.IsShowAnswer = false;
            Sprite[] list = { AllNeedUI.Instance.spriteList[5], AllNeedUI.Instance.spriteList[6] };
            MonoWay.Instance.DongHua(list, 3);
            AllNeedUI.Instance.XiWeiBg.GetComponent<Image>().overrideSprite = AllNeedUI.Instance.spriteList[6];
            MonoWay.Instance.DelayS11();
        });

        CQP.mission = "洗胃治疗";
        CQP.property = "职业技能";
        CQP.showQuestionCall.AddListener(scorePoint10);
        CQP.showQuestionCall2.AddListener(scorePoint10);
    }
    private static void scorePoint10Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "A、B、C、D";        
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if (AllStaticVariable.isInPingFen == false)
            {
                Sprite[] list = { AllNeedUI.Instance.spriteList[5], AllNeedUI.Instance.spriteList[6] };
                MonoWay.Instance.DongHua(list, 3);
                AllNeedUI.Instance.XiWeiBg.GetComponent<Image>().overrideSprite = AllNeedUI.Instance.spriteList[6];
                MonoWay.Instance.DelayS11();
            }

        });
    }
    public static void scorePoint11()
    {
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "2、插胃管时，胃管常规深度是？";
        CQP.title = "单 选 题";
        CQP.answers.Clear();

        CQP.answers.Add("A . 25-35cm");
        CQP.answers.Add("B . 35-45cm");
        CQP.answers.Add("C . 45-55cm");
        CQP.answers.Add("D . 55-65cm");
        CQP.corrects = new int[] { 2 };
        CQP.analysisCall.AddListener(scorePoint11Analysis);
        CQP.submitCall.AddListener(() => {
            AllNeedUI.Instance.XiWeiBg.GetComponent<Image>().overrideSprite = AllNeedUI.Instance.spriteList[7];
            MonoWay.Instance.DelayS12();
        });
        CQP.NextAnswerCall.AddListener(() =>
        {
            AllStaticVariable.IsShowAnswer = false;
            AllNeedUI.Instance.XiWeiBg.GetComponent<Image>().overrideSprite = AllNeedUI.Instance.spriteList[7];
            MonoWay.Instance.DelayS12();
        });

        CQP.mission = "洗胃治疗";
        CQP.property = "职业技能";
        CQP.showQuestionCall.AddListener(scorePoint11);
        CQP.showQuestionCall2.AddListener(scorePoint11);
    }

    private static void scorePoint11Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "C";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if (AllStaticVariable.isInPingFen == false)
            {
                AllNeedUI.Instance.XiWeiBg.GetComponent<Image>().overrideSprite = AllNeedUI.Instance.spriteList[8];
                MonoWay.Instance.DelayS12();
            }            
        });
    }
    public static void scorePoint12()
    {
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "3、如何确定胃管已经置入胃内？";
        CQP.title = "多 选 题";
        CQP.BgPic.overrideSprite = Resources.Load("DuoXuan", typeof(Sprite)) as Sprite;
        CQP.answers.Clear();

        CQP.answers.Add("A . 向胃管注入空气剑突下听到气过水声");
        CQP.answers.Add("B . 胃管已经插入一定长度难以再插进去");
        CQP.answers.Add("C . 胃管插入后能回抽胃液");
        CQP.answers.Add("D . 将胃管末端放入水中有气泡溢出");
        CQP.corrects = new int[] { 0,2 };
        CQP.analysisCall.AddListener(scorePoint12Analysis);
        CQP.submitCall.AddListener(() => {
            AllNeedUI.Instance.XueYangDownWarning.SetActive(true);
        });
        CQP.NextAnswerCall.AddListener(() =>
        {
            AllStaticVariable.IsShowAnswer = false;
            AllNeedUI.Instance.XueYangDownWarning.SetActive(true);
        });

        CQP.mission = "洗胃治疗";
        CQP.property = "职业技能";
        CQP.showQuestionCall.AddListener(scorePoint12);
        CQP.showQuestionCall2.AddListener(scorePoint12);
    }
    private static void scorePoint12Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "A、C";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if (AllStaticVariable.isInPingFen == false)
                AllNeedUI.Instance.XueYangDownWarning.SetActive(true);
        });
    }
    public static void scorePoint13()
    {
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "5、洗胃过程中需要严密检测什么指标？";
        CQP.title = "多 选 题";
        CQP.BgPic.overrideSprite = Resources.Load("DuoXuan", typeof(Sprite)) as Sprite;
        CQP.answers.Clear();

        CQP.answers.Add("A . 血压及心率");
        CQP.answers.Add("B . 血压及血氧饱和度");
        CQP.answers.Add("C . 心率及血氧饱和度");
        CQP.answers.Add("D . 体温及心率");
        CQP.corrects = new int[] { 0,1 };
        CQP.analysisCall.AddListener(scorePoint13Analysis);
        CQP.submitCall.AddListener(() =>
        {
            //AllNeedUI.Instance.XueYangDownWarning.SetActive(true);
            //AllNeedUI.Instance.XiWeiBg.SetActive(false);
            AllNeedUI.Instance.XiWeiBg.transform.SetAsFirstSibling();
        });
        CQP.NextAnswerCall.AddListener(() =>
        {
            AllStaticVariable.IsShowAnswer = false;
            //AllNeedUI.Instance.XiWeiBg.SetActive(false);
            AllNeedUI.Instance.XiWeiBg.transform.SetAsFirstSibling();
        });

        CQP.mission = "洗胃治疗";
        CQP.property = "职业技能";
        CQP.showQuestionCall.AddListener(scorePoint13);
        CQP.showQuestionCall2.AddListener(scorePoint13);

        if (AllStaticVariable.isInPingFen == false)
        {
            //修改治疗图标顺序
            Transform[] item = { AllNeedUI.Instance.ZhiLiaoItems[3] };
            MonoWay.Instance.PreferItem(item);

            AllStaticVariable.ZhiLiaoTime = 2;
            print("治疗次数：2");
            AllNeedUI.Instance.ZhiLiaoLeftLabel.text =
                AllStaticVariable.LeftZhiLiaoNum[AllStaticVariable.ZhiLiaoTime - 1];
            //AllNeedUI.Instance.ChaTiLeftLabel.text =
            //    AllStaticVariable.LeftChaTiNum[AllStaticVariable.JianChaTime + 1];
        }
    }
    private static void scorePoint13Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "B";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {           
            Destroy(analysisGo);
            if (AllStaticVariable.isInPingFen == false)
            {
                AllNeedUI.Instance.XiWeiBg.transform.SetAsFirstSibling();
            }
        });
    }
    public static void scorePoint15()
    {
        MonoWay.Instance.CloseAllMainPanel();
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "1、啥时将管芯拔出？";
        CQP.title = "单 选 题";
        CQP.answers.Clear();

        CQP.answers.Add("A . 导管尖端越过两侧扁桃体");
        CQP.answers.Add("B . 导管尖端越过悬雍垂");
        CQP.answers.Add("C . 导管尖端越过会厌");
        CQP.answers.Add("D . 导管尖端越过声门");
        CQP.corrects = new int[] { 3 };

        CQP.analysisCall.AddListener(scorePoint15Analysis);
        CQP.submitCall.AddListener(() => {
            MonoWay.Instance.DelayS16();
        });
        CQP.NextAnswerCall.AddListener(() =>
        {
            AllStaticVariable.IsShowAnswer = false;
            MonoWay.Instance.DelayS16();
        });
        CQP.mission = "气管插管";
        CQP.property = "职业技能";
        CQP.showQuestionCall.AddListener(scorePoint15);
        CQP.showQuestionCall2.AddListener(scorePoint15);
    }
    private static void scorePoint15Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "D";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if (AllStaticVariable.isInPingFen == false)
                MonoWay.Instance.DelayS16();
        });
    }
    public static void scorePoint16()
    {
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "2、导管插入气管内深度成人为";
        CQP.title = "单 选 题";
        CQP.answers.Clear();

        CQP.answers.Add("A . 2-3cm");
        CQP.answers.Add("B . 3-4cm");
        CQP.answers.Add("C . 4-5cm");
        CQP.answers.Add("D . 5-6cm");
        CQP.corrects = new int[] { 2 };
        CQP.analysisCall.AddListener(scorePoint16Analysis);
        CQP.submitCall.AddListener(() => {
            MonoWay.Instance.DelayS17();
        });
        CQP.NextAnswerCall.AddListener(() =>
        {
            AllStaticVariable.IsShowAnswer = false;
            MonoWay.Instance.DelayS17();
        });

        CQP.mission = "气管插管";
        CQP.property = "职业技能";
        CQP.showQuestionCall.AddListener(scorePoint16);
        CQP.showQuestionCall2.AddListener(scorePoint16);
    }
    private static void scorePoint16Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "C";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if (AllStaticVariable.isInPingFen == false)
                MonoWay.Instance.DelayS17();
        });
    }
    public static void scorePoint17()
    {
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "3、导管尖端至门齿的距离为";
        CQP.title = "单 选 题";
        CQP.answers.Clear();

        CQP.answers.Add("A . 14-18cm");
        CQP.answers.Add("B . 16-20cm");
        CQP.answers.Add("C . 18-22cm");
        CQP.answers.Add("D . 20-24cm");
        CQP.corrects = new int[] { 2 };
        CQP.analysisCall.AddListener(scorePoint17Analysis);
        CQP.submitCall.AddListener(() => {
            MonoWay.Instance.DelayS18();
        });
        CQP.NextAnswerCall.AddListener(() =>
        {
            AllStaticVariable.IsShowAnswer = false;
            MonoWay.Instance.DelayS18();
        });

        CQP.mission = "气管插管";
        CQP.property = "职业技能";
        CQP.showQuestionCall.AddListener(scorePoint17);
        CQP.showQuestionCall2.AddListener(scorePoint17);
    }
    private static void scorePoint17Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "C";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if (AllStaticVariable.isInPingFen == false)
                MonoWay.Instance.DelayS18();
        });
    }
    public static void scorePoint18()
    {
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "4、阿托品化的判断标准不包括";
        CQP.title = "单 选 题";
        CQP.analysis = "1";
        CQP.answers.Clear();

        CQP.answers.Add("A . 瞳孔较前扩大（对光反射存在）");
        CQP.answers.Add("B . 颜面潮红、口干、皮肤干燥");
        CQP.answers.Add("C . 心率增快90-100次/分");
        CQP.answers.Add("D . 两肺湿啰音消失");
        CQP.answers.Add("E . 神志转清");
        CQP.corrects = new int[] { 4 };
        CQP.analysisCall.AddListener(scorePoint18Analysis);
        CQP.submitCall.AddListener(() => {
            if (!AllStaticVariable.isInPingFen)
            {
                AllNeedUI.Instance.ZhiLiaoLeftLabel.text = "1";
                Transform[] item2 =
                {
                    AllNeedUI.Instance.ZhiLiaoItems[7]
                };
                MonoWay.Instance.PreferItem(item2);
                MonoWay.Instance.OpenTip("请进行药物治疗");
                ////新增治疗环节
                //AllNeedUI.Instance.ChaTiLeftLabel.text = "1";
                //Transform[] item2 =
                //{
                //    AllNeedUI.Instance.ChaTiItems[7]
                //};
                //MonoWay.Instance.PreferChaTiItem(item2);
                //MonoWay.Instance.OpenTip("请进行CT检查");
            }
        });
        CQP.NextAnswerCall.AddListener(() =>
        {
            AllStaticVariable.IsShowAnswer = false;
            if (!AllStaticVariable.isInPingFen)
            {
                AllNeedUI.Instance.ZhiLiaoLeftLabel.text = "1";
                Transform[] item2 =
                {
                    AllNeedUI.Instance.ZhiLiaoItems[7]
                };
                MonoWay.Instance.PreferItem(item2);
                MonoWay.Instance.OpenTip("请进行药物治疗");
            }
        });

        CQP.mission = "药物治疗";
        CQP.property = "临床诊断";
        CQP.showQuestionCall.AddListener(scorePoint18);
        CQP.showQuestionCall2.AddListener(scorePoint18);
    }
    private static void scorePoint18Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "E";
        analysisGo.transform.Find("Text3").GetComponent<TextMeshProUGUI>().text = "      考察阿托品化的判断标准";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if (AllStaticVariable.isInPingFen == false)
            {
                if (!AllStaticVariable.isInPingFen)
                {
                    AllNeedUI.Instance.ZhiLiaoLeftLabel.text = "1";
                    Transform[] item2 =
                    {
                    AllNeedUI.Instance.ZhiLiaoItems[7]
                };
                    MonoWay.Instance.PreferItem(item2);
                    MonoWay.Instance.OpenTip("请进行药物治疗");
                }
            }
        });
    }
    public static void scorePoint19()
    {
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "5、针对本例患者，解磷定首剂的合适剂量是";
        CQP.title = "单 选 题";
        CQP.answers.Clear();

        CQP.answers.Add("A . 0.5-1g");
        CQP.answers.Add("B . 1-2g");
        CQP.answers.Add("C . 1.5-3g");
        CQP.answers.Add("D . 3-4g");
        CQP.answers.Add("E . 4g以上");
        CQP.corrects = new int[] { 2 };
        CQP.analysisCall.AddListener(scorePoint19Analysis);
        CQP.submitCall.AddListener(() =>
        {
            MonoWay.Instance.DelayS59();
        });
        CQP.NextAnswerCall.AddListener(() =>
        {
            AllStaticVariable.IsShowAnswer = false;
            MonoWay.Instance.DelayS59();
        });
        CQP.mission = "药物治疗";
        CQP.property = "临床诊断";
        CQP.showQuestionCall.AddListener(scorePoint19);
        CQP.showQuestionCall2.AddListener(scorePoint19);
    }
    private static void scorePoint19Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "C";
        analysisGo.transform.Find("Text3").GetComponent<TextMeshProUGUI>().text = "      重度有机磷中毒患者解磷定适合剂量为1.5-3g。";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            MonoWay.Instance.DelayS59();
            Destroy(analysisGo);
        });
    }
    public static void scorePoint20()
    {
        MonoWay.Instance.CloseAllMainPanel();
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "根据患者血液检查回报和CT扫描回报，结合抢救室的洗胃、气管插管、解毒药物等初步处置，患者神志仍不清。为求进一步救治,以下正确的是：";
        CQP.title = "单 选 题";
        CQP.answers.Clear();

        CQP.answers.Add("A . 拟“急性重度有机磷农药中毒 ”收住普通病房。");
        CQP.answers.Add("B . 拟“急性重度有机磷农药中毒 吸入性肺炎”收住EICU。");
        CQP.answers.Add("C . 拟“急性重度有机磷农药中毒 ”收住EICU。");
        CQP.answers.Add("D . 拟“急性重度有机磷农药中毒 吸入性肺炎”继续急诊治疗。");
        CQP.corrects = new int[] { 1 };
        CQP.analysisCall.AddListener(scorePoint20Analysis);
        CQP.submitCall.AddListener(() =>
        {
            MonoWay.Instance.ReFreshBingShi();
            MonoWay.Instance.Go2EICU();
            AllNeedUI.Instance.BgNoise.gameObject.SetActive(false);
        });
        CQP.NextAnswerCall.AddListener(() =>
        {
            AllStaticVariable.IsShowAnswer = false;
            MonoWay.Instance.ReFreshBingShi();
            MonoWay.Instance.Go2EICU();
            AllNeedUI.Instance.BgNoise.gameObject.SetActive(false);
        });

        CQP.mission = "临床诊断";
        CQP.property = "临床诊断";
        CQP.showQuestionCall.AddListener(scorePoint20);
        CQP.showQuestionCall2.AddListener(scorePoint20);

        if (AllStaticVariable.isInPingFen == false)
        {
            print("!!!!");
            //修改治疗图标顺序
            Transform[] item = { AllNeedUI.Instance.ZhiLiaoItems[11], AllNeedUI.Instance.ZhiLiaoItems[8], AllNeedUI.Instance.ZhiLiaoItems[7] };
            MonoWay.Instance.PreferItem(item);
            //修改查体图标顺序
            Transform[] ChaTiItemThree =
            {
                AllNeedUI.Instance.ChaTiItems[11],AllNeedUI.Instance.ChaTiItems[6],AllNeedUI.Instance.ChaTiItems[0]
            };
            MonoWay.Instance.PreferItem(ChaTiItemThree);
            Transform[] ChaItem =
            {
                AllNeedUI.Instance.ChaTiItems[5]
            };
            MonoWay.Instance.PreferChaTiItem(ChaItem);

            AllStaticVariable.IsInEICU = true;
            AllStaticVariable.ZhiLiaoTime = 3;
            AllStaticVariable.JianChaTime = 0;
            PatientChaTi.ResetChaTi();
            PatientZhiLiao.ResetZhiLiao();
            print("治疗次数：3 检查次数：0");
            //刷新查体&治疗剩余项目
            AllNeedUI.Instance.ZhiLiaoLeftLabel.text =
                AllStaticVariable.LeftZhiLiaoNum[AllStaticVariable.ZhiLiaoTime - 1];
            print(AllStaticVariable.ZhiLiaoTime + 1);
            print(AllNeedUI.Instance.ZhiLiaoLeftLabel.text);
            AllNeedUI.Instance.ChaTiLeftLabel.text =
                AllStaticVariable.LeftChaTiNum[AllStaticVariable.JianChaTime + 1];
        }
    }
    private static void scorePoint20Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "B";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            if (AllStaticVariable.isInPingFen == false)
            {
                MonoWay.Instance.ReFreshBingShi();
                MonoWay.Instance.Go2EICU();
                AllNeedUI.Instance.BgNoise.gameObject.SetActive(false);
            }              
            Destroy(analysisGo);
        });
    }
    public static void scorePoint26()
    {
        MonoWay.Instance.CloseAllMainPanel();
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "通过刚才的查体，患者最可能的诊断是：";
        CQP.title = "单 选 题";
        CQP.analysis = "1";
        CQP.answers.Clear();

        CQP.answers.Add("A . 中间期肌无力综合征");
        CQP.answers.Add("B . 脑出血");
        CQP.answers.Add("C . 镇静药物过量");
        CQP.answers.Add("D . 危重病相关性肌病");
        CQP.answers.Add("D . 低钾相关性肌无力");
        CQP.corrects = new int[] { 0 };
        CQP.analysisCall.AddListener(scorePoint26Analysis);
        CQP.submitCall.AddListener(() =>
        {
            if (!AllStaticVariable.isInPingFen)
            {
                if (AllNeedUI.Instance.ChaTiLeftLabel.text == "0" && AllStaticVariable.IsFinishTodayAsk)
                {
                    AllNeedUI.Instance.XueYeJingHuaWarning.SetActive(true);
                    MonoWay.Instance.OpenTip("请点击患者治疗");
                    AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().enabled = true;
                }
            }
        });

        CQP.mission = "临床诊断";
        CQP.property = "临床诊断";
        CQP.showQuestionCall.AddListener(scorePoint26);
        CQP.showQuestionCall2.AddListener(scorePoint26);
    }
    private static void scorePoint26Analysis()
    {                                
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));        
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "A";
        analysisGo.transform.Find("Text3").GetComponent<TextMeshProUGUI>().text = "      主要考察中毒后24-96小时内发病的中间期肌无力综合征。";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if(!AllStaticVariable.isInPingFen)
            {
                if (AllNeedUI.Instance.ChaTiLeftLabel.text == "0" && AllStaticVariable.IsFinishTodayAsk)
                {
                    AllNeedUI.Instance.XueYeJingHuaWarning.SetActive(true);
                    MonoWay.Instance.OpenTip("请点击患者治疗");
                    AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().enabled = true;
                }
            }
        });
    }
    public static void scorePoint33()
    {
        MonoWay.Instance.CloseAllMainPanel();
        AllStaticVariable.IsDone33 = true;
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "通过刚才的查体，患者首先考虑是：";
        CQP.title = "单 选 题";
        CQP.analysis = "1";
        CQP.answers.Clear();

        CQP.answers.Add("A . 有机磷中毒反跳");
        CQP.answers.Add("B . 阿托品过量");
        CQP.answers.Add("C . 脑血管意外");
        CQP.answers.Add("D . 监护室综合征");
        CQP.answers.Add("E . 高热惊厥");
        CQP.corrects = new int[] { 1 };
        CQP.analysisCall.AddListener(scorePoint33Analysis);
        CQP.submitCall.AddListener(()=> {
            MonoWay.Instance.DelayS34();
        });

        CQP.mission = "临床诊断";
        CQP.property = "临床诊断";
        CQP.showQuestionCall.AddListener(scorePoint33);
        CQP.showQuestionCall2.AddListener(scorePoint33);
    }
    public static void scorePoint33Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "B";
        analysisGo.transform.Find("Text3").GetComponent<TextMeshProUGUI>().text = "      治疗过程中最常见的药物副作用。";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if (AllStaticVariable.isInPingFen == false)
                MonoWay.Instance.DelayS34();
        });
    }
    public static void scorePoint34()
    {
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "如何处置阿托品过量？";
        CQP.title = "多 选 题";
        CQP.BgPic.overrideSprite = Resources.Load("DuoXuan", typeof(Sprite)) as Sprite;
        CQP.answers.Clear();

        CQP.answers.Add("A . 停用阿托品，观察30-60min");
        CQP.answers.Add("B . 严重时地西泮对症处理");
        CQP.answers.Add("C . 保护性约束");
        //CQP.answers.Add("D . 减少阿托品的维持剂量");
        CQP.answers.Add("D . 完善辅助检查，除外其他疾病可能");
        CQP.corrects = new int[] { 0,1,2,3 };
        CQP.analysisCall.AddListener(scorePoint34Analysis);
        CQP.submitCall.AddListener(() =>
        {
            if (AllNeedUI.Instance.ChaTiLeftLabel.text == "0" && AllStaticVariable.IsFinishTodayAsk)
            {
                MonoWay.Instance.OpenTip("请点击患者治疗");
                AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().enabled = true;
            }
        });
        CQP.NextAnswerCall.AddListener(() =>
        {
            AllStaticVariable.IsShowAnswer = false;
            if (AllNeedUI.Instance.ChaTiLeftLabel.text == "0" && AllStaticVariable.IsFinishTodayAsk)
            {
                MonoWay.Instance.OpenTip("请点击患者治疗");
                AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().enabled = true;
            }
        });

        CQP.mission = "临床诊断";
        CQP.property = "临床诊断";
        CQP.showQuestionCall.AddListener(scorePoint34);
        CQP.showQuestionCall2.AddListener(scorePoint34);
    }
    public static void scorePoint34Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "A、B、C、D";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if (!AllStaticVariable.isInPingFen)
            {
                if (AllNeedUI.Instance.ChaTiLeftLabel.text == "0" && AllStaticVariable.IsFinishTodayAsk)
                {
                    MonoWay.Instance.OpenTip("请点击患者治疗");
                    AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().enabled = true;
                }
            }
        });
    }

    public static void scorePoint40()
    {
        MonoWay.Instance.CloseAllMainPanel();
        AllStaticVariable.IsDone40 = true;
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "结合上诉病症，考虑患者出现什么情况？";
        CQP.title = "单 选 题";
        CQP.analysis = "1";
        CQP.answers.Clear();

        CQP.answers.Add("A . 中间期肌无力综合征尚未恢复");
        CQP.answers.Add("B . 心力衰竭");
        CQP.answers.Add("C . 吸入性肺炎未好转");
        CQP.answers.Add("D . 有机磷中毒反跳");
        CQP.answers.Add("E . 肺栓塞");
        CQP.corrects = new int[] { 0 };
        CQP.analysisCall.AddListener(scorePoint40Analysis);
        CQP.submitCall.AddListener(() => {
            MonoWay.Instance.DelayS41();
        });

        CQP.mission = "临床诊断";
        CQP.property = "临床诊断";
        CQP.showQuestionCall.AddListener(scorePoint40);
        CQP.showQuestionCall2.AddListener(scorePoint40);
    }
    public static void scorePoint40Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "A";
        analysisGo.transform.Find("Text3").GetComponent<TextMeshProUGUI>().text = "      有机磷中毒中间期肌无力综合征一部分病人常出现拔管失败。需要密切监测。";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if (AllStaticVariable.isInPingFen == false)
                MonoWay.Instance.DelayS41();
        });
    }
    public static void scorePoint41()
    {
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "对于出现拔管失败的病人，应该如何预防及处置？";
        CQP.title = "多 选 题";
        CQP.BgPic.overrideSprite = Resources.Load("DuoXuan", typeof(Sprite)) as Sprite;
        CQP.answers.Clear();

        CQP.answers.Add("A . 给予足够的恢复时间，通畅一周左右甚至更长");
        CQP.answers.Add("B . 控制好肺部感染");
        CQP.answers.Add("C .拔管前常规进行SBT试验");
        CQP.answers.Add("D . 立即进行心肺复苏操作");
        CQP.answers.Add("E . 拔管前严格评估患者肌力");
        CQP.answers.Add("F . Bipap辅助通气序贯治疗");
        CQP.corrects = new int[] { 0,1,2,4,5 };
        CQP.analysisCall.AddListener(scorePoint41Analysis);
        CQP.submitCall.AddListener(() =>
        {
            print("11");
            AllStaticVariable.IsBeRed = false;
            if (!AllStaticVariable.isInPingFen)
            {
                MonoWay.Instance.ReFreshBingShi();
                MonoWay.Instance.OpenTip("请点击病史采集，进行医患沟通");
                //播放慢的节奏音效
                AllNeedUI.Instance.SlowAudio.enabled = true;
                AllNeedUI.Instance.FastAudio.enabled = false;
            }
            //AllNeedUI.Instance.JumpNum.SetActive(false);
        });
        CQP.NextAnswerCall.AddListener(() =>
        {
            print("22");
            AllStaticVariable.IsBeRed = false;
            AllStaticVariable.IsShowAnswer = false;
            if (!AllStaticVariable.isInPingFen)
            {
                MonoWay.Instance.ReFreshBingShi();
                MonoWay.Instance.OpenTip("请点击病史采集，进行医患沟通");
                //播放慢的节奏音效
                AllNeedUI.Instance.SlowAudio.enabled = true;
                AllNeedUI.Instance.FastAudio.enabled = false;
            }
            //AllNeedUI.Instance.JumpNum.SetActive(false);
        });

        CQP.mission = "临床诊断";
        CQP.property = "临床诊断";
        CQP.showQuestionCall.AddListener(scorePoint41);
        CQP.showQuestionCall2.AddListener(scorePoint41);
    }
    public static void scorePoint41Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "A、B、C、E、F";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            print("33");
            //AllNeedUI.Instance.JumpNum.SetActive(false);
            Destroy(analysisGo);
            if(!AllStaticVariable.isInPingFen)
            {
                MonoWay.Instance.ReFreshBingShi();
                MonoWay.Instance.OpenTip("请点击病史采集，进行医患沟通");
            }
        });
    }
    public static void scorePoint46()
    {
        MonoWay.Instance.CloseAllMainPanel();
        AllNeedUI.Instance.ZhiLiaoPanel.SetActive(false);
        AllStaticVariable.IsDone46 = true;
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "目前病患的病症，患者转入哪类病房继续治疗？";
        CQP.title = "单 选 题";
        CQP.answers.Clear();

        CQP.answers.Add("A . 急诊病房");
        CQP.answers.Add("B . 普通病房");
        CQP.answers.Add("C . ICU病房");
        CQP.answers.Add("D . CCU病房");
        CQP.corrects = new int[] { 1 };
        CQP.analysisCall.AddListener(scorePoint46Analysis);
        CQP.submitCall.AddListener(() =>
        {
            if (AllStaticVariable.isInPingFen == false)
            {
                MonoWay.Instance.HeiPingS();
                MonoWay.Instance.OpenTip("进入普通病房，请点击患者查体");
                AllStaticVariable.IsInEICU = false;
                AllStaticVariable.IsInPt = true;
                CamMove.Instance.MoveCamto(7);
                PatientChaTi.CheckHasMiss();
                PatientZhiLiao.CheckHasMiss();
                AllNeedUI.Instance.FinishJobBtn.SetActive(true);
                AllNeedUI.Instance.XinDianCheck.SetActive(false);
                AllNeedUI.Instance.PTWithPerson.SetActive(true);
                PatientChaTi.ResetChaTi();
                PatientZhiLiao.ResetZhiLiao();
                AllStaticVariable.medicineTime = 5;
                AllStaticVariable.ZhiLiaoTime = 8;
                AllStaticVariable.JianChaTime = 5;
                //修改治疗图标顺序
                Transform[] item = { AllNeedUI.Instance.ZhiLiaoItems[8], AllNeedUI.Instance.ZhiLiaoItems[7], AllNeedUI.Instance.ZhiLiaoItems[5] };
                MonoWay.Instance.PreferItem(item);
                //刷新查体&治疗剩余项目
                AllNeedUI.Instance.ZhiLiaoLeftLabel.text =
                    AllStaticVariable.LeftZhiLiaoNum[AllStaticVariable.ZhiLiaoTime - 1];
                AllNeedUI.Instance.ChaTiLeftLabel.text =
                    AllStaticVariable.LeftChaTiNum[AllStaticVariable.JianChaTime + 1];
                MonoWay.Instance.ReFreshBingShi();
                print("治疗次数：3 检查次数：0");
            }
        });
        CQP.NextAnswerCall.AddListener(() =>
        {
            MonoWay.Instance.HeiPingS();
            AllStaticVariable.IsShowAnswer = false;
            MonoWay.Instance.OpenTip("进入普通病房，请点击患者查体");
            AllStaticVariable.IsInEICU = false;
            AllStaticVariable.IsInPt = true;
            CamMove.Instance.MoveCamto(7);
            PatientChaTi.CheckHasMiss();
            PatientZhiLiao.CheckHasMiss();
            AllNeedUI.Instance.FinishJobBtn.SetActive(true);
            AllNeedUI.Instance.XinDianCheck.SetActive(false);
            AllNeedUI.Instance.PTWithPerson.SetActive(true);
            PatientChaTi.ResetChaTi();
            PatientZhiLiao.ResetZhiLiao();
            AllStaticVariable.medicineTime = 5;
            AllStaticVariable.ZhiLiaoTime = 8;
            AllStaticVariable.JianChaTime = 5;
            //修改治疗图标顺序
            Transform[] item = { AllNeedUI.Instance.ZhiLiaoItems[8], AllNeedUI.Instance.ZhiLiaoItems[7], AllNeedUI.Instance.ZhiLiaoItems[5] };
            MonoWay.Instance.PreferItem(item);
            //刷新查体&治疗剩余项目
            AllNeedUI.Instance.ZhiLiaoLeftLabel.text =
                AllStaticVariable.LeftZhiLiaoNum[AllStaticVariable.ZhiLiaoTime - 1];
            AllNeedUI.Instance.ChaTiLeftLabel.text =
                AllStaticVariable.LeftChaTiNum[AllStaticVariable.JianChaTime + 1];
            MonoWay.Instance.ReFreshBingShi();
        });

        CQP.mission = "临床诊断";
        CQP.property = "临床诊断";
        CQP.showQuestionCall.AddListener(scorePoint46);
        CQP.showQuestionCall2.AddListener(scorePoint46);
    }
    public static void scorePoint46Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "B";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            if (AllStaticVariable.isInPingFen == false)
            {
                MonoWay.Instance.HeiPingS();
                MonoWay.Instance.OpenTip("进入普通病房，请点击患者查体");
                AllStaticVariable.IsInEICU = false;
                AllStaticVariable.IsInPt = true;
                CamMove.Instance.MoveCamto(7);
                PatientChaTi.CheckHasMiss();
                PatientZhiLiao.CheckHasMiss();
                AllNeedUI.Instance.FinishJobBtn.SetActive(true);
                AllNeedUI.Instance.XinDianCheck.SetActive(false);
                AllNeedUI.Instance.PTWithPerson.SetActive(true);
                PatientChaTi.ResetChaTi();
                PatientZhiLiao.ResetZhiLiao();
                AllStaticVariable.medicineTime = 5;
                AllStaticVariable.ZhiLiaoTime = 8;
                AllStaticVariable.JianChaTime = 5;
                //修改治疗图标顺序
                Transform[] item = { AllNeedUI.Instance.ZhiLiaoItems[8], AllNeedUI.Instance.ZhiLiaoItems[7], AllNeedUI.Instance.ZhiLiaoItems[5] };
                MonoWay.Instance.PreferItem(item);
                //刷新查体&治疗剩余项目
                AllNeedUI.Instance.ZhiLiaoLeftLabel.text =
                    AllStaticVariable.LeftZhiLiaoNum[AllStaticVariable.ZhiLiaoTime - 1];
                AllNeedUI.Instance.ChaTiLeftLabel.text =
                    AllStaticVariable.LeftChaTiNum[AllStaticVariable.JianChaTime + 1];
                MonoWay.Instance.ReFreshBingShi();
                print("治疗次数：8 检查次数：5");
            }
            Destroy(analysisGo);
        });
    }
    public static void scorePoint51()
    {
        MonoWay.Instance.CloseAllMainPanel();
        AllStaticVariable.IsDone51 = true;
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "患者入住普通病房，会出现阵发性头晕、视物模糊、双影等现象，伴有胸部不适感。你作为查房医师，首先考虑：";
        CQP.title = "单 选 题";
        CQP.answers.Clear();

        CQP.answers.Add("A . 脑供血不足");
        CQP.answers.Add("B . 颈椎病");
        CQP.answers.Add("C . 冠心病可能");
        CQP.answers.Add("D . 解磷定的副作用");
        CQP.answers.Add("E . 有机磷农药的中枢毒性");
        CQP.corrects = new int[] { 3 };
        CQP.analysisCall.AddListener(scorePoint51Analysis);
        CQP.NextAnswerCall.AddListener(() =>
        {
            AllStaticVariable.IsShowAnswer = false;
        });

        CQP.mission = "临床诊断";
        CQP.property = "临床诊断";
        CQP.showQuestionCall.AddListener(scorePoint51);
        CQP.showQuestionCall2.AddListener(scorePoint51);
    }
    public static void scorePoint51Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "D";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
        });
    }
    public static void scorePoint52()
    {
        MonoWay.Instance.CloseAllMainPanel();
        AllStaticVariable.IsDone52 = true;
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "遇到类似突发事件，您该如何处理？";
        CQP.title = "多 选 题";
        CQP.BgPic.overrideSprite = Resources.Load("DuoXuan", typeof(Sprite)) as Sprite;
        CQP.analysis = "1";
        CQP.answers.Clear();

        CQP.answers.Add("A . 立即汇报科主任、总值班");
        CQP.answers.Add("B . 同时报警，出动警力协助寻找");
        CQP.answers.Add("C . 调取监控，获取患者走失线索");
        CQP.answers.Add("D . 组织科室力量进行寻找");
        CQP.answers.Add("E . 做好家属安抚工作");
        CQP.answers.Add("F . 家属安抚失败，为防止医闹应请假躲避");
        CQP.corrects = new int[] { 0,1,2,3,4 };
        CQP.analysisCall.AddListener(scorePoint52Analysis);
        CQP.submitCall.AddListener(() => {
            MonoWay.Instance.DelayS53();
        });

        CQP.mission = "突发事件处理";
        CQP.property = "临床诊断";
        CQP.showQuestionCall.AddListener(scorePoint52);
        CQP.showQuestionCall2.AddListener(scorePoint52);
    }
    public static void scorePoint52Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "A、B、C、D、E";
        analysisGo.transform.Find("Text3").GetComponent<TextMeshProUGUI>().text = "      自杀患者具有再次自我伤害倾向，容易出现突发状况。";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if (AllStaticVariable.isInPingFen == false)
                MonoWay.Instance.DelayS53();
        });
    }
    public static void scorePoint53()
    {
        AllNeedUI.Instance.FinishJobBtn.SetActive(true);
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "作为主管医师，如何防范自杀患者的再次伤害？";
        CQP.title = "多 选 题";
        CQP.BgPic.overrideSprite = Resources.Load("DuoXuan", typeof(Sprite)) as Sprite;
        CQP.answers.Clear();

        CQP.answers.Add("A . 病人清醒后，及时进行心理干预");
        CQP.answers.Add("B . 病人转入普通病房，需由家人24小时陪护");
        CQP.answers.Add("C . 主管医师及责任护士应有意识的给予关注");
        CQP.answers.Add("D . 医护和家属协同及时反馈患者的情绪状态");
        CQP.answers.Add("E . 做好门窗的防护");
        CQP.corrects = new int[] { 0, 1, 2, 3, 4 };
        CQP.analysisCall.AddListener(scorePoint53Analysis);
        CQP.submitCall.AddListener(() =>
        {
            if(!AllStaticVariable.isInPingFen)
            {
                AllNeedUI.Instance.ChuYuanPanel.SetActive(true);
                //播放慢的节奏音效
                AllNeedUI.Instance.SlowAudio.enabled = true;
                AllNeedUI.Instance.FastAudio.enabled = false;
            }
        });
        CQP.NextAnswerCall.AddListener(() =>
        {
            AllStaticVariable.IsShowAnswer = false;
            AllNeedUI.Instance.ChuYuanPanel.SetActive(true);
            //播放慢的节奏音效
            AllNeedUI.Instance.SlowAudio.enabled = true;
            AllNeedUI.Instance.FastAudio.enabled = false;
        });

        CQP.mission = "突发事件处理";
        CQP.property = "临床诊断";
        CQP.showQuestionCall.AddListener(scorePoint53);
        CQP.showQuestionCall2.AddListener(scorePoint53);
    }
    public static void scorePoint53Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "A、B、C、D、E";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            if (!AllStaticVariable.isInPingFen)
            {
                AllNeedUI.Instance.ChuYuanPanel.SetActive(true);
                //播放慢的节奏音效
                AllNeedUI.Instance.SlowAudio.enabled = true;
                AllNeedUI.Instance.FastAudio.enabled = false;
            }
            Destroy(analysisGo);
        });
    }
    public static void scorePoint57()
    {
        MonoWay.Instance.CloseAllMainPanel();
        AllStaticVariable.IsDone57 = true;
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "1、该如何治疗？";
        CQP.title = "多 选 题";
        CQP.BgPic.overrideSprite = Resources.Load("DuoXuan", typeof(Sprite)) as Sprite;
        CQP.analysis = "1";
        CQP.answers.Clear();

        CQP.answers.Add("A . 功能锻炼");
        CQP.answers.Add("B . 应用糖皮质激素");
        CQP.answers.Add("C . B族维生素");
        CQP.answers.Add("D . 神经营养因子");
        CQP.answers.Add("E . 放血治疗");
        CQP.answers.Add("F . 中医中药治疗");
        CQP.corrects = new int[] { 0, 1, 2, 3, 5 };
        CQP.analysisCall.AddListener(scorePoint57Analysis);
        CQP.submitCall.AddListener(() => {
            MonoWay.Instance.DelayS58();
        });

        CQP.mission = "临床诊断";
        CQP.property = "临床诊断";
        CQP.showQuestionCall.AddListener(scorePoint57);
        CQP.showQuestionCall2.AddListener(scorePoint57);
    }
    public static void scorePoint57Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "A、B、C、D、F";
        analysisGo.transform.Find("Text3").GetComponent<TextMeshProUGUI>().text = "      迟发性多发性神经病主要靠功能锻炼为主，一般预后良好。";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if (AllStaticVariable.isInPingFen == false)
                MonoWay.Instance.DelayS58();
        });
    }
    public static void scorePoint58()
    {
        PatientChaTi.CheckHasMiss();
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "2、你认为患者最可能出现了什么情况？";
        CQP.title = "单 选 题";
        CQP.analysis = "1";
        CQP.answers.Clear();

        CQP.answers.Add("A . 脑梗死");
        CQP.answers.Add("B . 费用性肌萎缩");
        CQP.answers.Add("C . 颈椎病");
        CQP.answers.Add("D . 迟发性多发性周围神经病");
        CQP.answers.Add("E . 重症肌无力");
        CQP.corrects = new int[] { 3 };
        CQP.analysisCall.AddListener(scorePoint58Analysis);
        CQP.submitCall.AddListener(() =>
        {
            if (AllStaticVariable.isInPingFen == false)
            {
                AllNeedUI.Instance.EndingPlane.SetActive(true);
            }
        });

        CQP.mission = "临床诊断";
        CQP.property = "临床诊断";
        CQP.showQuestionCall.AddListener(scorePoint58);
        CQP.showQuestionCall2.AddListener(scorePoint58);
    }
    public static void scorePoint58Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "D";
        analysisGo.transform.Find("Text3").GetComponent<TextMeshProUGUI>().text = "      部分重度有机磷农药中毒患者可能出现迟发性周围神经病。";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            if (AllStaticVariable.isInPingFen == false)
            {
                //AllNeedUI.Instance.StarProgress.GetComponent<RectTransform>().sizeDelta += new Vector2(128/7, 0);
                AllNeedUI.Instance.EndingPlane.SetActive(true);
            }
            Destroy(analysisGo);
        });
    }

    ////切换黑屏
    //private static void HeiPing()
    //{
    //    AllNeedUI.Instance.StarProgress.GetComponent<RectTransform>().sizeDelta += new Vector2(128 / 7, 0);
    //    AllNeedUI.Instance.HeiPing.SetActive(true);
    //    AllNeedUI.Instance.HeiPing.GetComponent<Image>().DOFade(1, 1);
    //    StartCoroutine(DelayHeiPing());
    //}
    //IEnumerator DelayHeiPing()
    //{
    //    yield return new WaitForSeconds(1);
    //    AllNeedUI.Instance.HeiPing.GetComponent<Image>().DOFade(0, 1);
    //    AllNeedUI.Instance.HeiPing.SetActive(false);
    //}
  
    public static void scorePoint59()
    {
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "1、本例患者第一时间应选择的药物包括";
        CQP.title = "多 选 题";
        CQP.BgPic.overrideSprite = Resources.Load("DuoXuan", typeof(Sprite)) as Sprite;
        CQP.analysis = "1";
        CQP.answers.Clear();

        CQP.answers.Add("A . 阿托品");
        CQP.answers.Add("B . 解磷定");
        CQP.answers.Add("C . 胃肠道保护剂");
        CQP.answers.Add("D . 纳洛酮");
        CQP.answers.Add("E . 抗菌药物");
        CQP.corrects = new int[] { 0, 1 };
        CQP.analysisCall.AddListener(scorePoint59Analysis);
        CQP.submitCall.AddListener(() => {
            MonoWay.Instance.DelayS60();
        });

        CQP.mission = "临床诊断";
        CQP.property = "临床诊断";
        CQP.showQuestionCall.AddListener(scorePoint59);
        CQP.showQuestionCall2.AddListener(scorePoint59);
    }
    private static void scorePoint59Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "A、B";
        analysisGo.transform.Find("Text3").GetComponent<TextMeshProUGUI>().text = "      考察有机磷中毒解毒药物的应用。洗胃同时，应第一时间给予解毒药物，包括阿托品和解磷定。";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if (AllStaticVariable.isInPingFen == false)
            {
                MonoWay.Instance.DelayS60();
            }
            //scorePoint7();
        });
    }

    public static void scorePoint60()
    {
        GameObject question = GameObject.Instantiate
            (Resources.Load<GameObject>(QuestionPath)) as GameObject;
        Transform qTrans = question.transform;
        qTrans.parent = GameObject.Find("Canvas").transform;
        qTrans.localScale = Vector3.one;
        qTrans.localPosition = new Vector3(0, -20, 0);
        qTrans.localEulerAngles = Vector3.zero;
        ChoiceQuestionPanel CQP = question.GetComponent<ChoiceQuestionPanel>();
        CQP.question = "2、针对本例患者，阿托品首剂静脉推注的合适剂量是";
        CQP.title = "单 选 题";
        CQP.analysis = "1";
        CQP.answers.Clear();

        CQP.answers.Add("A . 2-4mg");
        CQP.answers.Add("B . 5-10mg");
        CQP.answers.Add("C . 10-20mg");
        CQP.answers.Add("D . 20-30mg");
        CQP.answers.Add("E . 1-2mg");
        CQP.corrects = new int[] { 2 };
        CQP.analysisCall.AddListener(scorePoint60Analysis);
        CQP.submitCall.AddListener(() => {
            AllNeedUI.Instance.ZhiLiaoLeftLabel.text = "1";
            Transform[] item2 =
            {
                    AllNeedUI.Instance.ZhiLiaoItems[1]
                };
            MonoWay.Instance.PreferItem(item2);
            MonoWay.Instance.OpenTip("请进行患者血透置管治疗");
        });

        CQP.mission = "临床诊断";
        CQP.property = "临床诊断";
        CQP.showQuestionCall.AddListener(scorePoint59);
        CQP.showQuestionCall2.AddListener(scorePoint59);
    }
    private static void scorePoint60Analysis()
    {
        GameObject analysisGo = (GameObject)Instantiate(Resources.Load(AnalysisPath));
        analysisGo.transform.parent = GameObject.Find("Canvas").transform;
        analysisGo.transform.localScale = Vector3.one;
        analysisGo.transform.localPosition = Vector3.zero;
        analysisGo.transform.localEulerAngles = Vector3.zero;
        analysisGo.transform.Find("Text2").GetComponent<TextMeshProUGUI>().text = "C";
        analysisGo.transform.Find("Text3").GetComponent<TextMeshProUGUI>().text = "      考察对患者病情程度的判断及阿托品首剂的应用。阿托品首剂应用依赖于病情的严重程度。本例患者有机磷农药中毒伴有中枢神经系统功能障碍，提示为重度中毒，阿托品用量10-20mg。";
        Button btn = analysisGo.GetComponentInChildren<Button>();
        btn.onClick.AddListener(() =>
        {
            Destroy(analysisGo);
            if (AllStaticVariable.isInPingFen == false)
            {
                AllNeedUI.Instance.ZhiLiaoLeftLabel.text = "1";
                Transform[] item2 =
                {
                    AllNeedUI.Instance.ZhiLiaoItems[1]
                };
                MonoWay.Instance.PreferItem(item2);
                MonoWay.Instance.OpenTip("请进行患者血透置管治疗");
            }
            //scorePoint7();
        });
    }
}
