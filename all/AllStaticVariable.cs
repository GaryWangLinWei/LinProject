﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllStaticVariable : MonoBehaviour {
    //天数
    public static string day = "第一天";
    //星星数
    public static int star = 100;
    //是否进入评分
    public static bool isInPingFen = false;
    //是否再接再厉中
    public static bool isAgain = false;
    //用药次数
    public static int medicineTime = 0;
    //问诊次数
    public static int wenZhenTime = 1;
    //治疗次数
    public static int ZhiLiaoTime = 0;
    //检查次数
    public static int JianChaTime = -2;
    //病史问题list
    public static string[] QuestionStrings =
    {
        //音频从1开始，此处填充一个空值
        "",
        //1
        "您好，我是急诊医生。请问患者叫什么名字？",
        "请问患者多大年龄？",
        "请问患者哪里不舒服？",
        "患者发病多久了？",
        "患者最近心情状况如何？",
        "患者最近吃过哪些东西？",
        "患者最近去哪里游玩过？",
        "患者有什么药物过敏吗？",
        "患者最近是否有过其他检查？",
        "为什么不舒服，有否接触过什么药物？",
        //11
        "最近是否吃过过敏食物？",
        "患者什么时候开始昏迷的？",
        "患者身边有没有其他东西？",
        "患者最近有没有发现异常行为？",
        "昏迷之前喝了多少农药？",
        "目前有伴随其它疾病？",
        "嘴角是否有异物，是否擦拭过？",
        "有无腹泻/拉肚子？",
        "腹泻如何开始的？",
        "腹泻何时开始的？",
        //21
        "以前有/得过什么病吗？",
        "有以前的病历和检查结果吗？",
        "平时服用什么药物吗？",
        "平时服的药用了多久？",
        "接触过传染病患者吗？",
        "以前得过传染病吗？如肝炎、结核病等。",
        "以前受过外伤吗？",
        "以前做过手术吗？",
        "对药物，食物等有无过敏情况？",
        "过敏时有什么反应？",
        //31
        "疫苗接种情况？",
        "以前输过血吗？",
        "献过血吗？",
        "（患者）出生在什么地方？长期住在哪？",
        "（生长和发育史）和正常人相比，生长和发育状况怎么样？",
        "以前免疫接种正常吗？",
        "患者最高学历是什么？",
        "以前做过哪些工作（职业史）？",
        "有过哪些理想和目标（生活目标）？",
        "平时每天怎么都做些什么（日常活动）？",
        //41
        "和家人、朋友、同事关系（社会关系）怎么样？",
        "经常出去旅游/旅行吗？",
        "有没有不洁性交史？比如经常性交没有采取保护措施？",
        "有没有和动物接触过？比如被蚊虫叮咬或其他进行动物体肤接触？",
        "生活工作环境怎么样？有没有职业危害？",
        "平时抽烟吗？每天抽几只？",
        "平时常喝酒吗？喝酒多吗？",
        "平时经常锻炼身体吗？常做哪些运动。",
        "平时饮食",
        "咖啡因",
        //51
        "家庭成员状况",
        "家族成员健康情况",
        "有无犯罪记录、违法记录等",
        "虐待：是否曾被恐吓、攻击、性侵害？",
        "有无种族背景？",
        "有无宗教信仰？",
        "有去过疫区吗？",
        "喝酒吸烟吗？有其他不良嗜好吗？",
        "双亲、兄弟姐妹、子女健康情况",
        "有无遗传性疾病？",
        //61
        "家里人健康吗？有无家族病史？",
        "家族有无精神病史？",
        "",
        "患者有没有其他的不良反应体征？",
        "患者中途有没有醒过？",
        "患者中途喝过或者吃过什么东西？",
        "患者有没有做过其他检查？",
        "有没有什么过敏症状？",
        "患者有没有其他的不良反应体征？",
        "患者中途有没有醒过？",
        //71
        "患者中途喝过或者吃过什么东西？",
        "患者有没有做过其他检查？",
        "有没有什么过敏症状？",
        "患者有说哪里不舒服吗？",
        "您感觉怎么样？",
        "您要不要吃点东西？",
        "您要上厕所吗？",
        "您的手可以动吗？",
        "您要喝水吗？",
        "有没有觉得不舒服？",
        //81
        "患者情绪是否稳定？",
        "患者是否仍有寻死念头？",
        "患者有说哪里不舒服吗？",
        "患者情绪是否稳定？",
        "患者是否仍有寻死念头？",
        "您感觉怎么样？",
        "您要不要吃点东西？",
        "您要上厕所吗？",
        "您的手可以动吗？",
        "您要喝水吗？",
        //91
        "有没有觉得不舒服？",
        "您现在觉得怎么样？",
        "吃东西喝水是否正常？",
        "一天大便几次？",
        "还有恶心、呕吐感觉吗？",
        "是否出现胸闷得情况？",
        "您的手可以动吗？",
        "您的脚可以动吗？",
        "您现在觉得怎么样？",
        "吃东西喝水是否正常？",
        //101
        "一天大便几次？",
        "还有恶心、呕吐感觉吗？",
        "是否出现胸闷得情况？",
        "您的手可以动吗？",
        "您的脚可以动吗？",
        "患者情绪是否稳定？",
        "患者是否仍有寻死念头？",
        "您现在觉得怎么样？",
        "吃东西喝水是否正常？",
        "一天大便几次？",
        //111
        "还有恶心、呕吐感觉吗？",
        "是否出现胸闷得情况？",
        "您的手可以动吗？",
        "您的脚可以动吗？",
        "您好，我是门诊医生。请问您叫什么名字？",
        "请问您多大年龄？",
        "请问您哪里不舒服？",
        "您发病多久了？",
        " 从什么时候开始不舒服的?",
        "您最近心情状况如何？",
        //121
        "您最近吃过哪些东西？",
        "您最近去哪里游玩过？",
        "您有什么药物过敏吗？",
        "最近是否有情绪波动，精神状态如何？",
        "您最近是否有过其他检查？",
        "一天大便几次？",
        "还有恶心、呕吐感觉吗？",
        "您昏迷多久了？",
        "您的脚可以动吗？",
        "在家里有经常散步等活动吗？",
        //131
        "您愿不愿意做一下口腔清洗？",
        "我是王玉医生，患者叫什么名字？",
        "哪里不舒服？",
        "这种病症持续多久啦？",
        "吃了什么东西吗？",
        "吃了多少？",
        "为什么吃，和家人有矛盾吗？",
        "呼吸情况如何？",
        "呼吸是不是很费力？",
        "是否感觉有痰？",
        //141
        "呼吸情况如何？",
        "呼吸是不是很费力？",
        "是否感觉有痰？",
        "请问您哪里不舒服？",
        "这样的症状什么时候开始的？",
        "这症状是一直有还是时有时无",
        "症状越来越重还是越来越轻",
        "除了没力气和麻麻感觉以外还有其他不适的吗？"

    };
    //病史回答list
    public static string[] AnswerStrings =
    {
        //音频从1开始，此处填充一个空值
        "",
        //1
        "她叫刘芳",
        "52岁",
        "恶心，呕吐及腹痛，伴有出汗",
        "2-3个小时",
        "不太好",
        "吃的跟平时一样",
        "一直在家里",
        "没有",
        "没有",
        "心情不好，喝了农药",
        //11
        "没有",
        "3小时前，喝了甲胺磷农药后不久就昏过去了。",
        "有一个农药瓶子",
        "心情比较烦躁",
        "半斤的药瓶，还剩下1/3",
        "没有。",
        "没有。",
        "没有腹泻。",
        "没有腹泻。",
        "没有腹泻。",
        //21
        "没有。",
        "没有。",
        "没有。",
        "没有。",
        "没有。",
        "没有。",
        "没有。",
        "没有。",
        "没有。",
        "没有。",
        //31
        "没有。",
        "没有。",
        "没有。",
        "在四川，长期在浦东。",
        "自小长得比别人都慢，现在都5岁了都没有3岁的弟弟长得高，又瘦。",
        "正常。",
        "初中",
        "保姆",
        "没有。",
        "不是清楚。",
        //41
        "还好。",
        "没有。",
        "没有。",
        "没有。",
        "没有。",
        "没有。",
        "没有。",
        "没有。",
        "清淡。",
        "没有。",
        //51
        "良好。",
        "良好。",
        "没有。",
        "没有。",
        "没有。",
        "没有。",
        "没有。",
        "没有。",
        "良好。",
        "没有。",
        //61
        "家里的人都很健康，没有人有大病。",
        "没有。",
        "",
        "不清楚。",
        "没有。",
        "没有。",
        "不知道",
        "没有。",
        "感觉她没力气。",
        "能睁开眼睛了。",
        //71
        "没有。",
        "不知道",
        "没有。",
        "他感觉喉咙不舒服",
        "…",
        "…",
        "…",
        "…",
        "…",
        "…",
        //81
        "还算稳定。",
        "目前还不确定。",
        "他感觉喉咙不舒服",
        "有时候情绪不佳。",
        "应该没有了。",
        "…",
        "…",
        "…",
        "…",
        "…",
        //91
        "…",
        "还好,就是喉咙不舒服。",
        "恩可以的",
        "一次",
        "没有了。",
        "有",
        "可以",
        "可以",
        "还好。",
        "恩，正常。",
        //101
        "一次",
        "没有了。",
        "没有。",
        "可以",
        "可以",
        "有时候情绪不佳。",
        "应该没有了。",
        "有时候会头晕、眼花、看不清东西，胸口不舒服。",
        "恩，正常。",
        "一次",
        //111
        "没有了。",
        "没有。",
        "可以",
        "可以",
        "我叫刘芳。",
        "52岁。",
        "双手没有力气，拿不起重物，麻麻的感觉。",
        "2周前出院就没有什么力气。",
        "2周前。",
        "时好时坏。",
        //121
        "正常饮食。",
        "一直在家里。",
        "没有。",
        "有情绪波动，精神一般。",
        "没有。",
        "1-2次。",
        "没有了。",
        "现在不昏迷了。",
        "可以。",
        "没有。",
        //131
        "不需要。",
        "她叫刘芳",
        "恶心，呕吐及腹痛，全身出汗",
        "3个小时",
        "喝了甲胺磷农药",
        "半斤的药瓶，还剩下1/3",
        "是的，她最近精神一直不佳，说过不想活的话。",
        "每次呼吸总觉的不顺。",
        "是的",
        "有的",
        //141
        "比昨天好些。",
        "好些了",
        "有的",
        "双手没有力气，拿不起重物，麻麻的感觉。",
        "两个星期之前开始的",
        "一直都有",
        "最近更加没力气了",
        "没有了",


    };
    //病史问题分数
    public static int[] QuestionScore =
    {
        //音频从1开始，此处填充一个无用值
        0,
        //1
        0,
        0,
        1,
        1,
        1,
        0,
        0,
        1,
        0,
        0,
        //11
        0,
        1,
        1,
        0,
        1,
        0,
        0,
        0,
        0,
        0,
        //21
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        //61
        0,
        0,
        0,
        0,
        0,
        -1,
        0,
        0,
        1,
        0,
        //71
        -1,
        0,
        0,
        1,
        -1,
        -1,
        -1,
        -1,
        -1,
        -1,
        //81
        1,
        1,
        0,
        1,
        1,
        -1,
        -1,
        -1,
        -1,
        -1,
        //91
        -1,
        1,
        0,
        0,
        0,
        1,
        0,
        0,
        1,
        1,
        //101
        1,
        0,
        0,
        0,
        0,
        1,
        1,
        1,
        0,
        0,
        //111
        0,
        0,
        0,
        0,
        1,
        1,
        1,
        1,
        0,
        1,
        //121
        0,
        0,
        0,
        0,
        0,
        1,
        1,
        -1,
        -1,
        1,
        //131
        -1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        //141
        1,
        1,
        1,
        1,
        1,
        1,
        1,
        1,
    };
    //警告点击次数
    public static int WarningTime = 0;
    //剩余查体项目数们
    public static string[] LeftChaTiNum = { "1", "4","2","3","3","2","1","6"};
    //剩余治疗项目数们
    public static string[] LeftZhiLiaoNum = {"1","1","3","2","2","2","3","3"};
    //问诊记录1是否生成
    public static bool IsCreateRecord1 = false;
    //问诊记录2是否生成
    public static bool IsCreateRecord2 = false;
    //是否拨除鼻导管
    public static bool IsRemoveBDG = false;
    //是否在EICU
    public static bool IsInEICU = false;
    //是否在普通病房
    public static bool IsInPt = false;
    //是否在门诊
    public static bool IsInMenZhen = false;
    //是否做过选择题
    public static bool IsDone33 = false;
    public static bool IsDone40 = false;
    public static bool IsDone46 = false;
    public static bool IsDone51 = false;
    public static bool IsDone57 = false;
    public static bool IsDone52 = false;
    //选择题中是否显示答案
    public static bool IsShowAnswer = false;
    //当天体温
    public static float TodayTiWen = 37.8f;
    //当天血压1
    public static int TodayXueYa1 = 134;
    //当天血压2
    public static int  TodayXueYa2 = 86;
    //当天呼吸
    public static int  TodayHuXi = 24;
    //当天血氧饱和
    public static int  TodayXueYang = 98;
    //当天心率
    public static int  TodayXinLv = 102;
    //心电数据是否发红
    public static bool IsBeRed = false;
    //是否门诊问诊
    public static bool IsMenZhenAsk = false;
    //是否完成当天问诊
    public static bool IsFinishTodayAsk = false;
    //是否跳出查体tip
    public static bool IsJumpChaTiTip = false;
    //是否第一次关闭ct2
    public static bool IsOccur33 = false;
    //是否提示
    public static bool IsTip = true;


    //进任务前所用时间
    public static float CostTime;

    public static void ResetVariable()
    {
        day = "第一天";
        star = 60;
        isInPingFen = false;
        medicineTime = 0;
        ZhiLiaoTime = 0;
        JianChaTime = -2;
        wenZhenTime = 1;
        WarningTime = 0;
        IsCreateRecord1 = false;
        IsCreateRecord2 = false;
        IsRemoveBDG = false;
        IsInEICU = false;
        IsInPt = false;
        IsInMenZhen = false;
        IsDone33 = false;
        IsDone40 = false;
        IsDone46 = false;
        IsDone51 = false;
        IsDone57 = false;
        IsDone52 = false;
        isAgain = false;
        PatientChaTi.ResetChaTi();
        PatientZhiLiao.ResetZhiLiao();
        IsShowAnswer = false;
        TodayTiWen = 37.8f;
        TodayXueYa1 = 134;
        TodayXueYa2 = 86;
        TodayHuXi = 24;
        TodayXueYang = 98;
        TodayXinLv = 102;
        IsBeRed = false;
        IsMenZhenAsk = false;
        IsFinishTodayAsk = false;
        IsJumpChaTiTip = false;
        AllNeedUI.Instance.starText.text = "100";
        IsOccur33 = false;

    }
}
