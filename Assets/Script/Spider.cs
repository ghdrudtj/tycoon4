using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Spider : MonoBehaviour
{
    public static Spider spider;
    public GameObject spiderObj;
    [SerializeField] private int spiderMaxNum = 20; // �Ź��� �ִ� Ŭ�� ��
    [SerializeField] private float spawnInterval = 30;  // �Ź� ��ȯ ����
    [SerializeField] private float spiderActiveDuration = 5f; // �Ź� Ȱ��ȭ �ð�

    private int currentspiderClicks; // �Ź� Ŭ���� Ƚ��
    private bool isspiderActive; // �Ź� ��ȯ ����

    public Animation S_out;
    //public Animation S_act;
    void Start()
    {
        StartCoroutine(spiderSpawnRoutine());
        S_out = spiderObj.GetComponent<Animation>();
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
            S_out.Play();
            // ���� �Ź� ��ȯ�� ���� ���
            if (currentspiderClicks <= spiderMaxNum)
            {
                Invoke("Overspider",0.5f);
            }
            else
            {
                Invoke("Evaluatespider", 0.5f);
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
        Debug.Log("�Ź� ��ȯ!");
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
