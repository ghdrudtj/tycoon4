using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    public static Thief thief;
    public GameObject thiefObj;
    [SerializeField] private int thiefMaxNum = 10; // ������ �ִ� Ŭ�� ��
    [SerializeField] private float spawnInterval = 5;  // ���� ��ȯ ����
    [SerializeField] private float thiefActiveDuration = 5f; // ���� Ȱ��ȭ �ð�
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
        while (true) // ��� �ݺ��Ͽ� ������ ���� �������� ��ȯ
        {
            yield return new WaitForSecondsRealtime(spawnInterval);
            if (!isThiefActive)
            {
                // ���� ��ȯ
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
            // ���� ���� ��ȯ�� ���� ���
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
        currentThiefClicks = 0; // Ŭ�� �� �ʱ�ȭ
        Debug.Log("���� ��ȯ!");
    }
    void EvaluateThief()
    {
        if (currentThiefClicks >= thiefMaxNum)
        {
            Debug.Log("���� ��� ����!");
        }
       
        thiefObj.SetActive(false);
    }
    void OverThief()
    {
        if (currentThiefClicks <= thiefMaxNum)
        {
            Debug.Log("���� ��� ����!");
            Coin.instance.coin -= Coin.instance.coin / coin_m;
            Debug.Log("���İ��� = " + Coin.instance.coin / coin_m);
        }
        thiefObj.SetActive(false);
    }
    public void ThiefClick()
    {
        if (isThiefActive)
        {
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
