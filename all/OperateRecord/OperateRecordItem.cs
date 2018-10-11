using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OperateRecordItem : MonoBehaviour
{
    //顺序
    public TextMeshProUGUI sequence;
    //时间
    public TextMeshProUGUI time;
    //操作记录
    public TextMeshProUGUI operateReport;
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static GameObject Init(string text)
    {
        GameObject operateRecord = Instantiate(Resources.Load<GameObject>("Prefabs/all/OperateRecordItem"));
        AllNeedUI.Instance.recordParent.GetComponent<RectTransform>().sizeDelta += new Vector2(0, 35);
        operateRecord.transform.parent = AllNeedUI.Instance.recordParent.transform;

        operateRecord.transform.localScale = Vector3.one;
        operateRecord.transform.localPosition = Vector3.zero;
        operateRecord.transform.localEulerAngles = Vector3.zero;

        operateRecord.GetComponent<OperateRecordItem>().sequence.text =
            AllNeedUI.Instance.recordParent.transform.childCount.ToString();

        operateRecord.GetComponent<OperateRecordItem>().time.text = ConvertTime(Time.time - AllStaticVariable.CostTime);
        operateRecord.GetComponent<OperateRecordItem>().operateReport.text = text;
        return operateRecord;
        
    }

    //时间转换
    private static string ConvertTime(float time)
    {
        int num = (int)time;
        int num0 = num / 3600;
        int num1 = num / 60 % 60;
        int num2 = num % 60;
        return string.Format("{0:d2}:{1:d2}:{2:d2}", num0, num1, num2);
    }
}
