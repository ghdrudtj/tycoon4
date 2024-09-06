using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    public static Thief thief;
    public GameObject thiefObj;
    [SerializeField] private int thiefMaxNum = 10; // 도둑의 최대 클릭 수
    [SerializeField] private float spawnInterval = 5;  // 도둑 소환 간격
    [SerializeField] private float thiefActiveDuration = 5f; // 도둑 활성화 시간
    public int coin_m;

    private int currentThiefClicks;
    private bool isThiefActive;

    private bool Thiefclear;
    private bool Thiefover;
    void Start()
    {
        StartCoroutine(ThiefSpawnRoutine());
    }

    IEnumerator ThiefSpawnRoutine()
    {
        while (true) // 계속 반복하여 도둑을 일정 간격으로 소환
        {
            yield return new WaitForSecondsRealtime(spawnInterval);
            if (!isThiefActive)
            {
                // 도둑 소환
                SpawnThief();
                isThiefActive = true;

                // 도둑이 활성화되는 동안 대기
                float currentTime = 0f;
                while (currentTime < thiefActiveDuration)
                {
                    currentTime += Time.deltaTime;
                    yield return null;
                }
            }
            // 다음 도둑 소환을 위한 대기
            if(currentThiefClicks <= thiefMaxNum)
            {
                OverThief();
            }
            else
            {
                ThiefClick();
            }
            isThiefActive = false;
        }
    }
    void SpawnThief()
    {
        thiefObj.SetActive(true);
        currentThiefClicks = 0; // 클릭 수 초기화
        Debug.Log("도둑 소환!");
    }
    void EvaluateThief()
    {
        if (currentThiefClicks >= thiefMaxNum)
        {
            Debug.Log("도둑 방어 성공!");
        }
       
        thiefObj.SetActive(false);
    }
    void OverThief()
    {
        if (currentThiefClicks <= thiefMaxNum)
        {
            Debug.Log("도둑 방어 실패!");
            Coin.instance.coin -= Coin.instance.coin / coin_m;
            Debug.Log("훔쳐간돈 = " + Coin.instance.coin / coin_m);
        }
        thiefObj.SetActive(false);
    }
    public void ThiefClick()
    {
        if (isThiefActive)
        {
            currentThiefClicks++;
            Debug.Log("클릭 수 = " + currentThiefClicks);

            // 클릭 수가 목표에 도달하면 도둑을 즉시 비활성화
            if (currentThiefClicks >= thiefMaxNum)
            {
                EvaluateThief();
            }
            
        }
    }
    private void Update()
    {
    }
}
