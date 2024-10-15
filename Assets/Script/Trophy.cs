using UnityEngine;
using UnityEngine.SceneManagement;

public class Trophy : MonoBehaviour
{
    public static Trophy instance;
    [SerializeField] private GameObject TrophyCanvas;
    [SerializeField] private GameObject TrophyUI;

    [SerializeField] private GameObject Trophy_E;
    [SerializeField] private GameObject Trophy_P;
    [SerializeField] private GameObject Trophy_S1;
    [SerializeField] private GameObject Trophy_D; 
    [SerializeField] private GameObject Trophy_C;

    [SerializeField] private GameObject Trophy_E_T;
    [SerializeField] private GameObject Trophy_P_T;
    [SerializeField] private GameObject Trophy_S1_T;
    [SerializeField] private GameObject Trophy_D_T;
    [SerializeField] private GameObject Trophy_C_T;

    private float TrophyCount_E = 1.5f;
    private float TrophyCount_P = 1.5f;
    private float TrophyCount_S1 = 1.5f;
    private float TrophyCount_D = 1.5f;
    private float TrophyCount_C = 1.5f;

    public int DisturbanceNum;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(TrophyCanvas);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            Destroy(TrophyCanvas);
        }
    }
    public void TrophyImg()
    {
        TrophyUI.SetActive(!TrophyUI.activeSelf);
    }
    public void trophy()
    {
        if(SceneManager.GetActiveScene().name == "EndingScene")
        {
            Trophy_E_T.SetActive(true);
            Trophy_E.SetActive(true);

            TrophyCount_E -= Time.deltaTime;
            if (TrophyCount_E <= 0)
            {
                Trophy_E_T.SetActive(false);
            }
        }
        if(Unlock.instance.Unlock_4 == true)
        {
            Trophy_P_T.SetActive(true);
            Trophy_P.SetActive(true);

            TrophyCount_P -= Time.deltaTime;
            if (TrophyCount_P <= 0)
            {
                Trophy_P_T.SetActive(false);
            }
        }
        if(GameManager.instance.OrderclaerNum1 >= 15)
        {
            Trophy_S1_T.SetActive(true);
            Trophy_S1.SetActive(true);

            TrophyCount_S1 -= Time.deltaTime;
            if (TrophyCount_S1 <= 0)
            {
                Trophy_S1_T.SetActive(false);
            }
        }
        if(DisturbanceNum >= 10)
        {
            Trophy_D_T.SetActive(true);
            Trophy_D.SetActive(true);

            TrophyCount_D -= Time.deltaTime;
            if (TrophyCount_D <= 0)
            {
                Trophy_D_T.SetActive(false);
            }
        }
        if(Coin.instance.coin >= 1000)
        {
            Trophy_C_T.SetActive(true);
            Trophy_C.SetActive(true);

            TrophyCount_C -= Time.deltaTime;
            if (TrophyCount_C <= 0)
            {
                Trophy_C_T.SetActive(false);
            }
        }
    }
    void Start()
    {
    }

    void Update()
    {
        trophy();
    }
}
