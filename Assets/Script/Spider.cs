using System.Collections;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public static Spider spider;
    public GameObject spiderObj;
    [SerializeField] private GameObject spiderclickObj;

    [SerializeField] private int spiderMaxNum = 20; // �Ź��� �ִ� Ŭ�� ��
    [SerializeField] private float spawnInterval = 30;  // �Ź� ��ȯ ����
    [SerializeField] private float spiderActiveDuration = 5f; // �Ź� Ȱ��ȭ �ð�

    private int currentspiderClicks; // �Ź� Ŭ���� Ƚ��
    private bool isspiderActive; // �Ź� ��ȯ ����

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
                    animator.SetInteger("S_int", 0);
                    currentTime += Time.deltaTime;
                    yield return null;
                }
            }
            Overspider();
            animator.SetInteger("S_int", 2);
            // ���� �Ź� ��ȯ�� ���� ���
            isspiderActive = false;
            spawnInterval = Random.Range(30, 41);
            Debug.Log("���� �Ź� ��ȯ �ð� = " + spawnInterval);
        }
    }
    void Spawnspider()
    {
        S_s.Play();
        spiderObj.SetActive(true);
        spiderclickObj.SetActive(true);
        animator.SetInteger("S_int", 1);
        currentspiderClicks = 0; // Ŭ�� �� �ʱ�ȭ
        Debug.Log("�Ź� ��ȯ!");
    }
    void Evaluatespider()
    {
        if (currentspiderClicks >= spiderMaxNum)
        {
            S_o.Play();
            Debug.Log("�Ź� ��� ����!");
        }
        Trophy.instance.DisturbanceNum += 1;
        spiderclickObj.SetActive(false);
        spiderObj.SetActive(false);
    }
    void Overspider()
    {
        if (currentspiderClicks <= spiderMaxNum)
        {
            S_o.Play();
            Debug.Log("�Ź� ��� ����!");
            DollMakerManager.instance.Doll0();
        }
        spiderclickObj.SetActive(false);
        spiderObj.SetActive(false);
    }
    void spiderClick()
    {
        if (isspiderActive)
        {
            currentspiderClicks++;
            Debug.Log("Ŭ�� �� = " + currentspiderClicks);
            S_c.Play();
            // Ŭ�� ���� ��ǥ�� �����ϸ� �Ź̸� ��� ��Ȱ��ȭ
            if (currentspiderClicks >= spiderMaxNum)
            {
                Evaluatespider();
            }
        }
    }
}
