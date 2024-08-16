using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestM : MonoBehaviour
{
    public static QuestM instance;

    public int QNum;
    public int Num;

    public bool isClear;
    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        Num = DollMakerManager.instance.Num;
    }
    public void Quest()
    {
        QNum = Random.Range(1, 20);
        Debug.Log("QNum = " + QNum);
    }
    public void Clear()
    {
        if (QNum == Num)
        {
            Debug.Log("Å¬¸®¾î");
            QNum = Random.Range(1, 20);
            Debug.Log("QNum = " + QNum);
            Num = 0;
            isClear = true;
        }
        else if (QNum != Num)
        {
            Debug.Log("no");
            QNum = Random.Range(1, 20);
            Debug.Log("QNum = " + QNum);
            Num = 0;
            DollMakerManager.instance.isClear = true;
        }
    }
}
