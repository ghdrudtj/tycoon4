using System.Collections;
using UnityEngine;

public class Thief : MonoBehaviour
{
    public static Thief thief;
    public GameObject thiefObj;
    [SerializeField] private GameObject thiefclickObj;

    [SerializeField] private int thiefMaxNum = 10; // ������ �ִ� Ŭ�� ��
    [SerializeField] private float spawnInterval = 5;  // ���� ��ȯ ����
    [SerializeField] private float thiefActiveDuration = 5f; // ���� Ȱ��ȭ �ð�
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
        while (true) // ��� �ݺ��Ͽ� ������ ���� �������� ��ȯ
        {
            yield return new WaitForSecondsRealtime(spawnInterval);
            if (!isThiefActive)
            {
                // ���� ��ȯ
                T_s.Play();
                SpawnThief();
                isThiefActive = true;

                // ������ Ȱ��ȭ�Ǵ� ���� ���
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
            // ���� ���� ��ȯ�� ���� ���
            isThiefActive = false;
        }
    }
    void SpawnThief()
    {
        thiefObj.SetActive(true);
        thiefclickObj.SetActive(true);
        currentThiefClicks = 0; // Ŭ�� �� �ʱ�ȭ
        Debug.Log("���� ��ȯ!");
    }
    void EvaluateThief()
    {
        
            T_o.Play();
            Debug.Log("���� ��� ����!");
        
        Trophy.instance.DisturbanceNum += 1;
        thiefObj.SetActive(false);
        thiefclickObj.SetActive(false);
    }
    void OverThief()
    {
        if (currentThiefClicks < thiefMaxNum)
        {
            Debug.Log("���� ��� ����!");
            Debug.Log("���İ��� = " + Coin.instance.coin / coin_m);
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
            Debug.Log("Ŭ�� �� = " + currentThiefClicks);

            // Ŭ�� ���� ��ǥ�� �����ϸ� ������ ��� ��Ȱ��ȭ
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
