using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckYiZhu2 : MonoBehaviour {
    public string way;

    void Start()
    {
        StartCoroutine(YiZhu());
    }
    IEnumerator YiZhu()
    {
        AudioClip clip1 = Resources.Load("Recommend/" + way) as AudioClip;
        transform.GetComponent<AudioSource>().clip = clip1;
        transform.GetComponent<AudioSource>().enabled = true;
        yield return new WaitForSeconds(clip1.length);
        AllNeedUI.Instance.ChaTiPanel.SetActive(false);
        AllNeedUI.Instance.HandCamera.SetActive(true);
        if (AllStaticVariable.JianChaTime == 2)
        {
            AllNeedUI.Instance.NieQiuSong.SetActive(true);
        }
        else if (AllStaticVariable.JianChaTime == 3)
        {
            AllNeedUI.Instance.NieQieJin.SetActive(true);
        }
        Destroy(gameObject);

    }
}
