using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearNum : MonoBehaviour
{
    public Text ClearNumtext;
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
