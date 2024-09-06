using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class QuestM : MonoBehaviour
{
    public static QuestM instance;

    public int QNum;
    public int Num;

    private bool isClear;
    public GameObject QBtn;

    public UnityEngine.UI.Image order;
    public GameObject d0;
    public Sprite d1;
    public Sprite d2;
    public Sprite d3;
    public Sprite d4;
    public Sprite d5;
    public Sprite d6;
    public Sprite d7;
    public Sprite d8;
    public Sprite d9;
    public Sprite d10;
    public Sprite d11;
    public Sprite d12;
    public Sprite d13;
    public Sprite d14;
    public Sprite d15;
    public Sprite d16;
    public Sprite d17;
    public Sprite d18;
    public Sprite d19;
    public Sprite d20;

    [SerializeField]private float maxTimer = 10;
    Coroutine timerCoroutine;
    private bool timer;

    private List<int> Unlock1 = new List<int> { 1, 2, 3, 4, 5, 9, 13, 17 };
    private List<int> Unlock2 = new List<int> { 1, 2, 3, 4, 5, 9, 13, 17, 6, 10, 14, 18 };
    private List<int> Unlock3 = new List<int> { 1, 2, 3, 4, 5, 9, 13, 17, 6, 10, 14, 18, 7, 11, 15, 19 };

    public void lnit()
    {
        instance = this;
    }
    public void Start()
    {
        d0.SetActive(false);
        timer = false;
    }
    public void Quest()
    {
        d0.SetActive(true);
        
        timerCoroutine = StartCoroutine(TimerCoroutine());
        

        if (Unlock.instance != null) // Check if Unlock.Instance is not null
        {
            if (Unlock.instance.Unlock_4 == true)
            {
                QNum = Random.Range(1, 21);
            }
            else if (Unlock.instance.Unlock_3 == true)
            {
                QNum = Unlock3[Random.Range(1, Unlock3.Count)];
            }
            else if (Unlock.instance.Unlock_2 == true)
            {
                QNum = Unlock2[Random.Range(1, Unlock2.Count)];
            }
            else if (Unlock.instance.Unlock_1 == true)
            {
                QNum = Unlock1[Random.Range(1, Unlock1.Count)];
            }
            else
            {
                QNum =Random.Range(1,5);
            }
        }
        Debug.Log("QNum = " + QNum);

        switch (QNum)
        {
            case 1: order.sprite = d1; break;
            case 2: order.sprite = d2; break;
            case 3: order.sprite = d3; break;
            case 4: order.sprite = d4; break;
            case 5: order.sprite = d5; break;
            case 6: order.sprite = d6; break;
            case 7: order.sprite = d7; break;
            case 8: order.sprite = d8; break;
            case 9: order.sprite = d9; break;
            case 10: order.sprite = d10; break;
            case 11: order.sprite = d11; break;
            case 12: order.sprite = d12; break;
            case 13: order.sprite = d13; break;
            case 14: order.sprite = d14; break;
            case 15: order.sprite = d15; break;
            case 16: order.sprite = d16; break;
            case 17: order.sprite = d17; break;
            case 18: order.sprite = d18; break;
            case 19: order.sprite = d19; break;
            case 20: order.sprite = d20; break;
            default: order.sprite = null; break;
        }
        if (QNum == 0)
        {
            d0.SetActive(false);
        }
        QBtn.SetActive(false);
    }

    public void Clear()
    {
        StopCoroutine(timerCoroutine);

        if (QNum == Num)
        {
            Debug.Log("클리어");
            DollMakerManager.instance.Doll0();
            d0.SetActive(false);
            if (Num > 4)
            {
                Coin.instance.coin += 10;
            }
            Coin.instance.coin += 30;
        }
        else if (QNum != Num)
        {
            Debug.Log("no");
            DollMakerManager.instance.Doll0();
            d0.SetActive(false);
            Coin.instance.coin -= 30;
        }
        QBtn.SetActive(true);
    }
    private void Update()
    {
        Num = DollMakerManager.instance.Num;
    }
    IEnumerator TimerCoroutine()
    {
        float currentTimer = 0f;
        timer=true;
        while(currentTimer < maxTimer)
        {
            currentTimer += Time.deltaTime;
            Timer.instance.OnTimerChange(currentTimer, maxTimer);
            yield return null;
        }
      
        Debug.Log("타이머 끝");
        QNum = 0;
        d0.SetActive(false);
        Coin.instance.coin -= 30;
        timer = false;
    }
}
