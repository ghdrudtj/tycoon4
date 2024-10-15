using System.Collections;
using UnityEngine;

public class Thief : MonoBehaviour
{
    public static Thief thief;
    public GameObject thiefObj;
    [SerializeField] private GameObject thiefclickObj;

    [SerializeField] private int thiefMaxNum = 10; // 도둑의 최대 클릭 수
    [SerializeField] private float spawnInterval = 5;  // 도둑 소환 간격
    [SerializeField] private float thiefActiveDuration = 5f; // 도둑 활성화 시간
    public int coin_m;

    private int currentThiefClicks;
    private bool isThiefActive;

    [SerializeField] private AudioSource T_s;
    [SerializeField] private AudioSource T_o;
    [SerializeField] private AudioSource T_c;

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
                T_s.Play();
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
            if (currentThiefClicks < thiefMaxNum)
            {
                OverThief();
            }
            
            Thiefover= false;  
            // 다음 도둑 소환을 위한 대기
            isThiefActive = false;
        }
    }
    void SpawnThief()
    {
        thiefObj.SetActive(true);
        thiefclickObj.SetActive(true);
        currentThiefClicks = 0; // 클릭 수 초기화
        Debug.Log("도둑 소환!");
    }
    void EvaluateThief()
    {
        
            T_o.Play();
            Debug.Log("도둑 방어 성공!");
        
        Trophy.instance.DisturbanceNum += 1;
        thiefObj.SetActive(false);
        thiefclickObj.SetActive(false);
    }
    void OverThief()
    {
        if (currentThiefClicks < thiefMaxNum)
        {
            Debug.Log("도둑 방어 실패!");
            Debug.Log("훔쳐간돈 = " + Coin.instance.coin / coin_m);
            Coin.instance.coin -= Coin.instance.coin / coin_m;
        }
        T_o.Play();
        thiefObj.SetActive(false);
        thiefclickObj.SetActive(false);
    }
    public void ThiefClick()
    {
        if (isThiefActive)
        {
            T_c.Play();
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
