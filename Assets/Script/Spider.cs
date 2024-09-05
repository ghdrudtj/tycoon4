using System.Collections;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public static Spider spider;
    public GameObject spiderObj;
    public int spiderMaxNum = 20; // �Ź��� �ִ� Ŭ�� ��
    public float spawnInterval = 30;  // �Ź� ��ȯ ����
    public float spiderActiveDuration = 5f; // �Ź� Ȱ��ȭ �ð�

    private int currentspiderClicks; // �Ź� Ŭ���� Ƚ��
    private bool isspiderActive; // �Ź� ��ȯ ����

    void Start()
    {
        StartCoroutine(spiderSpawnRoutine());
    }

    IEnumerator spiderSpawnRoutine()
    {
        while (true) // ��� �ݺ��Ͽ� �Ź̸� ���� �������� ��ȯ
        {
            yield return new WaitForSecondsRealtime(spawnInterval);
            if (!isspiderActive)
            {
                // �Ź� ��ȯ
                Spawnspider();
                isspiderActive = true;

                // �Ź̰� Ȱ��ȭ�Ǵ� ���� ���
                float currentTime = 0f;
                while (currentTime < spiderActiveDuration)
                {
                    currentTime += Time.deltaTime;
                    yield return null;
                }
            }
            // ���� �Ź� ��ȯ�� ���� ���
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
            Debug.Log("���� �Ź� ��ȯ �ð� = " + spawnInterval);
        }
    }

    void Spawnspider()
    {
        spiderObj.SetActive(true);
        currentspiderClicks = 0; // Ŭ�� �� �ʱ�ȭ
        Debug.Log("���� ��ȯ!");
    }

    void Evaluatespider()
    {
        if (currentspiderClicks >= spiderMaxNum)
        {
            Debug.Log("�Ź� ��� ����!");
        }

        spiderObj.SetActive(false);
    }
    void Overspider()
    {
        if (currentspiderClicks <= spiderMaxNum)
        {
            Debug.Log("�Ź� ��� ����!");
            DollMakerManager.instance.Doll0();
        }
        spiderObj.SetActive(false);
    }

    public void spiderClick()
    {
        if (isspiderActive)
        {
            currentspiderClicks++;
            Debug.Log("Ŭ�� �� = " + currentspiderClicks);

            // Ŭ�� ���� ��ǥ�� �����ϸ� �Ź̸� ��� ��Ȱ��ȭ
            if (currentspiderClicks >= spiderMaxNum)
            {
                Evaluatespider();
            }
        }
    }
}
