using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Coin coin;
    [SerializeField] private DollMakerManager dollMakerManager;
    [SerializeField] private QuestM QuestM;
    [SerializeField] private Unlock Unlock;
    void Start()
    {
        coin.lnit();
        QuestM.lnit();
        dollMakerManager.lnit();
        Unlock.lnit();
    }
    void Update()
    {
       if(Coin.instance.coin <= 0)
        {
            SceneManager.LoadScene("OverScene");
        }

    }
}
