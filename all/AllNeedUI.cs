using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AllNeedUI : Monosingleton<AllNeedUI>
{
    //预检报告
    public GameObject yuJianBaoGao;
    //任务列表panel
    public GameObject missionList;
    //实时病情记录panel
    public GameObject BingQingRecord;
    //病史采集panel
    public GameObject BingShiCollect;
    //患者查体panel
    public GameObject ChaTiPanel;
    //患者治疗panel
    public GameObject ZhiLiaoPanel;
    //精灵列表
    public Sprite[] spriteList;
    //canvas图片
    public GameObject Canvas;
    //主菜单toggle
    public GameObject[] mainMenuToggles;
    //结束当天工作
    public GameObject FinishJobBtn;
    //日期
    public TextMeshProUGUI Date;
    //星星数量label
    public TextMeshProUGUI starText;
    //星星
    public GameObject StarParent;
    //星星进度条
    public GameObject StarProgress;
    //评分面板
    public GameObject pingFengPanel;
    //警告查看预检报告
    public GameObject YuJianWarning;
    //警告查看血检
    public GameObject XueJianWarning;
    //警告查看CT报告
    public GameObject CTScanWarning;
    //警告突发事件
    public GameObject EmergencyWarning;
    //警告电话
    public GameObject CallWarning;
    //视诊警告
    public GameObject ShiZhenWarning;
    //血氧下降警告
    public GameObject XueYangDownWarning;
    //血液净化警告
    public GameObject XueYeJingHuaWarning;
    //血液净化panel
    public GameObject XueYeJingHuaPanel;
    //电话内容
    public GameObject CallContent;
    //突发事件panel
    public GameObject EmergencyPanel;
    //突发事件2panel
    public GameObject EmergencyPanel2;
    //突发事件视诊
    public GameObject EmergencyShiZhen;
    //血检报告1
    public GameObject xueJianReport1;
    //血检报告2
    public GameObject xueJianReport2;
    //血检报告3
    public GameObject xueJianReport3;
    //血检报告4
    public GameObject xueJianReport4;
    //血检报告5
    public GameObject xueJianReport5;
    //CT扫描报告
    public GameObject CTScanReport;
    //病史详情
    public GameObject BingShiDetial;
    //评分Item父物体
    public GameObject pingFenParent;
    //操作记录父物体
    public GameObject recordParent;
    //操作记录面板
    public GameObject operateNote;
    //体温单
    public GameObject temperature;
    //查体结果
    public GameObject ChaTiResult;
    //知识点panel
    public GameObject KnowledgePanel;
    //确认结束人物窗口
    public GameObject SureFinishPanel;
    //病史采集toggle
    public GameObject[] BingShiToggles;
    //病史采集问题panel
    public GameObject[] BingShiQuestionPanels;
    //病史采集问题list
    public GameObject[] BingShiQuestionList;
    //查体剩余数量label
    public TextMeshProUGUI ChaTiLeftLabel;
    //治疗剩余数量label
    public TextMeshProUGUI ZhiLiaoLeftLabel;
    //问诊剩余数量label
    public TextMeshProUGUI WenZhenLeftLabel;
    //拔出鼻导管panel
    public GameObject RemoveBDGPanel;
    //黑屏
    public GameObject HeiPing;
    //肌力图
    public GameObject MRCPlane;
    //结束项目panel
    public GameObject EndingPlane;
    //温度1
    public Image Wendu1;
    //温度2
    public Image Wendu2;
    //数据
    public Image Value1;
    public Image Value2;
    //心电检测
    public GameObject XinDianCheck;
    //血压
    public TextMeshProUGUI xueYa;
    //体温
    public TextMeshProUGUI tiWen;
    //呼吸
    public TextMeshProUGUI huXi;
    //血氧饱和度
    public TextMeshProUGUI xueYang;
    //心率
    public TextMeshProUGUI xinLv;
    //跳动的血氧饱和心率
    public GameObject JumpNum;
    //职业技能得分
    public TextMeshProUGUI JiNengScore;
    //临床诊断得分
    public TextMeshProUGUI LinChuangScore;
    //专业知识得分
    public TextMeshProUGUI ZhuanYeScore;
    //医患沟通得分
    public TextMeshProUGUI YiHuanScore;
    //幻灯片遮罩
    public GameObject HDPMask;
    //幻灯片幕布
    public Image HuanDengPian;
    //医院画面
    public GameObject YiYuan;
    //开场白
    public GameObject KaichangPanel;
    //治疗项们
    public Transform[] ZhiLiaoItems;
    //查体项们
    public Transform[] ChaTiItems;
    //血氧下降panel
    public GameObject XueYangDownPanel;
    //洗胃背景图
    public GameObject XiWeiBg;
    //查看预见提示
    public GameObject YuJianShowTip;
    //底下提示
    public GameObject BottomTip;
    //快的节奏音效
    public AudioSource FastAudio;
    //慢的节奏音效
    public AudioSource SlowAudio;
    //嘈杂声
    public AudioSource BgNoise;
    //顶部静音
    public Toggle AudioTrigger;
    //门诊提示
    public GameObject MenZhenTip;
    //问诊提示
    public GameObject WenZhenTip;
    //报告提示
    public GameObject ReportTip;
    //查体提示
    public GameObject ChaTiTip;
    //操作指引
    public GameObject OperateGuidePanel;
    //病情记录操作记录页面
    public GameObject OperateNote;
    public GameObject TiWenNote;
    public GameObject ChaTiNote;
    //操作记录toggle
    public Toggle OperateToggle;
    public Toggle TiWenToggle;
    public Toggle ChaTiToggle;
    //CT报告2
    public GameObject CtReport2;
    //护士报告
    public GameObject HuShiReport;
    //呼吸机warning
    public GameObject HuXiWarning;
    //呼吸机panel
    public GameObject HuXiPanel;
    //推车画面
    public GameObject TuiChePanel;







    //查体结果
    //查体父物体
    public GameObject BodyParent;
    //查体报告内容
    public GameObject BodyContent;
    //查体地点们
    public GameObject[] BodyPlanes;
    //查体时间们
    public GameObject[] BodyTimes;

    #region 3D
        
    //家属担心
    public GameObject JiaShuWorry;
    //走廊问诊
    public GameObject ZouLangWenZhen;
    //普通病房有人
    public GameObject PTWithPerson;
    //普通病房无人
    public GameObject PTWithoutPerson;
    //开场医生
    public GameObject KaiChangDoctor;
    //推轮椅
    public GameObject TuiLunYi;
    //气管
    public GameObject QiGuan;
    //笔管
    public GameObject BiGuan;
    //急诊病人
    public GameObject JiZhenBingRen;
    //EICU病人
    public GameObject EICUPatient;
    //EICU被子
    public GameObject EICUBeiZi;
    //普通病房被子
    public GameObject PTBeiZi;
    //接诊医生
    public GameObject JieZhenDoc;
    //EICU相机
    public GameObject EICUCamera;
    //普通病房相机
    public GameObject PTCamera;
    //进EICU相机
    public GameObject ToEICUCamera;
    //EICU的门
    public GameObject EICUDoor;
    //门诊相机
    public GameObject MenZhenCamera;
    //门诊视诊对象
    public GameObject MenZhenObject;
    //门诊医患
    public GameObject MenZhenYiHuan;
    //睁眼camera
    public GameObject ZhengYanCamera;
    //出院画面
    public GameObject ChuYuanPanel;
    //icu背心
    public GameObject ICUBeiXin;
    //icu上衣
    public GameObject ICUShangYi;
    //普通背心
    public GameObject PtBeiXin;
    //普通上衣
    public GameObject PtShangYi;
    //门诊背心
    public GameObject MZBeiXin;
    //门诊上衣
    public GameObject MZShangYi;
    //EICU病人（不含器材）
    public GameObject EICUPatientWithoutTool;
    //抬手病人
    public GameObject EicuTaiShou;
    //电极导线
    public GameObject DianJiDaoXian;
    //血透机连接
    public GameObject XueTouJiLine;
    //呼吸球囊
    public GameObject HuXiQiuNang;
    //icu呼吸球囊
    public GameObject HuXiQiuNangICU;
    //闲置呼吸机
    public GameObject NoUseHuXiJi;
    //手部相机
    public GameObject HandCamera;
    //捏球松
    public GameObject NieQiuSong;
    //捏球紧
    public GameObject NieQieJin;
    //大堂相机
    public GameObject DaTangCamera;
    //大堂查体相机
    public GameObject DaTangChaTi;
    //大堂衣服
    public GameObject DaTangCloth;
    //大堂颤抖
    public GameObject LiNaiChanDou;
    //大堂盖被子
    public GameObject LiNaiBeiZi;
    

    #endregion
}
