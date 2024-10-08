using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    [SerializeField] private Coin coin;
    [SerializeField] private DollMakerManager dollMakerManager;
    [SerializeField] private QuestM QuestM;
    [SerializeField] private Unlock Unlock;
    public int OrderclaerNum1;
    public int OrderfailNum1;
    public int OrderclaerNum2;
    public int OrderfailNum2;
    public int OrderclaerNum3;
    public int OrderfailNum3;
    [SerializeField] public GameObject ClaerText;
    [SerializeField] public GameObject OverText;
    private float GameCount = 1.5f;
   
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        coin.lnit();
        QuestM.lnit();
        dollMakerManager.lnit();
        Unlock.lnit();
    }
    void Update()
    {
       if(Coin.instance.coin <= 0 || OrderfailNum1 >= 5 || OrderfailNum2 >= 5 || OrderfailNum3 >= 5)
        {
            OverText.SetActive(true);
            GameCount -= Time.deltaTime;
            if(GameCount <= 0)
            {
                 SceneManager.LoadScene("OverScene");
            }
        }
       if (OrderclaerNum1 >= 15)
        {
            ClaerText.SetActive(true);
            GameCount -= Time.deltaTime;
            if (GameCount <= 0)
            {
                SceneManager.LoadScene("Stage2Scene");
            }
        }
       if(OrderclaerNum2 >= 25)
        {
            ClaerText.SetActive(true);
            GameCount -= Time.deltaTime;
            if (GameCount <= 0)
            {
                SceneManager.LoadScene("Stage3Scene");
            }
        }
        if (OrderclaerNum3 >= 35)
        {
            ClaerText.SetActive(true);
            GameCount -= Time.deltaTime;
            if (GameCount <= 0)
            {
                SceneManager.LoadScene("EndingScene");
            }
        }
    }
}
