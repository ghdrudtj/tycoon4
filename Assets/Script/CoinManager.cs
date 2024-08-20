using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public Text CoinText;
    public int Coin =100;
    void Start()
    {
        CoinText=GetComponent<Text>();
    }
    private void Awake()
    {
        UpdateCoin();
    }

    public void UpdateCoin()
    {
        CoinText.text = Coin.ToString();
    }
    
}
