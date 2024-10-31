using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearNum : MonoBehaviour
{
    public Text ClearNumtext;// 현 스테이지에서 목표 개수 체크
    void Start()
    {
        ClearNumtext = GetComponent<Text>();
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Stage1Scene")
        {
            ClearNumtext.text = "목표 " + GameManager.instance.OrderclearNum1.ToString() + "/15";
        }
        if (SceneManager.GetActiveScene().name == "Stage2Scene")
        {
            ClearNumtext.text = "목표 " + GameManager.instance.OrderclearNum2.ToString() + "/25";
        }
        if (SceneManager.GetActiveScene().name == "Stage3Scene")
        {
            ClearNumtext.text = "목표 " + GameManager.instance.OrderclearNum3.ToString() + "/35";
        }
    }
   
}
