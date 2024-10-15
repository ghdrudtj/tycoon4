using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

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

    private float TrophyCount = 1f;

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
    public void TrophyText()
    {
        if(SceneManager.GetActiveScene().name == "EndingScene")
        {
            Trophy_E_T.SetActive(true);
            Trophy_E.SetActive(true);

            TrophyCount -= Time.deltaTime;
            if (TrophyCount <= 0)
            {
                Trophy_E_T.SetActive(false);
            }
        }
        if(Unlock.instance.Unlock_4 == true)
        {
            Trophy_P_T.SetActive(true);
            Trophy_P.SetActive(true);

            TrophyCount -= Time.deltaTime;
            if (TrophyCount <= 0)
            {
                Trophy_P_T.SetActive(false);
            }
        }
        if(GameManager.instance.OrderclaerNum1 >= 15)
        {
            Trophy_S1_T.SetActive(true);
            Trophy_S1.SetActive(true);

            TrophyCount -= Time.deltaTime;
            if (TrophyCount <= 0)
            {
                Trophy_S1_T.SetActive(false);
            }
        }
        if(DisturbanceNum >= 10)
        {
            Trophy_D_T.SetActive(true);
            Trophy_D.SetActive(true);

            TrophyCount -= Time.deltaTime;
            if (TrophyCount <= 0)
            {
                Trophy_D_T.SetActive(false);
            }
        }
        if(Coin.instance.coin >= 1000)
        {
            Trophy_C_T.SetActive(true);
            Trophy_C.SetActive(true);

            TrophyCount -= Time.deltaTime;
            if (TrophyCount <= 0)
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
        TrophyText();
    }
}
