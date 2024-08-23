using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Coin coin;
    [SerializeField] private DollMakerManager dollMakerManager;
    [SerializeField] private QuestM QuestM;
    void Start()
    {
        coin.lnit();
        QuestM.lnit();
        dollMakerManager.lnit();
    }

    void Update()
    {
        
    }
}
