using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour
{
    public GameObject doctorTalkPanel;
    public GameObject patientTalkPanel;
    public TextMeshProUGUI doctorText;
    public TextMeshProUGUI patientText;
    public List<string> doctorTexts;
    public List<string> patientTexts;
    public List<AudioClip> doctorAudio;
    public List<AudioClip> patientAudio;
    private float doctorAudioLength;
    private float patientAudioLength;
    private GameObject JiaShu;
    public Image PatientFrame;
    public Sprite[] spriteList;

    void Start()
    {
        if (!AllStaticVariable.IsRemoveBDG)
        {
            PatientFrame.sprite = spriteList[0];
        }
        else if(AllStaticVariable.IsRemoveBDG && !AllStaticVariable.IsInMenZhen)
        {
            PatientFrame.sprite = spriteList[1];
        }
        else
        {
            PatientFrame.sprite = spriteList[2];
        }
        JiaShu = AllNeedUI.Instance.JiaShuWorry;
        //doctorAudioLength = doctorAudio.length;
        //patientAudioLength = patientAudio.length;


        StartCoroutine(talking());
    }

    IEnumerator talking()
    {
        print(doctorAudio.Count);
        print(patientAudio.Count);
        print(doctorTexts.Count);
        for (int i = 0; i < doctorAudio.Count; i++)
        {
            doctorTalkPanel.SetActive(true);
            patientTalkPanel.SetActive(false);
            transform.GetComponent<AudioSource>().enabled = false;
            transform.GetComponent<AudioSource>().clip = doctorAudio[i];
            doctorText.text = doctorTexts[i];
            transform.GetComponent<AudioSource>().enabled = true;

            JiaShu.GetComponent<Animator>().SetBool("StartTalk", false);
            AllNeedUI.Instance.BingShiCollect.SetActive(false);

            yield return new WaitForSeconds(doctorAudio[i].length + 0.4f);

            doctorTalkPanel.SetActive(false);
            patientTalkPanel.SetActive(true);

            JiaShu.GetComponent<Animator>().SetBool("StartTalk", true);
            transform.GetComponent<AudioSource>().enabled = false;
            transform.GetComponent<AudioSource>().clip = patientAudio[i];
            patientText.text = patientTexts[i];
            yield return new WaitForSeconds(0.1f);
            transform.GetComponent<AudioSource>().enabled = true;
            yield return new WaitForSeconds(patientAudio[i].length + 0.4f);


            ////第八天普问诊后跳出题目
            //if (doctorAudio[i].name == "108")
            //{
            //    AllNeedUI.Instance.mainMenuToggles[0].GetComponent<Toggle>().isOn = false;
            //    AllNeedUI.Instance.mainMenuToggles[1].GetComponent<Toggle>().isOn = false;
            //    AllNeedUI.Instance.mainMenuToggles[2].GetComponent<Toggle>().isOn = false;
            //    AllNeedUI.Instance.mainMenuToggles[3].GetComponent<Toggle>().isOn = false;
            //    AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().isOn = false;
            //    AllNeedUI.Instance.BingShiCollect.SetActive(false);
            //    QuestionBank.scorePoint51();
            //}
        }
        
        JiaShu.GetComponent<Animator>().SetBool("StartTalk", false);
        //AllNeedUI.Instance.BingShiCollect.SetActive(true);
        //if (AllStaticVariable.day == "第八天" && AllStaticVariable.IsInPt)
        //{
        //    AllNeedUI.Instance.mainMenuToggles[0].GetComponent<Toggle>().isOn = false;
        //    AllNeedUI.Instance.mainMenuToggles[1].GetComponent<Toggle>().isOn = false;
        //    AllNeedUI.Instance.mainMenuToggles[2].GetComponent<Toggle>().isOn = false;
        //    AllNeedUI.Instance.mainMenuToggles[3].GetComponent<Toggle>().isOn = false;
        //    AllNeedUI.Instance.mainMenuToggles[4].GetComponent<Toggle>().isOn = false;
        //    AllNeedUI.Instance.BingShiCollect.SetActive(false);
        //    //QuestionBank.scorePoint51();
        //    AllNeedUI.Instance.ShiZhenWarning.SetActive(true);
        //}
        Destroy(gameObject);
        if (AllStaticVariable.day == "第一天" && !AllStaticVariable.IsInEICU)
        {
            MonoWay.Instance.DelayOpenWenZhenTip();
        }


    }

}
