using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestM : MonoBehaviour // 주문서와 주문서 클리어 여부 확인
{
    public static QuestM instance;

    public int QNum;
    public int Num;

    private bool isClear;
    public GameObject QBtn;
    public GameObject Cbtn;

    public UnityEngine.UI.Image order; // 주문서들 이미지 표시
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

    [SerializeField]private float maxTimer = 10; // 타이머
    Coroutine timerCoroutine;
    private bool timer;

    private List<int> Unlock1 = new List<int> { 1, 2, 3, 4, 5, 9, 13, 17 }; // 해금에 따라 나오는 주문서 범위
    private List<int> Unlock2 = new List<int> { 1, 2, 3, 4, 5, 9, 13, 17, 6, 10, 14, 18 };
    private List<int> Unlock3 = new List<int> { 1, 2, 3, 4, 5, 9, 13, 17, 6, 10, 14, 18, 7, 11, 15, 19 };

    public int coin_m; 
    public int clearNum;

    [SerializeField] private GameObject ClearT;
    [SerializeField] private GameObject FailT;

    [SerializeField] private AudioSource Q_s;
    [SerializeField] private AudioSource C_s;
    [SerializeField] private AudioSource F_s;
    public void lnit()
    {
        instance = this;
    }
    public void Start()
    {
        d0.SetActive(false);
        Cbtn.SetActive(false);
        timer = false;
    }
    public void Quest() // 주문서 생성 해금 정도에 따라 나오는 범위가 다름
    {
        Q_s.Play();
        d0.SetActive(true);
        Cbtn.SetActive(true);
        
        timerCoroutine = StartCoroutine(TimerCoroutine());// 주문서 생성과 동시에 타이어 실행
        
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
        switch (QNum)  // 나오는 수에 따라 해당 이미지 보임
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
            Cbtn.SetActive(false);
        }
        QBtn.SetActive(false);
    }
    public void Clear()// 클리어 여부 확인
    {
        C_s.Play();
        StopCoroutine(timerCoroutine);

        if (QNum == Num)// 맞을 시(성공)
        {
            Debug.Log("클리어");
            DollMakerManager.instance.Doll0();
            d0.SetActive(false);
            Cbtn.SetActive(false);
            if (Num > 4)
            {
                Coin.instance.coin += 10;
            }
            Coin.instance.coin += 30;
            ClearT.SetActive(true);
            Invoke("CoinColor_W", 0.45f);
            CoinColor_G();
            Invoke("Clear_F", 0.35f);
            if (SceneManager.GetActiveScene().name == "Stage1Scene")
            {
                GameManager.instance.OrderclearNum1++;
                Debug.Log("주문서 성공 횟수 = " + GameManager.instance.OrderclearNum1);
            }
            if (SceneManager.GetActiveScene().name == "Stage2Scene")
            {
                GameManager.instance.OrderclearNum2++;
                Debug.Log("주문서 성공 횟수 = " + GameManager.instance.OrderclearNum2);
            }
            if (SceneManager.GetActiveScene().name == "Stage3Scene")
            {
                GameManager.instance.OrderclearNum3++;
                Debug.Log("주문서 성공 횟수 = " + GameManager.instance.OrderclearNum3);
            }
        }
        else if (QNum != Num)// 다를 시(실패)
        {
            F_s.Play();
            Debug.Log("no");
            DollMakerManager.instance.Doll0();
            d0.SetActive(false);
            Cbtn.SetActive(false);
            Coin.instance.coin -= coin_m;
            FailT.SetActive(true);
            Invoke("Fail_F", 0.45f);
            CoinColor_R();
            Invoke("CoinColor_W", 0.35f);
            if (SceneManager.GetActiveScene().name == "Stage1Scene")
            {
                GameManager.instance.OrderfailNum1++;
            }
            if (SceneManager.GetActiveScene().name == "Stage2Scene")
            {
                GameManager.instance.OrderfailNum2++;
            }
            if (SceneManager.GetActiveScene().name == "Stage3Scene")
            {
                GameManager.instance.OrderfailNum3++;
            }
        }
        QBtn.SetActive(true);
    }
    private void Update()
    {
        Num = DollMakerManager.instance.Num;
    }
    IEnumerator TimerCoroutine() // 타이어 안에 Clear()를 하지 않을 시 무조건으로 실패 처리
    {
        float currentTimer = 0f;
        timer=true;
        while(currentTimer < maxTimer)
        {
            currentTimer += Time.deltaTime;
            Timer.instance.OnTimerChange(currentTimer, maxTimer);
            yield return null;
        }
        F_s.Play();
        GameManager.instance.OrderfailNum1++;
        QNum = 0;
        d0.SetActive(false);
        Cbtn.SetActive(false);
        QBtn.SetActive(true);
        timer = false;
        FailT.SetActive(true);
        Invoke("Fail_F", 0.45f);
        CoinColor_R();
        Invoke("CoinColor_W", 0.35f);
        if (SceneManager.GetActiveScene().name == "Stage1Scene")
        {
            GameManager.instance.OrderfailNum1++;
            Coin.instance.coin -= 30;
        }
        if (SceneManager.GetActiveScene().name == "Stage2Scene")
        {
            GameManager.instance.OrderclearNum2++;
            Coin.instance.coin -= 30;
        }
        if (SceneManager.GetActiveScene().name == "Stage3Scene")
        {
            GameManager.instance.OrderclearNum3++;
            Coin.instance.coin -= 60;
        }
    }
    void CoinColor_W()
    {
        Coin.instance.CoinColor_W();
    }
    void CoinColor_R()
    {
        Coin.instance.CoinColor_R();
    }
    void CoinColor_G()
    {
        Coin.instance.CoinColor_G();
    }
    void Fail_F()
    {
        FailT.SetActive(false);
    }
    void Clear_F()
    {
        ClearT.SetActive(false);
    }
}
