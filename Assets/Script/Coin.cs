using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour//ÄÚÀÎ
{
    public static Coin instance;
    public Text cointext;

    public int coin;

    private void Start()
    {
        cointext = GetComponent<Text>();
    }
    public void lnit()
    {
        instance = this;
    }
    private void Update()
    {
        cointext.text = coin.ToString();
    }
    public void CoinColor_W()
    {
        cointext.GetComponent<Text>().color = Color.black;
    }
    public void CoinColor_R()
    {
        cointext.GetComponent<Text>().color = Color.red;
    }
    public void CoinColor_G()
    {
        cointext.GetComponent<Text>().color = Color.green;
    }
}
