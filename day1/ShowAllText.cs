using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowAllText : MonoBehaviour
{
    public TextMeshProUGUI text;


    public void ShowAll()
    {
        ShowTextSlow.StopPrint = true;
        text.text = "        患者，姓名：刘芳。女性，52岁，因 “被家人发现神志改变1小时”送入急诊。\n"+
                    "        查体：T 36.8℃，BP 156 / 90mmHg，R 20次 / 分，HR 70次 / 分，指氧饱和度98 %。\n" +
                    "        神志朦胧，两瞳孔对称，1mm，光反射迟钝。皮肤出汗明显、湿冷，肢体可见阵发性震颤。\n" +
                    "        两肺呼吸音粗，可闻及少许湿罗音，心律齐，腹软，上腹部轻压痛，肠鸣音5 - 6次 / min。\n" +
                    "        衣物一只袖子被呕吐物污染，伴有蒜臭味。";
    }
}
