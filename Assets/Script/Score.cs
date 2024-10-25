using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public TextMeshPro Coin_m;
    void Start()
    {
        Coin_m = GetComponent<TextMeshPro>();
    }

    void Update()
    {
       
    }
    public void Active(Vector2 pos)
    {
        Coin_m.text = Thief.instance.coin_m.ToString();
        Coin_m.text = QuestM.instance.coin_m.ToString();
        transform.position = pos;
    }
    

    void Desctive()
    {
        Destroy(gameObject);
    }
}
