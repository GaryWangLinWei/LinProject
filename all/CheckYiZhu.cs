using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckYiZhu : MonoBehaviour {
    //public TextMeshProUGUI Talk;
    public string way;
    //private string[] Talk1 = new string[2] { "请抬起您的右手", "请用最大的力气握紧橡皮圈" };

	// Use this for initialization
	void Start () {
        StartCoroutine(YiZhu());
    }
    IEnumerator YiZhu()
    {
        //Talk.text = "请睁开您的眼睛";
        AudioClip clip1 = Resources.Load("Recommend/"+way) as AudioClip;
        transform.GetComponent<AudioSource>().clip = clip1;
        transform.GetComponent<AudioSource>().enabled = true;
        yield return new WaitForSeconds(clip1.length);
        AllNeedUI.Instance.ChaTiPanel.SetActive(false);
        AllNeedUI.Instance.ZhengYanCamera.SetActive(true);
        Destroy(gameObject);

    }
}
