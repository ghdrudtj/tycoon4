using UnityEngine;
using UnityEngine.SceneManagement;

public class Unlock : MonoBehaviour
{
    public static Unlock instance;
    [SerializeField] private GameObject Unlooks;
    [SerializeField] private GameObject S;

    public GameObject Unlock1obj;
    public GameObject Unlock2obj;
    public GameObject Unlock3obj;
    public GameObject Unlock4obj;

    public bool Unlock_1;
    public bool Unlock_2;
    public bool Unlock_3;
    public bool Unlock_4;

    [SerializeField] private AudioSource U_s;

    
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(Unlooks);
            DontDestroyOnLoad(S);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void Unlock1()
    {
        if (Coin.instance.coin >= 200)
        {
            U_s.Play();
            Unlock_1 = true;
            Coin.instance.coin -= 200;
            Unlock1obj.SetActive(false);
            Debug.Log("첫번째 해금");
        }
        else
        {
            Debug.Log("1돈 부족함");
        }
    }
    public void Unlock2()
    {
        if (Coin.instance.coin >= 200 & Unlock_1==true)
        {
            U_s.Play();
            Unlock_2 = true;
            Coin.instance.coin -= 200;
            Unlock2obj.SetActive(false);
            Debug.Log("두번째 해금");
        }
        else
        {
            Debug.Log("2조건 불충족");
        }
    }
    public void Unlock3()
    {
        if (Coin.instance.coin >= 200 & Unlock_1 == true & Unlock_2 == true)
        {
            U_s.Play();
            Unlock_3 = true;
            Coin.instance.coin -= 200;
            Unlock3obj.SetActive(false);
            Debug.Log("세번째 해금");
        }
        else
        {
            Debug.Log("3조건 불충족");
        }
    }
    public void Unlock4()
    {
        if (Coin.instance.coin >= 200 & Unlock_1 == true & Unlock_2 == true & Unlock_3 == true)
        {
            U_s.Play();
            Unlock_4 = true;
            Coin.instance.coin -= 200;
            Unlock4obj.SetActive(false);
            Debug.Log("네번째 해금");
        }
        else
        {
            Debug.Log("4조건 불충족");
        }
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "EndingScene"|| SceneManager.GetActiveScene().name == "OverScene" || SceneManager.GetActiveScene().name == "StartScene")
        {
            Unlooks.SetActive(false);
        }
        else
        {
            Unlooks.SetActive(true);
        }
        
    }
    
}
