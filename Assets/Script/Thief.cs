using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    public static Disturbance disturbance;
    public GameObject thiefObj;
    public int thiefMaxNum = 10; // ������ �ִ� Ŭ�� ��
    public float spawnInterval = 5;  // ���� ��ȯ ����
    public float thiefActiveDuration = 5f; // ���� Ȱ��ȭ �ð�

    private int currentThiefClicks;
    private float spawnTimer;
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
                EvaluateThief();
            }
            isThiefActive = false;
            Thiefclear=false;
            Thiefover=false;
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
            Debug.Log("���� ����!");
            Thiefclear = true;
        }
       
        thiefObj.SetActive(false);
    }
    void OverThief()
    {
        if (currentThiefClicks <= thiefMaxNum)
        {
            Debug.Log("���� ����!");
            Coin.instance.coin -= Coin.instance.coin / 10;
            Debug.Log("coin = " + Coin.instance.coin / 10);
            Thiefover = true;
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
