using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Thief : MonoBehaviour
{
    public static Thief instance;
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

    public Animator animator;
    void Start()
    {
        StartCoroutine(ThiefSpawnRoutine());
        animator = thiefObj.GetComponent<Animator>();
    }
    IEnumerator ThiefSpawnRoutine()
    {
        while (true) // ��� �ݺ��Ͽ� ������ ���� �������� ��ȯ
        {
            yield return new WaitForSecondsRealtime(spawnInterval);
            if (!isThiefActive || GameUI.instance.GameStop)
            {
                // ���� ��ȯ
                T_s.Play();
                SpawnThief(); 
                animator.SetTrigger("T_act");
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
        animator.SetTrigger("T_out_c");
        thiefclickObj.SetActive(false);
        Invoke("T_out", 0.95f);
    }
    void OverThief()
    {
        Debug.Log("���� ��� ����!");
        Debug.Log("���İ��� = " + Coin.instance.coin / coin_m);
        Coin.instance.coin -= Coin.instance.coin / coin_m;

        CoinColor_R();
        Invoke("CoinColor_W", 0.5f);

        T_o.Play();
        animator.SetTrigger("T_out_f");
        thiefclickObj.SetActive(false);
        Invoke("T_out", 0.95f);
    }
    public void ThiefClick()
    {
        if (isThiefActive)
        {
            thiefObj.GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("thiefcolor", 0.1f);

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

    void thiefcolor()
    {
        thiefObj.GetComponent<SpriteRenderer>().color = Color.white;
    }
    void T_out()
    {
        thiefObj.SetActive(false);
    }
    void CoinColor_W()
    {
        Coin.instance.CoinColor_W();
    }
    void CoinColor_R()
    {
        Coin.instance.CoinColor_R();
    }
}
