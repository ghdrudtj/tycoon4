using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestM : MonoBehaviour
{
    public static QuestM instance;

    public static int QNum;
    public static int Num;

    public static bool isClear;
    public void Start()
    {
        instance = this;
        Num = DollMakerMangaer.Num;
    }
    public void Quest()
    {
        int QNum = Random.Range(1, 20);
        Debug.Log("QNum = " + QNum);
        
    }
    public void Clear()
    {

        if (QNum == Num)
        {
            Debug.Log("Å¬¸®¾î");
            int QNum = Random.Range(0, 20);
            Debug.Log("QNum = " + QNum);
            Num = 0;
            isClear = true;
        }
        else if (QNum != Num)
        {
            Debug.Log("no");
            Num = 0;
            isClear = true;
        }
    }
}
