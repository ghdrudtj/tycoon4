using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Unlock_1 = false;
        Unlock_2 = false;
        Unlock_3 = false;
        Unlock_4 = false;
    }
    public void lnit()
    {
        instance = this;
    }
    public void Unlock1()
    {
        if(Coin.instance.coin >= 200)
        {
            Unlock_1 = true;
            Coin.instance.coin -= 200;
            Destroy(Unlock1obj);
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
            Destroy(Unlock2obj);
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
            Destroy(Unlock3obj);
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
            Destroy(Unlock4obj);
            Debug.Log("�׹�° �ر�");
        }
        else
        {
            Debug.Log("4���� ������");
        }
    }
}
