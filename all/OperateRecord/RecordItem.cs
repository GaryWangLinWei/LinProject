using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// 病情记录——查体结果item
/// </summary>
public class RecordItem : MonoBehaviour
{
    //记录内容
    public TextMeshProUGUI Text;
    //黄线
    public GameObject YellowLine;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="childNum">记录地点的序号</param>
    /// <returns></returns>
    public static GameObject Init()
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/all/NoteItem"));
        AllNeedUI.Instance.BodyContent.GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
        go.transform.parent = AllNeedUI.Instance.BodyParent.transform;
        switch (AllStaticVariable.day)
        {
            case "第一天":
                AllNeedUI.Instance.BodyTimes[0].GetComponent<RectTransform>().sizeDelta += new Vector2(0,45);
                break;
            case "第二天":
                AllNeedUI.Instance.BodyTimes[1].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
                break;
            case "第三天":
                AllNeedUI.Instance.BodyTimes[2].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
                break;
            case "第四天":
                AllNeedUI.Instance.BodyTimes[3].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
                break;
            case "第五天":
                AllNeedUI.Instance.BodyTimes[4].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
                break;
            case "第六天":
                AllNeedUI.Instance.BodyTimes[5].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
                break;
            case "第七天":
                AllNeedUI.Instance.BodyTimes[6].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
                break;
            case "第八天":
                AllNeedUI.Instance.BodyTimes[7].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
                break;
            case "两周后":
                AllNeedUI.Instance.BodyTimes[8].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 45);
                break;
        }
        go.transform.localScale = Vector3.one;
        go.transform.localPosition = Vector3.zero;
        go.transform.localEulerAngles = Vector3.zero;
        return go;
    }
}
