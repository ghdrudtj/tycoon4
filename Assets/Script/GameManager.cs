using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour // Ʋ�� Ƚ���� ��ǥ ������ Ȯ���Ͽ� Ŭ����, ���� ���� Ȯ��
{
    public static GameManager instance; 
    [SerializeField] private Coin coin;
    [SerializeField] private DollMakerManager dollMakerManager;
    [SerializeField] private QuestM QuestM;

    public int OrderclearNum1;
    public int OrderfailNum1;
    public int OrderclearNum2;
    public int OrderfailNum2;
    public int OrderclearNum3;
    public int OrderfailNum3;

    [SerializeField] public GameObject ClaerText;
    [SerializeField] public GameObject OverText;
    private float GameCount = 1.5f;

    [SerializeField] private AudioSource C_s;
    [SerializeField] private AudioSource F_s;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        coin.lnit();
        QuestM.lnit();
        dollMakerManager.lnit();
    }
    void Update()
    {
       if(Coin.instance.coin <= 0 || OrderfailNum1 >= 5 || OrderfailNum2 >= 5 || OrderfailNum3 >= 5)
        {
            F_s.Play();
            OverText.SetActive(true);
            GameCount -= Time.deltaTime;
            if(GameCount <= 0)
            {
                 SceneManager.LoadScene("OverScene");
            }
        }
       if (OrderclearNum1 >= 15)
        {
            C_s.Play();
            ClaerText.SetActive(true);
            GameCount -= Time.deltaTime;
            if (GameCount <= 0)
            {
                SceneManager.LoadScene("Stage2Scene");
            }
        }
       if(OrderclearNum2 >= 25)
        {
            C_s.Play();
            ClaerText.SetActive(true);
            GameCount -= Time.deltaTime;
            if (GameCount <= 0)
            {
                SceneManager.LoadScene("Stage3Scene");
            }
        }
        if (OrderclearNum3 >= 35)
        {
            C_s.Play();
            ClaerText.SetActive(true);
            GameCount -= Time.deltaTime;
            if (GameCount <= 0)
            {
                SceneManager.LoadScene("EndingScene");
            }
        }
    }
}
