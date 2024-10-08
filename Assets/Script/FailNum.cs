using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailNum : MonoBehaviour
{
    public Text FailNumtext;
    void Start()
    {
        FailNumtext = GetComponent<Text>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Stage1Scene")
        {
            FailNumtext.text = "Ʋ�� Ƚ�� "+ GameManager.instance.OrderfailNum1.ToString()+"/5";
        }
        if (SceneManager.GetActiveScene().name == "Stage2Scene")
        {
            FailNumtext.text = "Ʋ�� Ƚ�� " + GameManager.instance.OrderfailNum2.ToString() + "/5";
        }
        if (SceneManager.GetActiveScene().name == "Stage3Scene")
        {
            FailNumtext.text = "Ʋ�� Ƚ�� " + GameManager.instance.OrderfailNum3.ToString() + "/5";
        }
    }
}
