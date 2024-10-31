using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailNum : MonoBehaviour
{
    public Text FailNumtext; // 현 스테이지에서 틀린 횟수 체크
    void Start()
    {
        FailNumtext = GetComponent<Text>();
    }
    void Update() 
    {
        if (SceneManager.GetActiveScene().name == "Stage1Scene")
        {
            FailNumtext.text = "틀린 횟수 "+ GameManager.instance.OrderfailNum1.ToString()+"/5";
        }
        if (SceneManager.GetActiveScene().name == "Stage2Scene")
        {
            FailNumtext.text = "틀린 횟수 " + GameManager.instance.OrderfailNum2.ToString() + "/5";
        }
        if (SceneManager.GetActiveScene().name == "Stage3Scene")
        {
            FailNumtext.text = "틀린 횟수 " + GameManager.instance.OrderfailNum3.ToString() + "/5";
        }
    }
}
