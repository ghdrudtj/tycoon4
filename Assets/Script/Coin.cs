using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
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
    
}
