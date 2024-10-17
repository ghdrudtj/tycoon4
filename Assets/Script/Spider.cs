using System.Collections;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public static Spider spider;
    public GameObject spiderObj;
    [SerializeField] private GameObject spiderclickObj;

    [SerializeField] private int spiderMaxNum = 20; // 거미의 최대 클릭 수
    [SerializeField] private float spawnInterval = 30;  // 거미 소환 간격
    [SerializeField] private float spiderActiveDuration = 5f; // 거미 활성화 시간

    private int currentspiderClicks; // 거미 클릭한 횟수
    private bool isspiderActive; // 거미 소환 여부

    [SerializeField] private AudioSource S_s;
    [SerializeField] private AudioSource S_o;
    [SerializeField] private AudioSource S_c;

    public Animator animator;
    void Start()
    {
        spawnInterval = Random.Range(30, 41);
        StartCoroutine(spiderSpawnRoutine());
        animator = spiderObj.GetComponent<Animator>();
    }
    IEnumerator spiderSpawnRoutine()
    {
        while (true) // 계속 반복하여 거미를 일정 간격으로 소환
        {
            yield return new WaitForSecondsRealtime(spawnInterval);
            if (!isspiderActive || GameUI.instance.GameActive)
            {
                // 거미 소환
                S_s.Play();
                Spawnspider();
                animator.SetTrigger("S_act");
                isspiderActive = true;

                //거미가 활성화되는 동안 대기
                float currentTime = 0f;
                while (currentTime < spiderActiveDuration)
                {
                    currentTime += Time.deltaTime;
                    yield return null;
                }
            }
            if (currentspiderClicks < spiderMaxNum)
            {
                Overspider();
            }
            // 다음 거미 소환을 위한 대기
            isspiderActive = false;
            spawnInterval = Random.Range(30, 41);
            Debug.Log("다음 거미 소환 시간 = " + spawnInterval);
        }
    }
    void Spawnspider()
    {
        spiderObj.SetActive(true);
        spiderclickObj.SetActive(true);
        currentspiderClicks = 0; // 클릭 수 초기화
        Debug.Log("거미 소환!");
    }
    void Evaluatespider()
    {
        S_o.Play();
        Debug.Log("거미 방어 성공!");
        animator.SetTrigger("S_out_c");
        spiderclickObj.SetActive(false);
        Invoke("S_out", 0.75f);
        Trophy.instance.DisturbanceNum += 1;
    }
    void Overspider()
    {
        S_o.Play();
        Debug.Log("거미 방어 실패!");
        animator.SetTrigger("S_out_f");
        spiderclickObj.SetActive(false);
        Invoke("S_out", 0.75f);
        DollMakerManager.instance.Doll0();
    }
    void spiderClick()
    {
        if (isspiderActive)
        {
            spiderObj.GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("spiderColor", 0.1f);

            S_c.Play();
            currentspiderClicks++;
            Debug.Log("클릭 수 = " + currentspiderClicks);
            // 클릭 수가 목표에 도달하면 거미를 즉시 비활성화
            if (currentspiderClicks >= spiderMaxNum)
            {
                Evaluatespider();
            }
        }
    }
    void spiderColor()
    {
        spiderObj.GetComponent<SpriteRenderer>().color = Color.white;
    }
    void S_out()
    {
        spiderObj.SetActive(false);
    }
}
