using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Day1 : MonoBehaviour
{
    //病情记录toggle精灵
    public Sprite[] spriteList;
    //病情记录toggle
    public Toggle[] toggleList;
    //推轮椅
    public GameObject TuiLunYi;
    //任务按钮
    public GameObject MissionBtn;
    //自我介绍
    public GameObject RecommendImg;
    //自我介绍内容
    public TextMeshProUGUI RecommendText;
    //第二段介绍音频
    public AudioClip RecommendAudio;
    //第几段旁白
    private int pangBaiNum = 1;



    void Start()
    {
        StartCoroutine(OccurRecommend(17.7f));
    }

    //病情记录toggle方法
    private void onToggleChange()
    {
        toggleList[0].transform.GetChild(0).GetComponent<Image>().overrideSprite =
            toggleList[0].isOn ? spriteList[0] : spriteList[1];
        toggleList[1].transform.GetChild(0).GetComponent<Image>().overrideSprite =
            toggleList[1].isOn ? spriteList[2] : spriteList[3];
        toggleList[2].transform.GetChild(0).GetComponent<Image>().overrideSprite =
            toggleList[2].isOn ? spriteList[4] : spriteList[5];
    }
    //打开操作日志
    public void OpenOperateNote()
    {
        onToggleChange();
        if (toggleList[0].isOn)
        {
            AllNeedUI.Instance.operateNote.SetActive(true);
            AllNeedUI.Instance.temperature.SetActive(false);
            AllNeedUI.Instance.ChaTiResult.SetActive(false);
        }

    }
    //打开体温表
    public void OpenTemperature()
    {
        onToggleChange();
        if (toggleList[1].isOn)
        {
            AllNeedUI.Instance.operateNote.SetActive(false);
            AllNeedUI.Instance.temperature.SetActive(true);
            AllNeedUI.Instance.ChaTiResult.SetActive(false);
        }
    }
    //打开查体结果
    public void OpenBodyResult()
    {
        onToggleChange();
        if (toggleList[2].isOn)
        {
            AllNeedUI.Instance.operateNote.SetActive(false);
            AllNeedUI.Instance.temperature.SetActive(false);
            AllNeedUI.Instance.ChaTiResult.SetActive(true);
        }
    }
    //接任务按钮
    public void ReceivePatient()
    {
        //打开音效
        AllNeedUI.Instance.BgNoise.gameObject.SetActive(true);
        AllNeedUI.Instance.FastAudio.enabled = true;

        AllNeedUI.Instance.StarProgress.GetComponent<RectTransform>().sizeDelta += new Vector2(128 / 7, 0);
        AllStaticVariable.CostTime = Time.time;
        OperateRecordItem.Init("接待病患");
        MissionBtn.GetComponent<Toggle>().enabled = false;
        CamMove.Instance.MoveCamto(0);
        AllNeedUI.Instance.TuiChePanel.SetActive(true);
        AllNeedUI.Instance.KaiChangDoctor.SetActive(false);
        AllNeedUI.Instance.JieZhenDoc.SetActive(true);
        AllNeedUI.Instance.missionList.SetActive(false);
        StartCoroutine(OccurWarning1());
    }
    

    IEnumerator OccurWarning1()
    {
        yield return new WaitForSeconds(1f);
        //TuiLunYi.GetComponent<Animator>().enabled = false;
        //TuiLunYi.GetComponent<Rigidbody>().velocity = Vector3.zero;
        AllNeedUI.Instance.YuJianWarning.SetActive(true);
    }

    IEnumerator OccurRecommend(float time)
    {
        yield return new WaitForSeconds(time);
        RecommendImg.GetComponent<AudioSource>().enabled = false;
        pangBaiNum = 2;
        yield return new WaitForSeconds(0.1f);
        RecommendText.text = "点击右上角的任务栏，开始今天的工作吧！";
        RecommendImg.GetComponent<AudioSource>().clip = RecommendAudio;
        RecommendImg.GetComponent<AudioSource>().enabled = true;
        yield return new WaitForSeconds(5);
        AllNeedUI.Instance.mainMenuToggles[1].GetComponent<Toggle>().enabled = true;
        AllNeedUI.Instance.OperateGuidePanel.SetActive(true);
        RecommendImg.SetActive(false);
    }

    public void CloseJieShao()
    {
        if (pangBaiNum == 1)
        {
            StartCoroutine(OccurRecommend(0));
        }
        else if (pangBaiNum == 2)
        {
            StopAllCoroutines();
            AllNeedUI.Instance.OperateGuidePanel.SetActive(true);
            AllNeedUI.Instance.mainMenuToggles[1].GetComponent<Toggle>().enabled = true;
            RecommendImg.SetActive(false);
        }
        
    }




}
