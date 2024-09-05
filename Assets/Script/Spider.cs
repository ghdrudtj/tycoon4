using System.Collections;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public static Spider spider;
    public GameObject spiderObj;
    public int spiderMaxNum = 20; // 거미의 최대 클릭 수
    public float spawnInterval = 30;  // 거미 소환 간격
    public float spiderActiveDuration = 5f; // 거미 활성화 시간

    private int currentspiderClicks; // 거미 클릭한 횟수
    private bool isspiderActive; // 거미 소환 여부

    void Start()
    {
        StartCoroutine(spiderSpawnRoutine());
    }

    IEnumerator spiderSpawnRoutine()
    {
        while (true) // 계속 반복하여 거미를 일정 간격으로 소환
        {
            yield return new WaitForSecondsRealtime(spawnInterval);
            if (!isspiderActive)
            {
                // 거미 소환
                Spawnspider();
                isspiderActive = true;

                // 거미가 활성화되는 동안 대기
                float currentTime = 0f;
                while (currentTime < spiderActiveDuration)
                {
                    currentTime += Time.deltaTime;
                    yield return null;
                }
            }
            // 다음 거미 소환을 위한 대기
            if (currentspiderClicks <= spiderMaxNum)
            {
                Overspider();
            }
            else
            {
                Evaluatespider();
            }
            isspiderActive = false;
            spawnInterval = Random.Range(30, 41);
            Debug.Log("다음 거미 소환 시간 = " + spawnInterval);
        }
    }

    void Spawnspider()
    {
        spiderObj.SetActive(true);
        currentspiderClicks = 0; // 클릭 수 초기화
        Debug.Log("도둑 소환!");
    }

    void Evaluatespider()
    {
        if (currentspiderClicks >= spiderMaxNum)
        {
            Debug.Log("거미 방어 성공!");
        }

        spiderObj.SetActive(false);
    }
    void Overspider()
    {
        if (currentspiderClicks <= spiderMaxNum)
        {
            Debug.Log("거미 방어 실패!");
            DollMakerManager.instance.Doll0();
        }
        spiderObj.SetActive(false);
    }

    public void spiderClick()
    {
        if (isspiderActive)
        {
            currentspiderClicks++;
            Debug.Log("클릭 수 = " + currentspiderClicks);

            // 클릭 수가 목표에 도달하면 거미를 즉시 비활성화
            if (currentspiderClicks >= spiderMaxNum)
            {
                Evaluatespider();
            }
        }
    }
}
