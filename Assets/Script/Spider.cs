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
            if (!isspiderActive || GameUI.instance.GameActive)
            {
                // �Ź� ��ȯ
                S_s.Play();
                Spawnspider();
                animator.SetTrigger("S_act");
                isspiderActive = true;

                //�Ź̰� Ȱ��ȭ�Ǵ� ���� ���
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
            // ���� �Ź� ��ȯ�� ���� ���
            isspiderActive = false;
            spawnInterval = Random.Range(30, 41);
            Debug.Log("���� �Ź� ��ȯ �ð� = " + spawnInterval);
        }
    }
    void Spawnspider()
    {
        spiderObj.SetActive(true);
        spiderclickObj.SetActive(true);
        currentspiderClicks = 0; // Ŭ�� �� �ʱ�ȭ
        Debug.Log("�Ź� ��ȯ!");
    }
    void Evaluatespider()
    {
        S_o.Play();
        Debug.Log("�Ź� ��� ����!");
        animator.SetTrigger("S_out_c");
        spiderclickObj.SetActive(false);
        Invoke("S_out", 0.75f);
        Trophy.instance.DisturbanceNum += 1;
    }
    void Overspider()
    {
        S_o.Play();
        Debug.Log("�Ź� ��� ����!");
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
            Debug.Log("Ŭ�� �� = " + currentspiderClicks);
            // Ŭ�� ���� ��ǥ�� �����ϸ� �Ź̸� ��� ��Ȱ��ȭ
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
