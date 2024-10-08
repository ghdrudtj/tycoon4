using UnityEngine;
using UnityEngine.SceneManagement;

public class Unlock : MonoBehaviour
{
    public static Unlock instance;

    public GameObject Unlock1obj;
    public GameObject Unlock2obj;
    public GameObject Unlock3obj;
    public GameObject Unlock4obj;

    public bool Unlock_1;
    public bool Unlock_2;
    public bool Unlock_3;
    public bool Unlock_4;

    private void Start()
    {

    }
    public void lnit()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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
            Unlock_1 = true;
            Coin.instance.coin -= 200;
            Unlock1obj.SetActive(false);
            Debug.Log("ù��° �ر�");
        }
        else
        {
            Debug.Log("1�� ������");
        }
    }
    public void Unlock2()
    {
        if (Coin.instance.coin >= 200 & Unlock_1==true)
        {
            Unlock_2 = true;
            Coin.instance.coin -= 200;
            Unlock2obj.SetActive(false);
            Debug.Log("�ι�° �ر�");
        }
        else
        {
            Debug.Log("2���� ������");
        }
    }
    public void Unlock3()
    {
        if (Coin.instance.coin >= 200 & Unlock_1 == true & Unlock_2 == true)
        {
            Unlock_3 = true;
            Coin.instance.coin -= 200;
            Unlock3obj.SetActive(false);
            Debug.Log("����° �ر�");
        }
        else
        {
            Debug.Log("3���� ������");
        }
    }
    public void Unlock4()
    {
        if (Coin.instance.coin >= 200 & Unlock_1 == true & Unlock_2 == true & Unlock_3 == true)
        {
            Unlock_4 = true;
            Coin.instance.coin -= 200;
            Unlock4obj.SetActive(false);
            Debug.Log("�׹�° �ر�");
        }
        else
        {
            Debug.Log("4���� ������");
        }
    }
    private void Update()
    {
        if (Unlock_1 == true)
        {
            if (SceneManager.GetActiveScene().name == "Stage2Scene" || SceneManager.GetActiveScene().name == "Stage3Scene")
            {
                Unlock_1 = true;
                Unlock1obj.SetActive(false);
            }
        }
        if (Unlock_2 == true)
        {
            if (SceneManager.GetActiveScene().name == "Stage2Scene" || SceneManager.GetActiveScene().name == "Stage3Scene")
            {
                Unlock_2 = true;
                Unlock2obj.SetActive(false);
            }
        }
        if (Unlock_3 == true)
        {
            if (SceneManager.GetActiveScene().name == "Stage2Scene" || SceneManager.GetActiveScene().name == "Stage3Scene")
            {
                Unlock_3 = true;
                Unlock3obj.SetActive(false);
            }
        }
        if (Unlock_4 == true)
        {
            if (SceneManager.GetActiveScene().name == "Stage2Scene" || SceneManager.GetActiveScene().name == "Stage3Scene")
            {
                Unlock_4 = true;
                Unlock4obj.SetActive(false);
            }
        }
    }
    
}
