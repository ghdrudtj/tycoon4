using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class QuestM : MonoBehaviour
{
    public static QuestM instance;

    public int QNum;
    public int Num;

    public bool isClear;

    public Image order;
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

    public void lnit()
    {
        instance = this;
    }
    public void Start()
    {
        d0.SetActive(false);
    }
    public void Quest()
    {
        d0.SetActive(true);
        timerCoroutine = StartCoroutine(TimerCoroutine());
        QNum = Random.Range(1, 21);
        Debug.Log("QNum = " + QNum);
        if (QNum == 1)
        {
            order.sprite = d1;
        }
        if (QNum == 2)
        {
            order.sprite = d2;
        }
        if (QNum == 3)
        {
            order.sprite = d3;
        }
        if(QNum == 4)
        {
            order.sprite = d4;
        }
        if (QNum == 5)
        {
            order.sprite = d5;
        }
        if (QNum == 6)
        {
            order.sprite = d6;
        }
        if (QNum == 7)
        {
            order.sprite = d7;
        }
        if (QNum == 8)
        {
            order.sprite = d8;
        }
        if (QNum == 9)
        {
            order.sprite = d9;
        }
        if (QNum == 10)
        {
            order.sprite = d10;
        }
        if (QNum == 11)
        {
            order.sprite = d11;
        }
        if (QNum == 12)
        {
            order.sprite = d12;
        }
        if (QNum == 13)
        {
            order.sprite = d13;
        }
        if (QNum == 14)
        {
            order.sprite = d14;
        }
        if (QNum == 15)
        {
            order.sprite = d15;
        }
        if (QNum == 16)
        {
            order.sprite = d16;
        }
        if (QNum == 17)
        {
            order.sprite = d17;
        }
        if (QNum == 18)
        {
            order.sprite = d18;
        }
        if (QNum == 19)
        {
            order.sprite = d19;
        }
        if (QNum == 20)
        {
            order.sprite = d20;
        }
        if(QNum == 0)
        {
            d0.SetActive(false);
        }
    }

    public void Clear()
    {
        StopCoroutine(timerCoroutine);
        float currentTimer = 0f;

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

    }
    private void Update()
    {
        Num = DollMakerManager.instance.Num;
    }
    IEnumerator TimerCoroutine()
    {
        float currentTimer = 0f;

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
    }
}
