using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowTextSlow : MonoBehaviour {
    private TextMeshProUGUI text;
    public static bool StopPrint = false;
    public GameObject CloseButton;

    void Start()
    {
        text = transform.GetComponent<TextMeshProUGUI>();
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
		//yield return new WaitForSeconds (3f);
		//text.text += "\n        查体：T 36.8℃，BP 156/90mmHg，R 20次/分，HR 70次/分，指氧饱和度98%。";
		//yield return new WaitForSeconds (3f);
		//text.text += "\n        神志朦胧，两瞳孔对称，1mm，光反射迟钝。皮肤出汗明显、湿冷，肢体可见阵发性震颤。";
		//yield return new WaitForSeconds (3f);
		//text.text += "\n        两肺呼吸音粗，可闻及少许湿罗音，心律齐，腹软，上腹部轻压痛，肠鸣音5-6次/min。";
		yield return new WaitForSeconds (1f);
		text.text += "\n        衣物一只袖子被呕吐物污染，伴有蒜臭味。";
        CloseButton.GetComponent<Button>().enabled = true;
    }

    void Update()
    {
        if (StopPrint)
        {
            StopAllCoroutines();
            CloseButton.GetComponent<Button>().enabled = true;
        }

    }
}
