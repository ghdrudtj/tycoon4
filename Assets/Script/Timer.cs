using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    [SerializeField] private Image timerImg;
    //[SerializeField] private Text timerTxt;
    public void lnit()
    {
        instance = this;
    }
    
    public void OnTimerChange(int currentTimer, float maxTimer)
    {
        //timerTxt.text = $"{currentTimer:N1}/{maxTimer:N1}";
        timerImg.fillAmount = currentTimer / maxTimer;
        Debug.Log("Timer = " + currentTimer / maxTimer);
    }
    void Update()
    {
        
    }
}
