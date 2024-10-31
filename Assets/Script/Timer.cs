using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour//ȭ�� �� Ÿ�̸� ǥ��
{
    public static Timer instance;

    [SerializeField] private Image timerImg;
   
    private void Awake()
    {
        instance = this;
    }
    public void OnTimerChange(float currentTimer, float maxTimer)
    {
        timerImg.fillAmount = currentTimer / maxTimer;
    }
    void Update()
    {
        
    }
}
