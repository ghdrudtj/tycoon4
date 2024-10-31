using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearNum : MonoBehaviour
{
    public Text ClearNumtext;// �� ������������ ��ǥ ���� üũ
    void Start()
    {
        ClearNumtext = GetComponent<Text>();
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Stage1Scene")
        {
            ClearNumtext.text = "��ǥ " + GameManager.instance.OrderclearNum1.ToString() + "/15";
        }
        if (SceneManager.GetActiveScene().name == "Stage2Scene")
        {
            ClearNumtext.text = "��ǥ " + GameManager.instance.OrderclearNum2.ToString() + "/25";
        }
        if (SceneManager.GetActiveScene().name == "Stage3Scene")
        {
            ClearNumtext.text = "��ǥ " + GameManager.instance.OrderclearNum3.ToString() + "/35";
        }
    }
   
}
